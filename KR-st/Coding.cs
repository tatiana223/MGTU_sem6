using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace KR
{

    class Coding
    {
        private int UnicodeToWin(int unicode_int) //переводит код кириллицы в win1251
        {
            int win1251_int = unicode_int - 848;
            return win1251_int;
        }

        private int WinToUnicode(int win1251_int) //переводит код кириллицы обратно в юникод
        {
            int unicode_int = win1251_int + 848;
            return unicode_int;
        }
        public byte[] Encode(string message)
        {
            if (string.IsNullOrEmpty(message))
                return new byte[1];
            var result = new List<byte>();

            // составление массива интов из строки
            var messageArray = message.ToCharArray();
            var messageInt = new int[messageArray.Length];
            for (var i = 0; i < messageArray.Length; i++)
                messageInt[i] = Convert.ToInt32(messageArray[i]);

            // кодирование

            foreach (var letter in messageInt)
            {
                // храним в bitArray, важно - числа записываются справа налево
                var buffer = letter;
                if ((buffer >= 1040) && (buffer <= 1103)){ //проверка на кириллицу
                    buffer = UnicodeToWin(buffer);
                }
                //var uncoded = new BitArray(8); //любой символ - 8 бит
                //разбиение каждого символа на первые 4 бита и вторые 4 бита
                var uncoded_left = new BitArray(4);
                var uncoded_right = new BitArray(4); 

                var i = 0;
                while (buffer > 0) //переводим 10-тичное число в двоичное и делим на 2 4-х битных слова
                {
                    if ((buffer % 2 == 1) && (i < 4))
                    {
                        uncoded_right.Set(i, true);
                    }
                    if ((buffer % 2 == 1) && (i >= 4))
                    {
                        uncoded_left.Set(i-4, true);
                    }
                    buffer /= 2;
                    i++;
                }
                var coded_left = new BitArray(7);
                var coded_right = new BitArray(7);
                //кодируем первую(правую) часть 8 битного символа (Хэмминг 7 4)
                coded_right.Set(0, uncoded_right.Get(0));
                coded_right.Set(1, uncoded_right.Get(1));
                coded_right.Set(2, uncoded_right.Get(2));
                coded_right.Set(4, uncoded_right.Get(3));
                coded_right.Set(3, coded_right.Get(0) ^ coded_right.Get(1) ^ coded_right.Get(2));
                coded_right.Set(5, coded_right.Get(0) ^ coded_right.Get(1) ^ coded_right.Get(4));
                coded_right.Set(6, coded_right.Get(0) ^ coded_right.Get(2) ^ coded_right.Get(4));

                //кодируем вторую(левую) часть 8 битного символа (Хэмминг 7 4)
                coded_left.Set(0, uncoded_left.Get(0));
                coded_left.Set(1, uncoded_left.Get(1));
                coded_left.Set(2, uncoded_left.Get(2));
                coded_left.Set(4, uncoded_left.Get(3));
                coded_left.Set(3, coded_left.Get(0) ^ coded_left.Get(1) ^ coded_left.Get(2));
                coded_left.Set(5, coded_left.Get(0) ^ coded_left.Get(1) ^ coded_left.Get(4));
                coded_left.Set(6, coded_left.Get(0) ^ coded_left.Get(2) ^ coded_left.Get(4));

                //соединяем левую и правую части, добавляем два нуля слева для 2-ух байтов
                var coded = new BitArray(16);
                coded.Set(15, false);
                coded.Set(14, false);
                coded.Set(13, coded_left.Get(6));
                coded.Set(12, coded_left.Get(5));
                coded.Set(11, coded_left.Get(4));
                coded.Set(10, coded_left.Get(3));
                coded.Set(9, coded_left.Get(2));
                coded.Set(8, coded_left.Get(1));
                coded.Set(7, coded_left.Get(0));
                coded.Set(6, coded_right.Get(6));
                coded.Set(5, coded_right.Get(5));
                coded.Set(4, coded_right.Get(4));
                coded.Set(3, coded_right.Get(3));
                coded.Set(2, coded_right.Get(2));
                coded.Set(1, coded_right.Get(1));
                coded.Set(0, coded_right.Get(0));
                //создаем 2 байта
                var encoded_char = new byte[2];
                //копируем результат кодировки в 2 байта
                coded.CopyTo(encoded_char, 0);
                result.Add(encoded_char[0]);
                result.Add(encoded_char[1]);
            }
            return result.ToArray<byte>();
            }


            public string Decode(byte[] message)
        {
            var sequences_number = (message.Length / 2); //количество символов

            string result = null;
            for (var i = 0; i < sequences_number; i++)
            {
                var sequence = new byte[2];
                sequence[0] = message[i * 2]; //правый байт
                sequence[1] = message[i * 2 + 1]; //левый байт
                BitArray coded = new BitArray(sequence); //из 2-ух байтов получаем 16 бит
                var coded_left = new BitArray(7); //7 закодированных бит слева
                var coded_right = new BitArray(7); //7 закодированных бит справа
                BitArray syndrome_left = new BitArray(3); //синдром ошибки битов слева
                BitArray syndrome_right = new BitArray(3); //синдром ошибки битов справа

                coded_right.Set(0, coded.Get(0));
                coded_right.Set(1, coded.Get(1));
                coded_right.Set(2, coded.Get(2));
                coded_right.Set(3, coded.Get(3));
                coded_right.Set(4, coded.Get(4));
                coded_right.Set(5, coded.Get(5));
                coded_right.Set(6, coded.Get(6));

                coded_left.Set(0, coded.Get(7));
                coded_left.Set(1, coded.Get(8));
                coded_left.Set(2, coded.Get(9));
                coded_left.Set(3, coded.Get(10));
                coded_left.Set(4, coded.Get(11));
                coded_left.Set(5, coded.Get(12));
                coded_left.Set(6, coded.Get(13));

                syndrome_right.Set(0, coded_right.Get(6) ^ coded_right.Get(4) ^ coded_right.Get(2) ^ coded_right.Get(0));
                syndrome_right.Set(1, coded_right.Get(5) ^ coded_right.Get(4) ^ coded_right.Get(1) ^ coded_right.Get(0));
                syndrome_right.Set(2, coded_right.Get(3) ^ coded_right.Get(2) ^ coded_right.Get(1) ^ coded_right.Get(0));
                int[] error_pos_right = new int[1];
                syndrome_right.CopyTo(error_pos_right, 0); 
                if (error_pos_right[0] != 0) //если есть хоть одна в любом(данном) символе ошибка - вернуть пустую строку 
                {
                    return string.Empty;
                }

                syndrome_left.Set(0, coded_left.Get(6) ^ coded_left.Get(4) ^ coded_left.Get(2) ^ coded_left.Get(0));
                syndrome_left.Set(1, coded_left.Get(5) ^ coded_left.Get(4) ^ coded_left.Get(1) ^ coded_left.Get(0));
                syndrome_left.Set(2, coded_left.Get(3) ^ coded_left.Get(2) ^ coded_left.Get(1) ^ coded_left.Get(0));
                int[] error_pos_left = new int[1];
                syndrome_left.CopyTo(error_pos_left, 0);
                if (error_pos_left[0] != 0)
                {
                    return string.Empty;
                }
                BitArray decoded_left = new BitArray(4);
                BitArray decoded_right = new BitArray(4);

                decoded_right.Set(0, coded_right.Get(0));
                decoded_right.Set(1, coded_right.Get(1));
                decoded_right.Set(2, coded_right.Get(2));
                decoded_right.Set(3, coded_right.Get(4));

                decoded_left.Set(0, coded_left.Get(0));
                decoded_left.Set(1, coded_left.Get(1));
                decoded_left.Set(2, coded_left.Get(2));
                decoded_left.Set(3, coded_left.Get(4));

                BitArray decoded = new BitArray(8);

                decoded.Set(0, decoded_right.Get(0));
                decoded.Set(1, decoded_right.Get(1));
                decoded.Set(2, decoded_right.Get(2));
                decoded.Set(3, decoded_right.Get(3));
                decoded.Set(4, decoded_left.Get(0));
                decoded.Set(5, decoded_left.Get(1));
                decoded.Set(6, decoded_left.Get(2));
                decoded.Set(7, decoded_left.Get(3));

                int[] error_pos = new int[1];
                decoded.CopyTo(error_pos, 0);
                if ((error_pos[0] >= 192) && (error_pos[0] <= 255)) //проверка на кириллицу
                {
                    error_pos[0] = WinToUnicode(error_pos[0]);
                }
                result += Convert.ToChar(error_pos[0]);
            }
            return result;
        }
    }

}
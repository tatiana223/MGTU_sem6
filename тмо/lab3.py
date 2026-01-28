import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import LabelEncoder, StandardScaler
from sklearn.neighbors import KNeighborsRegressor
from sklearn.metrics import mean_squared_error, r2_score

# Загружаем данные
df = pd.read_csv("top100_kdrama_aug_2023.csv")

# Удаляем строки с пропусками
df.dropna(inplace=True)

# Преобразуем длительность (если есть)
if 'Duration' in df.columns:
    df['Duration'] = df['Duration'].astype(str).str.extract(r'(\d+)').astype(float)

# Преобразуем категориальные признаки в числа
categorical_cols = ['Genre', 'Aired Date']  # Укажите нужные колонки
label_encoders = {}

for col in categorical_cols:
    le = LabelEncoder()
    df[col] = le.fit_transform(df[col].astype(str))
    label_encoders[col] = le  # Сохраняем, если нужно расшифровывать

# Выбираем признаки и целевую переменную
X = df.drop(columns=['Rating'])  # Или другую целевую переменную
y = df['Rating']

# Разделяем на train/test
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Стандартизируем данные
scaler = StandardScaler()
X_train = scaler.fit_transform(X_train)
X_test = scaler.transform(X_test)

# Обучаем модель KNN
knn = KNeighborsRegressor(n_neighbors=5)
knn.fit(X_train, y_train)

# Оцениваем качество
y_pred = knn.predict(X_test)
mse = mean_squared_error(y_test, y_pred)
r2 = r2_score(y_test, y_pred)

print(f'MSE: {mse:.3f}, R²: {r2:.3f}')

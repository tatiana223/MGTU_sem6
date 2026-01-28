import streamlit as st
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.model_selection import train_test_split
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.ensemble import RandomForestClassifier
from sklearn.metrics import accuracy_score, confusion_matrix, classification_report
from sklearn.pipeline import Pipeline
from sklearn.compose import ColumnTransformer
from sklearn.preprocessing import FunctionTransformer

# Загрузка данных
@st.cache_data
def load_data():
    url = "https://raw.githubusercontent.com/justmarkham/DAT8/master/data/Womens_Clothing_E-Commerce_Reviews.csv"
    df = pd.read_csv('Womens Clothing E-Commerce Reviews.csv', index_col=0)
    df = df.dropna(subset=['Review Text', 'Rating', 'Recommended IND'])
    df['Review_Length'] = df['Review Text'].str.len()
    return df

def preprocess_features(X):
    return pd.DataFrame({
        'Rating': X['Rating'],
        'Review_Length': X['Review_Length'],
        'Age': X['Age']
    })

def main():
    st.set_page_config(page_title="Анализ отзывов о женской одежде", layout="wide")
    st.title("Анализ рекомендаций женской одежды")
    
    df = load_data()
    
    tab1, tab2, tab3 = st.tabs(["Данные", "Анализ", "Модель"])

    with tab1:
        st.header("Обзор данных")
        st.write(f"Всего отзывов: {len(df)}")
        st.dataframe(df.head())

    with tab2:
        st.header("Анализ признаков")
        fig1, ax1 = plt.subplots(1, 2, figsize=(12, 4))
        sns.countplot(x='Rating', data=df, ax=ax1[0])
        sns.countplot(x='Recommended IND', data=df, ax=ax1[1])
        ax1[1].set_xticklabels(["Не рекомендовано", "Рекомендовано"])
        st.pyplot(fig1)

    with tab3:
        st.header("Модель предсказания рекомендаций")
        
        st.sidebar.header("Параметры модели")
        n_estimators = st.sidebar.slider("Количество деревьев", 50, 500, 100)
        max_depth = st.sidebar.slider("Максимальная глубина", 2, 50, 10)
        use_text = st.sidebar.checkbox("Использовать текст отзыва", value=True)
        use_features = st.sidebar.checkbox("Использовать дополнительные признаки", value=True)

        y = df['Recommended IND']
        
        if use_text and use_features:

            preprocessor = ColumnTransformer(
                transformers=[
                    ('text', TfidfVectorizer(max_features=1000), 'Review Text'),
                    ('num', FunctionTransformer(preprocess_features), ['Rating', 'Review_Length', 'Age'])
                ])
            
            model = Pipeline([
                ('preprocessor', preprocessor),
                ('clf', RandomForestClassifier(
                    n_estimators=n_estimators,
                    max_depth=max_depth,
                    random_state=42
                ))
            ])
            X = df[['Review Text', 'Rating', 'Review_Length', 'Age']]
            
        elif use_text:
            model = Pipeline([
                ('tfidf', TfidfVectorizer(max_features=1000)),
                ('clf', RandomForestClassifier(
                    n_estimators=n_estimators,
                    max_depth=max_depth,
                    random_state=42
                ))
            ])
            X = df['Review Text']
            
        else:
            model = RandomForestClassifier(
                n_estimators=n_estimators,
                max_depth=max_depth,
                random_state=42
            )
            X = df[['Rating', 'Review_Length', 'Age']]

    
        X_train, X_test, y_train, y_test = train_test_split(
            X, y, test_size=0.2, random_state=42
        )
        try:
            model.fit(X_train, y_train)
            y_pred = model.predict(X_test)
            accuracy = accuracy_score(y_test, y_pred)
            
            st.subheader("Результаты модели")
            st.metric("Точность модели", f"{accuracy:.2%}")

            st.subheader("Матрица ошибок")
            fig2, ax2 = plt.subplots()
            sns.heatmap(confusion_matrix(y_test, y_pred), 
                       annot=True, fmt='d', cmap='Blues', ax=ax2)
            ax2.set_xlabel("Предсказано")
            ax2.set_ylabel("Фактически")
            st.pyplot(fig2)

        except Exception as e:
            st.error(f"Ошибка при обучении модели: {str(e)}")

if __name__ == '__main__':
    main()
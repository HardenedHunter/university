using System.Collections.Generic;
using System.Drawing;

// ReSharper disable CommentTypo

namespace Tree
{
    /// <summary>
    /// Интерфейс для Б+ дерева
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITree<T> : IEnumerable<T>
    {
        //Количество уровней
        int Level { get; }

        //Количество элементов
        int Count { get; }

        //Показатель ветвления
        int Factor { get; }

        //Проверка на пустоту
        bool IsEmpty { get; }

        //Элементы дерева
        IEnumerable<T> Nodes { get; }

        void Add(T node);
        void Clear();
        bool Contains(T node);
        void Remove(T node);
        void Draw(Graphics g);
    }
}
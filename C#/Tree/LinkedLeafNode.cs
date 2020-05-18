using System;
// ReSharper disable CommentTypo

namespace Tree
{
    /// <summary>
    /// Класс "Листьевое звено на основе линейного списка"
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedLeafNode<T> : LeafNode<T> where T: IComparable
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="factor">
        /// Параметр ветвления. Каждый лист содержит
        /// от (factor - 1) до (factor * 2 - 1) ключей.
        /// Для корня от 1 до (factor * 2 - 1).
        /// </param>
        public LinkedLeafNode(int factor)
        {
            Keys = new LinkedCollection<T>();
            Factor = factor;
            Factory = new LinkedNodeFactory<T>();
        }
    }
}
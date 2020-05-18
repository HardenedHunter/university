using System;
// ReSharper disable CommentTypo

namespace Tree
{
    public class ArrayLeafNode<T> : LeafNode<T> where T : IComparable
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="factor">
        /// Параметр ветвления. Каждый лист содержит
        /// от (factor - 1) до (factor * 2 - 1) ключей.
        /// Для корня от 1 до (factor * 2 - 1).
        /// </param>
        public ArrayLeafNode(int factor)
        {
            Keys = new ArrayCollection<T>();
            Factor = factor;
            Factory = new ArrayNodeFactory<T>();
        }
    }
}
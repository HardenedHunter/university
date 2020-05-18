using System;
// ReSharper disable CommentTypo

namespace Tree
{
    /// <summary>
    /// Класс "Внутреннее звено на основе массива"
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayInternalNode<T> : InternalNode<T> where T : IComparable
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="factor">
        /// Параметр ветвления. Каждый внутренний узел содержит
        /// от (factor - 1) до (factor * 2 - 1) ключей и на один
        /// больше дочерних узлов. Для корня от 1 до (factor * 2 - 1).
        /// </param>
        public ArrayInternalNode(int factor)
        {
            Keys = new ArrayCollection<T>();
            Children = new ArrayCollection<TreeNode<T>>();
            Factor = factor;
            Factory = new ArrayNodeFactory<T>();
        }

    }
}
using System;
// ReSharper disable CommentTypo

namespace Tree
{
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
            Keys = new ArrayList<T>();
            Children = new ArrayList<TreeNode<T>>();
            Factor = factor;
            Factory = new ArrayNodeFactory<T>();
        }

    }
}
using System;
// ReSharper disable CommentTypo

namespace Tree
{
    /// <summary>
    /// Класс-фабрика для создания звеньев на основе массива
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayNodeFactory<T> : ITreeNodeFactory<T> where T : IComparable
    {
        public InternalNode<T> CreateInternalNode(int factor)
        {
            return new ArrayInternalNode<T>(factor);
        }

        public LeafNode<T> CreateLeafNode(int factor)
        {
            return new ArrayLeafNode<T>(factor);
        }
    }
}
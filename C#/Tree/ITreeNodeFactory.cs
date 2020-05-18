using System;
// ReSharper disable CommentTypo

namespace Tree
{
    /// <summary>
    /// Интерфейс фабрики для создания звеньев дерева
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITreeNodeFactory<T> where T: IComparable
    {
        InternalNode<T> CreateInternalNode(int factor);
        LeafNode<T> CreateLeafNode(int factor);
    }
}
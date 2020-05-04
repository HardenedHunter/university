using System;

namespace Tree
{
    public interface ITreeNodeFactory<T> where T: IComparable
    {
        InternalNode<T> CreateInternalNode(int factor);
        LeafNode<T> CreateLeafNode(int factor);
    }
}
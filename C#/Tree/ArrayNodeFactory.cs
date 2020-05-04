using System;

namespace Tree
{
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
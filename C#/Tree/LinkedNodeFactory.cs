using System;

namespace Tree
{
    public class LinkedNodeFactory<T>: ITreeNodeFactory<T> where T : IComparable
    {
        public InternalNode<T> CreateInternalNode(int factor)
        {
            return new LinkedInternalNode<T>(factor);
        }

        public LeafNode<T> CreateLeafNode(int factor)
        {
            return new LinkedLeafNode<T>(factor);
        }
    }
}
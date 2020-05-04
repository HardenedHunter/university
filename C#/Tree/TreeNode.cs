using System;

namespace Tree
{
    public abstract class TreeNode<T> : IComparable where T : IComparable
    {
        public IExtendedCollection<T> Keys;
        public abstract TreeNode<T> Remove(T key);
        public abstract void Add(T key);
        public abstract T GetFirstLeafKey();
        public abstract LeafNode<T> GetFirstLeaf();
        public abstract void Merge(TreeNode<T> sibling);
        public abstract TreeNode<T> Split();
        public abstract bool IsOverflow();
        public abstract bool IsUnderFlow();
        public abstract int CompareTo(object obj);
    }
}
using System;

namespace Tree
{
    public abstract class LinkedNode<T>: IComparable where T: IComparable
    {
        public List<T> Keys;
        public abstract LinkedNode<T> Remove(T key);
        public abstract void Add(T key);
        public abstract T GetFirstLeafKey();
        public abstract LeafLinkedNode<T> GetFirstLeaf();
        public abstract void Merge(LinkedNode<T> sibling);
        public abstract LinkedNode<T> Split();
        public abstract bool IsOverflow();
        public abstract bool IsUnderFlow();
        public abstract int CompareTo(object obj);
    }
}
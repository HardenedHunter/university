using System;

namespace Tree
{
    public abstract class Node<T>: IComparable where T: IComparable
    {
        public List<T> Keys;
        public abstract void Remove(T key);
        public abstract void Add(T key);
        public abstract T GetFirstLeafKey();
        public abstract void Merge(Node<T> sibling);
        public abstract Node<T> Split();
        public abstract bool IsOverflow();
        public abstract bool IsUnderFlow();
        public abstract int CompareTo(object obj);
    }
}
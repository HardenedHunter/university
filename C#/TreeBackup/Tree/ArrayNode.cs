using System;

namespace Tree
{
    public abstract class ArrayNode<T> : IComparable where T : IComparable
    {
        public ArrayList<T> Keys;
        public abstract ArrayNode<T> Remove(T key);
        public abstract void Add(T key);
        public abstract T GetFirstLeafKey();
        public abstract LeafArrayNode<T> GetFirstLeaf();
        public abstract void Merge(ArrayNode<T> sibling);
        public abstract ArrayNode<T> Split();
        public abstract bool IsOverflow();
        public abstract bool IsUnderFlow();
        public abstract int CompareTo(object obj);
    }
}
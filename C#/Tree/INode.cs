using System;

namespace Tree
{
    interface INode<T>: IComparable where T: IComparable
    {
        void Remove(T key);
        void Add(T key);
        T GetFirstLeafKey();
        void Merge(INode<T> sibling);
        INode<T> Split();
        bool IsOverflow();
        bool IsUnderFlow();
    }
}
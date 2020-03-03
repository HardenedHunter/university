namespace Tree
{
    interface INode<T>
    {
        void Remove(T node);
        void Add(T node);
        T GetFirstLeafKey();
        void Merge(INode<T> sibling);
        INode<T> Split();
        bool IsOverflow();
        bool IsUnderFlow();
    }
}
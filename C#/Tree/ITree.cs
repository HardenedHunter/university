using System.Collections.Generic;

namespace Tree
{
    interface ITree<T> : IEnumerable<T>
    {
        void Add(T node);
        void Clear();
        bool Contains(T node);
        void Remove(T node);

        int Count { get; set; }
        bool IsEmpty { get; set; }
        IEnumerable<T> Nodes { get; set; }
    }
}
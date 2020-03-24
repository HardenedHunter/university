using System;
using System.Collections.Generic;

namespace Tree
{
    interface ITree<T> : IEnumerable<T>
    {
        void Add(T node);
        void Clear();
        bool Contains(T node);
        void Remove(T node);

        int Factor { get; }
        int Count { get; }
        bool IsEmpty { get;}
        IEnumerable<T> Nodes { get; set; }
    }
}
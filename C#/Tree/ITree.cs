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

        int BranchingFactor { get; }
        int Count { get; }
        bool IsEmpty { get; set; }
        IEnumerable<T> Nodes { get; set; }
    }
}
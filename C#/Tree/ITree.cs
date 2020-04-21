using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tree
{
    public interface ITree<T> : IEnumerable<T>
    {
        void Add(T node);
        void Clear();
        bool Contains(T node);
        void Remove(T node);
        void Draw(Graphics g);

        int Level { get; }
        int Factor { get; }
        bool IsEmpty { get;}
        IEnumerable<T> Nodes { get; set; }
    }
}
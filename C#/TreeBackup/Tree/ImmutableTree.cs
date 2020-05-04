using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Tree
{
    public class ImmutableTree<T> : ITree<T>
    {
        private readonly ITree<T> _tree;

        public int Level => _tree.Level;
        public int Count => _tree.Count;
        public int Factor => _tree.Factor;
        public bool IsEmpty => _tree.IsEmpty;
        public IEnumerable<T> Nodes => _tree.Nodes;

        public ImmutableTree(ITree<T> tree)
        {
            _tree = tree ?? throw new ArgumentNullException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _tree.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T node)
        {
            throw new ImmutableTreeException();
        }

        public void Clear()
        {
            throw new ImmutableTreeException();
        }

        public bool Contains(T node)
        {
            return _tree.Contains(node);
        }

        public void Remove(T node)
        {
            throw new ImmutableTreeException();
        }

        public void Draw(Graphics g)
        {
            _tree.Draw(g);
        }
    }
}
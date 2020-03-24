using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Tree
{
    public class LinkedTree<T> : ITree<T> where T: IComparable
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //Settings
        private const int DefaultFactor = 2;
        private const int MinFactor = 2;

        //TODO private
        public Node<T> _root;

        public int Factor { get; }
        //Rewrite
        public int Count { get; private set; }
        public bool IsEmpty => _root.Keys.Count == 0;
        public IEnumerable<T> Nodes { get; set; }

        public LinkedTree(int factor = DefaultFactor)
        {
            if (factor < MinFactor)
                throw new ArgumentOutOfRangeException(); //TODO REPLACE
            Factor = factor;
            Clear();
        }


        //Tested?
        public void Add(T node)
        {
            if (_root == null)
                _root = new LinkedLeafNode<T>(Factor);
            _root.Add(node);
            if (_root.IsOverflow())
            {
                Node<T> sibling = _root.Split();
                LinkedNode<T> newRoot = new LinkedNode<T>(Factor);
                newRoot.Keys.Add(sibling.GetFirstLeafKey());
                newRoot.Children.Add(_root);
                newRoot.Children.Add(sibling);
                _root = newRoot;
            }
        }


        public void Remove(T node)
        {
            var newRoot = _root.Remove(node);
            if (_root.IsUnderFlow()) _root = newRoot;
        }

        public bool Contains(T node)
        {
            return false;
//            return _root.Contains(node);
        }

        public void Clear()
        {
            _root = null;
            Count = 0;
        }
    }
}
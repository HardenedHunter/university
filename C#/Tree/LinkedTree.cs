using System;
using System.Collections;
using System.Collections.Generic;

namespace Tree
{
    class LinkedTree<T> : ITree<T>
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
        private const int DefaultBranchingFactor = 5;
        private const int MinBranchingFactor = 3;

        //ListNode
        private INode<T> _root;

        public int BranchingFactor { get; }
        //Rewrite
        public int Count { get; private set; }
        public bool IsEmpty { get; set; }
        public IEnumerable<T> Nodes { get; set; }

        public LinkedTree(int factor = DefaultBranchingFactor)
        {
            if (factor < MinBranchingFactor)
                throw new ArgumentOutOfRangeException(); //TODO REPLACE
            BranchingFactor = factor;
            Clear();
        }

        public void Add(T node)
        {
            _root.Add(node);
        }


        public bool Contains(T node)
        {
            return false;
//            return _root.Contains(node);
        }

        public void Remove(T node)
        {
            _root.Remove(node);
        }

        public void Clear()
        {
            _root = null;
            Count = 0;
        }
    }
}
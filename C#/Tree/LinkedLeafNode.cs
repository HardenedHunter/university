using System;

namespace Tree
{
    class LinkedLeafNode<T> : Node<T> where T : IComparable
    {
        public LinkedLeafNode<T> Next;
        private Node<T> _root;
        public int BranchingFactor { get; }

        public LinkedLeafNode(int branchingFactor, ref Node<T> root)
        {
            Keys = new List<T>();
            BranchingFactor = branchingFactor;
            _root = root;
        }

        public override void Remove(T key)
        {
            int location = Keys.IndexInSorted(key);
            if (location >= 0)
            {
                Keys.RemoveAt(location);
            }
        }

        public override void Add(T key)
        {
            int location = Keys.IndexInSorted(key);
            int insertIndex = location >= 0 ? location : -location - 1;
            Keys.Insert(insertIndex, key);
            if (_root.IsOverflow())
            {
                Node<T> sibling = Split();
                LinkedNode<T> newRoot = new LinkedNode<T>(BranchingFactor, ref _root);
                newRoot.Keys.Add(sibling.GetFirstLeafKey());
                newRoot.Children.Add(this);
                newRoot.Children.Add(sibling);
                _root = newRoot;
            }
        }

        public override T GetFirstLeafKey()
        {
            return Keys[0];
        }

        public override void Merge(Node<T> sibling)
        {
            LinkedLeafNode<T> node = (LinkedLeafNode<T>) sibling;
            Keys.AddRange(node.Keys);
            Next = node.Next;
        }

        public override Node<T> Split()
        {
            int from = Keys.Count / 2 + 1;
            int to = Keys.Count;
            LinkedLeafNode<T> sibling = new LinkedLeafNode<T>(BranchingFactor, ref _root);
            sibling.Keys.AddRange(Keys.GetRange(from, to - from));
            Keys = Keys.GetRange(from, to - from);
            Next = sibling;
            return sibling;
        }

        public override bool IsOverflow()
        {
            return Keys.Count > BranchingFactor - 1;
        }

        public override bool IsUnderFlow()
        {
            return Keys.Count < (BranchingFactor) / 2;
        }

        public override int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (!(obj is LinkedNode<T> otherNode))
                throw new ArgumentException("Object is not a Node");
            return BranchingFactor.CompareTo(otherNode.BranchingFactor);
        }
    }
}
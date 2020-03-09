using System;

namespace Tree
{
    public class LinkedLeafNode<T> : Node<T> where T : IComparable
    {
        public LinkedLeafNode<T> Next;
        public int BranchingFactor { get; }

        public LinkedLeafNode(int branchingFactor)
        {
            Keys = new List<T>();
            BranchingFactor = branchingFactor;
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
            // if (_root.IsOverflow())
            // {
            //     Node<T> sibling = Split();
            //     LinkedNode<T> newRoot = new LinkedNode<T>(BranchingFactor);
            //     newRoot.Keys.Add(sibling.GetFirstLeafKey());
            //     newRoot.Children.Add(this);
            //     newRoot.Children.Add(sibling);
            //     _root = newRoot;
            // }
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
            int from = Keys.Count / 2;
            int count = Keys.Count - from;
            LinkedLeafNode<T> sibling = new LinkedLeafNode<T>(BranchingFactor);
            sibling.Keys.AddRange(Keys.GetRange(from, count));
            Keys = Keys.GetRange(0, from);
            sibling.Next = Next;
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
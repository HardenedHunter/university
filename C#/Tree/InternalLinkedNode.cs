using System;

namespace Tree
{
    class InternalLinkedNode<T> : INode<T> where T: IComparable
    {
        private List<T> _keys;
        private List<INode<T>> _children;
        public int BranchingFactor { get;}

        public InternalLinkedNode(int branchingFactor)
        {
            BranchingFactor = branchingFactor;
            _keys = new List<T>();
            _children = new List<INode<T>>();
        }

        public void Remove(T key)
        {
            INode<T> child = GetChild(key);
            child.Remove(key);
            if (child.IsUnderFlow())
            {
                INode<T> childLeftSibling = GetChildLeftSibling(key);
                INode<T> childRightSibling = GetChildRightSibling(key);
                INode<T> left = childLeftSibling ?? child;
                INode<T> right = childLeftSibling != null ? child : childRightSibling;
                left.Merge(right);
                Remove(right.GetFirstLeafKey());
                if (left.IsOverflow())
                {
                    INode<T> sibling = left.Split();
                    InsertChild(sibling.GetFirstLeafKey(), sibling);
                }
            }
        }

        public void Add(T key)
        {
            throw new System.NotImplementedException();
        }


        public void Merge(INode<T> sibling)
        {
            InternalLinkedNode<T> node = (InternalLinkedNode<T>) sibling;
            _keys.Add(node.GetFirstLeafKey());
            _keys.AddRange(node._keys);
            _children.AddRange(node._children);
        }

        public INode<T> Split()
        {
            int from = _keys.Count / 2 + 1;
            int to = _keys.Count;
            InternalLinkedNode<T> sibling = new InternalLinkedNode<T>(BranchingFactor);
            sibling._keys.AddRange(_keys.GetRange(from, to - from));
            sibling._children.AddRange(_children.GetRange(from, to - from + 1));

            _keys = _keys.GetRange(from - 1, to - from);
            _children = _children.GetRange(from, to - from + 1);
            return sibling;
        }

        public bool IsOverflow()
        {
            return _children.Count > BranchingFactor;
        }

        public bool IsUnderFlow()
        {
            return _children.Count < (BranchingFactor + 1) / 2;
        }

        public T GetFirstLeafKey()
        {
            return _children[0].GetFirstLeafKey();
        }

        public INode<T> GetChildLeftSibling(T key)
        {
            int location = _keys.IndexInSorted(key);
            int childIndex = location >= 0 ? location + 1 : -location - 1;
            return childIndex > 0 ? _children[childIndex - 1] : null;
        }

        public INode<T> GetChild(T key)
        {
            int location = _keys.IndexInSorted(key);
            int childIndex = location >= 0 ? location + 1 : -location - 1;
            return _children[childIndex];
        }

        public INode<T> GetChildRightSibling(T key)
        {
            int location = _keys.IndexInSorted(key);
            int childIndex = location >= 0 ? location + 1 : -location - 1;
            return childIndex < _keys.Count ? _children[childIndex + 1] : null;
        }

        public void DeleteChild(T key)
        {
            int index = _keys.IndexOf(key);
            if (index >= 0)
            {
                _keys.RemoveAt(index);
                _children.RemoveAt(index + 1);
            }
        }

        public void InsertChild(T key, INode<T> child)
        {
            int location = _keys.IndexInSorted(key);
            int childIndex = location >= 0 ? location + 1 : -location - 1;
            if (location >= 0)
            {
                _children[childIndex] = child;
            }
            else
            {
                _keys.Insert(childIndex, key);
                _children.Insert(childIndex + 1, child);
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (!(obj is InternalLinkedNode<T> otherNode))
                throw new ArgumentException("Object is not a Node");
            return BranchingFactor.CompareTo(otherNode.BranchingFactor);
        }
    }
}
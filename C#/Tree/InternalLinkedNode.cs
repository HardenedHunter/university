using System;

namespace Tree
{
    class Constants
    {
    }
    class InternalLinkedNode<T> : INode<T> where T: IComparable<T>
    {
        private List<T> _keys;
        private List<INode<T>> _children;
        public int BranchingFactor { get; private set; }

        public InternalLinkedNode(int branchingFactor)
        {
            BranchingFactor = branchingFactor;
            _keys = new List<T>();
            _children = new List<INode<T>>();
        }

        public void Remove(T node)
        {
            throw new System.NotImplementedException();
        }

        public void Add(T node)
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

        //??????????????????????
        public INode<T> GetChildLeftSibling(T key)
        {
            if (_keys.Count == 0) return null;
            int location = 0;
            //Use IndexInSorted
            while (location < _keys.Count && key.CompareTo(_keys[location]) >= 0)
            {
                location++;
            }

            int childIndex = key.CompareTo(_keys[location]) == 0 ? location : location - 1; 
            return _children[childIndex];
        }

        //??????????????????????
        public INode<T> GetChild(T key)
        {
            if (_keys.Count == 0) return null;
            int location = 0;
            //Use IndexInSorted
            while (location < _keys.Count && key.CompareTo(_keys[location]) >= 0)
            {
                location++;
            }

            int childIndex = key.CompareTo(_keys[location]) == 0 ? location : location - 1;
            return _children[childIndex + 1];
        }

        //??????????????????????
        public INode<T> GetChildRightSibling(T key)
        {
            if (_keys.Count == 0) return null;
            int location = 0;
            //Use IndexInSorted
            while (location < _keys.Count && key.CompareTo(_keys[location]) >= 0)
            {
                location++;
            }

            int childIndex = key.CompareTo(_keys[location]) == 0 ? location : location - 1;
            return _children[childIndex + 2];
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

        public void InsertChild(T key)
        {

        }
    }
}
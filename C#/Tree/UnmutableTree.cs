using System.Collections;
using System.Collections.Generic;

namespace Tree
{
    class UnmutableTree<T> : ITree<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T node)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(T node)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(T node)
        {
            throw new System.NotImplementedException();
        }

        public int Factor { get; }

        public int Count { get; set; }
        public bool IsEmpty { get; set; }
        public IEnumerable<T> Nodes { get; set; }
    }
}
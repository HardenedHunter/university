using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Tree
{
    internal class Node<T>
    {
        public T Info;
        public Node<T> Next;

        public Node(T info, Node<T> next)
        {
            Info = info;
            Next = next;
        }
    }

    public class List<T> : IList<T>, IEnumerator<T> where T : new()
    {
        private Node<T> _head;
        private Node<T> _position;
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public List()
        {
            Clear();
        }

        //NOT IMPLEMENTED
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        //NOT IMPLEMENTED
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        //REWRITE
        public bool Remove(T item)
        {
            var indirect = new Node<T>(new T(), _head);
            while (indirect.Next != null && !EqualityComparer<T>.Default.Equals(indirect.Next.Info, item))
                indirect = indirect.Next;
            var result = indirect.Next != null;
            if (result)
            {
                if (indirect.Next == _head)
                    _head = _head.Next;
                else
                    indirect.Next = indirect.Next.Next;
            }
            return result;
        }

        //TESTED?
        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        //TESTED
        private Node<T> AddNode(ref Node<T> node, T item)
        {
            Count++;
            var result = new Node<T>(item, node);
            node = result;
            return result;
        }

        //TESTED
        private Node<T> GetNodeByIndex(int index)
        {
            if ((uint) index >= (uint) Count) throw new ArgumentOutOfRangeException();

            var indirect = _head;
            for (var i = 0; i < index; i++) indirect = indirect.Next;

            return indirect;
        }

        //TESTED
        public void Insert(int index, T item)
        {
            if ((uint)index > (uint)Count) throw new ArgumentOutOfRangeException();
            if (index == 0)
            {
                AddNode(ref _head, item);
            }
            else
            {
                var previous = GetNodeByIndex(index - 1);
                AddNode(ref previous.Next, item);
            }
        }

        //TESTED
        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        //TESTED
        public int IndexOf(T item)
        {
            var indirect = _head;
            var current = 0;
            while (indirect != null && !EqualityComparer<T>.Default.Equals(indirect.Info, item))
            {
                indirect = indirect.Next;
                current++;
            }
            return indirect == null ? -1 : current;
        }

        //TESTED
        public void Add(T item)
        {
            Insert(Count, item);
        }

        //TESTED
        public T this[int index]
        {
            get => GetNodeByIndex(index).Info;
            set
            {
                var indirect = GetNodeByIndex(index);
                indirect.Info = value;
            }
        }

        //TESTED
        #region IEnumerator and IEnumerable
        public void Dispose()
        {

        }

        object IEnumerator.Current => Current;

        public T Current
        {
            get
            {
                try
                {
                    return _position.Info;
                }
                catch (NullReferenceException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        bool IEnumerator.MoveNext()
        {
            _position = _position.Next;
            return _position != null;
        }

        void IEnumerator.Reset()
        {
            _position = _head;
        }

        public IEnumerator<T> GetEnumerator()
        {
            //Analog of "-1" for arrays, since MoveNext()
            //is called BEFORE yielding the fist element
            _position = new Node<T>(new T(), _head);
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion IEnumerator and IEnumerable
    }
}
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

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        private static Node<T> AddNode(ref Node<T> node, T info)
        {
            var result = new Node<T>(info, node);
            node = result;
            return result;
        }

        private void DelNode(ref Node<T> node)
        {
            node = node.Next;
        }

        private Node<T> GetNode(int index)
        {
            Console.WriteLine($"Count: {Count}");
            if ((uint) index >= (uint) Count) throw new ArgumentOutOfRangeException();

            var indirect = _head;
            for (var i = 0; i < index; i++) indirect = indirect.Next;

            return indirect;
        }

        private Node<T> GetLastNode()
        {
            return GetNode(Count - 1);
        }

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
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
        public void Add(T info)
        {
            if (_head == null)
            {
                _head = AddNode(ref _head, info);
            }
            else
            {
                var indirect = GetLastNode();
                AddNode(ref indirect.Next, info);
            }

            Count++;
        }

        //TESTED
        public T this[int index]
        {
            get => GetNode(index).Info;
            set
            {
                var indirect = GetNode(index);
                indirect.Info = value;
            }
        }

        //TESTED
        #region IEnumerator and IEnumerable
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
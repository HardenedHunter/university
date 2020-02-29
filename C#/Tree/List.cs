using System.Collections.Generic;
using System;
using System.Collections;


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

    public class List<T> : IEnumerator<T>, IList<T> where T : new()
    {
        private Node<T> _head;
        private Node<T> _position;

        public List()
        {
            Clear();
        }

        public int Count { get; private set; }

        object IEnumerator.Current
        {
            get => Current;
        }

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

        public void Dispose()
        {
            Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Node<T> AddNode(ref Node<T> node, T info)
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
            if ((uint) index >= (uint) Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var indirect = _head;
            for (int i = 0; i < index; i++)
            {
                indirect = indirect.Next;
            }

            return indirect;
        }

        private Node<T> GetLastNode()
        {
            return GetNode(Count);
        }

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        public T this[int index]
        {
            get => GetNode(index).Info;
            set
            {
                var indirect = GetNode(index);
                indirect.Info = value;
            }
        }

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

//        public bool Remove(T info)
//        {
//
//        }
    }
}
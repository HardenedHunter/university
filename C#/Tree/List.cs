using System;
using System.Collections;
using System.Collections.Generic;

namespace Tree
{
    internal class ListNode<T>
    {
        public T Info;
        public ListNode<T> Next;

        public ListNode(T info, ListNode<T> next)
        {
            Info = info;
            Next = next;
        }

        public ListNode(ListNode<T> next)
        {
            Next = next;
        }
    }

    public class List<T> : IList<T>, IEnumerator<T> where T: IComparable
    {
        private ListNode<T> _head;
        private ListNode<T> _position;
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public List()
        {
            Clear();
        }

        //NOT IMPLEMENTED
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        //TESTED
        public int IndexInSorted(T item)
        {
            var indirect = _head;
            int index = 0;
            while (indirect != null && item.CompareTo(indirect.Info) > 0)
            {
                indirect = indirect.Next;
                index++;
            }
            if (indirect == null) return -Count - 1;
            if (item.CompareTo(indirect.Info) == 0) return index;
            return -index - 1;
        }

        //TESTED
        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        //TESTED
        public bool Remove(T item)
        {
            var indirect = new ListNode<T>(next: _head);
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

        //TESTED
        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)Count) throw new ArgumentOutOfRangeException();
            if (index == 0)
            {
                _head = _head.Next;
            }
            else
            {
                var indirect = GetNodeByIndex(index - 1);
                indirect.Next = indirect.Next.Next;
            }
        }

        //TESTED
        public void Print()
        {
            foreach (var item in this)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        //TESTED
        private ListNode<T> AddNode(ref ListNode<T> listNode, T item)
        {
            Count++;
            var result = new ListNode<T>(item, listNode);
            listNode = result;
            return result;
        }

        //TESTED
        private ListNode<T> GetNodeByIndex(int index)
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
        public List<T> GetRange(int index, int count)
        {
            if (index < 0 || count < 0) throw new ArgumentOutOfRangeException();
            if (Count < count + index) throw new ArgumentException();

            var list = new List<T>();
            for (int i = index; i < count + index; i++)
            {
                list.Add(this[i]);
            }

            return list;
        }

        //TESTED
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Add(item);
            }
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
            _position = new ListNode<T>(next: _head);
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion IEnumerator and IEnumerable
    }
}
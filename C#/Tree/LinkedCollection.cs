using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable CommentTypo

namespace Tree
{
    /// <summary>
    /// Класс "Звено линейного списка"
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class ListCollectionNode<T>
    {
        public T Info;
        public ListCollectionNode<T> Next;

        public ListCollectionNode(T info, ListCollectionNode<T> next)
        {
            Info = info;
            Next = next;
        }

        public ListCollectionNode(ListCollectionNode<T> next)
        {
            Next = next;
        }
    }

    /// <summary>
    /// Класс "Коллекция элементов на основе линейного списка"
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedCollection<T> : IExtendedCollection<T> where T : IComparable
    {
        private ListCollectionNode<T> _head;
        private ListCollectionNode<T> _position;
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public LinkedCollection()
        {
            Clear();
        }

        public override string ToString()
        {
            return string.Join(" ", this);
        }

        /// <summary>
        /// Индекс элемента в упорядоченном списке. Если элемент отсутствует,
        /// возвращает -index-1, где index - позиция, где находился бы этот элемент
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Позицию элемента, либо -index-1, если элемент отсутствует.</returns>
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

        /// <summary>
        /// Очистка списка.
        /// </summary>
        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        /// <summary>
        /// Удаление элемента из списка.
        /// </summary>
        /// <param name="item">Элемент.</param>
        /// <returns>Был ли удален элемент.</returns>
        public bool Remove(T item)
        {
            var indirect = new ListCollectionNode<T>(next: _head);
            while (indirect.Next != null && !EqualityComparer<T>.Default.Equals(indirect.Next.Info, item))
                indirect = indirect.Next;
            var result = indirect.Next != null;
            if (result)
            {
                if (indirect.Next == _head)
                    _head = _head.Next;
                else
                    indirect.Next = indirect.Next.Next;
                Count--;
            }

            return result;
        }

        /// <summary>
        /// Удаление элемента по указанному индексу.
        /// </summary>
        /// <param name="index">Индекс элемента.</param>
        public void RemoveAt(int index)
        {
            if ((uint) index >= (uint) Count) throw new ArgumentOutOfRangeException();
            if (index == 0)
            {
                _head = _head.Next;
            }
            else
            {
                var indirect = GetNodeByIndex(index - 1);
                indirect.Next = indirect.Next.Next;
            }

            Count--;
        }

        /// <summary>
        /// Печать списка в консоль.
        /// </summary>
        public void Print()
        {
            foreach (var item in this)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Добавление звена в список.
        /// </summary>
        /// <param name="listCollectionNode">Звено, к которому происходит присоединение.</param>
        /// <param name="item">Элемент, содержащийся в новом звене.</param>
        /// <returns>Добавленное звено.</returns>
        private ListCollectionNode<T> AddNode(ref ListCollectionNode<T> listCollectionNode, T item)
        {
            Count++;
            var result = new ListCollectionNode<T>(item, listCollectionNode);
            listCollectionNode = result;
            return result;
        }

        /// <summary>
        /// Получение звена по индексу.
        /// </summary>
        /// <param name="index">Индекс звена.</param>
        /// <returns>Звено.</returns>
        private ListCollectionNode<T> GetNodeByIndex(int index)
        {
            if ((uint) index >= (uint) Count) throw new ArgumentOutOfRangeException();

            var indirect = _head;
            for (var i = 0; i < index; i++) indirect = indirect.Next;

            return indirect;
        }

        /// <summary>
        /// Вставка элемента в список на заданный индекс.
        /// </summary>
        /// <param name="index">Заданный индекс.</param>
        /// <param name="item">Элемент.</param>
        public void Insert(int index, T item)
        {
            if ((uint) index > (uint) Count) throw new ArgumentOutOfRangeException();
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

        /// <summary>
        /// Проверка на содеражние в списке заданного элемента.
        /// </summary>
        /// <param name="item">Заданный элемент.</param>
        /// <returns>Содержит ли список заданный элемент.</returns>
        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        /// <summary>
        /// Индекс заданного элемента в списке.
        /// </summary>
        /// <param name="item">Заданный элемент.</param>
        /// <returns>Индекс элемента.</returns>
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

        /// <summary>
        /// Добавление заданного элемента в список.
        /// </summary>
        /// <param name="item">Заданный элемент.</param>
        public void Add(T item)
        {
            Insert(Count, item);
        }

        /// <summary>
        /// Получение части списка с заданного индекса.
        /// </summary>
        /// <param name="index">Заданный индекс.</param>
        /// <param name="count">Количество элементов.</param>
        /// <returns></returns>
        public IExtendedCollection<T> GetRange(int index, int count)
        {
            if (index < 0 || count < 0) throw new ArgumentOutOfRangeException();
            if (Count < count + index) throw new ArgumentException();

            var list = new LinkedCollection<T>();
            for (int i = index; i < count + index; i++)
            {
                list.Add(this[i]);
            }

            return list;
        }

        /// <summary>
        /// Добавление в список элементов из заданной коллекции.
        /// </summary>
        /// <param name="collection">Заданная коллекция.</param>
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Получение элемента по заданному индексу.
        /// </summary>
        /// <param name="index">Заданный индекс.</param>
        /// <returns></returns>
        public T this[int index]
        {
            get => GetNodeByIndex(index).Info;
            set
            {
                var indirect = GetNodeByIndex(index);
                indirect.Info = value;
            }
        }

        /// <summary>
        /// Копирует все элементы коллекции в массив, начиная с заданного индекса.
        /// </summary>
        /// <param name="array">Заданный массив.</param>
        /// <param name="arrayIndex">Заданный индекс.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length - arrayIndex < this.Count) throw new ArgumentOutOfRangeException();
            foreach (var item in this)
            {
                array[arrayIndex] = item;
                arrayIndex++;
            }
        }

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
            _position = new ListCollectionNode<T>(next: _head);
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion IEnumerator and IEnumerable
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable PossibleMultipleEnumeration

// ReSharper disable CommentTypo

namespace Tree
{
    public class ArrayList<T> : IList<T>, IEnumerator<T> where T : IComparable
    {
        private const int DefaultCapacity = 10;
        private int _position;
        private T[] _items;

        private static readonly T[] EmptyArray = new T[0];

        public int Count { get; private set; }

        public int Capacity
        {
            get => _items.Length;
            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (Count > 0)
                        {
                            Array.Copy(_items, 0, newItems, 0, Count);
                        }

                        _items = newItems;
                    }
                    else
                    {
                        _items = EmptyArray;
                    }
                }
            }
        }

        public bool IsReadOnly => false;

        public ArrayList(int capacity)
        {
            if (capacity <= 0) throw new ArgumentOutOfRangeException();
            _items = new T[capacity];
            Count = 0;
        }

        public ArrayList()
        {
            _items = new T[DefaultCapacity];
            Count = 0;
        }

        /// <summary>
        /// Проверка, что в массиве есть место
        /// для по крайней мере min элементов.
        /// В противном случае, выделяется память под новый массив.
        /// </summary>
        /// <param name="min">Минимальное количество элементов.</param>
        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
                if ((uint) newCapacity > int.MaxValue) newCapacity = int.MaxValue;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
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
            int index = 0;
            while (index < Count && item.CompareTo(_items[index]) > 0)
            {
                index++;
            }

            if (index == Count) return -Count - 1;
            if (item.CompareTo(_items[index]) == 0) return index;
            return -index - 1;
        }

        /// <summary>
        /// Очистка списка.
        /// </summary>
        public void Clear()
        {
            if (Count > 0)
            {
                Array.Clear(_items, 0, Count);
                Count = 0;
            }
        }

        /// <summary>
        /// Удаление элемента из списка.
        /// </summary>
        /// <param name="item">Элемент.</param>
        /// <returns>Был ли удален элемент.</returns>
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index < 0) return false;
            RemoveAt(index);
            return true;
        }

        /// <summary>
        /// Удаление элемента по указанному индексу.
        /// </summary>
        /// <param name="index">Индекс элемента.</param>
        public void RemoveAt(int index)
        {
            if ((uint) index >= (uint) Count)
                throw new ArgumentOutOfRangeException();
            Count--;
            if (index < Count)
            {
                Array.Copy(_items, index + 1, _items, index, Count - index);
            }

            _items[Count] = default(T);
        }

        /// <summary>
        /// Вставка элемента в список на заданный индекс.
        /// </summary>
        /// <param name="index">Заданный индекс.</param>
        /// <param name="item">Элемент.</param>
        public void Insert(int index, T item)
        {
            if ((uint) index > (uint) Count)
                throw new ArgumentOutOfRangeException();
            if (Count == _items.Length) EnsureCapacity(Count + 1);
            if (index < Count)
            {
                Array.Copy(_items, index, _items, index + 1, Count - index);
            }

            _items[index] = item;
            Count++;
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
            return Array.IndexOf(_items, item, 0, Count);
        }

        /// <summary>
        /// Добавление заданного элемента в список.
        /// </summary>
        /// <param name="item">Заданный элемент.</param>
        public void Add(T item)
        {
            if (Count == _items.Length) EnsureCapacity(Count + 1);
            _items[Count++] = item;
        }

        /// <summary>
        /// Добавление в список элементов из заданной коллекции.
        /// </summary>
        /// <param name="collection">Заданная коллекция.</param>
        public void AddRange(IEnumerable<T> collection)
        {
            if (collection.Count() + Count > Capacity)
                throw new ArgumentOutOfRangeException();
            foreach (T item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Получение части списка с заданного индекса.
        /// </summary>
        /// <param name="index">Заданный индекс.</param>
        /// <param name="count">Количество элементов.</param>
        /// <returns></returns>
        public ArrayList<T> GetRange(int index, int count)
        {
            if (index < 0 || count < 0 || Count - index < count)
            {
                throw new ArgumentOutOfRangeException();
            }

            ArrayList<T> list = new ArrayList<T>(count);
            Array.Copy(_items, index, list._items, 0, count);
            list.Count = count;
            return list;
        }

        /// <summary>
        /// Получение элемента по заданному индексу.
        /// </summary>
        /// <param name="index">Заданный индекс.</param>
        /// <returns>Элемент.</returns>
        public T this[int index]
        {
            get
            {
                if ((uint) index >= (uint) Count)
                    throw new ArgumentOutOfRangeException();
                return _items[index];
            }

            set
            {
                if ((uint) index >= (uint) Count)
                    throw new ArgumentOutOfRangeException();
                _items[index] = value;
            }
        }

        /// <summary>
        /// Копирует все элементы коллекции в массив, начиная с заданного индекса.
        /// </summary>
        /// <param name="array">Заданный массив.</param>
        /// <param name="arrayIndex">Заданный индекс.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_items, 0, array, arrayIndex, Count);
        }

        #region IEnumerator and IEnumerable

        public void Dispose()
        {
        }

        object IEnumerator.Current => Current;

        public T Current => _items[_position];

        public bool MoveNext()
        {
            ++_position;
            return _position != Count;
        }

        public void Reset()
        {
            _position = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            _position = -1;
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion IEnumerator and IEnumerable
    }
}
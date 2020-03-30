using System;
using System.Collections.Generic;

// ReSharper disable CommentTypo

namespace Hashing
{
    public class HashTable<T>
    {
        private readonly TableCell<T>[] _table;

        //Размер таблицы
        private const int DefaultSize = 211;
        public int Size { get; set; }
        
        //Количество элементов
        public int Count { get; private set; }

        //Перечислитель элементов (включает пустые ячейки)
        public IEnumerable<TableCell<T>> Data => _table;

        public HashTable(int size = DefaultSize)
        {
            Count = 0;
            Size = size;
            _table = new TableCell<T>[Size];
        }

        private int HashFunction(int key)
        {
            return key % Size;
        }

        private static bool IsEqualKey(int first, int second)
        {
            return first == second;
        }

        public void Clear()
        {
            for (var i = 0; i < Size; i++)
            {
                _table[i] = null;
            }
            Count = 0;
        }

        public void DebugConsolePrint()
        {
            Console.WriteLine("Table:");
            for (int i = 0; i < Size; i++)
            {
                Console.Write($"[{i}] ");
                if (_table[i] != null)
                    Console.WriteLine(_table[i].Info + " " + _table[i].Next);
                else
                    Console.WriteLine("____");
            }

            Console.WriteLine("\n");
        }

        public int IndexOf(int key, out int previous)
        {
            int index = HashFunction(key);
            previous = -1;
            bool found = false;
            while (!found && index != -1)
            {
                found = _table[index] != null && IsEqualKey(key, _table[index].Info.GetHashCode());
                if (!found)
                {
                    previous = index;
                    if (_table[index] == null)
                        index = -1;
                    else
                        index = _table[index].Next;
                }
            }
            return index;
        }

        public bool Find(int key, ref T item)
        {
            var index = IndexOf(key, out int previous);
            var result = index != -1;
            if (result)
                item = _table[index].Info;
            return result;
        }

        public bool Add(T item)
        {
            int index = IndexOf(item.GetHashCode(), out int previous);
            var result = Count != Size && index == -1;
            if (result)
            {
                Count++;
                if (_table[previous] == null)
                    _table[previous] = new TableCell<T>(item);
                else
                {
                    index = previous;
                    //Поиск подходящего места для вставки
                    do
                    {
                        index = (index % Size) + 1;
                    } while (_table[index] != null);

                    _table[index] = new TableCell<T>(item);
                    _table[previous].Next = index;
                }
            }
            return result;
        }

        public bool Delete(int key)
        {
            int index = IndexOf(key, out int previous);
            bool result = Count > 0 && index != -1;
            if (result)
            {
                Count--;
                if (previous != -1)
                    _table[previous].Next = _table[index].Next;
                _table[index] = null;
                
            }
            return result;
        }
    }
}
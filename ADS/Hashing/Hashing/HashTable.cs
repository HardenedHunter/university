using System;

namespace Hashing
{
    class HashTable<T>
    {
        public const int Size = 11;
        
        public int Count { get; private set; }
        
        private readonly TableCell<T>[] _table;

        public HashTable()
        {
            _table = new TableCell<T>[Size];
            Count = 0;
        }

        private int HashFunction(T item)
        {
            return item.GetHashCode() % 2; //% Size
        }

        private static bool IsEqualKey(T first, T second)
        {
            return first.GetHashCode() == second.GetHashCode();
        }

        public void Clear()
        {
            for (var i = 0; i < Size; i++)
            {
                _table[i] = null;
            }
            Count = 0;
        }

        public void DebugPrint()
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

        public int IndexOf(T item, out int previous)
        {
            if (item == null) throw new ArgumentNullException();
            int index = HashFunction(item);
            previous = -1;
            bool found = false;
            while (!found && index != -1)
            {
                found = _table[index] != null && IsEqualKey(item, _table[index].Info);
                if (!found)
                {
                    previous = index;
                    if (_table[index] == null)
                    {
                        index = -1;
                    }
                    else
                    {
                        index = _table[index].Next;
                    }
                }
            }
            return index;
        }

        public bool Add(T item)
        {
            int index = IndexOf(item, out int previous);
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
            DebugPrint();
            return result;
        }

        public bool Delete(T item)
        {
            int index = IndexOf(item, out int previous);
            bool result = Count > 0 && index != -1;
            if (result)
            {
                Count--;
                if (previous != -1)
                    _table[previous].Next = _table[index].Next;
                _table[index] = null;
                
            }
            DebugPrint();
            return result;
        }
    }
}
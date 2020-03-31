using System;
using System.Collections.Generic;

// ReSharper disable CommentTypo

namespace Hashing
{
    public class HashTable<T>
    {
        //Сама таблица для хранения элементов
        private readonly TableCell<T>[] _table;

        //Размер таблицы
        private const int DefaultSize = 101;
        public int Size { get; set; }
        
        //Количество элементов
        public int Count { get; private set; }

        //Перечислитель элементов (включая "пустые" ячейки)
        public IEnumerable<TableCell<T>> Data => _table;

        public HashTable(int size = DefaultSize)
        {
            Count = 0;
            Size = size;
            _table = new TableCell<T>[Size];
        }

        /// <summary>
        /// Вычисление хеш-функции по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Значение хеш-функции</returns>
        private int HashFunction(int key)
        {
            return key % Size;
        }

        /// <summary>
        /// Проверка двух ключей на равенство
        /// </summary>
        /// <param name="first">Ключ</param>
        /// <param name="second">Ключ</param>
        /// <returns>Ранвны ли два ключа</returns>
        private static bool IsEqualKey(int first, int second)
        {
            return first == second;
        }

        /// <summary>
        /// Очистка таблицы
        /// </summary>
        public void Clear()
        {
            for (var i = 0; i < Size; i++)
            {
                _table[i] = null;
            }
            Count = 0;
        }

        /// <summary>
        /// Нахождение номера элемента по ключу
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="previous">Номер предыдущего элемента в цепочке (если он есть, иначе -1)</param>
        /// <returns>Индекс элемента</returns>
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

        /// <summary>
        /// Нахождение элемента по ключу
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="item">Элемент</param>
        /// <returns>Был ли найден элемент</returns>
        public bool Find(int key, ref T item)
        {
            var index = IndexOf(key, out int previous);
            var result = index != -1;
            if (result)
                item = _table[index].Info;
            return result;
        }

        /// <summary>
        /// Добавление элемента в хеш-таблицу
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns>Был ли добавлен элемент (false при переполнении)</returns>
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

        /// <summary>
        /// Удаление элемента из хеш-таблицы по ключу
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Был ли удален элемент (false, если элемент не был найден)</returns>
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
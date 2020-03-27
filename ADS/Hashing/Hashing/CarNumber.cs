﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Policy;

namespace Hashing
{
    class TableCell<T>
    {
        public T Info { get; set; }
        public int Next { get; set; }

        public TableCell(T info, int next = -1)
        {
            Info = info;
            Next = next;
        }
    }

    class HashTable<T> where T : class
    {
        public const int Size = 211;
        public int Count { get; private set; }
        private readonly TableCell<T>[] _table;

        public HashTable()
        {
            _table = new TableCell<T>[Size];
            Clear();
        }

        public void Clear()
        {
            foreach (var cell in _table)
            {
                cell.Info = null;
                cell.Next = -1;
            }
            Count = 0;
        }

        private int HashFunction(T item)
        {
            return item.GetHashCode() % Size;
        }

        private bool IsEqualKey(T first, T second)
        {
            return HashFunction(first) == HashFunction(second);
        }

        public int IndexOf(T item)
        {
            if (item == null) throw new ArgumentNullException();
            int index = HashFunction(item);
            bool found = false;
            while (!found && index != -1)
            {
                found = _table[index].Info != null && IsEqualKey(item, _table[index].Info);
                if (!found)
                {
                    if (_table[index].Info == null)
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
            int index;
            var result = Count != Size && IndexOf(item) == -1;
            if (result)
            {

            }

            return result;
        }

        public bool Delete(T item)
        {
            throw new NotImplementedException();
        }
    }

    class CarNumber
    {
        //Код региона 
        public int RegionCode { get; set; }

        //Регистрационный номер
        public int NumberCode { get; set; }

        //Серия
        private string _series;

        public string Series
        {
            get => _series;
            set
            {
                if (value.Length != 3)
                    throw new ArgumentException("Длина серии должна быть равна 3.");
                _series = value;
            }
        }

        //Разрешённые в серии буквы 
        private static readonly char[] ValidSeriesLetters =
            {'А', 'Е', 'У', 'В', 'О', 'Р', 'К', 'Н', 'Х', 'Т', 'С', 'М'};

        public CarNumber(int regionCode = 36, int numberCode = 001, string series = "ЕКХ")
        {
            RegionCode = regionCode;
            NumberCode = numberCode;
            Series = series;
        }

        public override string ToString()
        {
            return Series[0] + " " + NumToStr(NumberCode, 3) + " " + Series[1] + Series[2] + " " +
                   NumToStr(RegionCode, 2);
        }

        /// <summary>
        /// Конвертация числа в строку с заполнением недостающих разрядов нулями.
        /// </summary>
        /// <param name="num">Число.</param>
        /// <param name="minLength">Минимально заданное кол-во разрядов.</param>
        /// <returns>Строковое представление числа.</returns>
        private static string NumToStr(int num, int minLength)
        {
            string result = num.ToString();
            while (result.Length < minLength)
                result = '0' + result;
            return result;
        }

        public static bool TryReadAsText(StreamReader reader, ref CarNumber number)
        {
            string tmpNumber = "";
            return FileUtils.GetValueFromFile(reader, ref tmpNumber) && TryStrToCarNumber(tmpNumber, ref number);
        }

        public static bool TryStrToCarNumber(string source, ref CarNumber number)
        {
            source = source.ToUpper();
            string tmpSeries = "";
            int tmpRegionCode = 0, tmpNumberCode = 0;
            bool result = GetSeriesChar(ref source, ref tmpSeries) &&
                          GetNumber(ref source, 1, 999, ref tmpNumberCode) &&
                          GetSeriesChar(ref source, ref tmpSeries) && GetSeriesChar(ref source, ref tmpSeries) &&
                          GetNumber(ref source, 1, 999, ref tmpRegionCode) &&
                          source.Trim() == "";
            if (result)
                number = new CarNumber(tmpRegionCode, tmpNumberCode, tmpSeries);
            return result;
        }

        private static bool GetSeriesChar(ref string source, ref string series)
        {
            source = source.Trim();
            bool result = source != "" && ValidSeriesLetters.Contains(source[0]);
            if (result)
            {
                series += source[0];
                source = source.Remove(0, 1);
            }

            return result;
        }

        private static bool GetNumber(ref string source, int min, int max, ref int number)
        {
            source = source.Trim();
            int length = source.Length;
            number = 0;
            bool result = length > 0 && source[0] >= '0' && source[0] <= '9';
            if (result)
            {
                int i = 0;
                do
                {
                    number += (int)char.GetNumericValue(source[i]);
                    i++;
                } while (i < length && source[0] >= '0' && source[0] <= '9');

                source = source.Remove(0, i);
                result = number >= min && number <= max;
            }

            return result;
        }
    }
}
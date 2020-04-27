using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

// ReSharper disable CommentTypo

namespace RadixSort
{
    class RadixSorter
    {
        private readonly DataGridView _grid;

        public RadixSorter(DataGridView grid)
        {
            _grid = grid;
        }

        /// <summary>
        /// Поразрядная сортировка с основанием 10
        /// </summary>
        /// <param name="items">Исходный массив</param>
        /// <param name="length">Максимальная длина числа (в цифрах)</param>
        public void LsdRadixSortBase10(int[] items, int length = 10)
        {
            const int baseNumeric = 10;

            var buckets = new List<int>[baseNumeric];
            for (var i = 0; i < baseNumeric; ++i)
            {
                buckets[i] = new List<int>();
            }

            for (var step = 0; step < length; ++step)
            {

                for (var i = 0; i < items.Length; i++)
                {
                    var index = Math.Abs(items[i]) % (int)Math.Pow(baseNumeric, step + 1) /
                                (int)Math.Pow(baseNumeric, step);
                    buckets[index].Add(items[i]);
                }

                var j = 0;
                foreach (var bucket in buckets)
                {
                    foreach (var sortedItem in bucket)
                    {
                        items[j] = sortedItem;
                        ++j;
                    }
                }

                PopulateDataGrid(buckets, _grid);
                Thread.Sleep(500);

                foreach (var bucket in buckets)
                {
                    bucket.Clear();
                }
            }

            //Обработка отрицательных чисел,
            //проверка первого бита, который отвечает за знак
            foreach (var item in items)
            {
                int index = (item & (1 << length - 1)) != 0 ? 0 : 1;
                buckets[index].Add(item);
            }

            //Располагаем отрицательные числа
            var k = buckets[0].Count - 1;
            foreach (var sortedItem in buckets[0])
            {
                items[k] = sortedItem;
                k--;
            }

            //Располагаем положительные числа числа
            k = buckets[0].Count;
            foreach (var sortedItem in buckets[1])
            {
                items[k] = sortedItem;
                k++;
            }
        }

        /// <summary>
        /// Заполнение DataGridView
        /// </summary>
        public void PopulateDataGrid(List<int>[] buckets, DataGridView grid)
        {
            grid.Rows.Clear();

            for (int i = 0; i < buckets.Length; ++i)
            {
                for (int j = 0; j < buckets[i].Count; ++j)
                {
                    grid.Rows[j].Cells[i].Value = buckets[i][j];
                }
            }

            grid.Refresh();
            grid.ClearSelection();
        }
    }
}
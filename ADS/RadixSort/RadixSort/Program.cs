using System;
using System.Collections.Generic;
using System.Windows.Forms;

// ReSharper disable CommentTypo

namespace RadixSort
{
    static class Program
    {
        /// <summary>
        /// Поразрядная сортировка с основанием 2
        /// </summary>
        /// <param name="items">Исходный массив</param>
        static void LsdRadixSortBase2(int[] items)
        {
            const int baseNumeric = 2;
            const int length = sizeof(int) * 8;

            var buckets = new List<int>[baseNumeric];
            for (var i = 0; i < baseNumeric; ++i)
            {
                buckets[i] = new List<int>();
            }

            for (var step = 0; step < length - 2; ++step)
            {
                foreach (var item in items)
                {
                    int index = (item & (1 << step)) > 0 ? 1 : 0;
                    buckets[index].Add(item);
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

            var k = 0;
            foreach (var bucket in buckets)
            {
                foreach (var sortedItem in bucket)
                {
                    items[k] = sortedItem;
                    ++k;
                }
            }
        }

        /// <summary>
        /// Поразрядная сортировка с основанием 10
        /// </summary>
        /// <param name="items">Исходный массив</param>
        /// <param name="length">Максимальная длина числа (в цифрах)</param>
        static void LsdRadixSortBase10(int[] items, int length = 10)
        {
            const int baseNumeric = 10;

            var buckets = new List<int>[baseNumeric];
            for (var i = 0; i < baseNumeric; ++i)
            {
                buckets[i] = new List<int>();
            }

            for (var step = 0; step < length; ++step)
            {
                foreach (var item in items)
                {
                    var index = Math.Abs(item) % (int) Math.Pow(baseNumeric, step + 1) /
                                (int) Math.Pow(baseNumeric, step);
                    buckets[index].Add(item);
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
        public static void PopulateDataGrid(List<int>[] buckets, DataGridView grid)
        {
            grid.Rows.Clear();

            // var data = _table.Data;
            // int i = 0;
            // foreach (var tableCell in data)
            // {
            //     if (tableCell != null)
            //     {
            //         var (number, model, owner) = tableCell.Info;
            //         dgvHashTable.Rows.Add(i, number, model, owner, tableCell.Next);
            //     }
            //     i++;
            // }
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var arr = new int[] {-82, 84, -61, 44, -51, -41, -48, 79, -34, -51};
            var start = String.Join(" ", arr);
            LsdRadixSortBase10(arr);
            // MessageBox.Show(start + "\n" + String.Join(" ", arr), "", MessageBoxButtons.OK);
            Application.Run(new FormMain());
        }
    }
}
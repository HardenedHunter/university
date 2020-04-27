using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper disable CommentTypo

namespace RadixSort
{
    public partial class FormMain : Form
    {
        private static int DefaultCellSize = 50;
        private static int DefaultTestCount = 10;
        private static int NumberRange = 99;
        private Random _random = new Random();

        public FormMain()
        {
            InitializeComponent();
            SetupBuckets(dgvBuckets);
            SetupSource(dgvSource);
        }

        private void SetupSource(DataGridView source)
        {
            source.RowCount = 1;
            source.ColumnCount = DefaultTestCount;

            for (int i = 0; i < source.ColumnCount; i++)
            {
                source.Columns[i].Width = DefaultCellSize;
            }

            source.Rows[0].Height = DefaultCellSize;
        }

        /// <summary>
        /// Настройка DataGridView
        /// </summary>
        private void SetupBuckets(DataGridView buckets)
        {
            buckets.ColumnCount = DefaultTestCount;
            buckets.RowCount = DefaultTestCount;


            for (int i = 0; i < buckets.ColumnCount; i++)
            {
                buckets.Columns[i].Name = " " + i;
                buckets.Columns[i].Width = DefaultCellSize;
            }

            for (int i = 0; i < buckets.ColumnCount; i++)
            {
                buckets.Rows[i].Height = DefaultCellSize;
            }


            buckets.Width = DefaultCellSize * DefaultTestCount + 3;
            buckets.Height = DefaultCellSize * (DefaultTestCount + 1) + 2;

        }

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DefaultTestCount; i++)
            {
                dgvSource.Rows[0].Cells[i].Value = RandomNumber(-NumberRange, NumberRange);
            }
            dgvSource.ClearSelection();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            LsdRadixSortBase10();
        }

        /// <summary>
        /// Поразрядная сортировка с основанием 10
        /// </summary>
        /// <param name="items">Исходный массив</param>
        /// <param name="length">Максимальная длина числа (в цифрах)</param>
        void LsdRadixSortBase10(int length = 10)
        {
            const int baseNumeric = 10;

            int[] items = new int[10];
            
            for (var i = 0; i < dgvSource.Rows[0].Cells.Count; i++)
            {
                items[i] = Convert.ToInt32(dgvSource.Rows[0].Cells[i].Value);
            }

            var buckets = new List<int>[baseNumeric];
            for (var i = 0; i < baseNumeric; ++i)
            {
                buckets[i] = new List<int>();
            }

            for (var step = 0; step < length; ++step)
            {
                foreach (var item in items)
                {
                    var index = Math.Abs(item) % (int)Math.Pow(baseNumeric, step + 1) /
                                (int)Math.Pow(baseNumeric, step);
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

            MessageBox.Show(String.Join(" ", items), "", MessageBoxButtons.OK);
        }

        // /// <summary>
        // /// Поразрядная сортировка с основанием 10
        // /// </summary>
        // /// <param name="items">Исходный массив</param>
        // /// <param name="length">Максимальная длина числа (в цифрах)</param>
        // public void LsdRadixSortBase10(int length = 3)
        // {
        //     const int baseNumeric = 10;
        //     
        //     int[] items = new int[10];
        //     
        //     for (var i = 0; i < dgvSource.Rows[0].Cells.Count; i++)
        //     {
        //         items[i] = Convert.ToInt32(dgvSource.Rows[0].Cells[i].Value);
        //     }
        //
        //     var buckets = new List<int>[baseNumeric];
        //     for (var i = 0; i < baseNumeric; ++i)
        //     {
        //         buckets[i] = new List<int>();
        //     }
        //
        //     for (var step = 0; step < length; ++step)
        //     {
        //
        //         for (var i = 0; i < items.Length; i++)
        //         {
        //             var index = Math.Abs(items[i]) % (int)Math.Pow(baseNumeric, step + 1) /
        //                         (int)Math.Pow(baseNumeric, step);
        //          
        //             buckets[index].Add(items[i]);
        //
        //             // dgvSource.Rows[0].Cells[index].Style.BackColor = Color.SeaGreen;
        //             // dgvSource.Refresh();
        //             // Thread.Sleep(500);
        //             // dgvSource.Rows[0].Cells[index].Style.BackColor = Color.White;
        //             // dgvSource.Refresh();
        //             // //OPASNO
        //             // dgvBuckets.Rows[buckets[index].Count - 1].Cells[index].Value = items[i];
        //             // dgvBuckets.Rows[buckets[index].Count - 1].Cells[index].Style.BackColor = Color.SeaGreen;
        //             // dgvSource.Refresh();
        //             // Thread.Sleep(500);
        //             // dgvBuckets.Rows[buckets[index].Count - 1].Cells[index].Style.BackColor = Color.White;
        //             // dgvSource.Refresh();
        //
        //         }
        //
        //         var j = 0;
        //         foreach (var bucket in buckets)
        //         {
        //             foreach (var sortedItem in bucket)
        //             {
        //                 // dgvSource.Rows[0].Cells[j].Style.BackColor = Color.SeaGreen;
        //                 // dgvSource.Refresh();
        //                 // Thread.Sleep(250);
        //                 items[j] = sortedItem;
        //                 ++j;
        //             }
        //         }
        //
        //         // for (int i = 0; i < DefaultTestCount; i++)
        //         // {
        //         //     dgvSource.Rows[0].Cells[i].Style.BackColor = Color.White;
        //         // }
        //         // dgvSource.Refresh();
        //
        //
        //         // for (int i = 0; i < dgvBuckets.ColumnCount; i++)
        //         // {
        //         //     for (int l = 0; l < dgvBuckets.RowCount; l++)
        //         //     {
        //         //         dgvBuckets.Rows[l].Cells[i].Value = "";
        //         //     }
        //         // }
        //         //
        //         // dgvSource.Refresh();
        //         //
        //         // // PopulateDataGrid(buckets, dgvBuckets);
        //         // Thread.Sleep(500);
        //
        //         foreach (var bucket in buckets)
        //         {
        //             bucket.Clear();
        //         }
        //
        //
        //     }
        //
        //     //Обработка отрицательных чисел,
        //     //проверка первого бита, который отвечает за знак
        //     foreach (var item in items)
        //     {
        //         int index = (item & (1 << length - 1)) != 0 ? 0 : 1;
        //         buckets[index].Add(item);
        //     }
        //
        //     //Располагаем отрицательные числа
        //     var k = buckets[0].Count - 1;
        //     foreach (var sortedItem in buckets[0])
        //     {
        //         items[k] = sortedItem;
        //         k--;
        //     }
        //
        //     //Располагаем положительные числа числа
        //     k = buckets[0].Count;
        //     foreach (var sortedItem in buckets[1])
        //     {
        //         items[k] = sortedItem;
        //         k++;
        //     }
        //
        //     // for (int i = 0; i < items.Length; i++)
        //     // {
        //     //     dgvSource.Rows[0].Cells[i].Value = items[i];
        //     //     dgvSource.Refresh();
        //     // }
        //
        //     MessageBox.Show(String.Join(" ", items), "", MessageBoxButtons.OK);
        // }

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

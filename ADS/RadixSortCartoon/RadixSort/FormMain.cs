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
        //Размер ячейки таблицы по умолчанию
        private static int DefaultCellSize = 50;
        //Количество элементов в исходном массиве по умолчанию
        private static int DefaultTestCount = 10;
        //Диапазон чисел для генерации по умолчанию
        private static int NumberRange = 99;
        //Генератор случайных чисел
        private readonly Random _random = new Random();
        //Класс, ответственный за сортировку
        private readonly RadixSorter _sorter;

        public FormMain()
        {
            InitializeComponent();
            _sorter = new RadixSorter(DrawIteration, DrawBackPropagation, DrawIterationEnd);
            SetupBuckets(dgvBuckets);
            SetupSource(dgvSource);
            GenerateSourceRow();
        }

        /// <summary>
        /// Настройка DataGridView
        /// </summary>
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

        /// <summary>
        /// Заполнение массива из строки таблицы
        /// </summary>
        /// <param name="row">Строка таблицы</param>
        /// <returns>Массив</returns>
        private static int[] GridRowToArray(DataGridViewRow row)
        {
            int[] array = new int[row.Cells.Count];

            for (var i = 0; i < row.Cells.Count; i++)
            {
                array[i] = Convert.ToInt32(row.Cells[i].Value);
            }

            return array;
        }

        /// <summary>
        /// Генерация случайного числа в заданном диапазоне
        /// </summary>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <returns>Случайное число</returns>
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        /// <summary>
        /// Генерация последовательности случайных чисел
        /// </summary>
        private void GenerateSourceRow()
        {
            for (int i = 0; i < DefaultTestCount; i++)
            {
                dgvSource.Rows[0].Cells[i].Value = RandomNumber(-NumberRange, NumberRange);
            }

            dgvSource.ClearSelection();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            GenerateSourceRow();
        }

        private async void buttonSort_Click(object sender, EventArgs e)
        {
            buttonGenerate.Enabled = false;
            buttonSort.Enabled = false;
            await _sorter.RadixSortBase10(GridRowToArray(dgvSource.Rows[0]));
            buttonGenerate.Enabled = true;
            buttonSort.Enabled = true;
        }

        //Функция, которая выполнится при прохождении одной итерации в сортировке (отрисовка на форме)
        public async Task DrawIteration(int sourceIndex, int targetBucketCount, int targetIndex, int sortedItem)
        {
            dgvSource.Rows[0].Cells[sourceIndex].Style.BackColor = Color.SeaGreen;
            dgvBuckets.Rows[targetBucketCount - 1].Cells[targetIndex].Value = sortedItem;
            dgvBuckets.Rows[targetBucketCount - 1].Cells[targetIndex].Style.BackColor = Color.SeaGreen;
            dgvSource.Refresh();
            dgvBuckets.Refresh();
            await Task.Delay(150);
            dgvSource.Rows[0].Cells[sourceIndex].Style.BackColor = Color.White;
            dgvBuckets.Rows[targetBucketCount - 1].Cells[targetIndex].Style.BackColor = Color.White;
            dgvSource.Refresh();
            dgvBuckets.Refresh();
            await Task.Delay(150);
        }

        //Функция, которая выполнится при обратном распространении после итерации (отрисовка на форме)
        public async Task DrawBackPropagation(int sourceIndex, int sortedItem)
        {
            await Task.Delay(150);
            dgvSource.Rows[0].Cells[sourceIndex].Value = sortedItem;
            dgvSource.Rows[0].Cells[sourceIndex].Style.BackColor = Color.SeaGreen;
            dgvSource.Refresh();
        }

        //Функция, которая выполнится после одного блока итераций (отрисовка на форме)
        public void DrawIterationEnd()
        {
            for (var i = 0; i < DefaultTestCount; i++)
            {
                dgvSource.Rows[0].Cells[i].Style.BackColor = Color.White;
                for (var l = 0; l < DefaultTestCount; l++)
                {
                    dgvBuckets.Rows[l].Cells[i].Value = " ";
                }
            }
            dgvSource.Refresh();
            dgvBuckets.ClearSelection();
            dgvBuckets.Refresh();
        }
    }
}

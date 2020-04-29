﻿using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
// ReSharper disable CommentTypo

namespace RadixSort
{
    public partial class FormMain : Form
    {
        private readonly Random _random;
        //Класс, ответственный за сортировку
        private readonly RadixSorter _sorter;
        
        public FormMain()
        {
            InitializeComponent();
            _random = new Random();
            _sorter = new RadixSorter();
        }

        //Отрисовка графика
        private void DrawChart(Chart chart, int elementsNumber)
        {
            chart.Series[0].Points.Clear();
            chart.Series[1].Points.Clear();
            int size = elementsNumber / 10;
            while (size <= elementsNumber)
            {
                int[] array = new int[size];
                for (int i = 0; i < size; ++i)
                {
                    array[i] = _random.Next(int.MinValue, int.MaxValue);
                }

                _sorter.LsdRadixSortBase10(array);
                int base10Accesses = _sorter.NumberOfArrayAccesses;
                _sorter.LsdRadixSortBase2(array);
                int base2Accesses = _sorter.NumberOfArrayAccesses;
                
                chart.Series[0].Points.AddXY(size, base10Accesses);
                chart.Series[1].Points.AddXY(size, base2Accesses);
                size += elementsNumber / 10;
            }
        }

        private void buttonSmallSet_Click(object sender, EventArgs e)
        {
            DrawChart(chartSmall, 100);
        }

        private void buttonMediumSet_Click(object sender, EventArgs e)
        {
            DrawChart(chartMedium, 10000);
        }

        private void buttonLargeSet_Click(object sender, EventArgs e)
        {
            DrawChart(chartLarge, 100000);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            DrawChart(chartSmall, 100);
            DrawChart(chartMedium, 10000);
            DrawChart(chartLarge, 100000);
        }
    }
}

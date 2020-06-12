﻿using System;
// ReSharper disable CommentTypo

namespace Modeling
{
    public partial class ViewTestSize : System.Windows.Forms.Form
    {
        //Функция, которая выполнится при отправлении формы
        public Action<int> OnSubmit { get; }

        public ViewTestSize(Action<int> onSubmit)
        {
            InitializeComponent();
            OnSubmit = onSubmit;
            Setup();
        }

        private void Setup()
        {
            comboBoxTestSize.Items.Add(15);
            comboBoxTestSize.Items.Add(30);
            comboBoxTestSize.Items.Add(50);
            comboBoxTestSize.SelectedIndex = 0;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            Close();
            OnSubmit((int) comboBoxTestSize.SelectedItem);
        }
    }
}
using System;

// ReSharper disable CommentTypo

namespace ExternalSorting
{
    public partial class FormSortOption : System.Windows.Forms.Form
    {
        //Функция, которая выполнится при отправлении формы
        public Action<Country.GovernmentSystem> OnSubmit { get; }

        public FormSortOption(Action<Country.GovernmentSystem> onSubmit)
        {
            InitializeComponent();
            OnSubmit = onSubmit;
            Setup();
        }

        private void Setup()
        {
            foreach (var name in Country.GovernmentSystemNames)
            {
                comboBoxSystem.Items.Add(name);
            }

            comboBoxSystem.SelectedIndex = 0;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            Close();
            OnSubmit((Country.GovernmentSystem)comboBoxSystem.SelectedIndex);
        }
    }
}
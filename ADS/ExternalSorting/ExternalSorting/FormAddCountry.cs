using System;
using System.Windows.Forms;
// ReSharper disable StringLiteralTypo
// ReSharper disable LocalizableElement

// ReSharper disable CommentTypo

namespace ExternalSorting
{
    public partial class FormAddCountry : System.Windows.Forms.Form
    {
        //Функция, которая выполнится при успешном заполнении формы
        public Action<Country> OnSubmit { get; }

        public FormAddCountry(Action<Country> onSubmit)
        {
            InitializeComponent();
            OnSubmit = onSubmit;
            Setup();
        }

        private void Setup()
        {
            foreach (var name in Country.ContinentNames)
            {
                comboBoxContinent.Items.Add(name);
            }

            comboBoxContinent.SelectedIndex = 0;

            foreach (var name in Country.GovernmentSystemNames)
            {
                comboBoxGovernment.Items.Add(name);
            }

            comboBoxGovernment.SelectedIndex = 0;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            float area = 0;
            float population = 0;
            var result = textBoxName.Text != "" && textBoxCapital.Text != "" &&
                         float.TryParse(textBoxArea.Text, out area) &&
                         float.TryParse(textBoxPopulation.Text, out population);
            if (result)
            {
                var info = new Country(textBoxName.Text, textBoxCapital.Text, area, population,
                    (Country.Continent) comboBoxContinent.SelectedIndex,
                    (Country.GovernmentSystem) comboBoxGovernment.SelectedIndex);
                OnSubmit(info);
                Close();
            }
            else
            {
                MessageBox.Show("Обнаружены недопустимые значения.\n" +
                                "Проверьте правильность входных данных\n" +
                                "и попробуйте ещё раз", "Ошибка", MessageBoxButtons.OK);
            }
        }
    }
}
using System;
using System.Windows.Forms;
using Hashing;
// ReSharper disable LocalizableElement
// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo

namespace Hashing_GUI
{
    public partial class FormAddCarInfo : Form
    {
        //Функция, которая выполнится при успешном заполнении формы
        public Action<CarInfo> OnSubmit { get; }

        public FormAddCarInfo(Action<CarInfo> onSubmit)
        {
            OnSubmit = onSubmit;
            InitializeComponent();
        }

        private void ButtonSubmit_Click(object sender, System.EventArgs e)
        {
            var result = CarNumber.TryStrToCarNumber(TextBoxCarNumber.Text, out var number) &&
                         TextBoxCarModel.Text != "" &&
                         TextBoxCarOwner.Text != "";
            if (result)
            {
                var info = new CarInfo(number, TextBoxCarModel.Text, TextBoxCarOwner.Text);
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

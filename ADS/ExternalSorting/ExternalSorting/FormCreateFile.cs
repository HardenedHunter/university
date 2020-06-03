using System;
using System.Windows.Forms;
// ReSharper disable CommentTypo
// ReSharper disable LocalizableElement
// ReSharper disable StringLiteralTypo

namespace ExternalSorting
{
    public partial class FormCreateFile : Form
    {
        //Функция, которая выполнится при успешном заполнении формы
        public Action<string> OnSubmit { get; }

        public FormCreateFile(Action<string> onSubmit)
        {
            InitializeComponent();
            OnSubmit = onSubmit;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            var result = textBoxFile.Text != "";
            if (result)
            {
                OnSubmit(textBoxFile.Text);
                Close();
            }
            else
            {
                MessageBox.Show($"`{textBoxFile.Text}`");
                MessageBox.Show("Имя файла не может быть пустым.\n" +
                                "Проверьте правильность входных данных\n" +
                                "и попробуйте ещё раз", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

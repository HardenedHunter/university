using System;
using System.IO;
using System.Windows.Forms;
// ReSharper disable CommentTypo

namespace Backtracking
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Setup();
        }

        /// <summary>
        /// Настройка изначальных данных
        /// </summary>
        private void Setup()
        {
            if (File.Exists("../../Words.txt"))
            {
                var wordList = FormUtils.GetWordsFromFile("../../Words.txt");
                foreach (var word in wordList)
                {
                    TextBoxSource.AppendText(word + "\n");
                }
            }
        }

        /// <summary>
        /// Очистка текстовых полей.
        /// </summary>
        private void ClearTextBoxes()
        {
            TextBoxSource.Clear();
            TextBoxResult.Clear();
        }

        private void ButtonTask_Click(object sender, EventArgs e)
        {
            TextBoxResult.Clear();
            
            var words = TextBoxSource.Text.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var result = FormUtils.RunAlgorithm(words);
            
            foreach (var index in result)
            {
                TextBoxResult.AppendText(words[index] + '\n');
            }
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            var filename = "";
            if (FormUtils.ChooseFile(ref filename))
            {
                ClearTextBoxes();
                var wordList = FormUtils.GetWordsFromFile(filename);
                foreach (var word in wordList)
                {
                    TextBoxSource.AppendText(word + "\n");
                }
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

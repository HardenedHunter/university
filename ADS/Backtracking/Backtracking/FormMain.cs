using System;
using System.Collections.Generic;
using System.Windows.Forms;
// ReSharper disable CommentTypo

namespace Backtracking
{
    public partial class FormMain : Form
    {
        //Массив исходных слов
        private string[] _words;
        //Последовательность из слов (их индексов) максимальной длины
        private List<int> _maxSequence;
        //Последовательность из слов (их индексов), промежуточный результат
        private List<int> _currentSequence;
        //Массив из флагов уже использованных слов, где _usedWords[i] = true, если
        //i-ое слово уже было использовано в последовательности
        private bool[] _usedWords;

        /// <summary>
        /// Нахождение максимальной последовательности из слов, такой, что
        /// первая буква каждого слова равна последней букве предыдущего
        /// </summary>
        /// <param name="previousChar">Последняя буква предыдущего слова, для первого слова это символ с кодом 0.</param>
        private void FindMaxWordSequence(char previousChar = '\u0000')
        {
            for (var i = 0; i < _words.Length; i++)
            {
                string word = _words[i];
                //Если слово ещё не было использовано, и либо оно первое в последовательности, либо его первая буква
                //совпадает с последней буквой предыдущего, добавляем слово в последовательность, иначе пропускаем
                if (!_usedWords[i] && (previousChar == '\u0000' || previousChar == word[0]))
                {
                    //Добавили текущее слово в последовательность
                    _currentSequence.Add(i);
                    _usedWords[i] = true;

                    //Проверили все варианты с текущим словом
                    FindMaxWordSequence(word[word.Length - 1]);
                    
                    //Стерли текущее слово
                    _currentSequence.RemoveAt(_currentSequence.Count - 1);
                    _usedWords[i] = false;
                }
            }
            //Если текущее решение больше максимального, обновляем максимальное
            if (_currentSequence.Count > _maxSequence.Count)
                _maxSequence = _currentSequence.GetRange(0, _currentSequence.Count);
        }

        private void ButtonTask_Click(object sender, EventArgs e)
        {
            TextBoxResult.Clear();
            
            _maxSequence = new List<int>();
            _currentSequence = new List<int>();
            _words = TextBoxSource.Text.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            _usedWords = new bool[_words.Length];
         
            FindMaxWordSequence();
            foreach (var index in _maxSequence)
            {
                TextBoxResult.AppendText(_words[index] + '\n');
            }
        }

        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Очистка текстовых полей.
        /// </summary>
        private void ClearTextBoxes()
        {
            TextBoxSource.Clear();
            TextBoxResult.Clear();
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

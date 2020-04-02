using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
// ReSharper disable CommentTypo

namespace Backtracking
{
    static class FormUtils
    {
        //Массив исходных слов
        private static string[] _words;
        //Последовательность из слов (их индексов) максимальной длины
        private static List<int> _maxSequence;
        //Последовательность из слов (их индексов), промежуточный результат
        private static List<int> _currentSequence;
        //Массив из флагов уже использованных слов, где _usedWords[i] = true, если
        //i-ое слово уже было использовано в последовательности
        private static bool[] _usedWords;

        /// <summary>
        /// Основной алгоритм.
        /// Нахождение максимальной последовательности из слов, такой, что
        /// первая буква каждого слова равна последней букве предыдущего.
        /// </summary>
        /// <param name="previousChar">Последняя буква предыдущего слова, для первого слова это символ с кодом 0.</param>
        private static void FindMaxWordSequence(char previousChar = '\0')
        {
            for (var i = 0; i < _words.Length; i++)
            {
                string word = _words[i];
                //Если слово ещё не было использовано, и либо оно первое в последовательности, либо его первая буква
                //совпадает с последней буквой предыдущего, добавляем слово в последовательность, иначе пропускаем
                if (!_usedWords[i] && (previousChar == '\0' || previousChar == word[0]))
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

        /// <summary>
        /// Запуск основного алгоритма.
        /// </summary>
        /// <param name="words">Массив из исходных слов.</param>
        /// <returns>Массив из индексов найденных слов.</returns>
        public static int[] RunAlgorithm(string[] words)
        {
            _words = words;
            _maxSequence = new List<int>();
            _currentSequence = new List<int>();
            _usedWords = new bool[_words.Length];

            FindMaxWordSequence();

            return _maxSequence.ToArray();
        }

        /// <summary>
        /// Выбор файла на жестком диске.
        /// </summary>
        /// <param name="filename">Имя файла.</param>
        /// <returns>Был ли выбран файл.</returns>
        public static bool ChooseFile(ref string filename)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"txt files (*.txt)|*.txt",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            var result = openFileDialog.ShowDialog() == DialogResult.OK;
            if (result) filename = openFileDialog.FileName;
            return result;
        }

        /// <summary>
        /// Чтение из файла слов, записанных по одному на каждой строке.
        /// </summary>
        /// <param name="filename">Имя файла.</param>
        /// <returns>Список прочитанных слов.</returns>
        public static List<string> GetWordsFromFile(string filename)
        {
            var list = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    list.Add(reader.ReadLine());
                }
            }

            return list;
        }
    }
}
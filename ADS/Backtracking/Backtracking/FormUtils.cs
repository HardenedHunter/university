using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
// ReSharper disable CommentTypo

namespace Backtracking
{
    static class FormUtils
    {
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
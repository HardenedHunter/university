using System.IO;
using System.Windows.Forms;
// ReSharper disable CommentTypo

namespace Hashing
{
    public class FileUtils
    {
        /// <summary>
        /// Выбор файла на жестком диске для открытия.
        /// </summary>
        /// <param name="filename">Имя файла.</param>
        /// <returns>Был ли выбран файл.</returns>
        public static bool ChooseFileToOpen(ref string filename)
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
        /// Выбор файла на жестком диске для сохранения.
        /// </summary>
        /// <param name="filename">Имя файла.</param>
        /// <returns>Был ли выбран файл.</returns>
        public static bool ChooseFileToSave(ref string filename)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = @"txt files (*.txt)|*.txt",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            var result = saveFileDialog.ShowDialog() == DialogResult.OK;
            if (result) filename = saveFileDialog.FileName;
            return result;
        }

        /// <summary>
        /// Попытка достать значение из текстового файла
        /// </summary>
        /// <param name="reader">Объект, выполняющий чтение из потока</param>
        /// <param name="value">Значение</param>
        /// <returns>Успешно ли получено значение</returns>
        public static bool GetValueFromFile(StreamReader reader, ref string value)
        {
            value = "";
            bool result = !reader.EndOfStream;
            if (result)
            {
                value = reader.ReadLine();
                if (value == null) throw new EndOfStreamException("Ошибка чтения из файла.");
                int colonIndex = value.IndexOf(':');
                result = colonIndex >= 0 && colonIndex + 1 < value.Length;
                if (result)
                {
                    value = value.Substring(colonIndex + 1).Trim();
                }
            }
            return result;
        }
    }
}
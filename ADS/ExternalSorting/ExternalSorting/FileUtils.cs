using System.IO;
using System.Windows.Forms;
// ReSharper disable CommentTypo
// ReSharper disable StringLiteralTypo

namespace ExternalSorting
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
                Filter = @"binary files (*.bin)|*.bin",
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
    }
}
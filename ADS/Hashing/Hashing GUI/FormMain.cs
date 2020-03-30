using System;
using System.IO;
using System.Windows.Forms;
using Hashing;
// ReSharper disable CommentTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable LocalizableElement

namespace Hashing_GUI
{
    public partial class FormMain : Form
    {
        private HashTable<CarInfo> _table;

        public FormMain()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            _table = new HashTable<CarInfo>();

            dgvHashTable.ColumnCount = 4;
            dgvHashTable.Columns[0].Name = "№";
            dgvHashTable.Columns[0].Width = 30;
            dgvHashTable.Columns[1].Name = "Номер";
            dgvHashTable.Columns[1].Width = 80;
            dgvHashTable.Columns[2].Name = "Марка";
            dgvHashTable.Columns[2].Width = 100;
            dgvHashTable.Columns[3].Name = "Владелец";
            dgvHashTable.Columns[3].Width = 190;

            int width = 0;
            foreach (DataGridViewColumn column in dgvHashTable.Columns)
                width += column.Width;
            dgvHashTable.Width = width + dgvHashTable.ColumnCount - 1;
        }

        private void ClearTable()
        {
            dgvHashTable.Rows.Clear();
            _table.Clear();
        }

        /// <summary>
        /// Заполнение DataGridView из Хеш-таблицы
        /// </summary>
        public void PopulateDataGrid()
        {
            dgvHashTable.Rows.Clear();
            var data = _table.Data;
            int i = 0;
            foreach (var tableCell in data)
            {
                if (tableCell != null)
                {
                    var (number, model, owner) = tableCell.Info;
                    dgvHashTable.Rows.Add(i, number, model, owner); 
                }
                i++; 
            }
        }

        /// <summary>
        /// Выбор файла на жестком диске для открытия.
        /// </summary>
        /// <param name="filename">Имя файла.</param>
        /// <returns>Был ли выбран файл.</returns>
        private bool ChooseFileToOpen(ref string filename)
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
        private bool ChooseFileToSave(ref string filename)
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
        /// Заполнение дерева из текстового файла.
        /// </summary>
        private void FillTableFromFile()
        {
            var filename = "";
            if (ChooseFileToOpen(ref filename))
            {
                ClearTable();
                using (var reader = new StreamReader(File.OpenRead(filename)))
                {
                    bool result = true;
                    while (!reader.EndOfStream && result)
                    {
                        //Возможно исключение EndOfStreamException
                        result = CarInfo.TryReadAsText(reader, out var tmp);
                        if (result)
                        {
                            _table.Add(tmp);
                        }
                    }
                }
            }
        }

        private void SaveTableToFile()
        {
            var filename = "";
            if (ChooseFileToSave(ref filename))
            {
                using (var writer = new StreamWriter(File.Create(filename)))
                {
                    foreach (var tableCell in _table.Data)
                    {
                        tableCell? .Info.WriteAsText(writer);
                    }
                }
            }
        }

        private void ButtonFill_Click(object sender, EventArgs e)
        {
            try
            {
                FillTableFromFile();
                PopulateDataGrid();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveTableToFile();
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            string key = TextBoxCarNumber.Text;
            if (key != "")
            {
                bool result = CarNumber.TryStrToCarNumber(key, out var number);
                if (!result)
                    MessageBox.Show("Номер введён некорректно. Повторите ввод.", "Ошибка", MessageBoxButtons.OK);
                else
                {
                    CarInfo carInfo = null;
                    if (!_table.Find(number.GetHashCode(), ref carInfo))
                        MessageBox.Show("Данные не найдены.", "Ошибка", MessageBoxButtons.OK);
                    else
                        MessageBox.Show($"Номер: {number}\nМарка: {carInfo.Model}\nВладелец: {carInfo.Owner}", 
                            "Информация", MessageBoxButtons.OK);
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            string key = TextBoxCarNumber.Text;
            if (key != "")
            {
                bool result = CarNumber.TryStrToCarNumber(key, out var number);
                if (!result)
                    MessageBox.Show("Номер введён некорректно. Повторите ввод.", "Ошибка", MessageBoxButtons.OK);
                else
                {
                    if (!_table.Delete(number.GetHashCode()))
                        MessageBox.Show("Данные не найдены.", "Ошибка", MessageBoxButtons.OK);
                    else
                    {
                        MessageBox.Show("Запись удалена.", "Успешно.", MessageBoxButtons.OK);
                        PopulateDataGrid();
                    }
                }
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            FormAddCarInfo form = new FormAddCarInfo(info =>
            {
                _table.Add(info);
                PopulateDataGrid();
            });
            form.Show();
        }
    }
}

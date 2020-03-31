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
        //Хеш-таблица
        private HashTable<CarInfo> _table;

        public FormMain()
        {
            InitializeComponent();
            Setup();
        }

        /// <summary>
        /// Настройка DataGridView
        /// </summary>
        private void Setup()
        {
            _table = new HashTable<CarInfo>();

            dgvHashTable.ColumnCount = 5;
            dgvHashTable.Columns[0].Name = "№";
            dgvHashTable.Columns[0].Width = 30;
            dgvHashTable.Columns[1].Name = "Номер";
            dgvHashTable.Columns[1].Width = 80;
            dgvHashTable.Columns[2].Name = "Марка";
            dgvHashTable.Columns[2].Width = 100;
            dgvHashTable.Columns[3].Name = "Владелец";
            dgvHashTable.Columns[3].Width = 190;
            dgvHashTable.Columns[4].Name = "Next";
            dgvHashTable.Columns[4].Width = 35;

            int width = 0;
            foreach (DataGridViewColumn column in dgvHashTable.Columns)
                width += column.Width;
            dgvHashTable.Width = width + dgvHashTable.ColumnCount - 1;
        }

        /// <summary>
        /// Очистка DataGridView и самой хеш-таблицы
        /// </summary>
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
                    dgvHashTable.Rows.Add(i, number, model, owner, tableCell.Next); 
                }
                i++; 
            }
        }

        /// <summary>
        /// Заполнение таблицы из текстового файла.
        /// </summary>
        private void FillTableFromFile()
        {
            var filename = "";
            if (FileUtils.ChooseFileToOpen(ref filename))
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

        /// <summary>
        /// Сохранение таблицы в текстовый файл
        /// </summary>
        private void SaveTableToFile()
        {
            var filename = "";
            if (FileUtils.ChooseFileToSave(ref filename))
            {
                using (var writer = new StreamWriter(File.Create(filename)))
                {
                    foreach (var tableCell in _table.Data)
                    {
                        tableCell?.Info.WriteAsText(writer);
                    }
                }
            }
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
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

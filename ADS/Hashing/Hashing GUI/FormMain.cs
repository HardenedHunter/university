using System;
using System.IO;
using System.Windows.Forms;
using Hashing;
// ReSharper disable CommentTypo
// ReSharper disable StringLiteralTypo

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
            dgvHashTable.Columns[2].Width = 80;
            dgvHashTable.Columns[3].Name = "Владелец";
            dgvHashTable.Columns[3].Width = 150;

            int width = 0;
            foreach (DataGridViewColumn column in dgvHashTable.Columns)
                width += column.Width;
            dgvHashTable.Width = width + dgvHashTable.ColumnCount;
        }

        private void ClearTable()
        {
            dgvHashTable.Rows.Clear();
            _table.Clear();
        }

        public void PopulateDataGrid(DataGridView dgv)
        {
            var data = _table.Data;
            int i = 0;
            foreach (var tableCell in data)
            {
                string[] carInfo;
                if (tableCell != null)
                    carInfo = ($"{i} " + tableCell.Info.ToString()).Split();
                else
                    carInfo = new[] {$"{i}", "", "", ""};
                dgv.Rows.Add(carInfo);
                i++;
            }
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
        /// Заполнение дерева из текстового файла.
        /// </summary>
        private void FillTableFromFile()
        {
            var filename = "";
            if (ChooseFile(ref filename))
            {
                ClearTable();
                using (var reader = new StreamReader(File.OpenRead(filename)))
                {
                    bool result = true;
                    while (!reader.EndOfStream && result)
                    {
                        result = CarInfo.TryReadAsText(reader, out var tmp);
                        if (result)
                        {
                            _table.Add(tmp);
                        }
                    }
                }
                
            }
        }

        private void ButtonFill_Click(object sender, EventArgs e)
        {
            try
            {
                FillTableFromFile();
                PopulateDataGrid(dgvHashTable);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }
    }
}

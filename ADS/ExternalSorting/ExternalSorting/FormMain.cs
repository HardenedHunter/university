using System;
using System.IO;
using System.Windows.Forms;

// ReSharper disable LocalizableElement
// ReSharper disable CommentTypo
// ReSharper disable StringLiteralTypo

namespace ExternalSorting
{
    public partial class FormMain : Form
    {
        private string _fileName = "";

        public FormMain()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            dgvCountries.ColumnCount = 6;
            dgvCountries.Columns[0].Name = "Название";
            dgvCountries.Columns[0].Width = 100;
            dgvCountries.Columns[1].Name = "Столица";
            dgvCountries.Columns[1].Width = 100;
            dgvCountries.Columns[2].Name = "Площадь";
            dgvCountries.Columns[2].Width = 80;
            dgvCountries.Columns[3].Name = "Население";
            dgvCountries.Columns[3].Width = 80;
            dgvCountries.Columns[4].Name = "Континент";
            dgvCountries.Columns[4].Width = 120;
            dgvCountries.Columns[5].Name = "Форма правления";
            dgvCountries.Columns[5].Width = 160;

            int width = 0;
            foreach (DataGridViewColumn column in dgvCountries.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                width += column.Width;
            }
            dgvCountries.Width = width + dgvCountries.ColumnCount - 3;

            UpdateFileName("origin.bin");
            UpdateDataGrid(_fileName);
        }

        private void UpdateFileName(string fileName)
        {
            buttonAdd.Enabled = true;
            buttonSort.Enabled = true;
            _fileName = fileName;
            labelFile.Text = $"Открытый файл: {Path.GetFileName(_fileName)}";
        }

        private void AddToDataGrid(Country country)
        {
            var (name, capital, area, population, continent, system) = country;
            dgvCountries.Rows.Add(name, capital, area, population, Country.ContinentNames[(int) continent],
                Country.GovernmentSystemNames[(int) system]);
        }

        private void UpdateDataGrid(string filename)
        {
            var stream = File.OpenRead(filename);
            dgvCountries.Rows.Clear();
            while (stream.Length != stream.Position)
            {
                var country = Country.Read(stream);
                AddToDataGrid(country);
            }

            stream.Close();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            var filename = "";

            if (FileUtils.ChooseFileToOpen(ref filename))
            {
                UpdateFileName(filename);
                UpdateDataGrid(filename);
            }
        }

        private void CreateFile(object sender, EventArgs e)
        {
            var form = new FormCreateFile(fileName =>
            {
                UpdateFileName(fileName);
                var file = File.Create(fileName);
                file.Close();
                dgvCountries.Rows.Clear();
            });
            form.Show();
        }

        private void AddCountry(object sender, EventArgs e)
        {
            var form = new FormAddCountry(country =>
            {
                var fileStream = File.Open(_fileName, FileMode.Append, FileAccess.Write);
                Country.Write(fileStream, country);
                fileStream.Close();
                AddToDataGrid(country);
            });
            form.Show();
        }

        private void Sort(object sender, EventArgs e)
        {
            FileSorter.Sort(_fileName, (left, right) => string.Compare(left.Name, right.Name, StringComparison.Ordinal) < 0);
            UpdateDataGrid("origin.bin");
        }

        //        private static bool Less(Country left, Country right)
        //        {
        ////            return string.Compare(left.Name, right.Name, StringComparison.Ordinal) < 0;
        //            return left.Area < right.Area;
        //        }
    }
}
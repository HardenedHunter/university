using System;
using System.IO;
using System.Windows.Forms;

// ReSharper disable StringLiteralTypo

namespace ExternalSorting
{
    public class Sequence
    {
        public Country Element { get; set; }
        public bool Eof { get; set; }
        public bool Eor { get; set; }

        private FileStream _file;

        private string _fileName;

        public string FileName
        {
            get => _fileName;
            set
            {
                if (value.Length == 0)
                    throw new ArgumentException("Имя файла не может быть пустым.");
                _fileName = value;
            }
        }

        public Sequence(string fileName)
        {
            FileName = fileName;
        }

        public void ReadNext()
        {
            Eof = _file.Position == _file.Length;
            if (!Eof)
                Element = Country.Read(_file);
        }

        public void StartRead()
        {
            _file = File.OpenRead(FileName);
            ReadNext();
            Eor = Eof;
        }

        public void StartWrite()
        {
            _file = File.Create(FileName);
        }

        public void Close()
        {
            _file.Close();
        }

        public void CopyTo(Sequence sequence)
        {
            sequence.Element = Element;
            Country.Write(sequence._file, Element);
            ReadNext();
            Eor = Eof || string.Compare(Element.Name, sequence.Element.Name, StringComparison.Ordinal) < 0;
        }

        public void CopyRun(Sequence sequence)
        {
            do
            {
                CopyTo(sequence);
            } while (!Eor);
        }

        public void Distribute(Sequence first, Sequence second)
        {
            StartRead();
            first.StartWrite();
            second.StartWrite();
            while (!Eof)
            {
                CopyRun(first);
                if (!Eof) CopyRun(second);
            }

            Close();
            first.Close();
            second.Close();
        }

        public int Merge(Sequence first, Sequence second)
        {
            StartWrite();
            first.StartRead();
            second.StartRead();
            int count = 0;
            while (!first.Eof && !second.Eof)
            {
                while (!first.Eor && !second.Eor)
                    if (string.Compare(first.Element.Name, second.Element.Name, StringComparison.Ordinal) <= 0)
                        first.CopyTo(this);
                    else
                        second.CopyTo(this);
                if (!first.Eor)
                    first.CopyRun(this);
                if (!second.Eor)
                    second.CopyRun(this);

                first.Eor = first.Eof;
                second.Eor = second.Eof;
                count++;
            }

            while (!first.Eof)
            {
                first.CopyRun(this);
                count++;
            }

            while (!second.Eof)
            {
                second.CopyRun(this);
                count++;
            }

            Close();
            first.Close();
            second.Close();

            return count;
        }

        public static void Sort(string fileName)
        {
            var origin = new Sequence(fileName);
            var first = new Sequence("help1.bin");
            var second = new Sequence("help2.bin");
            int seriesCount;

            do
            {
                origin.Distribute(first, second);
                seriesCount = origin.Merge(first, second);
            } while (seriesCount > 1);

            File.Delete("help1.bin");
            File.Delete("help2.bin");
        }
    }
}
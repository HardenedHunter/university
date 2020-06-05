using System;
using System.IO;

// ReSharper disable StringLiteralTypo

namespace ExternalSorting
{
    //Класс, содержащий информацию о файле
    public class Sequence
    {
        //Последний прочитанный элемент
        public Country Element { get; set; }

        //Конец файла или нет
        public bool Eof { get; set; }

        //Конец серии элементов или нет
        public bool Eor { get; set; }

        //Имя файла
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

        //Соответствующий файловый поток
        private FileStream _fileStream;

        //Компаратор для сортировки
        private readonly Func<Country, Country, bool> _less;

        public Sequence(string fileName, Func<Country, Country, bool> less)
        {
            FileName = fileName;
            Element = null;
            _less = less;
        }

        ///Чтение следующего элемента
        public void ReadNext()
        {
            Eof = _fileStream.Position == _fileStream.Length;
            if (!Eof)
                Element = Country.Read(_fileStream);
        }

        //Подготовить файл к чтению
        public void StartRead()
        {
            _fileStream = File.OpenRead(FileName);
            ReadNext();
            Eor = Eof;
        }

        //Подготовить файл к записи
        public void StartWrite()
        {
            _fileStream = File.Create(FileName);
        }

        //Закрыть файловый поток
        public void Close()
        {
            _fileStream.Close();
        }

        //Скопировать элемент из текущего файла в другой
        public void CopyTo(Sequence sequence)
        {
            sequence.Element = Element;
            Country.Write(sequence._fileStream, Element);
            ReadNext();
            Eor = Eof || _less(Element, sequence.Element);
        }

        //Скопировать серию из элементов из текущего файла в другой
        public void CopySeriesTo(Sequence sequence)
        {
            do
            {
                CopyTo(sequence);
            } while (!Eor);
        }

        //Скопировать серию с проверкой, что предыдущая и текущая серии идут подряд
        public void CopySeriesBalanced(Sequence sequence)
        {
            Country previous = sequence.Element;
            bool shouldRepeat = previous != null && _less(previous, Element);
            CopySeriesTo(sequence);
            if (shouldRepeat)
                CopySeriesTo(sequence);
        }

        //Фаза распределения
        public void Distribute(Sequence first, Sequence second)
        {
            StartRead();
            first.StartWrite();
            second.StartWrite();
            while (!Eof)
            {
                CopySeriesBalanced(first);
                if (!Eof) CopySeriesBalanced(second);
            }

            Close();
            first.Close();
            second.Close();
        }

        //Фаза слияния
        public int Merge(Sequence first, Sequence second)
        {
            StartWrite();
            first.StartRead();
            second.StartRead();
            int count = 0;
            while (!first.Eof && !second.Eof)
            {
                while (!first.Eor && !second.Eor)
                    if (_less(first.Element, second.Element))
                        first.CopyTo(this);
                    else
                        second.CopyTo(this);
                if (!first.Eor)
                    first.CopySeriesTo(this);
                if (!second.Eor)
                    second.CopySeriesTo(this);

                first.Eor = first.Eof;
                second.Eor = second.Eof;
                count++;
            }

            while (!first.Eof)
            {
                first.CopySeriesTo(this);
                count++;
            }

            while (!second.Eof)
            {
                second.CopySeriesTo(this);
                count++;
            }

            Close();
            first.Close();
            second.Close();

            return count;
        }
    }
}
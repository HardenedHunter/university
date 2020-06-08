using System;
using System.IO;

// ReSharper disable CommentTypo
// ReSharper disable StringLiteralTypo

namespace ExternalSorting
{
    //Класс, содержащий информацию о файле
    public class FileInfo
    {
        //Последний прочитанный элемент
        public Country Element { get; set; }

        //Конец файла или нет
        public bool Eof { get; set; }

        //Конец серии элементов или нет
        public bool Eos { get; set; }

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

        public FileInfo(string fileName, Func<Country, Country, bool> less)
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
            _fileStream = File.Exists(FileName) ? File.OpenRead(FileName) : File.Create(FileName);
            ReadNext();
            Eos = Eof;
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
        public void CopyTo(FileInfo fileInfo)
        {
            fileInfo.Element = Element;
            Element.Write(fileInfo._fileStream);
            ReadNext();
            Eos = Eof || _less(Element, fileInfo.Element);
        }

        //Скопировать элемент с проверкой
        public void CopyTo(FileInfo fileInfo, Func<Country, bool> predicate)
        {
            fileInfo.Element = Element;
            if (predicate(Element))
                Element.Write(fileInfo._fileStream);
            ReadNext();
            Eos = Eof || _less(Element, fileInfo.Element);
        }
    }
}
using System;
using System.IO;

// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo

namespace ExternalSorting
{
    public class FileSorter
    {
        //Префикс для названий вспомогательных файлов
        public const string HelperFilesPrefix = "_f";

        //Количество путей в сортировке по умолчанию
        public const int DefaultWayCount = 3;

        //Количество путей в сортировке
        private int _wayCount;
        public int WayCount
        {
            get => _wayCount;
            set
            {
                if (value < 2)
                    throw new ArgumentException("Количество путей должно быть больше или равно 2.");
                _wayCount = value;
            }
        }

        //Массив из файлов размером 2 * _wayCount
        private FileInfo[][] _files;

        //Предикат для сравнения двух элементов во время сортировки
        public Func<Country, Country, bool> Less { get; set; }

        //Предикат для начального отбора элементов (по государственному строю или другим полям)
        public Func<Country, bool> ShouldSort { get; set; }

        public FileSorter(Func<Country, Country, bool> less, Func<Country, bool> predicate,
            int wayCount = DefaultWayCount)
        {
            WayCount = wayCount;
            Less = less;
            ShouldSort = predicate;
        }

        /// <summary>
        /// Инициализация данных перед сортировкой. Создаёт массив
        /// размера 2 * WayCount, в котором хранится информация о файлах.
        /// </summary>
        private void InitFiles()
        {
            _files = new FileInfo[2][];
            for (int i = 0; i < 2; i++)
            {
                _files[i] = new FileInfo[WayCount];
                for (int j = 0; j < WayCount; j++)
                {
                    _files[i][j] = new FileInfo(HelperFilesPrefix + i + j, Less);
                }
            }
        }

        /// <summary>
        /// Базовый метод для выполнения заданной операции над всеми файлами
        /// </summary>
        /// <param name="action">Операция</param>
        private void ForEach(Action<FileInfo> action)
        {
            foreach (var row in _files)
            foreach (var file in row)
                action(file);
        }

        /// <summary>
        /// Закрытие всех файлов
        /// </summary>
        private void CloseEach()
        {
            ForEach(info => info.Close());
        }

        /// <summary>
        /// Удаление всех файлов
        /// </summary>
        private void DeleteEach()
        {
            ForEach(info =>
            {
                string fileName = info.FileName;
                if (File.Exists(fileName))
                    File.Delete(fileName);
            });
        }

        /// <summary>
        /// Проверка, что все файлы в заданной последовательности дошли до конца
        /// </summary>
        /// <param name="files">Последовательность из файлов</param>
        /// <returns></returns>
        private bool AllFilesEnded(FileInfo[] files)
        {
            bool result = true;
            for (int i = 0; i < files.Length && result; i++)
                result = files[i].Eof;

            return result;
        }

        /// <summary>
        /// Возвращает индекс файла, в котором находится минимальный элемент
        /// из текущей серии. Если серия закончилась, возвращает -1.
        /// </summary>
        /// <param name="files">Последовательность из файлов</param>
        /// <returns>Индекс файла с минимальным элементом</returns>
        private int GetIndexOfFileWithMinElement(FileInfo[] files)
        {
            int minIndex = -1;
            int index = 0;
            while (index < files.Length && files[index].Eos) index++;
            if (index < files.Length)
            {
                Country min = files[index].Element;
                minIndex = index;
                index++;
                while (index < files.Length)
                {
                    if (!files[index].Eos && Less(files[index].Element, min))
                    {
                        minIndex = index;
                        min = files[index].Element;
                    }

                    index++;
                }
            }

            return minIndex;
        }

        /// <summary>
        /// Главный метод сортировки
        /// </summary>
        /// <param name="fileName">Имя исходного файла</param>
        public void Sort(string fileName)
        {
            //Исходный файл переименовывается и становится одним из вспомогательных,
            //по умолчанию он помещается в первый ряд на первое место
            File.Move(fileName, HelperFilesPrefix + "00");

            InitFiles();
            FirstDistribution();

            int phaseCount = 1;
            while (Phase(phaseCount) != 1)
            {
                phaseCount++;
            }

            var lastUsedFile = HelperFilesPrefix + (phaseCount + 1) % 2 + 0;
            File.Move(lastUsedFile, fileName);
            DeleteEach();
        }

        //Начальный отбор файлов по государственному строю
        public void FirstDistribution()
        {
            var source = _files[0][0];
            var target = _files[1][0];

            source.StartRead();
            target.StartWrite();

            while (!source.Eof)
                source.CopyTo(target, ShouldSort);

            source.Close();
            target.Close();
        }

        /// <summary>
        /// Одна полная фаза сортировки
        /// </summary>
        /// <param name="phaseCount">Номер этой фазы</param>
        /// <returns>Количество распределенных во время фазы серий</returns>
        public int Phase(int phaseCount)
        {
            //Индекс ряда, с файлов которого будет чтение
            int readIndex = phaseCount % 2;
            //Индекс ряда, в файлы которого будет запись
            int writeIndex = (phaseCount + 1) % 2;

            //Подготовка соответствующих файлов к чтению и записи
            for (int i = 0; i < WayCount; i++)
            {
                _files[readIndex][i].StartRead();
                _files[writeIndex][i].StartWrite();
            }

            //Счетчик прочитанных серий
            int seriesCount = 0;

            do
            {
                //Копируем одну серию в выбранный файл. Если не произошло слияния серий, увеличивается счетчик
                if (!CopySeries(_files[readIndex], _files[writeIndex][seriesCount % WayCount]))
                    seriesCount++;

                foreach (var fileInfo in _files[readIndex])
                    fileInfo.Eos = fileInfo.Eof;
            } while (!AllFilesEnded(_files[readIndex]));

            CloseEach();
            return seriesCount;
        }

        public bool CopySeries(FileInfo[] from, FileInfo to)
        {
            //Индекс файла, в котором находится минимальный элемент для текущей серии
            int index = GetIndexOfFileWithMinElement(from);
            //Проверка для сбалансированного слияния (нужно ли будет повторить и записать ещё одну серию)
            bool shouldRepeat = index != -1 && to.Element != null && Less(to.Element, from[index].Element);

            while (index != -1)
            {
                //Копируем этот элемент в файл
                from[index].CopyTo(to);
                index = GetIndexOfFileWithMinElement(from);
            }

            return shouldRepeat;
        }
    }
}
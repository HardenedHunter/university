// ReSharper disable CommentTypo
// ReSharper disable StringLiteralTypo

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Hashing
{
    public class CarNumber
    {
        //Код региона 
        public int RegionCode { get; set; }

        //Регистрационный номер
        public int NumberCode { get; set; }

        //Серия
        private string _series;
        public string Series
        {
            get => _series;
            set
            {
                if (value.Length != 3)
                    throw new ArgumentException("Длина серии должна быть равна 3.");
                _series = value;
            }
        }

        //Разрешённые в серии буквы 
        private static readonly char[] ValidSeriesLetters =
            {'А', 'Е', 'У', 'В', 'О', 'Р', 'К', 'Н', 'Х', 'Т', 'С', 'М'};

        public CarNumber(string source)
        {
            if (!TryStrToCarNumber(source, out var tmpSeries, out var tmpNumberCode, out var tmpRegionCode))
                throw new ArgumentException("Строка не может быть преобразована в номер автомобиля.");

            Series = tmpSeries;
            RegionCode = tmpRegionCode;
            NumberCode = tmpNumberCode;
        }

        public CarNumber(int regionCode = 36, int numberCode = 001, string series = "ЕКХ")
        {
            RegionCode = regionCode;
            NumberCode = numberCode;
            Series = series;
        }

        /// <summary>
        /// Вычисление значения ключа для хеш-таблицы
        /// </summary>
        /// <returns>Ключ</returns>
        public override int GetHashCode()
        {
            var result = 0;
            var carNumber = ToString();
            var length = carNumber.Length;
            for (int i = 0; i < length; i++)
                result += carNumber[i] * (int)Math.Pow(31, length - i - 1);
            return Math.Abs(result);
        }

        /// <summary>
        /// Преобразование номера в строку, формат:
        /// буква, 3 цифры, 2 буквы, 2 цифры
        /// </summary>
        /// <returns>Номер в виде строки</returns>
        public override string ToString()
        {
            return Series[0] + NumToStr(NumberCode, 3) + Series[1] + Series[2] + NumToStr(RegionCode, 2);
        }

        /// <summary>
        /// Конвертация числа в строку с заполнением недостающих разрядов нулями.
        /// </summary>
        /// <param name="num">Число.</param>
        /// <param name="minLength">Минимально заданное кол-во разрядов.</param>
        /// <returns>Строковое представление числа.</returns>
        private static string NumToStr(int num, int minLength)
        {
            var result = num.ToString();
            while (result.Length < minLength)
                result = '0' + result;
            return result;
        }

        /// <summary>
        /// Попытка чтения номера из файла
        /// </summary>
        /// <param name="reader">Объект, читающий данные из потока</param>
        /// <param name="number">Номер автомобиля</param>
        /// <returns>Успешно ли прошло чтение и конвертация</returns>
        public static bool TryReadAsText(StreamReader reader, out CarNumber number)
        {
            var tmpNumber = "";
            number = null;
            return FileUtils.GetValueFromFile(reader, ref tmpNumber) && TryStrToCarNumber(tmpNumber, out number);
        }

        /// <summary>
        /// Попытка конвертировать строку в номер автомобиля
        /// </summary>
        /// <param name="source">Исходная строка</param>
        /// <param name="series">Серия</param>
        /// <param name="numberCode">Регистрационный номер</param>
        /// <param name="regionCode">Код региона</param>
        /// <returns>Успешно ли прошла конвертация</returns>
        public static bool TryStrToCarNumber(string source, out string series, out int numberCode, out int regionCode) 
        {
            source = source.ToUpper();
            series = "";
            regionCode = 0; 
            numberCode = 0;
            var result = GetSeriesChar(ref source, ref series) &&
                         GetNumber(ref source, 1, 999, ref numberCode) &&
                         GetSeriesChar(ref source, ref series) && GetSeriesChar(ref source, ref series) &&
                         GetNumber(ref source, 1, 999, ref regionCode) &&
                         source.Trim() == "";
            return result;
        }

        /// <summary>
        /// Попытка конвертировать строку в номер автомобиля
        /// </summary>
        /// <param name="source">Исходная строка</param>
        /// <param name="number">Номер автомобиля</param>
        /// <returns>Успешно ли прошла конвертация</returns>
        public static bool TryStrToCarNumber(string source, out CarNumber number)
        {
            var result = TryStrToCarNumber(source, out var tmpSeries, out var tmpNumberCode, out var tmpRegionCode);
            if (result)
                number = new CarNumber(tmpRegionCode, tmpNumberCode, tmpSeries);
            else
                number = null;
            return result;
        }

        /// <summary>
        /// Попытка получить букву серии из строки
        /// </summary>
        /// <param name="source">Исходная строка</param>
        /// <param name="series">Серия</param>
        /// <returns>Успешно ли получена буква</returns>
        private static bool GetSeriesChar(ref string source, ref string series)
        {
            source = source.Trim();
            var result = source != "" && ValidSeriesLetters.Contains(source[0]);
            if (result)
            {
                series += source[0];
                source = source.Remove(0, 1);
            }

            return result;
        }

        /// <summary>
        /// Попытка достать число из строки
        /// </summary>
        /// <param name="source">Исходная строка</param>
        /// <param name="min">Минимальное допустимое значение числа</param>
        /// <param name="max">Максимальное допустимое значение числа</param>
        /// <param name="number">Число</param>
        /// <returns>Успешно ли получено число</returns>
        private static bool GetNumber(ref string source, int min, int max, ref int number)
        {
            source = source.Trim();
            var length = source.Length;
            number = 0;
            var result = length > 0 && source[0] >= '0' && source[0] <= '9';
            if (result)
            {
                var i = 0;
                do
                {
                    number = number * 10 + (int)char.GetNumericValue(source[i]);
                    i++;
                } while (i < length && source[i] >= '0' && source[i] <= '9');

                source = source.Remove(0, i);
                result = number >= min && number <= max;
            }

            return result;
        }
    }
}
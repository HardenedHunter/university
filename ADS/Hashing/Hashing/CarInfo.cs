using System;
using System.IO;
// ReSharper disable CommentTypo

// ReSharper disable StringLiteralTypo

namespace Hashing
{
    public class CarInfo
    {
        //Модель автомобиля
        private string _model;
        public string Model
        {
            get => _model;
            private set
            {
                if (value.Length == 0)
                    throw new ArgumentException("Модель автомобиля не может быть пустой.");
                _model = value;
            }
        }
        
        //Владелец автомобиля (ФИО)
        private string _owner;
        public string Owner
        {
            get => _owner;
            private set
            {
                if (value.Length == 0)
                    throw new ArgumentException("Владелец автомобиля не может быть пустым.");
                _owner = value;
            }
        }

        //Номер автомобиля
        public readonly CarNumber Number;

        public CarInfo(CarNumber number, string model, string owner)
        {
            Model = model;
            Owner = owner;
            Number = number;
        }

        /// <summary>
        /// Деконструкция объекта, используется для
        /// более простого получения всех полей.
        /// </summary>
        /// <param name="number">Номер</param>
        /// <param name="model">Модель</param>
        /// <param name="owner">Владелец</param>
        public void Deconstruct(out CarNumber number, out string model, out string owner)
        {
            number = Number;
            model = Model;
            owner = Owner;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Number} {_model} {_owner}";
        }

        /// <summary>
        /// Запись информации об автомобиле в текстовый файл
        /// </summary>
        /// <param name="writer">Объект, производящий запись</param>
        public void WriteAsText(StreamWriter writer)
        {
            writer.WriteLine($"Номер: {Number}");
            writer.WriteLine($"Марка: {_model}");
            writer.WriteLine($"Владелец: {_owner}");
        }

        /// <summary>
        /// Попытка считать информацию об автомобиле из текстового файла
        /// </summary>
        /// <param name="reader">Объект, производящий считывание</param>
        /// <param name="carInfo">Информация об автомобиле</param>
        /// <returns>Успешно ли была прочитана информация</returns>
        public static bool TryReadAsText(StreamReader reader, out CarInfo carInfo)
        {
            string tmpModel = "", tmpOwner = "";
                           
            bool result = CarNumber.TryReadAsText(reader, out var tmpNumber) && 
                          FileUtils.GetValueFromFile(reader, ref tmpModel) &&
                          FileUtils.GetValueFromFile(reader, ref tmpOwner);
            if (result)
                carInfo = new CarInfo(tmpNumber, tmpModel, tmpOwner);
            else
                carInfo = null;
            return result;
        }
    }
}
using System;
using System.IO;

// ReSharper disable StringLiteralTypo

namespace Hashing
{
    public class CarInfo
    {
        private string _model;
        
        private string _owner;
        
        public readonly CarNumber Number;

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

        public CarInfo(CarNumber number, string model, string owner)
        {
            Model = model;
            Owner = owner;
            Number = number;
        }

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

        public void WriteAsText(StreamWriter writer)
        {
            writer.WriteLine($"Номер: {Number}");
            writer.WriteLine($"Марка: {_model}");
            writer.WriteLine($"Владелец: {_owner}");
        }
        
        public void WriteToConsole()
        {
            Console.WriteLine($"Номер: {Number}");
            Console.WriteLine($"Марка: {_model}");
            Console.WriteLine($"Владелец: {_owner}");
        }

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
using System;
using System.IO;

namespace Hashing
{
    public class CarInfo
    {
        private string _model;
        
        private string _owner;
        
        private readonly CarNumber _number;

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

        public CarInfo(string model, string owner, CarNumber number)
        {
            Model = model;
            Owner = owner;
            _number = number;
        }

        public override int GetHashCode()
        {
            return _number.GetHashCode();
        }

        public override string ToString()
        {
            return $"{_number} {_model} {_owner}";
        }

        public void WriteAsText(StreamWriter writer)
        {
            writer.WriteLine($"Номер: {_number}");
            writer.WriteLine($"Марка: {_model}");
            writer.WriteLine($"Владелец: {_owner}");
        }
        
        public void WriteToConsole()
        {
            Console.WriteLine($"Номер: {_number}");
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
                carInfo = new CarInfo(tmpModel, tmpOwner, tmpNumber);
            else
                carInfo = null;
            return result;
        }
    }
}
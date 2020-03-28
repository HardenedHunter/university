using System;
using System.IO;

namespace Hashing
{
    class CarInfo
    {
        private string _model;
        
        private string _owner;
        
        private CarNumber _number;

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

        public static bool TryReadAsText(StreamReader reader, ref CarInfo carInfo)
        {
            string tmpModel = "", tmpOwner = "";
            var tmpNumber = new CarNumber();
                           
            bool result = CarNumber.TryReadAsText(reader, ref tmpNumber) && 
                          FileUtils.GetValueFromFile(reader, ref tmpModel) &&
                          FileUtils.GetValueFromFile(reader, ref tmpOwner);
            if (result)
                carInfo = new CarInfo(tmpModel, tmpOwner, tmpNumber);
            return result;
        }
    }
}
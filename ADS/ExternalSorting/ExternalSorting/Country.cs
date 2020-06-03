using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo

namespace ExternalSorting
{
    [Serializable]
    public class Country
    {
        [Serializable]
        public enum Continent
        {
            Antarctica,
            Australia,
            Africa,
            NorthAmerica,
            SouthAmerica,
            Eurasia
        }

        [Serializable]
        public enum GovernmentSystem
        {
            Monarchy,
            Republic
        }

        public static readonly string[] ContinentNames =
            {"Антарктика", "Австралия", "Африка", "Северная Америка", "Южная Америка", "Евразия"};

        public static readonly string[] GovernmentSystemNames =
            {"Монархия", "Республика"};

        //Название страны
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                if (value.Length == 0)
                    throw new ArgumentException("Название страны не может быть пустым.");
                _name = value;
            }
        }

        //Название столицы
        private string _capital;

        public string Capital
        {
            get => _capital;
            set
            {
                if (value.Length == 0)
                    throw new ArgumentException("Название столицы не может быть пустым.");
                _capital = value;
            }
        }

        //Площадь страны
        private float _area;

        public float Area
        {
            get => _area;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Площадь страны должна быть положительной.");
                _area = value;
            }
        }

        //Площадь страны
        private float _population;

        public float Population
        {
            get => _population;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Население страны должно быть положительным числом.");
                _population = value;
            }
        }

        //Континент
        public Continent Location { get; set; }

        //Государственный строй
        public GovernmentSystem System { get; set; }

        public Country(string name, string capital, float area, float population, Continent continent,
            GovernmentSystem system)
        {
            Name = name;
            Capital = capital;
            Area = area;
            Population = population;
            Location = continent;
            System = system;
        }

        public static void Write(FileStream fileStream, Country country)
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, country);
        }

        public static Country Read(FileStream fileStream)
        {
            if (fileStream.Position == fileStream.Length)
                return null;

            var formatter = new BinaryFormatter();
            return (Country) formatter.Deserialize(fileStream);
        }

        public void Deconstruct(out string name, out string capital, out float area, out float population,
            out Continent continent, out GovernmentSystem system)
        {
            name = Name;
            capital = Capital;
            area = Area;
            population = Population;
            continent = Location;
            system = System;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Cat> cats = new List<Cat>();

        string line = Console.ReadLine();
        while (line != "End")
        {
            string[] inputElements = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string breed = inputElements[0];
            string name = inputElements[1];
            double thirdElement = double.Parse(inputElements[2]);

            switch (breed)
            {
                case "Siamese":                    
                    cats.Add(new Cat.Siamese(name, (int)thirdElement));                    
                    break;

                case "Cymric":                    
                    cats.Add(new Cat.Cymric(name, thirdElement));
                    break;

                case "StreetExtraordinaire":
                    cats.Add(new Cat.StreetExtraordinaire(name, (int)thirdElement));
                    break;
            }
            line = Console.ReadLine();
        }

        string chosenCat = Console.ReadLine();
        Cat cat = cats.First(c => c.Name == chosenCat);

        Console.WriteLine(cat);
    }

    public class Cat
    {
        private string name;
      
        public Cat()
        {
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public class Siamese : Cat
        {
            private int earSize;

            public int EarSize
            {
                get { return earSize; }
                set { earSize = value; }
            }

            public Siamese(string name, int earSize)
            {
                this.name = name;
                this.earSize = earSize;
            }

            public override string ToString()
            {
                return string.Format($"Siamese {this.name} {this.earSize}");
            }
        }

        public class Cymric : Cat
        {
            private double furLength;

            public double EarSize
            {
                get { return furLength; }
                set { furLength = value; }
            }

            public Cymric(string name, double furLength)
            {
                this.name = name;
                this.furLength = furLength;
            }

            public override string ToString()
            {
                return string.Format($"Cymric {this.name} {this.furLength:f2}");
            }
        }

        public class StreetExtraordinaire : Cat
        {
            private int decibelsOfMeows;

            public int DecibelsOfMeows
            {
                get { return decibelsOfMeows; }
                set { decibelsOfMeows = value; }
            }

            public StreetExtraordinaire(string name, int decibelOfMeows)
            {
                this.name = name;
                this.decibelsOfMeows = decibelOfMeows;
            }

            public override string ToString()
            {
                return string.Format($"StreetExtraordinaire {this.name} {this.decibelsOfMeows}");
            }
        }
    }
}


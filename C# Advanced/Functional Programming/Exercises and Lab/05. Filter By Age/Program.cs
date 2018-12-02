using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());

            Dictionary<string, int> NameAge = new Dictionary<string, int>(peopleCount);
            PopulateDictionary(peopleCount, NameAge);

            string condition = Console.ReadLine();
            int conditionAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<KeyValuePair<string, int>, bool> filter = createFilter(condition, conditionAge);
            Action<KeyValuePair<string, int>> printer = creatPrinter(format);

            foreach (var person in NameAge)
            {
                if (filter(person))
                {
                    printer(person);
                }                
            }
        }

        private static void PopulateDictionary(int peopleCount, Dictionary<string, int> NameAge)
        {
            for (int i = 0; i < peopleCount; i++)
            {
                string[] inputNameAndAge = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string name = inputNameAndAge[0];
                int age = int.Parse(inputNameAndAge[1]);

                if (NameAge.ContainsKey(name) == false)
                {
                    NameAge.Add(name, age);
                }
            }
        }

        static Func<KeyValuePair<string, int>, bool> createFilter(string condition, int conditionAge)
        {
            if (condition == "younger")
            {
                return x => x.Value < conditionAge;
            }

            else
            {
                return x => x.Value >= conditionAge;
            }
        }

        static Action<KeyValuePair<string, int>> creatPrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Key}");

                case "age":
                    return person => Console.WriteLine($"{person.Value}");

                case "name age":
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");

                default:
                    return null;
            }
        }
    }
}

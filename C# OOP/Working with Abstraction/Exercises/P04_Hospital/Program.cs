using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] inputElements = command.Split();
                var departament = inputElements[0];
                var firstName = inputElements[1];
                var middleName = inputElements[2];
                var patient = inputElements[3];
                var doctorFullName = firstName + middleName;

                if (!doctors.ContainsKey(doctorFullName))                
                    doctors[doctorFullName] = new List<string>();     
                
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();
                    for (int rooms = 0; rooms < 20; rooms++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool checkFreeSpace = departments[departament].SelectMany(x => x).Count() < 60;
                if (checkFreeSpace)
                {
                    doctors[doctorFullName].Add(patient);
                    AddPatientToDepartment(departments, departament, patient);

                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                PrintOutput(doctors, departments, args);
                command = Console.ReadLine();
            }
        }

        private static void PrintOutput(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int room))
            {
                Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
            }
        }

        private static void AddPatientToDepartment(Dictionary<string, List<List<string>>> departments, string departament, string patient)
        {
            for (int roomIndex = 0; roomIndex < departments[departament].Count; roomIndex++)
            {
                if (departments[departament][roomIndex].Count < 3)
                {
                    departments[departament][roomIndex].Add(patient);
                    break;
                }
            }
        }
    }
}

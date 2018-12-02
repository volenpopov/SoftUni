using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Private> privates = new List<Private>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] elements = input.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
            string type = elements[0];

            try
            {
                switch (type)
                {
                    case "Private":
                        if (elements.Length == 5)
                        {
                            if (ParseSalary(elements))
                            {
                                Private privateSoldier =
                                    new Private(elements[1], elements[2], elements[3], double.Parse(elements[4]));

                                privates.Add(privateSoldier);
                                Console.WriteLine(privateSoldier);
                            }
                        }
                        break;

                    case "LeutenantGeneral":
                        if (elements.Length >= 5)
                        {
                            if (ParseSalary(elements))
                            {
                                LeutenantGeneral leutenant =
                                    new LeutenantGeneral(elements[1], elements[2], elements[3], double.Parse(elements[4]));

                                leutenant.AppointPrivates(privates, elements, leutenant);
                                Console.WriteLine(leutenant);
                            }

                        }
                        break;

                    case "Engineer":
                        if (elements.Length >= 6)
                        {
                            if (ParseSalary(elements))
                            {
                                if (!Private.ValidateCorps(elements[5]))
                                    continue;

                                if (elements.Length >= 7)
                                {
                                    Engineer engineer =
                                    new Engineer(elements[1], elements[2], elements[3], double.Parse(elements[4]), elements[5]);
                                    engineer.GetRepairs(elements);

                                    Console.WriteLine(engineer);
                                }

                            }

                        }
                        break;

                    case "Commando":
                        if (elements.Length >= 6)
                        {
                            if (!Private.ValidateCorps(elements[5]))
                                continue;

                            if (ParseSalary(elements))
                            {
                                Commando commando =
                                    new Commando(elements[1], elements[2], elements[3], double.Parse(elements[4]), elements[5]);
                                commando.GetMissions(elements);
                                Console.WriteLine(commando);
                            }

                        }
                        break;

                    case "Spy":
                        if (elements.Length == 5)
                        {
                            Spy spy = new Spy(elements[1], elements[2], elements[3], int.Parse(elements[4]));
                            Console.WriteLine(spy);
                        }
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
             
    private static bool ParseSalary(string[] elements)
    {
        return double.TryParse(elements[4], out double salary);
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Inferno_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] gems = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            bool[] gemExclusion = new bool[gems.Length];

            string inputLine = Console.ReadLine();
            List<string[]> commands = new List<string[]>();
            string command = "";
            string filterType = "";
            int parameter = 0;

            while (inputLine != "Forge")
            {
                commands.Add(inputLine.Split(';'));
                inputLine = Console.ReadLine();
            }

            for (int i = 0; i < commands.Count; i++)
            {
                if (commands[i][0] == "Reverse")
                {
                    filterType = commands[i][1];
                    parameter = int.Parse(commands[i][2]);

                    foreach (var array in commands)
                    {
                        if (array[0] == "Exclude" && array[1] == filterType && int.Parse(array[2]) == parameter)
                        {
                            commands.Remove(commands[i]);
                            commands.Remove(array);

                            i -= 2;

                            if (i < 0)
                                i = 0;

                            break;
                        }
                    }
                }
            }

            foreach (var filter in commands)
            {
                command = filter[0];
                filterType = filter[1];
                parameter = int.Parse(filter[2]);
                long sum = 0;


                switch (filterType)
                {
                    case "Sum Left":
                        for (int i = 0; i < gems.Length; i++)
                        {
                            if (i == 0)
                                sum = gems[i];
                            else
                            {
                                sum = gems[i] + gems[i - 1];
                            }

                            if (sum == parameter)
                                gemExclusion[i] = true;

                            sum = 0;
                        }
                        break;

                    case "Sum Right":
                        for (int i = 0; i < gems.Length; i++)
                        {
                            if (i == gems.Length - 1)
                                sum = gems[i];
                            else
                            {
                                sum = gems[i] + gems[i + 1];
                            }

                            if (sum == parameter)
                                gemExclusion[i] = true;

                            sum = 0;
                        }
                        break;                      
                }

            }

            for (int i = 0; i < gems.Length; i++)
            {
                if (gemExclusion[i] == false)
                    Console.Write(gems[i] + " ");
            }

        }
    }
}
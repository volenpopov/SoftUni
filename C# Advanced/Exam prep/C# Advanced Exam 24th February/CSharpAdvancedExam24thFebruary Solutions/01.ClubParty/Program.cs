using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> halls = new List<string>();
            List<List<int>> hallsPeople = new List<List<int>>();

            int capacity = int.Parse(Console.ReadLine());

            Stack<string> input = new Stack<string>(Console.ReadLine().Split());

            int result = -1;
            while (true)
            {                
                if (int.TryParse(input.Peek(), out result) == true)
                {
                    input.Pop();
                }
                else
                {
                    break;
                }
            }

            string currentHall = input.Pop();
            halls.Add(currentHall);
            hallsPeople.Add(new List<int>());

            int currentPeople = -1;
            while (input.Count > 0)
            {
                var currentElement = input.Pop();

                if (int.TryParse(currentElement, out currentPeople) == false)
                {
                    halls.Add(currentElement);
                    hallsPeople.Add(new List<int>());                                        
                }
                else if (hallsPeople.Count > 1)
                {
                    if (hallsPeople[0].Sum()  + currentPeople > capacity)
                    {
                        Console.WriteLine($"{halls[0]} -> {string.Join(", ", hallsPeople[0])}");
                        halls.RemoveAt(0);
                        hallsPeople.RemoveAt(0);                        
                    }
                    hallsPeople[0].Add(currentPeople);
                    //else
                    //{
                    //    hallsPeople[hallsPeople.Count - 2].Add(currentPeople);
                    //}
                } 
                else
                {
                    if (hallsPeople.Count > 0)
                    {
                        if (hallsPeople[0].Sum() + currentPeople > capacity)
                        {
                            Console.WriteLine($"{halls[0]} -> {string.Join(", ", hallsPeople[0])}");
                            halls.RemoveAt(0);
                            hallsPeople.RemoveAt(0);
                            continue;
                        }

                        hallsPeople[hallsPeople.Count - 1].Add(currentPeople);
                    }
                   
                }
                    
            }
        }
    }
}

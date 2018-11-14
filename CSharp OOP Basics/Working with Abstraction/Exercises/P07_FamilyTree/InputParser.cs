using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InputParser
{
    public static void ParseInput(string input, FamilyTreeBuilder familyTreeBuilder)
    {
        while (true)
        {
            if (input == "End")
            {
                familyTreeBuilder.familyTree.RemoveRange(1, familyTreeBuilder.familyTree.Count - 1);
                break;
            }

            string[] tokens = input.Split(" - ");
            if (tokens.Length > 1)
            {
                string parent = tokens[0];
                string child = tokens[1];

                Person currentPerson = familyTreeBuilder.familyTree.FirstOrDefault(p => p.Name == parent || p.Birthday == parent);

                if (currentPerson == null)
                {
                    currentPerson = Person.CreatePerson(parent);
                    familyTreeBuilder.familyTree.Add(currentPerson);
                }

                familyTreeBuilder.SetChild(currentPerson, child);

            }
            else
            {
                tokens = tokens[0].Split();
                string name = $"{tokens[0]} {tokens[1]}";
                string birthday = tokens[2];

                Person person = familyTreeBuilder.SetIndividualsPersonalInfo(name, birthday);

                familyTreeBuilder.CheckDuplicatePerson(name, birthday, person);
            }

            input = Console.ReadLine();
        }

        
    }
}


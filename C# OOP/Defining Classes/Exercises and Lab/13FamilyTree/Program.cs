using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
     {
        List<Person> familyTree = new List<Person>();

        string input = Console.ReadLine();        

        Person mainPerson = new Person();

        if (IsBirthday(input))
            mainPerson.Birthday = input;
        else
            mainPerson.Name = input;

        familyTree.Add(mainPerson);

        string inputLine = Console.ReadLine();
        while (inputLine != "End")
        {
            if (ContainsDash(inputLine))
            {
                string[] elements = inputLine.Split(" - ");
                string firstPerson = elements[0];
                string secondPerson = elements[1];

                Person currentPerson;

                if (IsBirthday(firstPerson))
                {
                    currentPerson = familyTree.FirstOrDefault(p => p.Birthday == firstPerson);

                    if (currentPerson == null)
                    {
                        currentPerson = new Person();
                        currentPerson.Birthday = firstPerson;
                        familyTree.Add(currentPerson);
                    }
                    SetChild(familyTree, currentPerson, secondPerson);
                }

                else
                {
                    currentPerson = familyTree.FirstOrDefault(p => p.Name == firstPerson);

                    if (currentPerson == null)
                    {
                        currentPerson = new Person();
                        currentPerson.Name = firstPerson;
                        familyTree.Add(currentPerson);
                    }
                    SetChild(familyTree, currentPerson, secondPerson);
                }
            }

            else
            {
                string[] elements = inputLine.Split();
                string name = $"{elements[0]} {elements[1]}";
                string birthday = elements[2];

                Person currentPerson = familyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);
                if (currentPerson == null)
                    currentPerson = new Person();

                currentPerson.Name = name;
                currentPerson.Birthday = birthday;
                familyTree.Add(currentPerson);

                int afterCurrentPersonIndex = familyTree.IndexOf(currentPerson) + 1;
                int count = familyTree.Count - afterCurrentPersonIndex;

                Person[] copy = new Person[count];
                familyTree.CopyTo(afterCurrentPersonIndex, copy, 0, count);

                Person copyPerson = copy.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

                if (copyPerson != null)
                {
                    familyTree.Remove(copyPerson);
                    currentPerson.Parents.AddRange(copyPerson.Parents);
                    currentPerson.Parents = currentPerson.Parents.Distinct().ToList();

                    currentPerson.Children.AddRange(copyPerson.Children);
                    currentPerson.Children = currentPerson.Children.Distinct().ToList();
                }
                                                    
            }

            inputLine = Console.ReadLine();
        }

        Console.WriteLine(mainPerson);
        Console.WriteLine("Parents:");
        foreach (var parent in mainPerson.Parents)
        {
            Console.WriteLine(parent);
        }
        Console.WriteLine("Children:");
        foreach (var child in mainPerson.Children)
        {
            Console.WriteLine(child);
        } 
    }

    private static void SetChild(List<Person> familyTree, Person parentPerson, string child)
    {
        Person childPerson = new Person();

        if (IsBirthday(child))
        {
            if (!familyTree.Any(p => p.Birthday == child))
                childPerson.Birthday = child;
            else
                childPerson = familyTree.First(p => p.Birthday == child);
        }

        else
        {
            if (!familyTree.Any(p => p.Name == child))
                childPerson.Name = child;
            else
                childPerson = familyTree.First(p => p.Name == child);
        }

        parentPerson.Children.Add(childPerson);
        childPerson.Parents.Add(parentPerson);
        familyTree.Add(childPerson);
    }

    public static bool ContainsDash(string inputLine)
    {
        return inputLine.Contains("-");
    }

    public static bool IsBirthday(string input)
    {
        return char.IsDigit(input[0]);
    }
}


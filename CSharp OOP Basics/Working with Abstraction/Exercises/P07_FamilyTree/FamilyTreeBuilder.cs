using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FamilyTreeBuilder
{
    public List<Person> familyTree { get; private set; }
    private Person mainPerson { get; set; }

    public FamilyTreeBuilder()
    {
        familyTree = new List<Person>();
    }
    public FamilyTreeBuilder(string mainPersonInput) : this()
    {
        mainPerson = Person.CreatePerson(mainPersonInput);
        familyTree.Add(mainPerson);
    }

    public void PrintTree()
    {       
        Console.WriteLine(mainPerson);
        Console.WriteLine("Parents:");
        foreach (var p in mainPerson.Parents)
        {
            Console.WriteLine(p);
        }
        Console.WriteLine("Children:");
        foreach (var c in mainPerson.Children)
        {
            Console.WriteLine(c);
        }
    }

    public void CheckDuplicatePerson(string name, string birthday, Person person)
    {
        Person copyPerson = familyTree
                                .Where(p => p.Name == name || p.Birthday == birthday)
                                .Skip(1) //we skip 1 because the first object will be the one that we just created and added to the list and we are interested in all the rest after him
                                .FirstOrDefault();

        if (copyPerson != null)
        {
            familyTree.Remove(copyPerson);
            person.Parents.AddRange(copyPerson.Parents);
            person.Parents = person.Parents.Distinct().ToList();
            foreach (var parent in copyPerson.Parents)
            {
                ReplaceDuplicate(person, copyPerson, parent);
            }

            person.Children.AddRange(copyPerson.Children);
            person.Children = person.Children.Distinct().ToList();
            foreach (var child in copyPerson.Children)
            {
                ReplaceDuplicate(person, copyPerson, child);
            }
        }
    }

    public Person SetIndividualsPersonalInfo(string name, string birthday)
    {
        Person person = familyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

        if (person == null)
        {
            person = new Person();
            familyTree.Add(person);
        }
        person.Name = name;
        person.Birthday = birthday;

        return person;
    }

    private void ReplaceDuplicate(Person person, Person copyPerson, Person parentOrChild)
    {
        int indexOfCopyPerson = parentOrChild.Children.IndexOf(copyPerson);
        if (indexOfCopyPerson > -1)
            parentOrChild.Children[indexOfCopyPerson] = person;
        else
            parentOrChild.Children.Add(person);
    }   

    public void SetChild(Person parentPerson, string childInput)
    {
        Person childPerson = new Person();

        childPerson = FindExistingOrInitializeChild(childPerson, childInput);

        parentPerson.Children.Add(childPerson);
        childPerson.Parents.Add(parentPerson);
        familyTree.Add(childPerson);
    }

    private Person FindExistingOrInitializeChild(Person childPerson, string childInput)
    {
        if (Person.IsBirthday(childInput))
        {
            if (!familyTree.Any(p => p.Birthday == childInput))
            {
                childPerson.Birthday = childInput;
            }
            else
            {
                childPerson = familyTree.First(p => p.Birthday == childInput);
            }
        }
        else
        {
            if (!familyTree.Any(p => p.Name == childInput))
            {
                childPerson.Name = childInput;
            }
            else
            {
                childPerson = familyTree.First(p => p.Name == childInput);
            }
        }

        return childPerson;
    }
}


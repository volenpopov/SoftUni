using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var addCollection = new AddCollection<string>();
        var addRemoveCollection = new AddRemoveCollection<string>();
        var myList = new MyList<string>();

        string[] input = Console.ReadLine().Split();
        int removeOperations = int.Parse(Console.ReadLine());

        StringBuilder sb = new StringBuilder();

        foreach (var word in input)
        {
            sb.Append(addCollection.Add(word) + " ");          
        }
        sb.ToString().TrimEnd();
        sb.AppendLine();

        foreach (var word in input)
        {
            sb.Append(addRemoveCollection.Add(word) + " ");
        }
        sb.ToString().TrimEnd();
        sb.AppendLine();

        foreach (var word in input)
        {
            sb.Append(myList.Add(word) + " ");
        }
        sb.ToString().TrimEnd();
        
        sb.AppendLine();
        for (int i = 1; i <= removeOperations; i++)
        {
            sb.Append(addRemoveCollection.Remove() + " ");
        }
        sb.ToString().TrimEnd();

        sb.AppendLine();
        for (int i = 1; i <= removeOperations; i++)
        {
            sb.Append(myList.Remove() + " ");
        }
        sb.ToString().TrimEnd();

        Console.WriteLine(sb);
    }
}


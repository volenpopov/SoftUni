using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string mainPersonInput = Console.ReadLine();
            FamilyTreeBuilder familyTreeBuilder = new FamilyTreeBuilder(mainPersonInput);

            string input = Console.ReadLine();
            InputParser.ParseInput(input, familyTreeBuilder);
            
            familyTreeBuilder.PrintTree();
        }

        
    }
}

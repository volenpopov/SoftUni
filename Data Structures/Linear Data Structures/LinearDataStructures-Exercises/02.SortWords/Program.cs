using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SortWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                string.Join(" ",
                 Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .OrderBy(w => w)));
               
        }
    }
}

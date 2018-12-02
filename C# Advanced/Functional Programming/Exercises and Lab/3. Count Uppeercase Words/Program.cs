using System;
using System.Linq;

namespace _3._Count_Uppeercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> isUpperCase = word => char.IsUpper(word[0]);

            var query = text.Where(word => isUpperCase(word));

            Console.Write(string.Join(Environment.NewLine, query));
        }
    }
}

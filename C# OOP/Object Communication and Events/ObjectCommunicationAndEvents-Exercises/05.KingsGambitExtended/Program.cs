using _02.KingsGambit.Interfaces;
using System;
using System.Collections.Generic;

namespace _02.KingsGambit
{
    public class Program
    {
        static void Main()
        {
            IKing king = SetUpKing();

            Engine engine = new Engine(king);
            engine.Run();
        }

        private static IKing SetUpKing()
        {
            string kingName = Console.ReadLine();
            IKing king = new King(kingName, new List<ISubordinate>());

            string[] royalGuards = Console.ReadLine().Split();
            foreach (string guard in royalGuards)
            {
                king.AddSubordinate(new RoyalGuard(king, guard));
            }

            string[] footmen = Console.ReadLine().Split();
            foreach (string footman in footmen)
            {
                king.AddSubordinate(new Footman(king, footman));
            }

            return king;
        }
    }
}

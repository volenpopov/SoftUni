using _02.KingsGambit.Interfaces;
using System;
using System.Linq;

namespace _02.KingsGambit
{
    public class Engine
    {
        private IKing king;

        public Engine(IKing king)
        {
            this.king = king;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] args = input.Split();
                string command = args[0];

                if (command == "Attack")
                    this.king.GetAttacked();
                else
                {
                    string subordinateName = args[1];
                    ISubordinate subordinate = this.king.Subordinates
                        .First(s => s.Name == subordinateName);

                    subordinate.Die();
                }

            }
        }


    }
}

using _02.KingsGambit.Models;
using System;

namespace _02.KingsGambit
{
    public class RoyalGuard : Subordinate
    {
        public RoyalGuard(string name) : base(name, "defending")
        { }

        public override void GetAttacked()
        {
            if (this.IsAlive == true)
                Console.WriteLine($"Royal Guard {this.Name} is {this.Action}!");
        }

    }
}

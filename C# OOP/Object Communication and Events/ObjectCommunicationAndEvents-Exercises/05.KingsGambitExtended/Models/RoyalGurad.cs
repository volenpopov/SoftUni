using _02.KingsGambit.Interfaces;
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
            Console.WriteLine($"Royal Guard {this.Name} is {this.Action}!");
        }

        public override void ReceiveStrike()
        {
            base.ReceiveStrike();

            if (base.StrikesReceived >= 3)
                base.Die();
        }
    }
}

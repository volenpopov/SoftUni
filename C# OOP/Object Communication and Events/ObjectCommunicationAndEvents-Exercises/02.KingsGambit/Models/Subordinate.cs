using _02.KingsGambit.Interfaces;
using System;

namespace _02.KingsGambit.Models
{
    public abstract class Subordinate : ISubordinate
    {
        public Subordinate(string name, string action)
        {
            this.Name = name;
            this.Action = action;
            this.IsAlive = true;            
        }

        public string Action { get; }

        public string Name { get; }

        public bool IsAlive { get; private set; }

        public event GetAttackedEventHandler GetAttackedEvent;

        public void Die()
        {
            this.IsAlive = false;
        }

        public virtual void GetAttacked()
        {
            if (this.IsAlive == true)
                Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");
        }
    }
}

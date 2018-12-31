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
            this.StrikesReceived = 0;
        }

        public string Action { get; }

        public string Name { get; }

        protected int StrikesReceived { get; private set; }

        public event GetKilledEventHandler GetKilledEvent;

        protected void Die()
        {
            if (this.GetKilledEvent != null)
                this.GetKilledEvent.Invoke(this);
        }

        public virtual void GetAttacked()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");
        }

        public virtual void ReceiveStrike()
        {
            this.StrikesReceived++;
        }
    }
}

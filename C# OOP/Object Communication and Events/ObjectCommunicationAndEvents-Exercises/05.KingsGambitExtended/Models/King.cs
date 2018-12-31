using _02.KingsGambit.Interfaces;
using System;
using System.Collections.Generic;

namespace _02.KingsGambit
{
    public class King : IKing
    {    
        private ICollection<ISubordinate> subordinates;

        public IReadOnlyCollection<ISubordinate> Subordinates =>
            (IReadOnlyCollection<ISubordinate>) this.subordinates;

        public King(string name, ICollection<ISubordinate> subordinates)
        {
            this.Name = name;
            this.subordinates = subordinates;
        }

        public string Name { get; }

        public event GetAttackedEventHandler GetAttackedEvent;

        public void AddSubordinate(ISubordinate subordinate)
        {
            this.subordinates.Add(subordinate);
            this.GetAttackedEvent += subordinate.GetAttacked;
            subordinate.GetKilledEvent += this.UnitKilled;
        }

        public void GetAttacked()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is under attack!");

            if (this.GetAttackedEvent != null)
                this.GetAttackedEvent.Invoke();
        }

        public void UnitKilled(ISubordinate subordinate)
        {
            this.subordinates.Remove(subordinate);
            this.GetAttackedEvent -= subordinate.GetAttacked;
        }
    }
}

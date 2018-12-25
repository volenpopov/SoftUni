using ObjectCommunicationAndEvents.Interfaces;
using System;

namespace ObjectCommunicationAndEvents.Models.Units
{
    public class Observer : IObserver
    {
        private const string GAINED_EXP_MESSAGE = "{0} gained {1} experience!";

        private IAttacker attacker;

        public Observer(IAttacker attacker)
        {
            this.attacker = attacker;
        }

        public void Update(int experience)
        {
            Console.WriteLine(string.Format(GAINED_EXP_MESSAGE, this.attacker, experience));
            this.attacker.Experience += experience;            
        }
    }
}

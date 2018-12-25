using ObjectCommunicationAndEvents.Interfaces;
using System.Collections.Generic;

namespace ObjectCommunicationAndEvents.Models.Groups
{
    public class Group : IAttackGroup
    {
        private List<IAttacker> attackers;

        public Group()
        {
            this.attackers = new List<IAttacker>();
        }

        public void AddMember(IAttacker attacker)
        {
            this.attackers.Add(attacker);
        }

        public void GroupAttack()
        {
            foreach (var attacker in this.attackers)
            {
                attacker.Attack();
            }
        }

        public void GroupTarget(IObservableTarget target)
        {
            foreach (var attacker in this.attackers)
            {
                attacker.SetTarget(target);
            }
        }

        public void GroupTargetAndAttack(IObservableTarget target)
        {
            foreach (var attacker in this.attackers)
            {
                attacker.SetTarget(target);
                attacker.Attack();
            }
        }
    }
}

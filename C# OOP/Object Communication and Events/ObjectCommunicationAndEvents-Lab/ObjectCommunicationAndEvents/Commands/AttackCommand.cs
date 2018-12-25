using ObjectCommunicationAndEvents;

namespace Object_Communication_and_Events_Lab
{
    public class AttackCommand : ICommand
    {
        private IAttacker attacker;

        public AttackCommand(IAttacker attacker)
        {
            this.attacker = attacker;
        }

        public void Execute()
        {
            this.attacker.Attack();
        }
    }
}
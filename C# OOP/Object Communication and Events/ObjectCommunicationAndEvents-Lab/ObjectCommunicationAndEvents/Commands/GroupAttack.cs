using ObjectCommunicationAndEvents.Interfaces;

namespace ObjectCommunicationAndEvents.Commands
{
    public class GroupAttack : ICommand
    {
        private IAttackGroup group;

        public GroupAttack(IAttackGroup group)
        {
            this.group = group;
        }

        public void Execute()
        {
            this.group.GroupAttack();
        }
    }
}

using ObjectCommunicationAndEvents.Interfaces;

namespace ObjectCommunicationAndEvents.Commands
{
    public class GroupTargetCommand : ICommand
    {
        private IAttackGroup group;
        private IObservableTarget target;

        public GroupTargetCommand(IAttackGroup group, IObservableTarget target)
        {
            this.group = group;
            this.target = target;
        }

        public void Execute()
        {
            this.group.GroupTarget(this.target);
        }
    }
}

using ObjectCommunicationAndEvents.Interfaces;

namespace ObjectCommunicationAndEvents
{
    public class TargetCommand : ICommand
    {
        private IAttacker attacker;
        private IObservableTarget target;

        public TargetCommand(IAttacker attacker, IObservableTarget target)
        {
            this.attacker = attacker;
            this.target = target;
        }

        public void Execute()
        {
            this.attacker.SetTarget(this.target);
        }
    }
}

using ObjectCommunicationAndEvents.Interfaces;

public interface IAttacker
{
    void Attack();

    void SetTarget(IObservableTarget target);

    int Experience { get; set; }
}

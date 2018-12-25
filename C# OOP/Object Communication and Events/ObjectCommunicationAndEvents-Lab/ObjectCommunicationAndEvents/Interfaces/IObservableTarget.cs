
namespace ObjectCommunicationAndEvents.Interfaces
{
    public interface IObservableTarget
    {
        void ReceiveDamage(int damage);

        bool IsDead { get; }

        void Register(IObserver observer);

        void Unregister(IObserver observer);

        void NotifyObservers();
    }
}

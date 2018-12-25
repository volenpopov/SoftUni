using ObjectCommunicationAndEvents;
using ObjectCommunicationAndEvents.Interfaces;
using System;
public class Warrior : AbstractHero
{
    private const string ATTACK_MESSAGE = "{0} damages {1} for {2}";

    public Warrior(string id, int damage, IHandler logger) : base(id, damage, logger)
    {
    }

    protected override void ExecuteClassSpecificAttack(IObservableTarget target, int damage)
    {
        Console.WriteLine(ATTACK_MESSAGE, this, target, damage);
        target.ReceiveDamage(damage);
    }
}

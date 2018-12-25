using ObjectCommunicationAndEvents;
using ObjectCommunicationAndEvents.Interfaces;
using System;
using System.Collections.Generic;

public class Dragon : IObservableTarget
{
    private const string THIS_DIED_EVENT = "{0} dies";

    private string id;
    private int hp;
    private int experience;
    private bool eventTriggered;
    private IHandler logger;
    private List<IObserver> observers;

    public Dragon(string id, int hp, int reward, IHandler logger)
    {
        this.id = id;
        this.hp = hp;
        this.experience = reward;
        this.logger = logger;
        this.observers = new List<IObserver>();
    }

    public bool IsDead { get => this.hp <= 0; }

    public void ReceiveDamage(int damage)
    {
        if (!this.IsDead)
        {
            this.hp -= damage;
        }

        if(this.IsDead && !eventTriggered)
        {
            Console.WriteLine(THIS_DIED_EVENT, this);
            this.eventTriggered = true;
            this.NotifyObservers();
        }
    }

    public void Register(IObserver observer)
    {
        this.observers.Add(observer);
    }

    public void Unregister(IObserver observer)
    {
        if (this.observers.Contains(observer))
            this.observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in this.observers)
        {
            observer.Update(this.experience);
        }
    }
}

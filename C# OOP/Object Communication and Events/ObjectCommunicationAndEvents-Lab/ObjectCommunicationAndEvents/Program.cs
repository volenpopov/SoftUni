using ObjectCommunicationAndEvents;
using ObjectCommunicationAndEvents.Commands;
using ObjectCommunicationAndEvents.Interfaces;
using ObjectCommunicationAndEvents.Models.Groups;
using ObjectCommunicationAndEvents.Models.Units;
using System;

namespace Object_Communication_and_Events_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger combatLog = new CombatLogger();
            Logger eventLog = new EventLogger();

            combatLog.SetSuccessor(eventLog);

            IAttacker hero1 = new Warrior("Pesho", 5, combatLog);
            IAttacker hero2 = new Warrior("Gosho", 6, combatLog);
            IObserver observer1 = new Observer(hero1);
            IObserver observer2 = new Observer(hero2);

            IAttackGroup group = new Group();
            group.AddMember(hero1);
            group.AddMember(hero2);

            IObservableTarget dragon = new Dragon("Charizard", 10, 15, combatLog);
            dragon.Register(observer1);
            dragon.Register(observer2);


            IExecutor executor = new CommandExecutor();
            ICommand groupTarget = new GroupTargetCommand(group, dragon);
            ICommand groupAttack = new GroupAttack(group);

            executor.ExecuteCommand(groupTarget);
            executor.ExecuteCommand(groupAttack);            
            }  
    }
}

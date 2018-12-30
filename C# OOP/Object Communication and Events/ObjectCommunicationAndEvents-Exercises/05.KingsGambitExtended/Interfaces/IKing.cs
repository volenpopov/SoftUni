using System.Collections.Generic;

namespace _02.KingsGambit.Interfaces
{
    public delegate void GetAttackedEventHandler();

    public interface IKing : IAttackable, INameable
    {
        event GetAttackedEventHandler GetAttackedEvent;

        IReadOnlyCollection<ISubordinate> Subordinates { get; }

        void AddSubordinate(ISubordinate subordinate);

        void UnitKilled(ISubordinate subordinate);
    }
}

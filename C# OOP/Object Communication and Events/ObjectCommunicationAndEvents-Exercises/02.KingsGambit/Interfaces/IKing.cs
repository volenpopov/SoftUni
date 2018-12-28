using System;
using System.Collections.Generic;

namespace _02.KingsGambit.Interfaces
{
    public interface IKing : IAttackable, INameable
    {
        IReadOnlyCollection<ISubordinate> Subordinates { get; }

        void AddSubordinate(ISubordinate subordinate);
    }
}

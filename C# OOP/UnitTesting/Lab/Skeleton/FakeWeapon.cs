using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints => 2;

        public int DurabilityPoints => 5;

        public void Attack(ITarget target)
        {
            target.TakeAttack(this.AttackPoints);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    public class FakeTarget : ITarget
    {
        public FakeTarget()
        {
            this.Health = 1;
        }

        public int Health
        {
            get;
            private set;
        }

        public int Experience => 1;

        public int GiveExperience()
        {
            return this.Experience;
        }

        public bool IsDead()
        {
            return this.Health <= 0;
        }

        public void TakeAttack(int attackPoints)
        {
            this.Health -= attackPoints;
        }            
        
    }
}

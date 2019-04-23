using MortalEngines.Entities.Contracts;
using System;

namespace MortalEngines.Entities.Machines
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double INITIAL_HEALTH_POINTS = 200;
        private const double MODE_ATTACK_POINTS_ADJUSTMENT = 50;
        private const double MODE_DEFENSE_POINTS_ADJUSTMENT = 25;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, INITIAL_HEALTH_POINTS)
        {             
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.AggressiveMode = false;

                this.AttackPoints -= MODE_ATTACK_POINTS_ADJUSTMENT;

                this.DefensePoints += MODE_DEFENSE_POINTS_ADJUSTMENT;
            }
            else
            {
                this.AggressiveMode = true;

                this.AttackPoints += MODE_ATTACK_POINTS_ADJUSTMENT;

                this.DefensePoints -= MODE_DEFENSE_POINTS_ADJUSTMENT;
            }
        }

        public override string ToString()
        {
            var mode = this.AggressiveMode
                ? "ON"
                : "OFF";
            
            var result = base.ToString()
                + Environment.NewLine
                + $" *Aggressive: {mode}";

            return result;
        }
    }
}

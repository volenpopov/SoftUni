using MortalEngines.Entities.Contracts;
using System;

namespace MortalEngines.Entities.Machines
{
    public class Tank : BaseMachine, ITank
    {
        private const double INITIAL_HEALTH_POINTS = 100;
        private const double MODE_ATTACK_POINTS_ADJUSTMENT = 40;
        private const double MODE_DEFENSE_POINTS_ADJUSTMENT = 30;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints,defensePoints, INITIAL_HEALTH_POINTS)
        {            
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        
        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;

                this.AttackPoints += MODE_ATTACK_POINTS_ADJUSTMENT;
                this.DefensePoints -= MODE_DEFENSE_POINTS_ADJUSTMENT;                

            }
            else
            {
                this.DefenseMode = true;

                this.AttackPoints -= MODE_ATTACK_POINTS_ADJUSTMENT;
                this.DefensePoints += MODE_DEFENSE_POINTS_ADJUSTMENT;                
            }
        }

        public override string ToString()
        {
            var mode = this.DefenseMode
               ? "ON"
               : "OFF";

            var result = base.ToString()
                + Environment.NewLine
                + $" *Defense: {mode}";

            return result;
        }
    }
}

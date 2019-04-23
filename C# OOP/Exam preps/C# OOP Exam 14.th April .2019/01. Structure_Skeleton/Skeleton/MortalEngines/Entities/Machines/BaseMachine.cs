using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.pilot = null;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (String.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; }

        public virtual void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            var damage = this.AttackPoints - target.DefensePoints;

            if (damage > 0)
            {
                target.HealthPoints -= damage;

                if (target.HealthPoints < 0)
                {
                    target.HealthPoints = 0;
                }
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:f2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:f2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:f2}");

            if (this.Targets.Count > 0)
            {
                var allTargets = string.Join(",", this.Targets);
                sb.AppendLine($" *Targets: {allTargets}");
            }
            else
            {
                sb.AppendLine($" *Targets: None");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}

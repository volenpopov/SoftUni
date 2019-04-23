namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            var result = string.Empty;

            if (!this.pilots.Any(p => p.Name == name))
            {
                this.pilots.Add(new Pilot(name));
                result = string.Format(OutputMessages.PilotHired, name);
            }
            else
            {
                result = string.Format(OutputMessages.PilotExists, name);
            }

            return result;
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            var tank = new Tank(name, attackPoints, defensePoints);

            this.machines
                .Add(tank);
            
            return string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(f => f.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }            
                var fighter = new Fighter(name, attackPoints, defensePoints);

                this.machines
                    .Add(fighter);

                return string.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, "ON");                       
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var result = string.Empty;

            var pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            var machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (pilot == null)
            {
                result = string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }
            else if (machine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }
            else if (pilot != null && machine != null)
            {
                if (machine.Pilot != null)
                {
                    result = string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
                }
                else
                {
                    pilot.AddMachine(machine);                    
                    result = string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
                }
            }
            
            return result;
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var result = string.Empty;

            var attackingMachine = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);
            var defendingMachine = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if ((attackingMachine == null && defendingMachine == null)
                || attackingMachine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            else if (defendingMachine == null)
            {
                result = string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attackingMachine.HealthPoints > 0 && defendingMachine.HealthPoints > 0)
            {
                attackingMachine.Attack(defendingMachine);
                result = string.Format(OutputMessages.AttackSuccessful, 
                    defendingMachineName, 
                    attackingMachineName, 
                    defendingMachine.HealthPoints);
            }
            else if (attackingMachine.HealthPoints <= 0)
            {
                result = string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }
            else if (defendingMachine.HealthPoints <= 0)
            {
                result = string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }
            
            return result;
        }

        public string PilotReport(string pilotReporting)
        {
            return this.pilots
                .FirstOrDefault(p => p.Name == pilotReporting)
                .Report();
        }

        public string MachineReport(string machineName)
        {
            return this.machines
                 .FirstOrDefault(m => m.Name == machineName)
                 .ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var fighter = (IFighter) this.machines
                .FirstOrDefault(f => f.Name == fighterName);

            if (fighter == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }
            else
            {
                fighter.ToggleAggressiveMode();
                return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var tank = (ITank) this.machines
                .FirstOrDefault(t => t.Name == tankName);

            if (tank == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }
            else
            {
                tank.ToggleDefenseMode();
                return string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }
        }
    }
}
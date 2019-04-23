using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public Pilot(string name)
        {
            this.machines = new List<IMachine>();
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            this.machines.Add(machine);
                        
            machine.Pilot = this;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} - {this.machines.Count} machines");

            foreach (var machine in this.machines)
            {                
                sb.AppendLine(machine.ToString().Substring(0, machine.ToString().LastIndexOf(Environment.NewLine)));
            }

            return sb.ToString().TrimEnd();
        }
    }
}

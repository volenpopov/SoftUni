using MortalEngines.Core.Contracts;

namespace MortalEngines.Core
{
    public class CommandInterpreter
    {
        private IMachinesManager machineManager;

        public CommandInterpreter()
        {
            this.machineManager = new MachinesManager();
        }

        public string ParseCommand(string command, string[] commandArgs)
        {
            var result = string.Empty;

            switch (command)
            {
                case "HirePilot":
                    string pilotName = commandArgs[0];
                    result = this.machineManager.HirePilot(pilotName);
                    break;

                case "PilotReport":
                    pilotName = commandArgs[0];
                    result = this.machineManager.PilotReport(pilotName);
                    break;

                case "ManufactureTank":
                    string tankName = commandArgs[0];
                    double attack = double.Parse(commandArgs[1]);
                    double defense = double.Parse(commandArgs[2]);

                    result = this.machineManager.ManufactureTank(tankName, attack, defense);
                    break;

                case "ManufactureFighter":
                    string fighterName = commandArgs[0];
                     attack = double.Parse(commandArgs[1]);
                     defense = double.Parse(commandArgs[2]);

                    result = this.machineManager.ManufactureFighter(fighterName, attack, defense);
                    break;

                case "MachineReport":
                    string machineName = commandArgs[0];
                    result = this.machineManager.MachineReport(machineName);
                    break;

                case "AggressiveMode":
                    fighterName = commandArgs[0];
                    result = this.machineManager.ToggleFighterAggressiveMode(fighterName);
                    break;

                case "DefenseMode":
                    tankName = commandArgs[0];
                    result = this.machineManager.ToggleTankDefenseMode(tankName);
                    break;

                case "Engage":
                    pilotName = commandArgs[0];
                    machineName = commandArgs[1];
                    result = this.machineManager.EngageMachine(pilotName, machineName);
                    break;

                case "Attack":
                    string attackerName = commandArgs[0];
                    string defenderName = commandArgs[1];
                    result = this.machineManager.AttackMachines(attackerName, defenderName);
                    break;
            }
                return result;
        }
    }
}

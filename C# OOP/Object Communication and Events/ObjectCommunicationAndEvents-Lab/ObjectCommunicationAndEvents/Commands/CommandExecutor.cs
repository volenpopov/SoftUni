using ObjectCommunicationAndEvents;

namespace Object_Communication_and_Events_Lab
{
    public class CommandExecutor : IExecutor
    {
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }
    }
}
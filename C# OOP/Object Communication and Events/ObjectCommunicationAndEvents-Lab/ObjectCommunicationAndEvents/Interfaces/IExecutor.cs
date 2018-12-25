namespace ObjectCommunicationAndEvents
{
    public interface IExecutor
    {
        void ExecuteCommand(ICommand command);
    }
}

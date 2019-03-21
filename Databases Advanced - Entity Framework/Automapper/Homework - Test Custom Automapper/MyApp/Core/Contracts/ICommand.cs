namespace MyApp.Core.Contracts
{
    public interface ICommand
    {
        string Execute(string[] commandParams);
    }
}

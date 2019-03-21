namespace MyApp.Core.Contracts
{
    public interface IEntityValidator
    {
        bool IsValid(object entity);
    }
}

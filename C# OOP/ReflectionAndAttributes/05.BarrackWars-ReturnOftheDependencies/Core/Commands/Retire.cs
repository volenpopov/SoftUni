
using _03BarracksFactory.Contracts;
using System;

public class Retire : Command
{
    [Inject]
    private IRepository repository;

    public Retire(string[] data, IRepository repository)
        : base(data)
    {
        this.repository = repository;
    }

    public override string Execute()
    {
        string unitType = base.Data[1];

        try
        {
            this.repository.RemoveUnit(unitType);
            return $"{unitType} retired!";
        }

        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}

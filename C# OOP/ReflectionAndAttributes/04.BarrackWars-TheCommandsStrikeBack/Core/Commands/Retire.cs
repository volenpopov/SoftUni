
using _03BarracksFactory.Contracts;
using System;
using System.Linq;

public class Retire : Command
{
    public Retire(string[] data, IRepository repository, IUnitFactory unitFactory)
        : base(data, repository, unitFactory)
    { }

    public override string Execute()
    {
        string unitType = base.Data[1];

        try
        {
            base.Repository.RemoveUnit(unitType);
            return $"{unitType} retired!";
        }

        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}

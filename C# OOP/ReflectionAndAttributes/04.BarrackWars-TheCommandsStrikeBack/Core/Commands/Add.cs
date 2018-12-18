using _03BarracksFactory.Contracts;

public class Add : Command
{
    public Add(string[] data, IRepository repository, IUnitFactory unitFactory) 
        : base(data, repository, unitFactory)
    { }

    public override string Execute()
    {
        string unitType = base.Data[1];
        IUnit unitToAdd = base.UnitFacory.CreateUnit(unitType);
        base.Repository.AddUnit(unitToAdd);
        string output = unitType + " added!";
        return output;
    }
}


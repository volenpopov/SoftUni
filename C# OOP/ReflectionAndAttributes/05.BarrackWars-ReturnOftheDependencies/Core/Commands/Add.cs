using _03BarracksFactory.Contracts;

public class Add : Command
{
    [Inject]
    private IRepository repository;

    [Inject]
    private IUnitFactory unitFactory;

    public Add(string[] data, IRepository repository, IUnitFactory unitFactory) 
        : base(data)
    {
        this.repository = repository;
        this.unitFactory = unitFactory;
    }

    public override string Execute()
    {
        string unitType = base.Data[1];
        IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        this.repository.AddUnit(unitToAdd);
        string output = unitType + " added!";
        return output;
    }
}


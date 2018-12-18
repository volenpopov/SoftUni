using _03BarracksFactory.Contracts;

public abstract class Command : IExecutable
{
    private string[] data;
    private IRepository repository;
    private IUnitFactory unitFactory;

    protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
    {
        this.Data = data;
        this.Repository = repository;
        this.UnitFacory = unitFactory;
    }

    protected string[] Data
    {
        get { return this.data; }
        set { this.data = value; }
    }

    protected IRepository Repository
    {
        get { return this.repository; }
        set { this.repository = value; }
    }

    protected IUnitFactory UnitFacory
    {
        get { return this.unitFactory; }
        set { this.unitFactory = value; }
    }

    public abstract string Execute();
}

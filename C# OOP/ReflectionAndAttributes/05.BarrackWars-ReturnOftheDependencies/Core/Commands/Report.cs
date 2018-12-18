
using _03BarracksFactory.Contracts;

public class Report : Command
{
    [Inject]
    private IRepository repository;

    public Report(string[] data, IRepository repository)
        : base(data)
    {
        this.repository = repository;
    }
    
    public override string Execute()
    {
        return this.repository.Statistics;
    }
}



using _03BarracksFactory.Contracts;

public class Report : Command
{
    public Report(string[] data, IRepository repository, IUnitFactory unitFactory)
        : base(data, repository, unitFactory)
    { }
    
    public override string Execute()
    {
        return base.Repository.Statistics;
    }
}


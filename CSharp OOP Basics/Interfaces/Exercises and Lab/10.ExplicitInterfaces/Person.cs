
public class Citizen : IResident, IPerson
{
    public Citizen(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public string Country { get; set; }

    string IResident.GetName()
    {
        return $"Mr/Ms/Mrs {this.Name}";        
    }

    string IPerson.GetName()
    {
        return this.Name;
    }
}


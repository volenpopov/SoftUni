
   public abstract class Soldier
{
    public override string ToString()
    {
        return $"Name: {FirstName} {LastName} Id: {Id}";
    }

    public Soldier(string id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;        
    }

    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}


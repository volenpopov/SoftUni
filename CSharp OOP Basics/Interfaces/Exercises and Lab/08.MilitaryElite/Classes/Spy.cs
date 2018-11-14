
public class Spy : Soldier, ISoldier, ISpy
{
    public override string ToString()
    {
        return $"{base.ToString()}\n" +
            $"Code Number: {CodeNumber}".TrimEnd();
    }

    public Spy(string id, string firstName, string lastName, int codeNumber) 
        : base(id, firstName, lastName)
    {
        CodeNumber = codeNumber;
    }

    public int CodeNumber { get; set; }
}


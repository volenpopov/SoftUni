public class Private : Soldier, ISoldier, IPrivate
{
    public override string ToString()
    {
        return $"{base.ToString()} Salary: {Salary:f2}";
    }

    public Private(string id, string firstName, string lastName, double salary) 
        : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public double Salary { get; set; }

    public static bool ValidateCorps(string corps)
    {
        return corps == "Airforces" || corps == "Marines";
    }
}
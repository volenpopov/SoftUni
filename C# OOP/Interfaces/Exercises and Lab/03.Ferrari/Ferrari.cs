
public class Ferrari : ICar
{
    public Ferrari(string driver)
    {
        Driver = driver;
    }

    public override string ToString()
    {
        return $"{Model}/{Brakes()}/{GasPedal()}/{Driver}";
    }

    public string Model { get { return "488-Spider"; } }
    
    public string Driver { get; set; }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string GasPedal()
    {
        return "Zadu6avam sA!";
    }
}


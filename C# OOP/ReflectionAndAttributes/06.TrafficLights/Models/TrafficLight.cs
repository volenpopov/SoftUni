
public class TrafficLight
{
    public TrafficLight(Signal signal)
    {
        this.Signal = signal;
    }

    public Signal Signal { get; private set; }

    public void SwitchLight()
    {
        int enumNumber = (int)this.Signal;

        if (enumNumber + 1 > 2)
            enumNumber = 0;
        else
            enumNumber += 1;

        this.Signal = (Signal)enumNumber;
    }

    public override string ToString()
    {
        return $"{this.Signal}";
    }
}


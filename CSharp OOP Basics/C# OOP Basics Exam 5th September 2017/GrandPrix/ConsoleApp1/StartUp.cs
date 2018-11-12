using System;

public class StartUp
{
    static void Main(string[] args)
    {
        int lapsNumber = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());

        RaceTower raceTower = new RaceTower();
        raceTower.SetTrackInfo(lapsNumber, trackLength);

        Engine engine = new Engine(raceTower);
        engine.Run();
    }
}


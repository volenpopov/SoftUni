
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private Track track;
    private DriverFactory driverFactory;
    private TyreFactory tyreFactory;
    private IList<Driver> racingDrivers;
    private Stack<Driver> failedDrivers;

    public RaceTower()
    {
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();
        this.racingDrivers = new List<Driver>();
        this.failedDrivers = new Stack<Driver>();        
    }

    public bool isRaceOver => this.track.CurrentLap == this.track.LapsNumber;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track = new Track(lapsNumber, trackLength);
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            string driverType = commandArgs[0];
            string driverName = commandArgs[1];
            int hp = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);

            string[] tyreArgs = commandArgs.Skip(4).ToArray();

            Tyre tyre = this.tyreFactory.CreateTyre(tyreArgs);

            Car car = new Car(hp, fuelAmount, tyre);

            Driver driver = this.driverFactory.CreateDriver(driverType, driverName, car);
            this.racingDrivers.Add(driver);
        }
        catch { }
    }
    
    public void DriverBoxes(List<string> commandArgs)
    {
        string reasonToBox = commandArgs[0];
        string driverName = commandArgs[1];

        string[] methodArgs = commandArgs.Skip(2).ToArray();

        Driver driver = this.racingDrivers.FirstOrDefault(d => d.Name == driverName);
        if (driver != null)
        {
            switch (reasonToBox)
            {
                case "ChangeTyres":
                    Tyre newTyre = this.tyreFactory.CreateTyre(methodArgs);
                    driver.ChangeTyres(newTyre);
                    break;

                case "Refuel":
                    driver.Refuel(methodArgs);
                    break;
            }
        }

        else
            throw new ArgumentException(ErrorMessages.InvalidDriverName);
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder sb = new StringBuilder();

        int numberOfLaps = int.Parse(commandArgs[0]);

        int lapsLeft = this.track.LapsNumber - this.track.CurrentLap;

        if (numberOfLaps > lapsLeft)
        {
            throw new ArgumentException(
                string.Format(ErrorMessages.InvalidNumberOfLaps, this.track.CurrentLap));
        }

        for (int lap = 1; lap <= numberOfLaps; lap++)
        {
            for (int index = 0; index < this.racingDrivers.Count; index++)
            {
                try
                {
                    racingDrivers[index].CompleteLap(this.track.TrackLength);
                }
                catch (ArgumentException ex)
                {
                    racingDrivers[index].Fail(ex.Message);
                    this.failedDrivers.Push(racingDrivers[index]);
                    racingDrivers.RemoveAt(index);
                    index--;
                }
            }

            this.track.CurrentLap++;

            var orderedRacingDrivers = this.racingDrivers
                .OrderByDescending(d => d.TotalTime)
                .ToList();

            for (int i = 0; i < orderedRacingDrivers.Count - 1; i++)
            {
                Driver overtakingDriver = orderedRacingDrivers[i];
                Driver targetDriver = orderedRacingDrivers[i + 1];

                string overtakingDriverType = overtakingDriver.GetType().Name;
                string overtakingDriverTyreType = overtakingDriver.Car.Tyre.GetType().Name;
                string weather = this.track.Weather.ToString();
                double timeDifference = overtakingDriver.TotalTime - targetDriver.TotalTime;

                try
                {
                    if (timeDifference <= 3)
                    {
                        double interval = 3.0;

                        if (overtakingDriverType == "AggressiveDriver" && overtakingDriverTyreType == "UltrasoftTyre")
                        {
                            if (weather == "Foggy")
                                throw new ArgumentException(ErrorMessages.Crash);
                            else
                            {                                
                                PerformOvertake(sb, overtakingDriver, targetDriver, interval);
                                i++;
                            }
                        }

                        else if (overtakingDriverType == "EnduranceDriver" && overtakingDriverTyreType == "HardTyre")
                        {
                            if (weather == "Rainy")
                                throw new ArgumentException(ErrorMessages.Crash);
                            else
                            {                                
                                PerformOvertake(sb, overtakingDriver, targetDriver, interval);
                                i++;
                            }
                        }

                        else if (timeDifference <= 2)
                        {
                            interval = 2.0;
                            
                            PerformOvertake(sb, overtakingDriver, targetDriver, interval);
                            i++;
                        }
                    }
                }

                catch (ArgumentException ex)
                {
                    overtakingDriver.Fail(ex.Message);
                    this.failedDrivers.Push(overtakingDriver);
                    Driver driverToRemove = this.racingDrivers.FirstOrDefault(d => d.Name == overtakingDriver.Name);

                    if (driverToRemove == null)
                        throw new ArgumentException(ErrorMessages.InvalidOvertakingDriver);

                    this.racingDrivers.Remove(driverToRemove);
                }

            }

            if (isRaceOver)
            {
                Driver winnerDriver = orderedRacingDrivers[orderedRacingDrivers.Count - 1];
                sb.AppendLine($"{winnerDriver.Name} wins the race for {winnerDriver.TotalTime:f3} seconds.");
                break;
            }
        }

        string result = sb.ToString().TrimEnd();

        return result;
    }

    private void PerformOvertake(StringBuilder sb, Driver overtakingDriver, Driver targetDriver, double interval)
    {
        overtakingDriver.Overtake(interval);
        targetDriver.GettingOvertaken(interval);

        sb.AppendLine($"{overtakingDriver.Name} has overtaken " +
                $"{targetDriver.Name} on lap {this.track.CurrentLap}.");
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Lap {this.track.CurrentLap}/{this.track.LapsNumber}");

        IEnumerable<Driver> leaderBoardDrivers = this
            .racingDrivers.OrderBy(d => d.TotalTime)
            .Concat(this.failedDrivers);

        int position = 1;
        foreach (var driver in leaderBoardDrivers)
        {
            sb.AppendLine($"{position} {driver.ToString()}");
            position++;
        }

        string result = sb.ToString().TrimEnd();

        return result;
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string weatherType = commandArgs[0];
        bool validWeather = Enum.TryParse(typeof(Weather), weatherType, out object newWeatherObj);

        if (!validWeather)
            throw new ArgumentException(ErrorMessages.InvalidWeatherType);

        Weather newWeather = (Weather)newWeatherObj;

        this.track.Weather = newWeather;
    }

}


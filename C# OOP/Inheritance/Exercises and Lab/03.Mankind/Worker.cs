using System;

public class Worker : Human
{
    private const int WORKINGDAYS_IN_A_WEEK = 5;
    private const string Error = "Expected value mismatch! Argument: {0}";

    private decimal weekSalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weeklySalary, double workHoursPerDay) : base(firstName, lastName)
    {
        WeeklySalary = weeklySalary;
        WorkHoursPerDay = workHoursPerDay;
    }
    
    public override string ToString()
    {
        return $"First Name: {base.firstName}\n" +
            $"Last Name: {base.lastName}\n" +
            $"Week Salary: {weekSalary:f2}\n" +
            $"Hours per day: {workHoursPerDay:f2}\n" +
            $"Salary per hour: {GetSalaryPerHour():f2}";
    }

    private decimal GetSalaryPerHour()
    {
        decimal result = 0.0m;
        result = weekSalary / (decimal)(workHoursPerDay * WORKINGDAYS_IN_A_WEEK);

        return result;
    }

    private double WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
                throw new ArgumentException(string.Format(Error, nameof(workHoursPerDay)));
            workHoursPerDay = value;
        }
    }


    private decimal WeeklySalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= 10)
                throw new ArgumentException(string.Format(Error, nameof(weekSalary)));
            weekSalary = value;
        }
    }

}


using _04.WorkForce.Interfaces;

namespace _04.WorkForce.Models
{
    public abstract class Employee : IEmployee
    {
        public Employee(string name, int workHoursPerWeek)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workHoursPerWeek;
        }

        public string Name { get; }

        public int WorkHoursPerWeek { get; }
    }
}

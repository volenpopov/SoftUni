using _04.WorkForce.Interfaces;

namespace _04.WorkForce.Models
{
    public class Job : IJob
    {
        private IEmployee employeeAssigned;

        public event JobDoneEventHandler JobDoneEvent;

        public Job(IEmployee employee, string name, int hoursRequired)
        {
            this.employeeAssigned = employee;
            this.Name = name;
            this.HoursOfWorkRequired = hoursRequired;
            this.WorkHoursRemaining = hoursRequired;
        }

        public int HoursOfWorkRequired { get; }

        public string Name { get; }

        public int WorkHoursRemaining { get; private set; }

        public void Update()
        {
            this.WorkHoursRemaining -= this.employeeAssigned.WorkHoursPerWeek;

            if (this.WorkHoursRemaining <= 0)
            {
                if (JobDoneEvent != null)
                    JobDoneEvent.Invoke(this);
            }
        }

        public override string ToString()
        {
            return 
                $"{this.GetType().Name}: {this.Name} Hours Remaining: {this.WorkHoursRemaining}";
        }
    }
}

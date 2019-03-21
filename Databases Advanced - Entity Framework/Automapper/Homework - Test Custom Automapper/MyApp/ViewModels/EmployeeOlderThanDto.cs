namespace MyApp.ViewModels
{
    public class EmployeeOlderThanDto : EmployeeBasicInfoDto
    {
        public decimal Salary { get; set; }

        public EmployeeBasicInfoDto Manager { get; set; }

        public override string ToString()
        {
            string managerName = this.Manager == null
                ? "[no manager]"
                : this.Manager.LastName;

            return $"{base.FirstName} {base.LastName} - ${this.Salary:f2} - Manager: {managerName}";
        }
    }
}

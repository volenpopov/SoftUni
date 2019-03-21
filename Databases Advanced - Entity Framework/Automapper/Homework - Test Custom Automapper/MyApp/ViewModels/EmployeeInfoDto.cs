
namespace MyApp.ViewModels
{
    public class EmployeeInfoDto : EmployeeBasicInfoDto
    {
        public int EmployeeId { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"ID: {this.EmployeeId} - {base.FirstName} {base.LastName} - ${this.Salary:f2}";
        }
    }
}

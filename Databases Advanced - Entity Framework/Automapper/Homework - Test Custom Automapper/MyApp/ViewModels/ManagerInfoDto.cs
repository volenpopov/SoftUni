using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.ViewModels
{
    public class ManagerInfoDto : EmployeeBasicInfoDto
    {
        public ManagerInfoDto()
        {
            this.ManagedEmployees = new List<EmployeeInfoDto>();
        }

        public List<EmployeeInfoDto> ManagedEmployees { get; set; }

        public override string ToString()
        {
            string result = $"{base.FirstName} {base.LastName} | Employees: {this.ManagedEmployees.Count}";

            if (this.ManagedEmployees.Count <= 0)
            {
                return result;
            }
            
            result += Environment.NewLine
                + string.Join(Environment.NewLine, 
                    this.ManagedEmployees.Select(e => $"    - {e.FirstName} {e.LastName} - ${e.Salary:f2}"));

            return result;
        }
    }
}

using System;

namespace MyApp.ViewModels
{
    public class EmployeePersonalInfoDto : EmployeeInfoDto
    {
        public DateTime? Birthday { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            return base.ToString()
                + Environment.NewLine
                + $"Birthday: {this.Birthday:dd-MM-yyyy}"
                + Environment.NewLine
                + $"Address: {this.Address}";
        }
    }
}

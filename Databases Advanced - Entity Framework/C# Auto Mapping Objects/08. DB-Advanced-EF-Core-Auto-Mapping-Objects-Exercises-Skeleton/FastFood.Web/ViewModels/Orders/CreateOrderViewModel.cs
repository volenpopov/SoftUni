namespace FastFood.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public int[] ItemsIds { get; set; }
        public string[] ItemsNames { get; set; }

        public int[] EmployeesIds { get; set; }
        public string[] EmployeesNames { get; set; }
    }
}

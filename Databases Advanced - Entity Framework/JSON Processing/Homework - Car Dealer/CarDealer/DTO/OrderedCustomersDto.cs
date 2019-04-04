using System;

namespace CarDealer.DTO
{
    public class OrderedCustomerDto /*: IComparable<OrderedCustomerDto>*/
    {
        public string Name { get; set; }

        public string BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        //public int CompareTo(OrderedCustomerDto other)
        //{
        //    int result = -3;

        //    var currentObjBirthdate = 
        //        DateTime.ParseExact(this.BirthDate, "dd/MM/yyyy", null);

        //    var otherObjBirthdate =
        //        DateTime.ParseExact(other.BirthDate, "dd/MM/yyyy", null);

        //    if (currentObjBirthdate < otherObjBirthdate)
        //        result = -1;
        //    else if (currentObjBirthdate > otherObjBirthdate)
        //        result = 1;
        //    else
        //    {
        //        if (!this.IsYoungDriver && other.IsYoungDriver)
        //            result = -1;
        //        else if (this.IsYoungDriver && !other.IsYoungDriver)
        //            result = 1;
        //        else
        //            result = 0;
        //    }

        //    return result;
        //}
    }
}

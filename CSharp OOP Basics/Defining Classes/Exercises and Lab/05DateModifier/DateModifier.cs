using System;
using System.Collections.Generic;
using System.Text;


public static class DateModifier
{
    public static int GetDaysBetweenDates(string date1, string date2)
    {       
        DateTime dayOne = DateTime.ParseExact(date1, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
        DateTime dayTwo = DateTime.ParseExact(date2, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);

        double difference = Math.Abs((dayOne - dayTwo).TotalDays);
       
        return (int)difference;
    }        

}


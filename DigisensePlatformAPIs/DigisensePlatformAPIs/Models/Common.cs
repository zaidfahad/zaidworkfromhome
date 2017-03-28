using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class Common
    {
        public enum platform
        {
            commercial = 1,
            mce = 2,
            farm = 3,
            mtbd = 4
        }
        public static int DateCompare(DateTime startDate, DateTime endDate)
        {  
            return DateTime.Compare(startDate, endDate);
        }
        public static DateTime BuildDateTimeFromYAFormat(string dateString)
        {
            //Regex r = new Regex(@"^\d{4}\d{2}\d{2}T\d{2}\d{2}Z$");
            Regex r = new Regex(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$");
            if (!r.IsMatch(dateString))
            {
                throw new FormatException(
                    string.Format("{0} is not the correct format. Should be yyyy-MM-dd HH:mm:ss", dateString));


            }

            DateTime dt = DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);

            return dt;
        }
    }
}
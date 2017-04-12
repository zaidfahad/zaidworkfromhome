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
            Regex r = new Regex(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$");
            if (!r.IsMatch(dateString))
            {
                throw new FormatException(
                    string.Format("{0} is not the correct format. Should be yyyy-MM-dd HH:mm:ss", dateString));
            }
            DateTime dt = DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
            return dt;
        }
        public static Tuple<bool, string, DateTime> BuildDateTimeFromYAFormatV1(string dateString)
        {
            Tuple<bool, string, DateTime> dateTimevalidation;
            try
            {

                Regex r = new Regex(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$");
                if (!r.IsMatch(dateString))
                {
                    dateTimevalidation = new Tuple<bool, string, DateTime>(false, string.Format("{0} is not the correct format. Should be yyyy-MM-dd HH:mm:ss", dateString), DateTime.Now);
                    return dateTimevalidation;
                }
                else
                {
                    DateTime dt = DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
                    dateTimevalidation = new Tuple<bool, string, DateTime>(true, "", dt);
                    return dateTimevalidation;
                }
            }
            catch (Exception ex)
            {
                dateTimevalidation = new Tuple<bool, string, DateTime>(false, string.Format("{0} " + ex.Message.ToString(), dateString), DateTime.Now);
                return dateTimevalidation;
            }
        }

        public static Tuple<bool, string> DateCompareV1(DateTime startDate, DateTime endDate)
        {
            Tuple<bool, string> data;
            try
            {
                if (DateTime.Compare(startDate, endDate) <= 0)
                {
                    data = new Tuple<bool, string>(true, "correct");
                }
                else
                {
                    data = new Tuple<bool, string>(false, "Start Date should not be greater than End Date.");
                }
            }
            catch (Exception ex)
            {
                data = new Tuple<bool, string>(false, ex.Message.ToString());
            }
            return data;
        }
    }
}
using DigisensePlatformAPIs.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace DigisensePlatformAPIs.Utilities
{
    public static class CustomValidation
    {
        #region Validate Date String
        /// <summary>
        /// ValidateDateString is date or not
        /// To Check string in date format or not
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidateDateString(this string value)
        {
            try
            {
                DateTime dt = DateTime.Parse(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region  Validate Start Date And End Date
        /// <summary>
        /// ValidateStartDateAndEndDate 
        /// Start Date should always come earlier from End Date
        /// </summary>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        public static bool ValidateStartDateAndEndDate(this string startdate, string enddate)
        {

            try
            {
                if (DateTime.Parse(enddate) <= DateTime.Parse(startdate))
                {
                    return false;
                }
                else
                {
                    return true;

                }

            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Validate Query String
        public static bool ValidateQueryString(this string value)
        {
            try
            {
                if (value.IndexOf("{") < 0 && value.IndexOf("}") < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public static string FirstLetterToUpper(this string value)
        {
            if (value == null)
                return null;

            if (value.Length > 1)
                return char.ToUpper(value[0]) + value.Substring(1);

            return value.ToUpper();
        }
        public static string CustomClassPropertyName(this string value)
        {
            string[] columnsName = value.Split('_');
            string customColumns = String.Empty;
            for (int a = 0; a < columnsName.Length; a++)
            {
                customColumns = customColumns + columnsName[a].FirstLetterToUpper();
            }
            return customColumns;
        }



        public static string ConvertSecondsToTime(this int seconds)
        {
            TimeSpan span = TimeSpan.FromSeconds(seconds);
            string label = span.ToString(@"hh\:mm\:ss");
            //TimeSpan t = TimeSpan.FromSeconds(Convert.ToDouble(seconds));

            //if (t.Days > 0)
            //   return t.ToString(@"d\d\,\ hh\:mm\:ss");
            //  return t.ToString(@"hh\:mm\:ss");
            return label;
        }

        public static string ConvertSecondsintoHHMMSSFormat(this double secs)
        {
            string answer = string.Empty;
            try
            {

                TimeSpan t = TimeSpan.FromSeconds(secs);

                if (t.Days > 0)
                {
                    answer = string.Format("{0:D2}day(s) {1:D2}h:{2:D2}m:{3:D2}s",
                                   t.Days,
                                   t.Hours,
                                   t.Minutes,
                                   t.Seconds
                                 );
                }
                else
                {

                    answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                               t.Hours,
                               t.Minutes,
                               t.Seconds
                             );

                }

            }

            catch (Exception ex)
            {

            }


            return answer;
        }
        public static string ConvertSecondsintoHHMMFormat(this double secs)
        {
            string answer = string.Empty;
            try
            {

                TimeSpan t = TimeSpan.FromSeconds(secs);

                if (t.Days > 0)
                {
                    answer = string.Format("{0:D2}day(s) {1:D2}h:{2:D2}m:{3:D2}s",
                                   t.Days,
                                   t.Hours,
                                   t.Minutes,
                                   t.Seconds
                                 );
                }
                else
                {

                    answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                               t.Hours,
                               t.Minutes,
                               t.Seconds
                             );

                }

            }

            catch (Exception ex)
            {

            }


            return answer;
        }

        public static bool ValidateBaseString(this string str)
        {
            try
            {
                // If no exception is caught, then it is possibly a base64 encoded string
                byte[] data = Convert.FromBase64String(str);
                // The part that checks if the string was properly padded to the
                // correct length was borrowed from d@anish's solution
                return (str.Replace(" ", "").Length % 4 == 0);
            }
            catch
            {
                // If exception is caught, then it is not a base64 encoded string
                return false;
            }
        }

        public static Tuple<bool, string> ValidateDecimalValue(this string value)
        {
            Tuple<bool, string> result;
            decimal val = 0;
            try
            {
                bool canConvert = decimal.TryParse(value, out val);
                if (canConvert)
                {
                    result = new Tuple<bool, string>(true, value);
                }
                else
                {
                    result = new Tuple<bool, string>(false, value + " value filed is invalid decimal");
                }
            }
            catch (Exception ex)
            {
                result = new Tuple<bool, string>(false, ex.Message);
            }
            return result;
        }

        /*
        public static Tuple<bool, string> LongitudeLatitudeValidation(this string logitude,string latitude)
        {
            Tuple<bool, string> result=null;
            try
            {
                var check= DecimalValueCheck(logitude);
                if (check)
                {
                    check = DecimalValueCheck(latitude);
                    if (!check)
                    {
                        result = new Tuple<bool, string>(false, latitude + " latitude value is invalid");
                    }
                    else
                    {
                        result = new Tuple<bool, string>(true, "success");

                    }
                }
                else
                {
                    result = new Tuple<bool, string>(false, logitude + " longitude value is invalid");
                }
            }
            catch (Exception ex)
            {
                result = new Tuple<bool, string>(false, ex.Message);
            }
            return result;
        }
        */

        public static Tuple<bool, string> LongitudeLatitudeValidation(this string logitude, string latitude)
        {
            Tuple<bool, string> result = null;
            try
            {
                var latExp = @"^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))$";
                var lngExp = @"^(\+|-)?(?:180(?:(?:\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{1,6})?))$";
                Regex reg = new Regex(lngExp);
                if (!reg.IsMatch(logitude))
                {
                    result = new Tuple<bool, string>(false, logitude + " logitude value is invalid");
                }
                else
                {
                    reg = new Regex(latExp);
                    if (!reg.IsMatch(latitude))
                    {
                        result = new Tuple<bool, string>(false, latitude + " latitude value is invalid");
                    }
                    else
                    {
                        result = new Tuple<bool, string>(true, "correct");
                    }
                }
            }
            catch (Exception ex)
            {
                result = new Tuple<bool, string>(false, ex.Message);
            }
            return result;
        }
        public static bool DecimalValueCheck(string value)
        {

            try
            {
                var valuesplit = value.Split('.');
                int _value;
                if (valuesplit.Length == 2)
                {

                    if (int.TryParse(valuesplit[0], out _value) && int.TryParse(valuesplit[1], out _value))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        #region Fetch Address Base on Logitude and Latitude 
        public static string FetchAddressByLongitudeLatitude(string logitude, string latitude)
        {
            string address = string.Empty;
            try
            {
                string apiurl = "http://maps.google.com/maps/api/geocode/json?latlng=" + latitude + " ," + logitude + "&sensor=false";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(apiurl);
                request.Method = "GET";
                String json = String.Empty;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                json = reader.ReadToEnd();
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                LongitudeLatitudeResponse routes_list =
                      JsonConvert.DeserializeObject<LongitudeLatitudeResponse>(json);
                reader.Close();
                dataStream.Close();
                address = Convert.ToString(routes_list.results[0].formatted_address);
            }
            catch (Exception ex)
            {
                return address = "Not Found";
            }
            return address;
        }

        public static string FetchAddressByLongitudeLatitude(this string latlong)
        {
            string address = string.Empty;
            try
            {
                string apiurl = "http://maps.google.com/maps/api/geocode/json?latlng=" +latlong+ "&sensor=false";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(apiurl);
                request.Method = "GET";
                String json = String.Empty;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                json = reader.ReadToEnd();
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                LongitudeLatitudeResponse routes_list =
                      JsonConvert.DeserializeObject<LongitudeLatitudeResponse>(json);
                reader.Close();
                dataStream.Close();
                address = Convert.ToString(routes_list.results[0].formatted_address);
            }
            catch (Exception ex)
            {
                return address = "Not Found";
            }
            return address;
        }
        #endregion
    }
}
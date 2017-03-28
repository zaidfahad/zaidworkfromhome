﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

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
    }
}
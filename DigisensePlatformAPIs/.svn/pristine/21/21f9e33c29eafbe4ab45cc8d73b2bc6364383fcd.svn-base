using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DigisensePlatformAPIs.Utilities;
using System.Reflection;
using log4net;
namespace DigisensePlatformAPIs.Controllers
{
    public class ExpenseController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Expense ALL GET API

        #region View Expense Details
        [HttpGet]
        [Route("api/expense/{vehicleRegNo}")]
        public HttpResponseMessage TripExpense(string vehicleRegNo, string startDate, string endDate)
        {
            //bool customcheck = false; string errorMessage = String.Empty;
            //if (vehicleRegNo != null)
            //{
            //    if (Convert.ToString(vehicleRegNo).ToLower() != "{vehicleregno}" && Convert.ToString(vehicleRegNo).ToLower() != "vehicleregno")
            //    {
            //        customcheck = true;
            //    }
            //    else
            //    {
            //        customcheck = false;
            //        errorMessage = "Vehicle registration number is wrong ";
            //    }
            //    if (customcheck)
            //    {
            //        if (startDate != null && startDate.ValidateDateString())
            //        {
            //            customcheck = true;
            //        }
            //        else
            //        {
            //            customcheck = false;
            //            errorMessage = "Date format is wrong";
            //        }
            //    }
            //    if (customcheck)
            //    {
            //        if (endDate != null && endDate.ValidateDateString() && customcheck)
            //        {
            //            customcheck = true;
            //        }
            //        else
            //        {
            //            customcheck = false;
            //            errorMessage = "Date format is wrong";
            //        }
            //    }
            //    if (customcheck)
            //    {
            //        if (startDate.ValidateStartDateAndEndDate(endDate))
            //        {
            //            customcheck = true;
            //        }
            //        else
            //        {
            //            customcheck = false;
            //            errorMessage = "Start Date should come earlier from End Date";
            //        }
            //    }
            //}
            //else
            //{
            //    customcheck = false;
            //    errorMessage = "Vehicle registration is required";
            //}
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            try
            {
                var _startDate = Common.BuildDateTimeFromYAFormat(startDate);
                var _endDate = Common.BuildDateTimeFromYAFormat(endDate);
                var result = Common.DateCompare(_startDate, _endDate);
                if (headers.Contains("token"))
                {
                    if (headers.GetValues("token") != null && Convert.ToString(headers.GetValues("token")) != "")
                    {
                        token = headers.GetValues("token").First();
                    }
                }
                  if (result < 0)
                {
                if (ModelState.IsValid)
                {
                   // if (customcheck)
                   // {
                        if (token != "")
                        {
                            bool validateToken = false;
                            string username = string.Empty;
                            DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);
                            if (dtTkenData.Rows.Count > 0)
                            {
                                username = Convert.ToString(dtTkenData.Rows[0]["_username"]);
                                validateToken = Convert.ToBoolean(dtTkenData.Rows[0]["_validation"]);
                            }
                            if (validateToken)
                            {
                                DataTable dtalert = new DataTable();
                                DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                                int RoleID = 0;
                                int BusinessType = 0;
                                if (dtLoginInfo.Rows.Count > 0)
                                {
                                    RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                    BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                                }
                                dtalert = DBUtilities.ExpenseRepository.ExpenseDetails(username, vehicleRegNo, Convert.ToDateTime(_startDate), Convert.ToDateTime(_endDate), BusinessType);
                                if (dtalert.Rows.Count > 0)
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Expense_BL.ExpenseResponse(dtalert));
                                }
                                else
                                {
                                    return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Records not found."));
                                }
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("Invalid Token."));
                            }
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Invalid Token."));
                        }
                    //}
                    //else
                    //{
                    //    return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response(errorMessage));
                    //}
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                }
                  else
                  {
                      return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response("startDate should not be greater than endDate."));

                  }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));
               
            }
        }
        #endregion

        #region View Expense Category Details
        [HttpGet]
        [Route("api/expenseCategory/{vehicleRegNo}")]
        public HttpResponseMessage ExpenseCategory(string vehicleRegNo)
        {
            bool customcheck = false; string errorMessage = String.Empty;
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            if (vehicleRegNo != null)
            {
                if (Convert.ToString(vehicleRegNo).ToLower() != "{vehicleregno}" && Convert.ToString(vehicleRegNo).ToLower() != "vehicleregno")
                {
                    customcheck = true;
                }
                else
                {
                    customcheck = false;
                    errorMessage = "Vehicle registration number is wrong ";
                }
            }
            try
            {
                if (headers.Contains("token"))
                {
                    if (headers.GetValues("token") != null && Convert.ToString(headers.GetValues("token")) != "")
                    {
                        token = headers.GetValues("token").First();
                    }
                }
                if (ModelState.IsValid)
                {
                    if (customcheck)
                    {
                        if (token != "")
                        {
                            bool validateToken = false;
                            string username = string.Empty;
                            DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);
                            if (dtTkenData.Rows.Count > 0)
                            {
                                username = Convert.ToString(dtTkenData.Rows[0]["_username"]);
                                validateToken = Convert.ToBoolean(dtTkenData.Rows[0]["_validation"]);
                            }
                            if (validateToken)
                            {
                                DataTable dtalert = new DataTable();
                                DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                                int RoleID = 0;
                                int BusinessType = 0;
                                if (dtLoginInfo.Rows.Count > 0)
                                {
                                    RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                    BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                                }
                                dtalert = DBUtilities.ExpenseRepository.ExpenseCategoryDetails(username, vehicleRegNo, BusinessType);
                                if (dtalert.Rows.Count > 0)
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Expense_BL.ExpenseCategoryResponse(dtalert));
                                }
                                else
                                {
                                    return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Records not found."));
                                }
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("Invalid Token."));
                            }
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Invalid Token."));
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response(errorMessage));
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));
               
            }
        }
        #endregion


        #endregion


        #region Expense POST API
        #region api/expenseCategory/platform/{platform}
        [HttpPost]
        [Route("api/expenseCategory/platform/{platform}")]
        public HttpResponseMessage ExpenseCategoryPost(string platform, [FromBody]ExpenseRequest expense)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            try
            {
                if (headers.Contains("token"))
                {
                    if (headers.GetValues("token") != null && Convert.ToString(headers.GetValues("token")) != "")
                    {
                        token = headers.GetValues("token").First();
                    }
                }
                if (ModelState.IsValid)
                {
                    if (token != "")
                    {
                        bool validateToken = false;
                        string username = string.Empty;
                        DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);
                        if (dtTkenData.Rows.Count > 0)
                        {
                            username = Convert.ToString(dtTkenData.Rows[0]["_username"]);
                            validateToken = Convert.ToBoolean(dtTkenData.Rows[0]["_validation"]);
                        }
                        if (validateToken)
                        {
                            DataTable dtalert = new DataTable();
                            DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                            int RoleID = 0;
                            int BusinessType = 0;
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                            }
                            dtalert = DBUtilities.ExpenseRepository.ExpenseCategoryPlatformPost(username, platform, expense, BusinessType);
                            if (dtalert.Rows.Count > 0)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Expense_BL.ExpenseCategoryPostResponse(dtalert));
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Records not found."));
                            }
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("Invalid Token."));
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Invalid Token."));
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));
               
            }
        }

        #endregion
        #endregion

        #region Expense Put API

        #region api/expense/{vehicleRegNo}

        [HttpPut]
        [Route("api/expense/{vehicleRegNo}")]
        public HttpResponseMessage Expense(string vehicleRegNo, [FromBody] Expense objDriverAttributeInfo)
        {

            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;

            string labels = objDriverAttributeInfo.label.ToLower();
            DateTime date = objDriverAttributeInfo.date;
            string values = objDriverAttributeInfo.value;
            try
            {
                if (headers.Contains("token"))
                {
                    if (headers.GetValues("token") != null && Convert.ToString(headers.GetValues("token")) != "")
                    {
                        token = headers.GetValues("token").First();
                    }
                }

                 
                if (ModelState.IsValid)
                {
                    if (token != "")
                    {
                        bool validateToken = false;
                        string username = string.Empty;
                        DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);
                        if (dtTkenData.Rows.Count > 0)
                        {
                            username = Convert.ToString(dtTkenData.Rows[0]["_username"]);
                            validateToken = Convert.ToBoolean(dtTkenData.Rows[0]["_validation"]);
                        }
                        if (validateToken)
                        {
                            DataTable dtalert = new DataTable();
                            DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                            int RoleID = 0;
                            int BusinessType = 0;
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                            }
                            dtalert = DBUtilities.ExpenseRepository.insertExpense(username, vehicleRegNo, labels, values, Convert.ToDateTime(date), BusinessType);
                            if (dtalert.Rows.Count > 0)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Expense_BL.ExpenseCategoryPutResponse(dtalert));
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Records not found."));
                            }
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("Invalid Token."));
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Invalid Token."));
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));
               
            }
        }
        #endregion


        #region api/expenseOld/{vehicleRegNo}

        [HttpPut]
        [Route("api/expenseOld/{vehicleRegNo}")]
        public HttpResponseMessage Expenseold(string vehicleRegNo, [FromBody] List<object> objDriverAttributeInfo)
        {

            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;

            string labels = string.Empty;
            string date = string.Empty;
            string values = string.Empty;
            try
            {
                if (headers.Contains("token"))
                {
                    if (headers.GetValues("token") != null && Convert.ToString(headers.GetValues("token")) != "")
                    {
                        token = headers.GetValues("token").First();
                    }
                }


                ExpenseRequestPut objDriver = new ExpenseRequestPut();

                Type type = typeof(ExpenseRequestPut);

                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo property in properties)
                {

                    foreach (dynamic item in objDriverAttributeInfo)
                    {

                        if (property.Name.ToLower() == ((string)item.label).ToLower())
                        {
                            property.SetValue(objDriver, (string)item.value);

                            labels = labels + "," + ((string)item.label).ToLower();
                            values = values + "," + (string)item.value;

                            if (date == null || date == "")
                            {
                                date = (string)item.date;
                            }
                            else
                            {
                                if (Convert.ToDateTime((string)item.date) > Convert.ToDateTime(date))
                                {
                                    date = (string)item.date;
                                }
                            }
                            labels = ((string)item.label).ToLower();
                            values = (string)item.value;
                            date = (string)item.date;
                        }

                    }

                }

                if (ModelState.IsValid)
                {
                    if (token != "")
                    {
                        bool validateToken = false;
                        string username = string.Empty;
                        DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);
                        if (dtTkenData.Rows.Count > 0)
                        {
                            username = Convert.ToString(dtTkenData.Rows[0]["_username"]);
                            validateToken = Convert.ToBoolean(dtTkenData.Rows[0]["_validation"]);
                        }
                        if (validateToken)
                        {
                            DataTable dtalert = new DataTable();
                            DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                            int RoleID = 0;
                            int BusinessType = 0;
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                            }
                            dtalert = DBUtilities.ExpenseRepository.insertExpense(username, vehicleRegNo, labels.TrimStart(','), values.TrimStart(','), Convert.ToDateTime(date), BusinessType);
                            if (dtalert.Rows.Count > 0)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Expense_BL.ExpenseCategoryPutResponse(dtalert));
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Records not found."));
                            }
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("Invalid Token."));
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Invalid Token."));
                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));
               
            }
        }
        #endregion
        #endregion
    }
}

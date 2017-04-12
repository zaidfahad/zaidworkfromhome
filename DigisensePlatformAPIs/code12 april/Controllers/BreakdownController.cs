﻿using DigisensePlatformAPIs.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using log4net;
using System.Configuration;
namespace DigisensePlatformAPIs.Controllers
{
    public class BreakdownController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Break Down  Details  get we are not using now 5 april
        [HttpGet]
         [Route("api/breakDown/{vehicleregno}")]
        public HttpResponseMessage BreakDownDetails(string vehicleregno)
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
                if (headers.Contains("apikey"))
                {
                    if (headers.GetValues("apikey") != null && Convert.ToString(headers.GetValues("apikey")) != "")
                    {
                        apikey = headers.GetValues("apikey").First();
                    }
                }
                if (ModelState.IsValid)
                {
                    if (token != "")
                    {

                        // bool validateToken = JWTTokenGenration.JWTTokenGenration.VerifyJWT(token);

                        bool validateToken = false;
                        string username = string.Empty;
                        string userid = string.Empty;

                        DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);

                        if (dtTkenData.Rows.Count > 0)
                        {
                            userid = Convert.ToString(dtTkenData.Rows[0]["_userid"]);
                            username = Convert.ToString(dtTkenData.Rows[0]["_username"]);
                            validateToken = Convert.ToBoolean(dtTkenData.Rows[0]["_validation"]);
                        }


                        if (validateToken)
                        {

                            DataTable dtDetails = new DataTable();

                            DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);

                            int RoleID = 0;
                            int BusinessType = 0;
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                            }
                            
                             dtDetails = DBUtilities.BreakDownRepository.BreakDownDetails(username, vehicleregno, BusinessType);
                            
                           

                            if (dtDetails.Rows.Count > 0)
                            {
                                 
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Breakdown_BL.BreakdownResponse(dtDetails));
                                
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not found."));
                            }


                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("Invalid Token."));

                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response("Invalid Token."));

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

        #region PUT  Break Down  Details  
        [HttpPut]
        [Route("api/breakDown/{vehicleregno}")]
        public HttpResponseMessage BreakDown(string vehicleregno)
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
                if (headers.Contains("apikey"))
                {
                    if (headers.GetValues("apikey") != null && Convert.ToString(headers.GetValues("apikey")) != "")
                    {
                        apikey = headers.GetValues("apikey").First();
                    }
                }
                if (ModelState.IsValid)
                {
                    if (token != "")
                    {

                        // bool validateToken = JWTTokenGenration.JWTTokenGenration.VerifyJWT(token);

                        bool validateToken = false;
                        string username = string.Empty;
                        string userid = string.Empty;

                        DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);

                        if (dtTkenData.Rows.Count > 0)
                        {
                            userid = Convert.ToString(dtTkenData.Rows[0]["_userid"]);
                            username = Convert.ToString(dtTkenData.Rows[0]["_username"]);
                            validateToken = Convert.ToBoolean(dtTkenData.Rows[0]["_validation"]);
                        }


                        if (validateToken)
                        {

                            DataTable dtDetails = new DataTable();
                            DataTable dtgetDetails = new DataTable();
                            DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);

                            int RoleID = 0;
                            int BusinessType = 0;
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                            }

                            dtDetails = DBUtilities.BreakDownRepository.InsertBreakDown(username, vehicleregno, BusinessType);
                            if (dtDetails.Rows.Count > 0)
                            {
                                if (dtDetails.Rows[0][0].ToString() == "0")
                                {
                                    dtgetDetails = DBUtilities.BreakDownRepository.getBreakDown(username, vehicleregno, BusinessType);
                                    // Sending SMS To Parent Dealer
                                    // string CurrentLocationofVehicle = geoLocation.LocationAddress(Convert.ToDouble(dtDetails.Rows[0]["Latitude"]), Convert.ToDouble(dtDetails.Rows[0]["Longitude"]));

                                    // string ParamName = "Current Location: " + CurrentLocationofVehicle + " Customer Name:" + (Convert.ToString(dtDetails.Rows[0]["FirstName"]) + " " + Convert.ToString(dtDetails.Rows[0]["LastName"])) + " Customer MobileNo: " + Convert.ToString(dtDetails.Rows[0]["CustomerMobNo"]);
                                    string Starttext = "Alert !!! Breakdown";
                                    //string smsText = Starttext + ", Vehicle Registration Number: " + vehicleregno + ", Date %26 Time " + Convert.ToString(dtDetails.Rows[0]["PacketTime"]) + " " + ParamName;
                                    string smsText = Starttext + ", Vehicle Registration Number: " + vehicleregno + ", Date %26 Time " + Convert.ToString(dtgetDetails.Rows[0]["EventTime"]);


                                    if (!(string.IsNullOrEmpty(Convert.ToString(dtgetDetails.Rows[0]["DealerNumber"]))))
                                    {
                                        if (Convert.ToBoolean(ConfigurationManager.AppSettings["SendSMS"]) == true)
                                        {
                                            SMSManagement.SendSMS(smsText, Convert.ToString(dtgetDetails.Rows[0]["DealerNumber"]));
                                        }

                                    }

                                    //Sending SMS To Emergency ContactNumbers
                                    string EC1 = string.Empty;
                                    string EC2 = string.Empty;

                                    StringBuilder mobileNumberSTR = new StringBuilder();
                                    // string CurrentLocationofVehicle1 = geoLocation.LocationAddress(Convert.ToDouble(dtDetails.Rows[0]["Latitude"]), Convert.ToDouble(dtDetails.Rows[0]["Longitude"]));
                                    // string ParamName1 = " Current Location: " + CurrentLocationofVehicle1;
                                    string Starttext1 = "Alert !!! Breakdown";

                                    string smsText1 = Starttext1 + ", Vehicle Registration Number: " + vehicleregno + ", Date %26 Time " + Convert.ToString(dtgetDetails.Rows[0]["EventTime"]);
                                    //string smsText1 = Starttext1 + ", Vehicle Registration Number: " + vehicleregno + ", Date %26 Time " + Convert.ToString(dtDetails.Rows[0]["PacketTime"]) + " " + ParamName;

                                    if (!(string.IsNullOrEmpty(Convert.ToString(dtgetDetails.Rows[0]["EmergencyContactNo1"]))))
                                    {
                                        EC1 = Convert.ToString(dtgetDetails.Rows[0]["EmergencyContactNo1"]);
                                        mobileNumberSTR.Append(EC1);
                                    }

                                    if (!(string.IsNullOrEmpty(Convert.ToString(dtgetDetails.Rows[0]["EmergencyContactNo2"]))))
                                    {
                                        EC2 = Convert.ToString(dtgetDetails.Rows[0]["EmergencyContactNo2"]);
                                        if (EC1 != EC2)
                                        {
                                            mobileNumberSTR.Append("," + EC2);
                                        }
                                    }


                                    foreach (DataRow drow in dtgetDetails.Rows)
                                    {
                                        string ConfigMobilenum = Convert.ToString(drow["MobileNumber"]);
                                        if (!(string.IsNullOrEmpty(ConfigMobilenum)))
                                        {
                                            mobileNumberSTR.Append("," + ConfigMobilenum);
                                        }
                                    }
                                    if (!(string.IsNullOrEmpty(Convert.ToString(mobileNumberSTR))))
                                    {

                                        if (Convert.ToBoolean(ConfigurationManager.AppSettings["SendSMS"]) == true)
                                        {
                                            SMSManagement.SendSMS(smsText1, mobileNumberSTR.ToString());
                                        }
                                    }
                                }
                                //////////////////////////////

                                if (dtDetails.Rows[0][0].ToString() == "0")
                                {

                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Breakdown_BL.BreakdownResponse(dtgetDetails));

                                }
                                else if (dtDetails.Rows[0][0].ToString() == "1")
                                {

                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Breakdown already triggered and not yet closed."));

                                }
                                else
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not found."));
                                }
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not found."));
                            }

                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("Invalid Token."));

                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response("Invalid Token."));

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

    }
}
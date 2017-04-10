﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using DigisensePlatformAPIs.Models;
using DigisensePlatformAPIs.BLUtilities;
using log4net;
namespace DigisensePlatformAPIs.Controllers
{
    public class VehicleController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        #region List of Vehicle  Details
        [HttpGet]
        [Route("api/listVehicles")]
        public HttpResponseMessage VehicleDetails()
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
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
                        // bool validateToken = JWTTokenGenration.JWTTokenGenration.VerifyJWT(token);
                        bool validateToken = false;
                        string username = string.Empty;
                        string userid = string.Empty;
                        DataTable dtDetailsRank = new DataTable();
                        DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);
                        if (dtTkenData.Rows.Count > 0)
                        {
                            userid =   Convert.ToString(dtTkenData.Rows[0]["_userid"]);
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

                            dtDetails = DBUtilities.VehicleRepository.VehicleDetails(username, BusinessType);




                            dtDetails.Columns.Add(new DataColumn("DriverName", typeof(System.String)));


                            dtDetailsRank = DBUtilities.VehicleRepository.VehicleDriverMapping(username, BusinessType);

                            for (int i = 0; i < dtDetails.Rows.Count; i++)
                            {
                                
                               var rows = from row in dtDetailsRank.AsEnumerable()
                                           where row.Field<string>("RegistrationNumber").Trim() == dtDetails.Rows[i]["RegistrationNumber"].ToString()
                                           select row;
                               if (rows.Any())
                                //if(!string.IsNullOrEmpty(str))
                                {
                                    DataTable dataTable = rows.CopyToDataTable();



                                    dtDetails.Rows[i]["DriverName"] = dataTable.Rows[0]["DriverName"].ToString();   // or set it to some other value

                                }
                                else
                                {
                                    dtDetails.Rows[i]["DriverName"] = "";
                                }
                            }



                            if (dtDetails.Rows.Count > 0)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Vehicle_BL.VehicleResponse(dtDetails));
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, Common_BL.Response(ex.Message));
                
            }
        }
        #endregion

        #region MTBD List of Vehicle  Details
        [HttpGet]
        [Route("api/listVehicles/MTBD")]
        public HttpResponseMessage MTBDVehicleDetails()
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
                        string userid = string.Empty;
                        DataTable dtDetailsRank = new DataTable();
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
                            dtDetails = DBUtilities.VehicleRepository.VehicleDetailsMTBD(username, BusinessType);


                            dtDetails.Columns.Add(new DataColumn("DriverName", typeof(System.String)));


                            dtDetailsRank = DBUtilities.VehicleRepository.VehicleDriverMapping(username, BusinessType);

                            for (int i = 0; i < dtDetails.Rows.Count; i++)
                            {

                                var rows = from row in dtDetailsRank.AsEnumerable()
                                           where row.Field<string>("RegistrationNumber").Trim() == dtDetails.Rows[i]["RegistrationNumber"].ToString()
                                           select row;
                                if (rows.Any())
                                //if(!string.IsNullOrEmpty(str))
                                {
                                    DataTable dataTable = rows.CopyToDataTable();



                                    dtDetails.Rows[i]["DriverName"] = dataTable.Rows[0]["DriverName"].ToString();   // or set it to some other value

                                }
                                else
                                {
                                    dtDetails.Rows[i]["DriverName"] = "";
                                }
                            }


                            if (dtDetails.Rows.Count > 0)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Vehicle_BL.MTBDVehicleResponse(dtDetails));
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, Common_BL.Response(ex.Message));
               
            }
        }
        #endregion

        //#region  VehicleSummary  Details
        //[HttpGet]
        //[Route("api/vehiclesSummary/{vehicleregno}")]
        //public HttpResponseMessage vehiclesSummaryDetails(string vehicleregno)
        //{

        //    System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
        //    string token = string.Empty;
        //    string apikey = string.Empty;
        //    try
        //    {
        //        if (headers.Contains("token"))
        //        {
        //            if (headers.GetValues("token") != null && Convert.ToString(headers.GetValues("token")) != "")
        //            {
        //                token = headers.GetValues("token").First();
        //            }
        //        }
        //        if (headers.Contains("apikey"))
        //        {
        //            if (headers.GetValues("apikey") != null && Convert.ToString(headers.GetValues("apikey")) != "")
        //            {
        //                apikey = headers.GetValues("apikey").First();
        //            }
        //        }
        //        if (ModelState.IsValid)
        //        {
        //            if (token != "")
        //            {

        //                // bool validateToken = JWTTokenGenration.JWTTokenGenration.VerifyJWT(token);
        //                bool validateToken = false;
        //                string username = string.Empty;
        //                string userid = string.Empty;

        //                DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);

        //                if (dtTkenData.Rows.Count > 0)
        //                {
        //                    userid = Convert.ToString(dtTkenData.Rows[0]["_userid"]);
        //                    username = Convert.ToString(dtTkenData.Rows[0]["_username"]);
        //                    validateToken = Convert.ToBoolean(dtTkenData.Rows[0]["_validation"]);
        //                }


        //                if (validateToken)
        //                {

        //                    DataTable dtDetails = new DataTable();

        //                    DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);

        //                    int RoleID = 0;
        //                    int BusinessType = 0;
        //                    if (dtLoginInfo.Rows.Count > 0)
        //                    {
        //                        RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
        //                        BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
        //                    }

        //                    dtDetails = DBUtilities.VehicleRepository.VehicleSummaryDetails(username, vehicleregno, BusinessType);
        //                    if (dtDetails.Rows.Count > 0)
        //                    {

        //                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Vehicle_BL.VehicleSummaryResponse(dtDetails));
        //                    }
        //                    else
        //                    {
        //                        return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Records not found."));
        //                    }


        //                }
        //                else
        //                {
        //                    return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("Invalid Token."));

        //                }
        //            }
        //            else
        //            {
        //                return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Invalid Token."));

        //            }
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}
        //#endregion

        #region MTBD VehicleSummary  Details
        [HttpGet]
        [Route("api/vehiclesSummary/{vehicleregno}")]
        public HttpResponseMessage MTBDvehiclesSummaryDetails(string vehicleregno)
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
                            if (BusinessType == 4)
                            {
                                dtDetails = DBUtilities.VehicleRepository.MTBDVehicleSummaryDetails(username, vehicleregno, BusinessType);
                            }
                            else
                            {
                                dtDetails = DBUtilities.VehicleRepository.VehicleSummaryDetails(username, vehicleregno, BusinessType);
                            }

                            if (dtDetails.Rows.Count > 0)
                            {
                                if (BusinessType == 4)
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK,  BLUtilities.Vehicle_BL.MTBDVehicleSummaryResponse(dtDetails));
                                }
                                else
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Vehicle_BL.VehicleSummaryResponse(dtDetails));
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, Common_BL.Response(ex.Message));
               
            }
        }
        #endregion

        //#region   VehicleInformation
        //[HttpGet]
        //[Route("api/liveVehicleInformation/{vehicleregno}")]
        //public HttpResponseMessage VehicleInformation(string vehicleregno)
        //{
        //    System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
        //    string token = string.Empty;
        //    try
        //    {
        //        if (headers.Contains("token"))
        //        {
        //            if (headers.GetValues("token") != null && Convert.ToString(headers.GetValues("token")) != "")
        //            {
        //                token = headers.GetValues("token").First();
        //            }
        //        }
        //        if (ModelState.IsValid)
        //        {
        //            if (token != "")
        //            {
        //                bool validateToken = false;
        //                string username = string.Empty;
        //                string userid = string.Empty;

        //                DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);

        //                if (dtTkenData.Rows.Count > 0)
        //                {
        //                    userid = Convert.ToString(dtTkenData.Rows[0]["_userid"]);
        //                    username = Convert.ToString(dtTkenData.Rows[0]["_username"]);
        //                    validateToken = Convert.ToBoolean(dtTkenData.Rows[0]["_validation"]);
        //                }
        //                if (validateToken)
        //                {
        //                    DataTable dtDetails = new DataTable();
        //                    DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
        //                    int RoleID = 0;
        //                    int BusinessType = 0;
        //                    if (dtLoginInfo.Rows.Count > 0)
        //                    {
        //                        RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
        //                        BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
        //                    }
        //                    dtDetails = DBUtilities.VehicleRepository.VehicleInformation(username, vehicleregno, BusinessType);
        //                    if (dtDetails.Rows.Count > 0)
        //                    {

        //                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Vehicle_BL.VehicleInformationResponse(dtDetails));
        //                    }
        //                    else
        //                    {
        //                        return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Records not found."));
        //                    }
        //                }
        //                else
        //                {
        //                    return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("Invalid Token."));
        //                }
        //            }
        //            else
        //            {
        //                return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Invalid Token."));
        //            }
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}
        //#endregion

        #region MTBD  VehicleInformation

       
        [HttpGet]
        [Route("api/liveVehicleInformation/{vehicleregno}")]
        public HttpResponseMessage MTBDVehicleInformation(string vehicleregno)
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
                        DataTable dtDetailsRank = new DataTable();
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
                            if (BusinessType == 4)
                            {
                                dtDetails = DBUtilities.VehicleRepository.MTBDVehicleInformation(username, vehicleregno, BusinessType);



                                dtDetails.Columns.Add(new DataColumn("DriverName", typeof(System.String)));


                                dtDetailsRank = DBUtilities.VehicleRepository.VehicleDriverMapping(username, BusinessType);

                                for (int i = 0; i < dtDetails.Rows.Count; i++)
                                {

                                    var rows = from row in dtDetailsRank.AsEnumerable()
                                               where row.Field<string>("RegistrationNumber").Trim() == dtDetails.Rows[i]["RegistrationNumber"].ToString()
                                               select row;
                                    if (rows.Any())
                                    //if(!string.IsNullOrEmpty(str))
                                    {
                                        DataTable dataTable = rows.CopyToDataTable();



                                        dtDetails.Rows[i]["DriverName"] = dataTable.Rows[0]["DriverName"].ToString();   // or set it to some other value

                                    }
                                    else
                                    {
                                        dtDetails.Rows[i]["DriverName"] = "";
                                    }
                                }
                            }
                            else
                            {
                                dtDetails = DBUtilities.VehicleRepository.VehicleSummaryDetails(username, vehicleregno, BusinessType);
                            }
                            if (dtDetails.Rows.Count > 0)
                            {
                                if (BusinessType == 4)
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Vehicle_BL.MTBDVehicleInformationResponse(dtDetails));
                                }
                                else
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Vehicle_BL.VehicleInformationResponse(dtDetails));
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, Common_BL.Response(ex.Message));
               
            }
        }
        #endregion

        #region Vehicle Location History Details
        [HttpGet]
        [Route("api/LocationHistory/{vehicleregno}")]
        public HttpResponseMessage VehicleLocationHistoryDetails(string vehicleregno, string startDate, string endDate)
        {

            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            try
            {
                var _startDate = Common.BuildDateTimeFromYAFormat(startDate);
                var _endDate = Common.BuildDateTimeFromYAFormat(endDate);
                var result =Common.DateCompare(_startDate, _endDate);
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

                            dtalert = DBUtilities.VehicleRepository.VehicleLocationHistory(username, vehicleregno, Convert.ToDateTime(_startDate), Convert.ToDateTime(_endDate), BusinessType);
                            if (dtalert.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Vehicle_BL.VehicleLocationHistoryResponse(dtalert));
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
                 else
                 {
                     return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response("startDate should not be greater than endDate."));

                 }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, Common_BL.Response(ex.Message));
                
            }
        }
        #endregion

        #region single Vehicle Alerts Details
        [HttpGet]
        [Route("api/vehicleAlerts/{vehicleregno}")]
        public HttpResponseMessage SingleVehicleAlerts(string vehicleregno, string startDate, string endDate)
        {

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
                if (headers.Contains("apikey"))
                {
                    if (headers.GetValues("apikey") != null && Convert.ToString(headers.GetValues("apikey")) != "")
                    {
                        apikey = headers.GetValues("apikey").First();
                    }
                }
                if (result < 0)
                {
                if (ModelState.IsValid)
                {
                    if (token != "")
                    {

                        // bool validateToken = JWTTokenGenration.JWTTokenGenration.VerifyJWT(token);

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

                            dtalert = DBUtilities.VehicleRepository.SingleVehicleAlerts(username, vehicleregno, Convert.ToDateTime(startDate), Convert.ToDateTime(endDate), BusinessType);
                            if (dtalert.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Vehicle_BL.SingleVehicleAlertsResponse(dtalert));
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
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response("startDate should not be greater than endDate."));

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, Common_BL.Response(ex.Message));
               
            }
        }
        #endregion
       
        #region Vehicle Alerts Details
        [HttpGet]
        [Route("api/vehicleAlerts")]
        
        public HttpResponseMessage VehicleAlerts(string startDate, string endDate)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            try
            {
                var _startDate = Common.BuildDateTimeFromYAFormat(startDate);
                var _endDate = Common.BuildDateTimeFromYAFormat(endDate);
               var result= Common.DateCompare(_startDate, _endDate);
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
                                dtalert = DBUtilities.VehicleRepository.VehicleAlerts(username, Convert.ToDateTime(_startDate), Convert.ToDateTime(_endDate), BusinessType);
                                if (dtalert.Rows.Count > 0)
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Vehicle_BL.VehicleAlertsResponse(dtalert));
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
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response("startDate should not be greater than endDate."));

                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, Common_BL.Response(ex.Message));
               
            }
        }
        #endregion

        #region MTBD vehicle Mapping With Driver   
        [HttpPost]
        [Route("api/vehicleMappingWithDriver/{vehicleRegNo}/{driverId}")]
        public HttpResponseMessage vehicleMappingWithDriver(string vehicleRegNo, string driverId)
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
                        Int32 result = 2;
                        //bool result = false;
                        string username = string.Empty;
                        string userid = string.Empty;
                        DataTable dtDetailsRank = new DataTable();
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
                            result = DBUtilities.VehicleRepository.DriverVehicleMapping(username, vehicleRegNo, Convert.ToInt32(driverId), BusinessType);

                            if (result == 0)
                            {
                                dtDetails = DBUtilities.VehicleRepository.VehicleDetailsMTBD(username, BusinessType);


                                var rowsdtDetails = from row in dtDetails.AsEnumerable()
                                                    where row.Field<string>("RegistrationNumber").Trim() == vehicleRegNo
                                               select row;
                                if (rowsdtDetails.Any())
                                //if(!string.IsNullOrEmpty(str))
                                {
                                    dtDetails = rowsdtDetails.CopyToDataTable();
                                }
                                else
                                {
                                    dtDetails = null;
                                }


                                if (dtDetails != null)
                                {
                                    dtDetails.Columns.Add(new DataColumn("DriverName", typeof(System.String)));

                                    dtDetailsRank = DBUtilities.VehicleRepository.VehicleDriverMapping(username, BusinessType);

                                    // for (int i = 0; i < dtDetails.Rows.Count; i++)
                                    // {

                                    var rows = from row in dtDetailsRank.AsEnumerable()
                                               where row.Field<int>("driverid") == Convert.ToInt32(driverId)
                                               select row;
                                    if (rows.Any())
                                    //if(!string.IsNullOrEmpty(str))
                                    {
                                        DataTable dataTable = rows.CopyToDataTable();



                                        dtDetails.Rows[0]["DriverName"] = dataTable.Rows[0]["DriverName"].ToString();   // or set it to some other value

                                    }
                                    else
                                    {
                                        dtDetails.Rows[0]["DriverName"] = "";
                                    }
                                    // }

                                }
                                if (dtDetails != null)
                               // if (dtDetails.Rows.Count > 0)
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Vehicle_BL.MTBDVehicleResponse(dtDetails));
                                }
                                else
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not found."));
                                }
                            }
                            else if (result==1)
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Vehicle is already assigned to the driver."));
                                }
                            else
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not found."));
                                }
                        }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("Records not updated."));
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, Common_BL.Response(ex.Message));
                
            }
        }
        #endregion    

        #region MTBD vehicle unMapping With Driver
        [HttpPost]
        [Route("api/vehicleMappingWithDriver/{vehicleRegNo}")]
        public HttpResponseMessage vehicleUNMappingWithDriver(string vehicleRegNo)
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
                       // bool result = false;
                        Int32 result = 2;
                        string username = string.Empty;
                        string userid = string.Empty;
                        DataTable dtDetailsRank = new DataTable();
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
                            result = DBUtilities.VehicleRepository.DriverVehicleUNMapping(username, vehicleRegNo, BusinessType);

                            if (result == 0)
                            {
                                dtDetails = DBUtilities.VehicleRepository.VehicleDetailsMTBD(username, BusinessType);


                                var rowsdtDetails = from row in dtDetails.AsEnumerable()
                                                    where row.Field<string>("RegistrationNumber").Trim() == vehicleRegNo
                                                    select row;
                                if (rowsdtDetails.Any())
                                //if(!string.IsNullOrEmpty(str))
                                {
                                    dtDetails = rowsdtDetails.CopyToDataTable();
                                }
                                else
                                {
                                    dtDetails = null;
                                }


                                if (dtDetails != null)
                                {
                                    dtDetails.Columns.Add(new DataColumn("DriverName", typeof(System.String)));

                                    dtDetails.Rows[0]["DriverName"] = "";
                                    

                                }
                                if (dtDetails != null)
                                // if (dtDetails.Rows.Count > 0)
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Vehicle_BL.MTBDVehicleResponse(dtDetails));
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
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not updated."));
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, Common_BL.Response(ex.Message));
                
            }
        }
        #endregion    
    }
}
﻿    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using log4net;
    using DigisensePlatformAPIs.Models;

    namespace DigisensePlatformAPIs.Controllers
    {
        public class ReportController : ApiController
        {
            private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            #region Report Summary 8.02 
            [HttpGet]
            [Route("api/reportsummary/platform/mtbd")]
            public HttpResponseMessage ReportSummaryPlatformMTBD()
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

                                dtDetails = DBUtilities.ReportRepository.ReportSummaryPlatformMTBD(username, BusinessType);
                                if (dtDetails.Rows.Count > 0)
                                {

                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.ReportSummaryPlatformMTBD(dtDetails));
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

            #region Report Summary 8.03

            [HttpGet]
            [Route("api/report/{vehicleRegNo}")]
            public HttpResponseMessage ReportSummaryForSpecificVehicle(string vehicleRegNo)
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
                string token = string.Empty;
                string apikey = string.Empty;
                try
                {
                    int b = 0;
                    int a = 3 / b;
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

                                dtDetails = DBUtilities.ReportRepository.ReportSummaryForSpecificVehicle(username, BusinessType);
                                if (dtDetails.Rows.Count > 0)
                                {

                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.ReportSummaryForSpecificVehicle(dtDetails));
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
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.DefaultResponse(404, ex.Message.ToString()));

                }

            }

            #endregion

            #region   Vehicle Health  Details 8.05 Periority 1.18
            [HttpGet]
            [Route("api/reportSummary/platform/{platform}/health")]
            public HttpResponseMessage VehicleHealthStatus(string platform)
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
                            DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);
                            if (dtTkenData.Rows.Count > 0)
                            {
                                userid = Convert.ToString(dtTkenData.Rows[0]["_userid"]);
                                username = Convert.ToString(dtTkenData.Rows[0]["_username"]);
                                validateToken = Convert.ToBoolean(dtTkenData.Rows[0]["_validation"]);
                            }
                            if (validateToken)
                            {
                                DataSet dtStatus = new DataSet();
                                DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                                int RoleID = 0;
                                int BusinessType = 0;
                                if (dtLoginInfo.Rows.Count > 0)
                                {
                                    RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                    BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                                }

                                Models.Common.platform enumplatform = (Models.Common.platform)BusinessType;

                                if (enumplatform.ToString() == platform.ToString())
                                {
                                    dtStatus = DBUtilities.ReportRepository.VehicleHealthStatus(username, BusinessType);
                                    if (dtStatus.Tables.Count > 0)
                                    {
                                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehicleHealthStatusResponse(dtStatus));
                                    }
                                    else
                                    {
                                        return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Records not found."));
                                    }
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

            #region List of Vehicle Status  8.06 Perirority 1.18
            [HttpGet]
            [Route("api/reportSummary/platform/{platform}/status")]
            public HttpResponseMessage VehicleStatus(string platform)
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
                            DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);
                            if (dtTkenData.Rows.Count > 0)
                            {
                                userid = Convert.ToString(dtTkenData.Rows[0]["_userid"]);
                                username = Convert.ToString(dtTkenData.Rows[0]["_username"]);
                                validateToken = Convert.ToBoolean(dtTkenData.Rows[0]["_validation"]);
                            }
                            if (validateToken)
                            {
                                DataTable dtStatus = new DataTable();
                                DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                                int RoleID = 0;
                                int BusinessType = 0;
                                if (dtLoginInfo.Rows.Count > 0)
                                {
                                    RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                    BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                                }

                                Models.Common.platform enumplatform = (Models.Common.platform)BusinessType;

                                if (enumplatform.ToString() == platform.ToString())
                                {
                                    dtStatus = DBUtilities.ReportRepository.VehicleStatus(username, BusinessType);
                                    if (dtStatus.Rows.Count > 0)
                                    {
                                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehicleStatusResponse(dtStatus));
                                    }
                                    else
                                    {
                                        return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Records not found."));
                                    }
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

            #region /reportsummary/platform/mtbd/vehiclemovement/usagetime/{vehicleRegNo} 8.03 Periority 2.09
            [HttpGet]
            [Route("api/reportsummary/platform/mtbd/vehiclemovement/usagetime/{vehicleRegNo}")]
            public HttpResponseMessage VehilceMovementUsageTimeForSpecificVehilce(string vehicleRegNo, string startDate, string endDate)
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

                    if (ModelState.IsValid)
                    {
                        if (result <= 0)
                        {
                            if (token != "")
                            {
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

                                    dtDetails = DBUtilities.ReportRepository.VehicleMovementUsageTime(username, BusinessType, vehicleRegNo, _startDate, _endDate);
                                    if (dtDetails.Rows.Count > 0)
                                    {

                                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehilceMovementUsageTime(dtDetails));
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
                            return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(" Start Date should come earlier from End Date"));
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
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.DefaultResponse(404, ex.Message));

                }
            }

            #endregion

            #region   api/reportsummary/platform/mtbd/vehiclemovement/speeddata/{vehicleRegNo} 8.03 Periority 2.09
            [HttpGet]
            [Route("api/reportsummary/platform/mtbd/vehiclemovement/speeddata/{vehicleRegNo}")]
            public HttpResponseMessage PlatformVehilceMovementSpeedData(string vehicleRegNo, string startDate, string endDate)
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
                string token = string.Empty;
                string apikey = string.Empty;
                var _startDate = Common.BuildDateTimeFromYAFormat(startDate);
                var _endDate = Common.BuildDateTimeFromYAFormat(endDate);
                var result = Common.DateCompare(_startDate, _endDate);
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
                        if (result <= 0)
                        {
                            if (token != "")
                            {
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

                                    dtDetails = DBUtilities.ReportRepository.PlatformVehilceMovementSpeedData(username, BusinessType, vehicleRegNo, _startDate, _endDate);
                                    if (dtDetails.Rows.Count > 0)
                                    {

                                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.PlatformVehilceMovementSpeedResponse(dtDetails));
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
                            return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.DefaultResponse(404, "startDate should not be greater than endDate."));
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

            #region /reportsummary/platform/mtbd/vehiclemovement/enginerpm/{vehicleRegNo} 8.03 Periority 2.09
            [HttpGet]
            [Route("api/reportsummary/platform/mtbd/vehiclemovement/enginerpm/{vehicleRegNo}")]
            public HttpResponseMessage VehilceMoevementEngineRpm(string vehicleRegNo, string startDate, string endDate)
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
                string token = string.Empty;
                string apikey = string.Empty;
                var _startDate = Common.BuildDateTimeFromYAFormat(startDate);
                var _endDate = Common.BuildDateTimeFromYAFormat(endDate);
                var result = Common.DateCompare(_startDate, _endDate);
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
                        if (result <= 0)
                        {
                            if (token != "")
                            {
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

                                    dtDetails = DBUtilities.ReportRepository.VehicleMovementEngineRpm(username, BusinessType, vehicleRegNo, _startDate, _endDate);
                                    if (dtDetails.Rows.Count > 0)
                                    {

                                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehilceMovementEngineRpm(dtDetails));
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
                            return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.DefaultResponse(404, "startDate should not be greater than endDate."));
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
                #region  /reportsummary/platform/mtbd/vehiclemovement/vehiclemovementsummary/{vehicleRegNo} 8.03 Periority 2.09
            [HttpGet]
            [Route("api/reportsummary/platform/mtbd/vehiclemovement/vehiclemovementsummary/{vehicleRegNo}")]
            public HttpResponseMessage VehilceMovementSummary(string vehicleRegNo, string startDate, string endDate)
            {
                System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
                string token = string.Empty;
                string apikey = string.Empty;
                var _startDate = Common.BuildDateTimeFromYAFormat(startDate);
                var _endDate = Common.BuildDateTimeFromYAFormat(endDate);
                var result = Common.DateCompare(_startDate, _endDate);
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
                        if (result <= 0)
                        {
                            if (token != "")
                            {
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

                                    dtDetails = DBUtilities.ReportRepository.VehicleMovementSummary(username, BusinessType, vehicleRegNo, _startDate, _endDate);
                                    if (dtDetails.Rows.Count > 0)
                                    {

                                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehilceMovementSummary(dtDetails));
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
                            return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.DefaultResponse(404, "startDate should not be greater than endDate."));
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

            #region Other Reports From Swagger

            #region GET /reportsummary/platform/mtbd/vehiclemovement/vehiclemovementreport/{vehicleRegNo}
            [HttpGet]
            [Route("api/reportsummary/platform/mtbd/vehiclemovement/vehiclemovementreport/{vehicleRegNo}")]
            public HttpResponseMessage VehilceMovementReport(string vehicleRegNo, string startDate, string endDate)
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

                                dtDetails = DBUtilities.ReportRepository.VehicleMovementReport(username, BusinessType);
                                if (dtDetails.Rows.Count > 0)
                                {

                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehicleMovementReport(dtDetails));
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

            #region GET /reportsummary/platform/mtbd/alerts/vehiclealerts/{vehicleRegNo}
            [HttpGet]
            [Route("api/reportsummary/platform/mtbd/alerts/vehiclealerts/{vehicleRegNo}")]
            public HttpResponseMessage VehicleAlerts(string vehilceRegNo, string startDate, string endDate)
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

                                dtDetails = DBUtilities.ReportRepository.VehicleAlerts(username, BusinessType);
                                if (dtDetails.Rows.Count > 0)
                                {

                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehicleAlerts(dtDetails));
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

            #region GET /reportsummary/platform/mtbd/alerts/violation/{vehicleRegNo}

            [HttpGet]
            [Route("api/reportsummary/platform/mtbd/alerts/violation/{vehicleRegNo}")]
            public HttpResponseMessage AlertsViolation(string vehicleRegNo, string startDate, string endDate)
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

                                dtDetails = DBUtilities.ReportRepository.AlertsViolation(username, BusinessType);
                                if (dtDetails.Rows.Count > 0)
                                {

                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.AlertsViolation(dtDetails));
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

            #region  /reportsummary/platform/mtbd/alerts/alertssummary/{vehicleRegNo}
            [HttpGet]
            [Route("api/reportsummary/platform/mtbd/alerts/alertssummary/{vehicleRegNo}")]
            public HttpResponseMessage ReportAlertsSummary(string vehicleRegNo, string startDate, string endDate)
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

                                dtDetails = DBUtilities.ReportRepository.AlertsSummary(username, BusinessType);
                                if (dtDetails.Rows.Count > 0)
                                {

                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.AlertsSummaryResponse(dtDetails));
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

            #region /reportsummary/platform/mtbd/delivery/vehicleusage/{vehicleRegNo}

            public HttpResponseMessage VehicleUsage(string vehicleRegNo, string startDate, string endDate)
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

                                dtDetails = DBUtilities.ReportRepository.VehicleUsage(username, BusinessType);
                                if (dtDetails.Rows.Count > 0)
                                {

                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehicleUsage(dtDetails));
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

            #region GET /reportsummary/platform/mtbd/delivery/vehicleusagesummary/{vehicleRegNo}
            public HttpResponseMessage VehicleUsageSummary(string vehicleRegNo, string startDate, string endDate)
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

                                dtDetails = DBUtilities.ReportRepository.VehicleUsageSummary(username, BusinessType);
                                if (dtDetails.Rows.Count > 0)
                                {

                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehicleReportSummary(dtDetails));
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

            #region /reportsummary/platform/mtbd/vehiclehealth/vehiclehealthsummary/{vehicleRegNo}
            public HttpResponseMessage VehicleHealthSummary(string vehicleRegNo, string startDate, string endDate)
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

                                dtDetails = DBUtilities.ReportRepository.VehicleHealthSummary(username, BusinessType);
                                if (dtDetails.Rows.Count > 0)
                                {

                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehicleHealthSummary(dtDetails));
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

            #region GET /reportsummary/platform/mtbd/driver/distancecovered
            public HttpResponseMessage DriverDistanceCovered(string startDate, string endDate)
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

                                dtDetails = DBUtilities.ReportRepository.DistanceCovered(username, BusinessType);
                                if (dtDetails.Rows.Count > 0)
                                {

                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.DistanceCovered(dtDetails));
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

            #region GET /report/delivery/{vehicleRegNo}/{delivery}
            [HttpGet]
            [Route("api/report/delivery/{vehicleRegNo}/{delivery}")]
            public HttpResponseMessage ReportSummaryDelivery(string vehicleRegNo, string delivery)
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

                                dtDetails = DBUtilities.ReportRepository.ReportSummaryDeliveryVehicle(username, BusinessType);
                                if (dtDetails.Rows.Count > 0)
                                {

                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.ReportSummaryDeliveryVehicle(dtDetails));
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

            #region Get /report/vehiclehealth/{vehicleRegNo}/{vehiclehealth}
            [HttpGet]
            [Route("api/report/vehiclehealth/{vehicleRegNo}/{vehiclehealth}")]
            public HttpResponseMessage ReportSummaryVehicleHealth(string vehicleRegNo, string vehiclehealth)
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

                                dtDetails = DBUtilities.ReportRepository.VehicleHealth(username, BusinessType);
                                if (dtDetails.Rows.Count > 0)
                                {

                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehicleHealth(dtDetails));
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

            #region Get /report/alerts/{vehicleRegNo}/{alerts}
            [HttpGet]
            [Route("api/report/alerts/{vehicleRegNo}/{alerts}")]
            public HttpResponseMessage ReportsAlerts(string vehicleRegNo, string alerts, string startDate, string endDate)
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

                                dtDetails = DBUtilities.ReportRepository.ReportAlerts(username, BusinessType);
                                if (dtDetails.Rows.Count > 0)
                                {

                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.ReportAlerts(dtDetails));
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

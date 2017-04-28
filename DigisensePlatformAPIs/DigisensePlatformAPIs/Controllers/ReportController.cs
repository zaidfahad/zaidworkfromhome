﻿using System;
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

        #region Completed

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
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.ReportSummaryPlatformMTBD());
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));

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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));

            }
        }
        #endregion

        #region  /report/platform/mtbd/vehiclemovement/usagetime/{vehicleRegNo} 8.03 Periority 2.09
        /*
        GET /report/platform/mtbd/vehiclemovement/usagetime/{vehicleRegNo}
        */
        [HttpGet]
        [Route("api/report/platform/mtbd/vehiclemovement/usagetime/{vehicleRegNo}")]
        public HttpResponseMessage VehilceMovementUsageTimeForSpecificVehilce(string vehicleRegNo, string startDate, string endDate)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            DateTime _startDate = new DateTime();
            DateTime _endDate = new DateTime();
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
                var inputValidation = Common.BuildDateTimeFromYAFormatV1(startDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _startDate = inputValidation.Item3;
                }
                inputValidation = Common.BuildDateTimeFromYAFormatV1(endDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _endDate = inputValidation.Item3;
                }
                var inputValidationCompare = Common.DateCompareV1(_startDate, _endDate);
                if (!inputValidationCompare.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidationCompare.Item2));
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

                            dtDetails = DBUtilities.ReportRepository.VehicleMovementUsageTime(username, BusinessType, vehicleRegNo, _startDate, _endDate);
                            if (dtDetails.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehilceMovementUsageTime(dtDetails));
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.DefaultResponse(404, ex.Message));

            }
        }

        #endregion

        #region   api/report/platform/mtbd/vehiclemovement/speeddata/{vehicleRegNo} 8.03 Periority 2.09
        [HttpGet]
        [Route("api/report/platform/mtbd/vehiclemovement/speeddata/{vehicleRegNo}")]
        public HttpResponseMessage PlatformVehilceMovementSpeedData(string vehicleRegNo, string startDate, string endDate)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            DateTime _startDate = new DateTime();
            DateTime _endDate = new DateTime();
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
                var inputValidation = Common.BuildDateTimeFromYAFormatV1(startDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _startDate = inputValidation.Item3;
                }
                inputValidation = Common.BuildDateTimeFromYAFormatV1(endDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _endDate = inputValidation.Item3;
                }
                var inputValidationCompare = Common.DateCompareV1(_startDate, _endDate);
                if (!inputValidationCompare.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidationCompare.Item2));
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

                            dtDetails = DBUtilities.ReportRepository.PlatformVehilceMovementSpeedData(username, BusinessType, vehicleRegNo, _startDate, _endDate);
                            if (dtDetails.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.PlatformVehilceMovementSpeedResponse(dtDetails));
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));

            }
        }
        #endregion

        #region /report/platform/mtbd/vehiclemovement/enginerpm/{vehicleRegNo} 8.03 Periority 2.09
        [HttpGet]
        [Route("api/report/platform/mtbd/vehiclemovement/enginerpm/{vehicleRegNo}")]
        public HttpResponseMessage VehilceMoevementEngineRpm(string vehicleRegNo, string startDate, string endDate)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            DateTime _startDate = new DateTime();
            DateTime _endDate = new DateTime();
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
                var inputValidation = Common.BuildDateTimeFromYAFormatV1(startDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _startDate = inputValidation.Item3;
                }
                inputValidation = Common.BuildDateTimeFromYAFormatV1(endDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _endDate = inputValidation.Item3;
                }
                var inputValidationCompare = Common.DateCompareV1(_startDate, _endDate);
                if (!inputValidationCompare.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidationCompare.Item2));
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

                            dtDetails = DBUtilities.ReportRepository.VehicleMovementEngineRpm(username, BusinessType, vehicleRegNo, _startDate, _endDate);
                            if (dtDetails.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehilceMovementEngineRpm(dtDetails));
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));

            }
        }
        #endregion
        
        #region /report/platform/mtbd/vehiclemovement/vehiclemovementsummary/{vehicleRegNo} 8.03 Periority 2.09
        /*
        /report/platform/mtbd/vehiclemovement/vehiclemovementsummary/{vehicleRegNo}
        */
        [HttpGet]
        [Route("api/report/platform/mtbd/vehiclemovement/vehiclemovementsummary/{vehicleRegNo}")]
        public HttpResponseMessage VehilceMovementSummary(string vehicleRegNo, string startDate, string endDate)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            DateTime _startDate = new DateTime();
            DateTime _endDate = new DateTime();
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
                var inputValidation = Common.BuildDateTimeFromYAFormatV1(startDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _startDate = inputValidation.Item3;
                }
                inputValidation = Common.BuildDateTimeFromYAFormatV1(endDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _endDate = inputValidation.Item3;
                }
                var inputValidationCompare = Common.DateCompareV1(_startDate, _endDate);
                if (!inputValidationCompare.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidationCompare.Item2));
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

                            dtDetails = DBUtilities.ReportRepository.VehicleMovementSummary(username, BusinessType, vehicleRegNo, _startDate, _endDate);
                            if (dtDetails.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehilceMovementSummary(dtDetails));
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));

            }
        }

        #endregion

        #region GET /report/platform/mtbd/vehiclemovement/vehiclemovementreport/{vehicleRegNo}

        [HttpGet]
        [Route("api/report/platform/mtbd/vehiclemovement/vehiclemovementreport/{vehicleRegNo}")]
        public HttpResponseMessage VehilceMovementReport(string vehicleRegNo, string startDate, string endDate)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            DateTime _startDate = new DateTime();
            DateTime _endDate = new DateTime();
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
                var inputValidation = Common.BuildDateTimeFromYAFormatV1(startDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _startDate = inputValidation.Item3;
                }
                inputValidation = Common.BuildDateTimeFromYAFormatV1(endDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _endDate = inputValidation.Item3;
                }
                var inputValidationCompare = Common.DateCompareV1(_startDate, _endDate);
                if (!inputValidationCompare.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidationCompare.Item2));
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

                            dtDetails = DBUtilities.ReportRepository.VehicleMovementReport(username, BusinessType, vehicleRegNo, _startDate, _endDate);
                            if (dtDetails.Rows.Count > 0)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehicleMovementReport(dtDetails));
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));

            }
        }


        #endregion

        #region /report/platform/mtbd/delivery/vehicleusage/{vehicleRegNo}
        /*
        GET /report/platform/mtbd/alerts/vehiclealerts/{vehicleRegNo}
        */
        [Route("api/report/platform/mtbd/delivery/vehicleusage/{vehicleRegNo}")]
        [HttpGet]
        public HttpResponseMessage VehicleUsage(string vehicleRegNo, string startDate, string endDate)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            DateTime _startDate = new DateTime();
            DateTime _endDate = new DateTime();
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
                var inputValidation = Common.BuildDateTimeFromYAFormatV1(startDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _startDate = inputValidation.Item3;
                }
                inputValidation = Common.BuildDateTimeFromYAFormatV1(endDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _endDate = inputValidation.Item3;
                }
                var inputValidationCompare = Common.DateCompareV1(_startDate, _endDate);
                if (!inputValidationCompare.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidationCompare.Item2));
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

                            dtDetails = DBUtilities.ReportRepository.VehicleUsage(username, BusinessType, vehicleRegNo, _startDate, _endDate);
                            if (dtDetails.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehicleUsage(dtDetails));
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));
            }
        }
        #endregion

        #region GET /report/platform/mtbd/alerts/vehiclealerts/{vehicleRegNo}
        /*
        GET /report/platform/mtbd/alerts/vehiclealerts/{vehicleRegNo}
        */
        [HttpGet]
        [Route("api/report/platform/mtbd/alerts/vehiclealerts/{vehicleRegNo}")]
        public HttpResponseMessage VehicleAlerts(string vehicleRegNo, string startDate, string endDate)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            DateTime _startDate = new DateTime();
            DateTime _endDate = new DateTime();
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
                var inputValidation = Common.BuildDateTimeFromYAFormatV1(startDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _startDate = inputValidation.Item3;
                }
                inputValidation = Common.BuildDateTimeFromYAFormatV1(endDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _endDate = inputValidation.Item3;
                }
                var inputValidationCompare = Common.DateCompareV1(_startDate, _endDate);
                if (!inputValidationCompare.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidationCompare.Item2));
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

                            DataSet dsDetails = new DataSet();
                            DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);

                            int RoleID = 0;
                            int BusinessType = 0;
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                            }

                            dsDetails = DBUtilities.ReportRepository.VehicleAlerts(username, BusinessType, vehicleRegNo, _startDate, _endDate);
                            bool check = false;
                            for (int icount = 0; icount < dsDetails.Tables.Count; icount++)
                            {
                                if (dsDetails.Tables[icount].Rows.Count > 0)
                                {
                                    check = true;
                                }
                            }
                            if (check)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehicleAlerts(dsDetails));
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));

            }
        }
        #endregion

        #region GET /report/platform/mtbd/alerts/violation/{vehicleRegNo}

        [HttpGet]
        [Route("api/report/platform/mtbd/alerts/violation/{vehicleRegNo}")]
        public HttpResponseMessage AlertsViolation(string vehicleRegNo, string startDate, string endDate)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            DateTime _startDate = new DateTime();
            DateTime _endDate = new DateTime();
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
                var inputValidation = Common.BuildDateTimeFromYAFormatV1(startDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _startDate = inputValidation.Item3;
                }
                inputValidation = Common.BuildDateTimeFromYAFormatV1(endDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _endDate = inputValidation.Item3;
                }
                var inputValidationCompare = Common.DateCompareV1(_startDate, _endDate);
                if (!inputValidationCompare.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidationCompare.Item2));
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

                            DataSet dsDetails = new DataSet();
                            DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);

                            int RoleID = 0;
                            int BusinessType = 0;
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                            }

                            dsDetails = DBUtilities.ReportRepository.AlertsViolation(username, BusinessType, vehicleRegNo, _startDate, _endDate);
                            bool check = false;
                            for (int icount = 0; icount < dsDetails.Tables.Count; icount++)
                            {
                                if (dsDetails.Tables[icount].Rows.Count > 0)
                                {
                                    check = true;
                                }
                            }
                            if (check)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.AlertsViolation(dsDetails));
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));

            }
        }

        #endregion

        #region  /report/platform/mtbd/alerts/alertssummary/{vehicleRegNo} 8.03
        [HttpGet]
        [Route("api/report/platform/mtbd/alerts/alertssummary/{vehicleRegNo}")]
        public HttpResponseMessage ReportAlertsSummary(string vehicleRegNo, string startDate, string endDate)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            DateTime _startDate = new DateTime();
            DateTime _endDate = new DateTime();
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
                var inputValidation = Common.BuildDateTimeFromYAFormatV1(startDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _startDate = inputValidation.Item3;
                }
                inputValidation = Common.BuildDateTimeFromYAFormatV1(endDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _endDate = inputValidation.Item3;
                }
                var inputValidationCompare = Common.DateCompareV1(_startDate, _endDate);
                if (!inputValidationCompare.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidationCompare.Item2));
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

                            dtDetails = DBUtilities.ReportRepository.AlertsSummary(username, BusinessType, vehicleRegNo, _startDate, _endDate);
                            if (dtDetails.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.AlertsSummaryResponse(dtDetails));
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));

            }
        }

        #endregion

        #region /report/platform/mtbd/vehiclehealth/vehiclehealthsummary/{vehicleRegNo}
        [Route("api/report/platform/mtbd/vehiclehealth/vehiclehealthsummary/{vehicleRegNo}")]
        [HttpGet]
        public HttpResponseMessage VehicleHealthSummary(string vehicleRegNo, string startDate, string endDate)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            DateTime _startDate = new DateTime();
            DateTime _endDate = new DateTime();
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
                var inputValidation = Common.BuildDateTimeFromYAFormatV1(startDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _startDate = inputValidation.Item3;
                }
                inputValidation = Common.BuildDateTimeFromYAFormatV1(endDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _endDate = inputValidation.Item3;
                }
                var inputValidationCompare = Common.DateCompareV1(_startDate, _endDate);
                if (!inputValidationCompare.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidationCompare.Item2));
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

                            dtDetails = DBUtilities.ReportRepository.VehicleHealthSummary(username, BusinessType, vehicleRegNo, _startDate, _endDate);
                            if (dtDetails.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehicleHealthSummary(dtDetails));
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));

            }
        }
        #endregion

        #region GET /report/platform/mtbd/delivery/vehicleusagesummary/{vehicleRegNo} 
        [Route("api/report/platform/mtbd/delivery/vehicleusagesummary/{vehicleRegNo}")]
        [HttpGet]
        public HttpResponseMessage VehicleUsageSummary(string vehicleRegNo, string startDate, string endDate)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            DateTime _startDate = new DateTime();
            DateTime _endDate = new DateTime();
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
                var inputValidation = Common.BuildDateTimeFromYAFormatV1(startDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _startDate = inputValidation.Item3;
                }
                inputValidation = Common.BuildDateTimeFromYAFormatV1(endDate);
                if (!inputValidation.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidation.Item2));
                }
                else
                {
                    _endDate = inputValidation.Item3;
                }
                var inputValidationCompare = Common.DateCompareV1(_startDate, _endDate);
                if (!inputValidationCompare.Item1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(inputValidationCompare.Item2));
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

                            dtDetails = DBUtilities.ReportRepository.VehicleUsageSummary(username, BusinessType, vehicleRegNo, _startDate, _endDate);
                            if (dtDetails.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.VehicleReportSummary(dtDetails));
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
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

        #region Pending swagger 2.0 added some new also need to structures of that also

        #region Other Reports From Swagger

        #region Report Summary  GET /report/{vehicleRegNo}

        [HttpGet]
        [Route("api/report/{vehicleRegNo}")]
        public HttpResponseMessage ReportSummaryForSpecificVehicle(string vehicleRegNo)
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

                            dtDetails = DBUtilities.ReportRepository.ReportSummaryForSpecificVehicle(username, BusinessType);
                            if (dtDetails.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Report_BL.ReportSummaryForSpecificVehicle(dtDetails));
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
                        return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("Invalid Token."));

                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.DefaultResponse(404, ex.Message.ToString()));

            }

        }

        #endregion

        #region GET /report/platform/mtbd/driver/distancecovered
        [Route("api/report/platform/mtbd/driver/distancecovered")]
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
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
                    return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
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

        #endregion
    }
}

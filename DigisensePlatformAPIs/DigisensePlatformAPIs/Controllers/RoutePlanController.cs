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
    public class RoutePlanController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Route Plan Details   [VerNo - 10.01]
        [HttpGet]
        [Route("api/routePlan")]
        public HttpResponseMessage routePlan()
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
                            dtalert = DBUtilities.RoutePlanRepository.GetAllRoutePlan(username, BusinessType);
                            if (dtalert.Rows.Count > 0)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.RoutePlan_BL.ListAllRoutePlanResponse(dtalert));
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        #endregion

        #region Route Plan Post   [VerNo - 10.02]

        [HttpPost]
        [Route("api/routePlan")]
        public HttpResponseMessage routePlanPost([FromBody]RoutePlanRequestPost routeplanPostrequest)
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
                            dtalert = DBUtilities.RoutePlanRepository.CreateRoutePlanPost(username, BusinessType, routeplanPostrequest);
                            if (dtalert.Rows.Count > 0)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.RoutePlan_BL.RoutePlanPostResponse(dtalert));
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        #endregion

        #region Route Plan Post  10.03
        [HttpPost]
        [Route("api/routePlan/{routeName}/mapVehicle")]
        public HttpResponseMessage AssignRouteToVehicles([FromBody]List<RoutePlanAssginRoute> routeplanAssgin, string routeName)
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
                            dtalert = DBUtilities.RoutePlanRepository.RoutePlanAssignToVehicles(username, BusinessType, routeplanAssgin);
                            if (dtalert.Rows.Count > 0)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.RoutePlan_BL.RoutePlanDelete(dtalert));
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        #endregion

        #region Route Plan Get 10.04
        [HttpPut]
        [Route("api/vehicles/{vehicleRegNo}/routes")]
        public HttpResponseMessage ViewAssignTripForVehicle(string vehicleRegNo)
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
                            dtalert = DBUtilities.RoutePlanRepository.ViewAssignTripForVehicle(username, BusinessType, vehicleRegNo);
                            if (dtalert.Rows.Count > 0)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.RoutePlan_BL.ViewAssignTripForVehicleResponse(dtalert));
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        #endregion

        #region Route Plan Details   [VerNo - 10.05]
        [HttpGet]
        [Route("api/routePlan/{routeName}")]
        public HttpResponseMessage routePlan(string routeName)
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

                            dtalert = DBUtilities.RoutePlanRepository.RoutePlan(username, routeName, BusinessType);
                            if (dtalert.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.RoutePlan_BL.RoutePlanResponse(dtalert));
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        #endregion

        #region Route Plan Details   [VerNo - 10.06]
        [HttpPut]
        [Route("api/routePlan/{routeName}")]
        public HttpResponseMessage UpdateOnGoingTrip(List<UpdateOnGoingTripRequest> updateongoingTriprequest)
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

                            dtalert = DBUtilities.RoutePlanRepository.UpdateOnGoingTrip(username, BusinessType, updateongoingTriprequest);
                            if (dtalert.Rows.Count > 0)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.RoutePlan_BL.OnGoingTripsResponse(dtalert));
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        #endregion

        #region Route Plan Details   [VerNo - 10.07]
        [HttpGet]
        [Route("api/vehicles/{vehicleRegNo}/currenttrip")]
        public HttpResponseMessage routePlan1007(string routeName)
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

                            dtalert = DBUtilities.RoutePlanRepository.RoutePlan(username, routeName, BusinessType);
                            if (dtalert.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.RoutePlan_BL.RoutePlanResponse(dtalert));
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        #endregion

        #region Route Plan Details   [VerNo - 10.08]
        [HttpDelete]
        [Route("api/routePlan/{routeName}")]
        public HttpResponseMessage routePlan1008(string routeName)
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

                            dtalert = DBUtilities.RoutePlanRepository.RoutePlan(username, routeName, BusinessType);
                            if (dtalert.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.RoutePlan_BL.RoutePlanResponse(dtalert));
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        #endregion
    }
}
﻿using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using log4net;
using DigisensePlatformAPIs.Utilities;
namespace DigisensePlatformAPIs.Controllers
{
    public class GeofenceController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region View All Geofence
        [Route("api/geofence")]
        [HttpGet]
        public HttpResponseMessage Geofence()
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

                        DataTable dt = new DataTable();
                        DataTable dtGeofenceDetails = new DataTable();

                        DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                        int RoleID = 0;
                        int BusinessType = 0;
                        if (dtLoginInfo.Rows.Count > 0)
                        {
                            RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                            BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                        }


                        if (ModelState.IsValid)
                        {
                            dtGeofenceDetails = DBUtilities.GeofenceRepository.Geofence(username, BusinessType);
                        }
                        else
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                        }
                        if (dtGeofenceDetails.Rows.Count > 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Geofence_BL.GeofenceAllResponse(dtGeofenceDetails));

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
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));
            }
        }
        #endregion

        #region Create Geofence  [2.01]
        [Route("api/geofence")]
        [HttpPost]
        public HttpResponseMessage InsertGeofence([FromBody]  List<Geofence> geofence)
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
                
                        DataTable dt = new DataTable();
                        DataTable dtGeofenceDetails = new DataTable();
                        DataTable dtgetDetails = new DataTable();
                        DataTable dataTable = new DataTable();
                        
                        DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                        int RoleID = 0;
                        int BusinessType = 0;
                        if (dtLoginInfo.Rows.Count > 0)
                        {
                            RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                            BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                        }
                        var geofencename=string.Empty;
                   
                        var geofenceboundary = "POLYGON((";
                        var geoboundarydata = string.Empty;

                        dtgetDetails = DBUtilities.GeofenceRepository.Geofence(username, BusinessType);

                        var rows = from row in dtgetDetails.AsEnumerable()
                                   where row.Field<string>("geofence_name").Trim() == geofence[0].name
                                   select row;
                        if (rows.Any())
                        {
                            dataTable = rows.CopyToDataTable();
                        }

                        if (dataTable.Rows.Count <= 0)
                        {
                            if (geofence[0].points.Count >= 3)
                            {
                                for (int i = 0; i < geofence[0].points.Count; i++)
                                {
                                    geofencename = geofence[0].name;

                                    geofenceboundary = geofenceboundary + geofence[0].points[i].latitude.ToString() + " " + geofence[0].points[i].longitude.ToString() + ",";
                                    geoboundarydata = geoboundarydata + geofence[0].points[i].latitude.ToString() + "," + geofence[0].points[i].longitude.ToString() + ",";

                                }
                                geofenceboundary = geofenceboundary + geofence[0].points[0].latitude.ToString() + " " + geofence[0].points[0].longitude.ToString() + "))";
                                geoboundarydata = geoboundarydata.TrimEnd(',');


                                if (ModelState.IsValid)
                                {
                                    dtGeofenceDetails = DBUtilities.GeofenceRepository.InsertGeofence(geofencename, geofenceboundary, geoboundarydata, username, BusinessType);

                                }
                                else
                                {
                                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                                }
                                if (dtGeofenceDetails.Rows.Count > 0)
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Geofence_BL.GeofenceAllResponse(dtGeofenceDetails));
                                    //return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Records not updated.")); ;
                                }

                                else
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not added."));
                                }
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response("Please pass 3 or more geographical points."));
                            }
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Geofence name is already exists."));
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

            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));
               
            }
        }
        #endregion

        #region View by Geofence Name   [2.02]
        [Route("api/geofence/{name}")]
        [HttpGet]
        public HttpResponseMessage Geofence(string name)
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

                        DataTable dt = new DataTable();
                        DataTable dtGeofenceDetails = new DataTable();
                        DataTable dataTable = new DataTable();
                        DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                        int RoleID = 0;
                        int BusinessType = 0;
                        if (dtLoginInfo.Rows.Count > 0)
                        {
                            RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                            BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                        }


                        if (ModelState.IsValid)
                        {
                            dtGeofenceDetails = DBUtilities.GeofenceRepository.Geofence(username, BusinessType);

                            var rows = from row in dtGeofenceDetails.AsEnumerable()
                                       where row.Field<string>("geofence_name").Trim() == name
                                           select row;
                              if (rows.Any())
                               
                              {
                                    dataTable = rows.CopyToDataTable();
                              }

                        }
                        else
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                        }
                        if (dataTable.Rows.Count > 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Geofence_BL.GeofenceAllResponse(dataTable));

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

            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));
                 
            }
        }
        #endregion

        #region Update [2.03]
        [Route("api/geofence/{name}")] 
        [HttpPatch]
        public HttpResponseMessage UpdateGeofence([FromBody]  List<points> geofence, string name)
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

                        DataTable dt = new DataTable();
                        DataTable dtGeofenceDetails = new DataTable();
                        DataTable dtgetDetails = new DataTable();
                        DataTable dataTable = new DataTable();

                        DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                        int RoleID = 0;
                        int BusinessType = 0;
                        if (dtLoginInfo.Rows.Count > 0)
                        {
                            RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                            BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                        }
                        var geofencename = string.Empty;

                        var geofenceboundary = "POLYGON((";
                        var geoboundarydata = string.Empty;

                        dtgetDetails = DBUtilities.GeofenceRepository.Geofence(username, BusinessType);

                        var rows = from row in dtgetDetails.AsEnumerable()
                                   where row.Field<string>("geofence_name").Trim() == name
                                   select row;
                        if (rows.Any())
                        {
                            dataTable = rows.CopyToDataTable();
                        }

                        if (dataTable.Rows.Count > 0)
                        {
                            if (geofence.Count >= 3)
                            {
                                for (int i = 0; i < geofence.Count; i++)
                                {
                                    geofencename = name;

                                    geofenceboundary = geofenceboundary + geofence[i].latitude.ToString() + " " + geofence[i].longitude.ToString() + ",";
                                    geoboundarydata = geoboundarydata + geofence[i].latitude.ToString() + "," + geofence[i].longitude.ToString() + ",";

                                }
                                geofenceboundary = geofenceboundary + geofence[0].latitude.ToString() + " " + geofence[0].longitude.ToString() + "))";
                                geoboundarydata = geoboundarydata.TrimEnd(',');


                                if (ModelState.IsValid)
                                {
                                    dtGeofenceDetails = DBUtilities.GeofenceRepository.UpdateGeofence(geofencename, geofenceboundary, geoboundarydata, username, BusinessType);

                                }
                                else
                                {
                                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                                }
                                if (dtGeofenceDetails.Rows.Count > 0)
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Geofence_BL.GeofenceAllResponse(dtGeofenceDetails));
                                     
                                }

                                else
                                {
                                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not updated."));
                                }
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response("Please pass 3 or more geographical points."));
                            }
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Geofence name is not exists."));
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

            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));
             
            }
        }
        #endregion

        #region Delete the Geofence   [2.05]
        [Route("api/geofence/{name}")]
        [HttpDelete]

        public HttpResponseMessage DeleteGeofence(string name)
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
                if (token != "")
                {
                    bool validateToken = false;
                    bool result = false;
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
                        // String result = string.Empty;
                        DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                        int RoleID = 0;
                        int BusinessType = 0;
                        if (dtLoginInfo.Rows.Count > 0)
                        {
                            RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                            BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                        }
                        result = DBUtilities.GeofenceRepository.DeleteGeofence(username, name, BusinessType);

                        if (result == true)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Sucess"));
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
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));

            }
        }
        #endregion

        #region Lists currently active geofences [2.06]
        [Route("api/geofence/vehicles")]
        [HttpGet]
        public HttpResponseMessage ListsActiveGeofences()
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

                        DataTable dt = new DataTable();
                        DataTable dtGeofenceDetails = new DataTable();
                        DataTable dtgetDetails = new DataTable();
                        DataTable dataTable = new DataTable();

                        DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                        int RoleID = 0;
                        int BusinessType = 0;
                        if (dtLoginInfo.Rows.Count > 0)
                        {
                            RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                            BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                        }

                        if (ModelState.IsValid)
                        {
                            dtGeofenceDetails = DBUtilities.GeofenceRepository.ListsActiveGeofences(username, BusinessType);

                        }
                        else
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                        }
                        if (dtGeofenceDetails.Rows.Count > 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Geofence_BL.GeofenceVehicleMappingResponse(dtGeofenceDetails));

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

            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));

            }
        }
        #endregion

        #region Get vehicles mapped to a given geofence with dates.  [2.07]
        [Route("api/geofence/{name}/vehicles")]
        [HttpGet]
        public HttpResponseMessage GeofenceVehiclesMapping(string name, string startDate, string endDate)
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

                var _startDate = Common.BuildDateTimeFromYAFormat(startDate);
                var _endDate = Common.BuildDateTimeFromYAFormat(endDate);
                var result = Common.DateCompare(_startDate, _endDate);

                if (result < 0)
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

                            DataTable dt = new DataTable();
                            DataTable dtGeofenceDetails = new DataTable();
                            DataTable dtgetDetails = new DataTable();
                            DataTable dataTable = new DataTable();

                            DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                            int RoleID = 0;
                            int BusinessType = 0;
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                            }
                            
                            if (ModelState.IsValid)
                            {
                                dtGeofenceDetails = DBUtilities.GeofenceRepository.GeofenceVehicleMapping(username, name, Convert.ToDateTime(startDate), Convert.ToDateTime(endDate), BusinessType);

                            }
                            else
                            {
                                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                            }
                            if (dtGeofenceDetails.Rows.Count > 0)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Geofence_BL.GeofenceVehicleMappingResponse(dtGeofenceDetails));

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

        #region insert vehicle geofence  9.04
        [Route("api/geofence/{name}/vehicles")]
        [HttpPut]
        public HttpResponseMessage InsertVehicleGeoFence(string name,[FromBody]List<GeoFencePutRequest>geofenceRequest)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            string errorMessage = string.Empty;
            bool check = false;
            check = name.ValidateQueryString();
            if (!check)
            {
                errorMessage = "Geofence name is invalid";
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
                if (headers.Contains("apikey"))
                {
                    if (headers.GetValues("apikey") != null && Convert.ToString(headers.GetValues("apikey")) != "")
                    {
                        apikey = headers.GetValues("apikey").First();
                    }
                }
                if (!check)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(errorMessage));
                }
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
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
                        DataTable dt = new DataTable();
                        DataTable dtGeofenceDetails = new DataTable();
                        DataTable dtgetDetails = new DataTable();
                        DataTable dataTable = new DataTable();
                        DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                        int RoleID = 0;
                        int BusinessType = 0;
                        if (dtLoginInfo.Rows.Count > 0)
                        {
                            RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                            BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                        }
                            dtGeofenceDetails = DBUtilities.GeofenceRepository.InsertVehicleGeoFence(username, BusinessType,name,geofenceRequest);
                        if (dtGeofenceDetails.Rows.Count > 0)
                        {
                            if (dtGeofenceDetails.Columns["errorMessage"] != null)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response(Convert.ToString(dtGeofenceDetails.Rows[0]["errorMessage"])));
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Geofence_BL.GeofenceVehicleMappingResponse(dtGeofenceDetails));
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
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));
            }
        }
        #endregion
    }
}
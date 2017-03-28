﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DigisensePlatformAPIs.Models;
using System.Data;
using log4net;
namespace DigisensePlatformAPIs.Controllers
{
    public class AlertsController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Alerts Details
        [HttpGet]
        [Route("api/alert")]
        public HttpResponseMessage AlertDetails()
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

                            int RoleID =0; 
                            int BusinessType=0;
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                            }

                            dtalert = DBUtilities.AlertRepository.Alerts(username, BusinessType);
                            if (dtalert.Rows.Count > 0)
                            {
                             
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Alert_BL.AlertResponse(dtalert));
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
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));
                
            }
        }
        #endregion
    }
}

using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DigisensePlatformAPIs.Controllers
{
    public class VehicleLocationHistoryController : ApiController
    {

        #region Vehicle Location History Details
        [HttpGet]
        [Route("api/VehicleLocationHistory/{vehicleregno}")]
        public HttpResponseMessage VehicleLocationHistoryDetails(string vehicleregno, string startDate, string endDate)
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

                            dtalert = DBUtilities.VehicleLocationHistoryRepository.VehicleLocationHistory(username,vehicleregno, startDate, endDate, BusinessType);
                            if (dtalert.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.BuisnessLogic.AlertResponse(dtalert));
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.BuisnessLogic.Response("Incorrect request parameters."));
                            }


                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.BuisnessLogic.Response("Invalid Token."));

                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.BuisnessLogic.Response("Invalid Token."));

                    }
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, Common_BL.Response(ex.Message));
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DigisensePlatformAPIs.Controllers
{
    public class VehicleAlertsController : ApiController
    {
        [Route("api/VehicleAlerts/{vehicleregno}")]
        [HttpGet]
        public string VehicleAlerts(string vehicleregno,string startdate,string enddate)
        {
            string jsonResponse = "";
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
                if (token != "" && apikey != "")
                {
                    bool validateToken = JWTTokenGenration.JWTTokenGenration.VerifyJWT(token,apikey);
                    if (validateToken)
                    {
                        var vehiclelocationHistory = DBUtilities.BuisnessLogic.DigiSMAVehicleAlerts(vehicleregno);
                        if (vehiclelocationHistory.Length > 0)
                        {
                            jsonResponse = DBUtilities.BuisnessLogic.VehicleLocationHistoryJsonResponse(vehiclelocationHistory);
                            return jsonResponse;
                        }
                    }
                    else
                    {
                        jsonResponse = DBUtilities.BuisnessLogic.ErrorResponse("401", "Auth Failed", "Your credetials are incorrect");
                    }
                }
                else
                {
                    jsonResponse = DBUtilities.BuisnessLogic.ErrorResponse("400", "Bad Request", "Check your request format, your request does not meet our requirements");
                }
                //code to authenticate and return some thing
                return jsonResponse;
            }
            catch (Exception ex)
            {
                jsonResponse = DBUtilities.BuisnessLogic.ErrorResponse("Default", "Error ", ex.Message.ToString());
                return jsonResponse;
            }
        }
    }
}

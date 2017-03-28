using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DigisensePlatformAPIs.Controllers
{
    public class DealersController : ApiController
    {
        [Route("api/vehicle/{vehicleregno}/dealers")]
        [HttpGet]
        public string DealersVehicle(string vehicleregno)
        {
            string jsonResponse = "";
            string token = string.Empty;
            string apikey = string.Empty;
            var digisenseQuerystr = Request.GetQueryNameValuePairs();
            IDictionary<string, string> digisenseQuerystrarray = digisenseQuerystr.ToDictionary(k => k.Key.ToLower(), v => v.Value.ToLower());
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
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
                if (token != "" && apikey != "" && vehicleregno!="")
                {
                    bool validateToken = JWTTokenGenration.JWTTokenGenration.VerifyJWT(token,apikey);
                    if (validateToken)
                    {
                        var dealers = DBUtilities.BuisnessLogic.DigiSMADealers(vehicleregno);
                        if (dealers.Length > 0)
                        {
                            jsonResponse = DBUtilities.BuisnessLogic.DealersJsonResponse(dealers);
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

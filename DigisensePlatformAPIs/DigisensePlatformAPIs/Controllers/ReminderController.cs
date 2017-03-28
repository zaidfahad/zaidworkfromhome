using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;
namespace DigisensePlatformAPIs.Controllers
{
    public class ReminderController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region List of Reminders
        [HttpGet]
        [Route("api/reminders")]
        public HttpResponseMessage getReminders( string fromDate, string toDate)
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

                            DataSet dtDetails = new DataSet();

                            DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);

                            int RoleID = 0;
                            int BusinessType = 0;
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                            }

                            dtDetails = DBUtilities.ReminderRepository.getReminders(username, Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate), BusinessType);
                            if (dtDetails.Tables[0].Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Records not found."));
                               // return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Vehicle_BL.VehicleResponse(dtDetails));
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
    }
}

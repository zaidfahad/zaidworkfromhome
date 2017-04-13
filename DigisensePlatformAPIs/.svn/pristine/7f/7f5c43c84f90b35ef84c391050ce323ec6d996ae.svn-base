using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DigisensePlatformAPIs.Models;
using System.Data;
using DigisensePlatformAPIs.Utilities;
using log4net;
namespace DigisensePlatformAPIs.Controllers
{
    public class ChangePasswordController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Change Password
        [HttpPost]
        [Route("api/ChangePassword")]
        public HttpResponseMessage ChangePassword([FromBody] ChangePassword clsChangePassword)
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

                            var changePassword = false;
                            DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(clsChangePassword.username, 5);

                            int RoleID = 0;
                            int BusinessType = 0;
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                            }
                            if (clsChangePassword.email == null)
                            {
                                clsChangePassword.email = "";
                            }
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RandomPasswordGenerator objRadomPasswordGenerator = null;
                                objRadomPasswordGenerator = new RandomPasswordGenerator();

                                string oldpassword = objRadomPasswordGenerator.Encrypt(clsChangePassword.oldpassword, true);
                                string newpassword = objRadomPasswordGenerator.Encrypt(clsChangePassword.newpassword, true);
                                if (oldpassword == newpassword)
                                {
                                    return Request.CreateResponse(HttpStatusCode.Forbidden, BLUtilities.Common_BL.Response("New password should not be same as old password."));
                                }
                                else
                                {
                                    changePassword = DBUtilities.LoginRepository.DigiSMAChangePassword(clsChangePassword.username, clsChangePassword.phonenumber, clsChangePassword.email, RoleID, oldpassword, newpassword, BusinessType);

                                    if (changePassword)
                                    {


                                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("success"));
                                    }
                                    else
                                    {
                                    //Need to ask To nilesh Sir about Status, i  think it should be oK
                                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("credentials are incorrect."));

                                    }
                                }
                            }
                            {
                                //Need to ask To nilesh Sir about Status, i  think it should be oK
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("credentials are incorrect."));

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


        #endregion
        }



    }
}
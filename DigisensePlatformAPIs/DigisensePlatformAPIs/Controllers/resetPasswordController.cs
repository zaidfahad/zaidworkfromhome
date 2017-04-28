using DigisensePlatformAPIs.Models;
using DigisensePlatformAPIs.Utilities;
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
    public class resetPasswordController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Reset Password
        [HttpPost]
        [Route("api/resetPassword")]
        public HttpResponseMessage resetPassword([FromBody] ResetPassword clsresetPassword)
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            try
            {
                if (clsresetPassword == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("parameters are required"));
                }
                if (ModelState.IsValid)
                {
                    bool validateToken = false;
                    string username = string.Empty;
                    DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);

                    if (dtTkenData.Rows.Count > 0)
                    {
                        username = Convert.ToString(dtTkenData.Rows[0]["_username"]);
                        validateToken = Convert.ToBoolean(dtTkenData.Rows[0]["_validation"]);
                    }

                    DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(clsresetPassword.username, 5);

                    int RoleID = 0;
                    int BusinessType = 0;
                    if (dtLoginInfo.Rows.Count > 0)
                    {
                        RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                        BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                    }
                    if (clsresetPassword.email == null)
                    {
                        clsresetPassword.email = "";
                    }
                    if (dtLoginInfo.Rows.Count > 0)
                    {
                        RandomPasswordGenerator objRadomPasswordGenerator = null;
                        objRadomPasswordGenerator = new RandomPasswordGenerator();

                        string otp = objRadomPasswordGenerator.Encrypt(clsresetPassword.newpassword, true);
                        string newpassword = objRadomPasswordGenerator.Encrypt(clsresetPassword.newpassword, true);

                       var resetPassword = DBUtilities.LoginRepository.DigiSMAResetPasswordNew(clsresetPassword.username, clsresetPassword.phonenumber, clsresetPassword.email, RoleID, otp, newpassword, BusinessType);

                        if (resetPassword.Item1)
                        {


                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response(resetPassword.Item2.ToString()));
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response(resetPassword.Item2.ToString()));

                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("credentials are incorrect."));

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

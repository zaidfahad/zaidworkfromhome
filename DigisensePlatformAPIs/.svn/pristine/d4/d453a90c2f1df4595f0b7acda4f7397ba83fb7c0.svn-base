using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using DigisensePlatformAPIs.Models;
using log4net;
using log4net.Config;
 
namespace DigisensePlatformAPIs.Controllers
{

    public class LoginController : ApiController
    {
     private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    
       #region Post - return true false

        //[HttpPost]
        //public HttpResponseMessage Authenicate_old([FromBody] Login login)
        //{ 

        //    try
        //    {

        //        string token = string.Empty;
        //        if (ModelState.IsValid)
        //        {
                    
        //                var IsValidLogin = false;
        //                IsValidLogin = DBUtilities.LoginRepository.LoginValidation(login.username.ToString(), login.password.ToString(), Convert.ToBoolean(login.remember_me), 5);

        //                if (IsValidLogin)
        //                {
        //                    token = JWTTokenGenration.JWTTokenGenration.GetJWToken(login.username);
        //                    bool isTokenRegister = false;
        //                    isTokenRegister = DBUtilities.LoginRepository.TokenRegistration(login.username.ToString(), token, Convert.ToBoolean(login.remember_me), 5);
        //                    if (isTokenRegister)
        //                    {
        //                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Login_BL.LoginResponse(token));
        //                    }
        //                    else
        //                    {
        //                        return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("credentials are incorrect"));
        //                    }

                            
        //                }
        //                else
        //                {
        //                    return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("credentials are incorrect"));
                             
                             
        //                }
                   
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}
        #endregion


        #region Post return token

        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Authenicate([FromBody] Login login)
        {

            try
            {

                if (login == null)
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("parameters are required"));
                }
                 
                string token = string.Empty;
                if (ModelState.IsValid)
                {

                    var IsValidLogin = false;
                    IsValidLogin = DBUtilities.LoginRepository.LoginValidation(login.username.ToString(), login.password.ToString(), Convert.ToBoolean(login.remember_me), 5);

                    if (IsValidLogin)
                    {
                        token = JWTTokenGenration.JWTTokenGenration.GetJWToken(login.username);
                       // bool isTokenRegister = false;
                        token = DBUtilities.LoginRepository.TokenRegistration(login.username.ToString(), token, Convert.ToBoolean(login.remember_me), 5);

                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Login_BL.LoginResponse(token));

                  
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("credentials are incorrect"));


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
    }

  
    
}

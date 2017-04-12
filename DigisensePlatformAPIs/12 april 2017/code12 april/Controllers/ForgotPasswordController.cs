﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DigisensePlatformAPIs.Models;
using DigisensePlatformAPIs.Utilities;
using System.Data;
using log4net;
using System.Configuration;
namespace DigisensePlatformAPIs.Controllers
{
    public class ForgotPasswordController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Forgot Password
        [HttpPost]
        [Route("api/ForgotPassword")]
        public HttpResponseMessage ForgotPassword([FromBody] ForgotPassword clsForgotPassword)
        {
        
           
            try
            {
                DataTable dtforgotPassword = new DataTable();
                string token = string.Empty;

                if (ModelState.IsValid)
                {
                    DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(clsForgotPassword.username, 5);

                    int RoleID = 0;
                    int BusinessType = 0;
                    if (dtLoginInfo.Rows.Count > 0)
                    {
                        RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                        BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                    }

                    if (clsForgotPassword.email == null)
                    { 
                        clsForgotPassword.email="";
                    }
                    if (dtLoginInfo.Rows.Count > 0 && clsForgotPassword.username != "" && clsForgotPassword.phonenumber != "")
                    {
                        dtforgotPassword = DBUtilities.LoginRepository.DigiSMAForgotPassword(clsForgotPassword.username, RoleID, clsForgotPassword.phonenumber, BusinessType, clsForgotPassword.email);
                    }
                  
                    if (dtforgotPassword.Rows.Count > 0)
                    {
                        string encryptedPassword = string.Empty;
                        RandomPasswordGenerator objRadomPasswordGenerator = null;
                        objRadomPasswordGenerator = new RandomPasswordGenerator();

                        encryptedPassword = objRadomPasswordGenerator.Decrypt(dtforgotPassword.Rows[0][0].ToString(), true);
                         
                       // SMSManagement objSMSManagement = new SMSManagement();
                        string smsText = "Your account password is -" + encryptedPassword;

                        if (Convert.ToBoolean(ConfigurationManager.AppSettings["SendSMS"]) == true)
                        {
                            SMSManagement.SendSMS(smsText, clsForgotPassword.phonenumber);
                        }
                         
                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("success"));
                    }
                    else
                    {
                        //Need to ask to Nilesh sir about the status code 
                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Incorrect request parameters."));
                      
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

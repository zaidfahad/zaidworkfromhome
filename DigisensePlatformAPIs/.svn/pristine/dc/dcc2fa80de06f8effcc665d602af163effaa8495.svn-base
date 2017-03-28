using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using log4net;
namespace DigisensePlatformAPIs.Controllers
{
    public class UserController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region profile Details
        [HttpGet]
        [Route("api/profile")]
        public HttpResponseMessage profileDetails()
        {
            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            try
            {
                if (headers.Contains("token"))
                {
                    if (headers.GetValues("token") != null && Convert.ToString(headers.GetValues("token")) != "")
                    {
                        token = headers.GetValues("token").First();
                    }
                }
                if (ModelState.IsValid)
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
                            DataTable dtDetails = new DataTable();
                            DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                            int RoleID = 0;
                            int BusinessType = 0;
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                            }

                            dtDetails = DBUtilities.UserRepository.ProfileDetails(username, RoleID,BusinessType);
                            if (dtDetails.Rows.Count > 0)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.User_BL.UserResponse(dtDetails));
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

        #region User Profiles Patch Request with userid id
        [Route("api/profile")]
        [HttpPatch]
        public HttpResponseMessage DriverProfileDetailsPatch([FromBody]  List<object> objUserAttributeInfo)
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
                    string _userid = string.Empty;
                    DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);
                    if (dtTkenData.Rows.Count > 0)
                    {
                        _userid = Convert.ToString(dtTkenData.Rows[0]["_userid"]);
                        username = Convert.ToString(dtTkenData.Rows[0]["_username"]);
                        validateToken = Convert.ToBoolean(dtTkenData.Rows[0]["_validation"]);
                    }
                    if (validateToken)
                    {

                        DataTable dtDetailsRank = new DataTable();
                        DataTable dt = new DataTable();
                        DataTable dtDetails = new DataTable();
                        DataTable dtAssginedVehicles = new DataTable();
                        DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                        int RoleID = 0;
                        int BusinessType = 0;
                        if (dtLoginInfo.Rows.Count > 0)
                        {
                            RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                            BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                        }

                      //  if ((userid != _userid) || (RoleID == 1))
                      //  {
                            dt = DBUtilities.UserRepository.ProfileDetails(username, RoleID, BusinessType);

                            UserUpdate objUser = new UserUpdate();

                            Type type = typeof(UserUpdate);

                            PropertyInfo[] properties = type.GetProperties();

                            foreach (PropertyInfo property in properties)
                            {
                                if (property.Name.ToLower() == "idproof".ToLower())
                                {
                                    if (!Convert.IsDBNull(dt.Rows[0][property.Name]))
                                    {
                                        property.SetValue(objUser, (byte[])dt.Rows[0][property.Name]);
                                    }
                                    else
                                    {
                                        property.SetValue(objUser, null);
                                    }

                                }
                                else
                                {
                                    property.SetValue(objUser, dt.Rows[0][property.Name].ToString());
                                }
                                foreach (dynamic item in objUserAttributeInfo)
                                {

                                    if (((string)item.field).ToLower() == "idproof".ToLower())
                                    {
                                        property.SetValue(objUser, (byte[])item.value);
                                    }
                                    else if (property.Name.ToLower() == ((string)item.field).ToLower())
                                    {
                                        property.SetValue(objUser, (string)item.value);
                                    }

                                }

                            }

                            if (ModelState.IsValid)
                            {

                                if (dt.Rows.Count > 0)
                                {


                                    dtDetails = DBUtilities.UserRepository.ProfileDetailsUpdate(username, objUser, BusinessType, RoleID);

                                    if (dtDetails.Rows.Count > 0)
                                    {
                                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.User_BL.UserResponse(dtDetails));
                                    }

                                    else
                                    {
                                        return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Records not updated."));
                                    }

                                }
                                else
                                {
                                    return Request.CreateResponse(HttpStatusCode.NotFound, BLUtilities.Common_BL.Response("Records not updated."));
                                }
                            }
                            else
                            {
                                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                            }
                       // }
                      //  else
                      //  {
                         //   return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("Unauthorized access."));
                      //  }
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

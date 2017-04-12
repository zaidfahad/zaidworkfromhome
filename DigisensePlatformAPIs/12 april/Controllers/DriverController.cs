using DigisensePlatformAPIs.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using log4net;
using DigisensePlatformAPIs.Utilities;
namespace DigisensePlatformAPIs.Controllers
{
    public class DriverController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region List of Driver  Details
        [HttpGet]
        [Route("api/driverProfiles")]
        public HttpResponseMessage DriverDetails()
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
                            DataTable dtDetailsRank = new DataTable();
                            DataTable dtAssginedVehicles = new DataTable();
                            DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);

                            int RoleID = 0;
                            int BusinessType = 0;
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                            }

                            dtDetails = DBUtilities.DriverRepository.DriverDetails(username, BusinessType);

                            dtDetails.Columns.Add(new DataColumn("Rank", typeof(System.String)));
                            dtDetails.Columns.Add(new DataColumn("AssignedVehicles", typeof(System.String)));
                           // dtDetails.Columns.Add(new DataColumn("benchmarkfe", typeof(System.String)));
                            //dtDetails.Columns.Add(new DataColumn("benchmarkkmspermonth", typeof(System.String)));

                            dtDetailsRank = DBUtilities.DriverRepository.GetDriverRanking(username, Convert.ToDateTime(DateTime.Now), Convert.ToDateTime(DateTime.Now.AddDays(-120)), BusinessType);

                            dtAssginedVehicles = DBUtilities.DriverRepository.DriverAssignVehiclesDetails(username, BusinessType);

                            for (int i = 0; i < dtDetails.Rows.Count; i++)
                            {
                                var rows = from row in dtDetailsRank.AsEnumerable()
                                           where row.Field<Int32>("driverid") ==  Convert.ToInt32(dtDetails.Rows[i]["id"].ToString())
                                           select row;
                                if (rows.Any())
                                {
                                    DataTable dataTable = rows.CopyToDataTable();

                                    dtDetails.Rows[i]["Rank"] = dataTable.Rows[0]["Rank"].ToString();   // or set it to some other value
                                }
                                else
                                {
                                    dtDetails.Rows[i]["Rank"] = "";
                                }
                                var rowsAssgined = from row in dtAssginedVehicles.AsEnumerable()
                                                   where row.Field<Int32>("id") == Convert.ToInt32(dtDetails.Rows[i]["id"].ToString())
                                           select row;
                                if (rowsAssgined.Any())
                                {
                                    DataTable dataTableAssgined = rowsAssgined.CopyToDataTable();

                                    dtDetails.Rows[i]["AssignedVehicles"] = dataTableAssgined.Rows[0]["AssignedVehicles"].ToString();   // or set it to some other value
                                }
                                else
                                {
                                    dtDetails.Rows[i]["AssignedVehicles"] = "";
                                }
                            }
                            if (dtDetails.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Driver_BL.DriverResponse(dtDetails));
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not found."));
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

        #region Driver  Profile Details
        [HttpGet]
        
        [Route("api/driverProfiles/{driverid:int}")]
        public HttpResponseMessage DriverProfileDetails(Int32 driverid)
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
                            DataTable dtDetailsRank = new DataTable();
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
                           
                    
                            dtDetails = DBUtilities.DriverRepository.DriverProfileDetails(username,driverid, BusinessType);


                            if (dtDetails.Rows.Count > 0)
                            {

                                dtDetailsRank = DBUtilities.DriverRepository.GetDriverRanking(username, Convert.ToDateTime(DateTime.Now), Convert.ToDateTime(DateTime.Now.AddDays(-120)), BusinessType);

                                dtDetails.Columns.Add(new DataColumn("Rank", typeof(System.String)));

                                dtDetails.Columns.Add(new DataColumn("AssignedVehicles", typeof(System.String)));

                                var rows = from row in dtDetailsRank.AsEnumerable()
                                          // where row.Field<string>("firstName").Trim() == dtDetails.Rows[0]["firstName"].ToString()
                                           where row.Field<Int32>("driverid") == Convert.ToInt32(dtDetails.Rows[0]["id"].ToString())
                                           select row;
                                if (rows.Any())
                                {
                                    DataTable dataTable = rows.CopyToDataTable();
                                   //  foreach (DataRow row in dtDetails.Rows)
                                   // {
                                    dtDetails.Rows[0]["Rank"] = dataTable.Rows[0]["Rank"].ToString();   // or set it to some other value
                                   // }
                                }
                                else
                                {
                                    dtDetails.Rows[0]["Rank"] = "";
                                }
                                dtAssginedVehicles = DBUtilities.DriverRepository.DriverAssignVehiclesDetails(username, BusinessType);

                                var rowsAssgined = from row in dtAssginedVehicles.AsEnumerable()
                                                   //where row.Field<string>("firstname").Trim() == dtDetails.Rows[0]["firstname"].ToString()
                                                   where row.Field<Int32>("id") == Convert.ToInt32(dtDetails.Rows[0]["id"].ToString())
                                                   select row;
                                if (rowsAssgined.Any())
                                {
                                    DataTable dataTableAssgined = rowsAssgined.CopyToDataTable();

                                    dtDetails.Rows[0]["AssignedVehicles"] = dataTableAssgined.Rows[0]["AssignedVehicles"].ToString();   // or set it to some other value
                                }
                                else
                                {
                                    dtDetails.Rows[0]["AssignedVehicles"] = "";
                                }

                            }


                        
                            if (dtDetails.Rows.Count > 0)
                            {

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Driver_BL.DriverResponse(dtDetails));
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not found."));
                            }


                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response("Invalid Token."));

                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response("Invalid Token."));

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

        #region Insert Driver  Profile Details
        [HttpPost]
        [Route("api/driverProfiles/driver")]
        public HttpResponseMessage DriverProfileDetails([FromBody] Driver objDriver)
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

                    #region Base 64 String Validation
                    if (objDriver.idProof != null)
                    {
                        if (Convert.ToString(objDriver.idProof).Trim() != "")
                        {
                            if (!objDriver.idProof.ValidateBaseString())
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Id proof image is  invalid"));
                            }
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Id proof  field cannot be empty"));
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Id proof parameter is missing"));
                    }
                    #endregion

                    if (token != "")
                    {
                        bool validateToken = false;
                        string username = string.Empty;
                        string userid = string.Empty;
                        DataTable dtDetails = new DataTable();
                        DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);
                        if (dtTkenData.Rows.Count > 0)
                        {
                            userid = Convert.ToString(dtTkenData.Rows[0]["_userid"]);
                            username = Convert.ToString(dtTkenData.Rows[0]["_username"]);
                            validateToken = Convert.ToBoolean(dtTkenData.Rows[0]["_validation"]);
                        }
                        if (validateToken)
                        {
                            String result = string.Empty;
                            DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                            int RoleID = 0;
                            int BusinessType = 0;
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                            }
                            result = DBUtilities.DriverRepository.InsertDriverDetails(username, objDriver, BusinessType);
                            string[] strres = result.Split('|');
                            if (strres[0].ToString() == "0")
                            {
                                dtDetails = DBUtilities.DriverRepository.DriverProfileDetails(username, Convert.ToInt32(strres[1].ToString()), BusinessType);
                                dtDetails.Columns.Add(new DataColumn("Rank", typeof(System.String)));

                                dtDetails.Columns.Add(new DataColumn("AssignedVehicles", typeof(System.String)));

                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Driver_BL.DriverResponse(dtDetails));
                              //  return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Sucess"));
                            }
                            else if (strres[0].ToString() == "1")
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Phone number is already exists. Please provide another phone number."));
                            }
                            else if (strres[0].ToString() == "2")
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Email id is already exists. Please provide another email id."));
                            }
                            else if (strres[0].ToString() == "3")
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Name is already exists. Please provide another name."));
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not added."));
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

        #region Driver  Get -IdProof Details
        [HttpGet]
        [Route("api/driverprofiles/{driverid:int}/idProof")]
        public HttpResponseMessage GetIdProof(int driverid)
        {
           HttpResponseMessage response = new HttpResponseMessage();
          
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
                            DataTable dtDetailsRank = new DataTable();
                            DataTable dtDetails = new DataTable();

                            DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);

                            int RoleID = 0;
                            int BusinessType = 0;
                            if (dtLoginInfo.Rows.Count > 0)
                            {
                                RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                                BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                            }



                            dtDetails = DBUtilities.DriverRepository.DriverProfileDetails(username, driverid, BusinessType);

                            if (dtDetails.Rows.Count > 0)
                            {

                                response.Content = new ByteArrayContent((byte[])(dtDetails.Rows[0]["idProof"]));


                                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                                response.StatusCode = HttpStatusCode.OK;

                                return response;
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not found."));
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

        public byte[] getphoto(string filePath)
        {

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] photo = br.ReadBytes(Convert.ToInt32(fs.Length));
            br.Close();
            fs.Close();
            return photo;



        }
         #region Driver  Post IdProof Details
        [HttpPost]
        [Route("api/IdProof/{driverid:int}")]
        public HttpResponseMessage Post(string driverid)
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            string fname = string.Empty, filepath = string.Empty, NewPath = string.Empty;

           if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
     foreach (string files in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[files];
                      fname = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                    //postedFile.SaveAs(files);

                    filepath = Path.GetFileNameWithoutExtension(fname);
                    NewPath = fname.Replace(filepath, driverid.ToString());

                    //FileInfo filenew = new FileInfo(NewPath);
                    //if (filenew.Exists)
                    //{
                    //    filenew.Delete();
                    //}
                    //postedFile.SaveAs(NewPath);
                }
      byte[] photo = null;
                    photo = getphoto(NewPath);
                
                result = Request.CreateResponse(HttpStatusCode.Created, BLUtilities.Common_BL.Response("Sucess"));
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response("Idproof not uploaded."));
            }
             return result;
        }
#endregion


        #region Driver Profiles with Driver id For Delete
        [Route("api/driverProfiles/{driverId:int}")]
        [HttpDelete]
         
        public HttpResponseMessage DriverProfilesWithDriverIdDelete(Int32 driverId)
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
                        String result = string.Empty;
                        DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                        int RoleID = 0;
                        int BusinessType = 0;
                        if (dtLoginInfo.Rows.Count > 0)
                        {
                            RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                            BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                        }
                        result = DBUtilities.DriverRepository.DriverProfileDelete(username, driverId.ToString(), BusinessType);
                        string[] strres = result.Split('|');
                        if (strres[0].ToString() == "0")
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Sucess"));
                        }
                        else if (strres[0].ToString() == "1")
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not deleted,driver is mapped to the vehicle."));
                        }
                        else if (strres[0].ToString() == "2")
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not found."));
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not deleted."));
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
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));
               
            }
        }
        #endregion
      

        #region Driver Profiles Patch Request with Driver id
        [Route("api/DriverProfiles/{driverId:int}")]
        [HttpPatch]
        public HttpResponseMessage DriverProfileDetailsPatch([FromBody]  List<object> objDriverAttributeInfo, string driverid)
        {
           
         System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string token = string.Empty;
            string apikey = string.Empty;
            string[] strres=null;
            string result = string.Empty;
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
                        DataTable dtDetailsRank = new DataTable();
                        DataTable dt = new DataTable();
                       // DataTable dtDetails = new DataTable();
                        DataTable dtAssginedVehicles = new DataTable();
                        DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
                        int RoleID = 0;
                        int BusinessType = 0;
                        if (dtLoginInfo.Rows.Count > 0)
                        {
                            RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
                            BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
                        }

                        dt = DBUtilities.DriverRepository.DriverProfileDetails(username, Convert.ToInt32(driverid), BusinessType);

                        DriverUpdate objDriver = new DriverUpdate();

                        if (dt.Rows.Count > 0)
                        {
                            

                            Type type = typeof(DriverUpdate);

                            PropertyInfo[] properties = type.GetProperties();

                            foreach (PropertyInfo property in properties)
                            {
                                if (property.Name.ToLower() == "idproof".ToLower())
                                {
                                    if (!Convert.IsDBNull(dt.Rows[0][property.Name]))
                                    {
                                        property.SetValue(objDriver, (byte[])dt.Rows[0][property.Name]);
                                    }
                                    else
                                    {
                                        property.SetValue(objDriver, null);
                                    }

                                }
                                else
                                {
                                    property.SetValue(objDriver, dt.Rows[0][property.Name].ToString());
                                }
                                foreach (dynamic item in objDriverAttributeInfo)
                                {

                                    if (((string)item.field).ToLower() == "idproof".ToLower())
                                    {
                                        property.SetValue(objDriver, (byte[])item.value);
                                        dt.Rows[0][((string)item.field).ToLower()] = (byte[])item.value;
                                         
                                    }
                                    else if (property.Name.ToLower() == ((string)item.field).ToLower())
                                    {
                                         property.SetValue(objDriver, (string)item.value);
                                        dt.Rows[0][((string)item.field).ToLower()] = (string)item.value;
                                    }

                                }

                            }
                        }

                        if (ModelState.IsValid)
                        {

                            if (dt.Rows.Count > 0)
                            {
                                


                                result = DBUtilities.DriverRepository.DriverProfileWithDriverIdUpdate(username, objDriver, BusinessType);
                                strres = result.Split('|');
                                if (strres[0].ToString() == "0")
                                {
                                    dtDetailsRank = DBUtilities.DriverRepository.GetDriverRanking(username, Convert.ToDateTime(DateTime.Now), Convert.ToDateTime(DateTime.Now.AddDays(-120)), BusinessType);

                                    dt.Columns.Add(new DataColumn("Rank", typeof(System.String)));

                                    dt.Columns.Add(new DataColumn("AssignedVehicles", typeof(System.String)));
                                    var rows = from row in dtDetailsRank.AsEnumerable()
                                               // where row.Field<string>("firstname").Trim() == dtDetails.Rows[0]["firstname"].ToString()
                                               where row.Field<Int32>("driverid") == Convert.ToInt32(dt.Rows[0]["id"].ToString())
                                               select row;
                                    if (rows.Any())
                                    //if(!string.IsNullOrEmpty(str))
                                    {
                                        DataTable dataTable = rows.CopyToDataTable();

                                        foreach (DataRow row in dt.Rows)
                                        {
                                            row["Rank"] = dataTable.Rows[0]["Rank"].ToString();   // or set it to some other value
                                        }
                                    }
                                    else
                                    {
                                        dt.Rows[0]["Rank"] = "";
                                    }
                                    dtAssginedVehicles = DBUtilities.DriverRepository.DriverAssignVehiclesDetails(username, BusinessType);
                                    var rowsAssgined = from row in dtAssginedVehicles.AsEnumerable()
                                                       // where row.Field<string>("firstname").Trim() == dtDetails.Rows[0]["firstname"].ToString()
                                                       where row.Field<Int32>("id") == Convert.ToInt32(dt.Rows[0]["id"].ToString())
                                                       select row;
                                    if (rowsAssgined.Any())
                                    {
                                        DataTable dataTableAssgined = rowsAssgined.CopyToDataTable();

                                        dt.Rows[0]["AssignedVehicles"] = dataTableAssgined.Rows[0]["AssignedVehicles"].ToString();   // or set it to some other value
                                    }
                                    else
                                    {
                                        dt.Rows[0]["AssignedVehicles"] = "";
                                    }
                                }
                            }
                        }
                        else
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                        }



                        if (strres[0].ToString() == "0")
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Driver_BL.DriverResponse(dt));
                        }
                        else if (strres[0].ToString() == "1")
                        {
                           
                                return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Phone number is already exists. Please provide another phone number."));
                        }
                       else if (strres[0].ToString() == "2")
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Email id is already exists. Please provide another email id."));
                        }
                       else if (strres[0].ToString() == "3")
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Name is already exists. Please provide another name."));
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not updated."));
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
           
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));
               
            }
        }

        //public HttpResponseMessage DriverProfileDetailsPatch_bckup([FromBody]  List<object> objDriverAttributeInfo, string driverid)
        //{

        //    System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
        //    string token = string.Empty;
        //    string apikey = string.Empty;
        //    try
        //    {
        //        if (headers.Contains("token"))
        //        {
        //            if (headers.GetValues("token") != null && Convert.ToString(headers.GetValues("token")) != "")
        //            {
        //                token = headers.GetValues("token").First();
        //            }
        //        }
        //        if (headers.Contains("apikey"))
        //        {
        //            if (headers.GetValues("apikey") != null && Convert.ToString(headers.GetValues("apikey")) != "")
        //            {
        //                apikey = headers.GetValues("apikey").First();
        //            }
        //        }



        //        if (token != "")
        //        {
        //            bool validateToken = false;
        //            string username = string.Empty;
        //            string userid = string.Empty;
        //            DataTable dtTkenData = DBUtilities.LoginRepository.TokenValidation(token, 5);
        //            if (dtTkenData.Rows.Count > 0)
        //            {
        //                userid = Convert.ToString(dtTkenData.Rows[0]["_userid"]);
        //                username = Convert.ToString(dtTkenData.Rows[0]["_username"]);
        //                validateToken = Convert.ToBoolean(dtTkenData.Rows[0]["_validation"]);
        //            }
        //            if (validateToken)
        //            {
        //                DataTable dtDetailsRank = new DataTable();
        //                DataTable dt = new DataTable();
        //                DataTable dtDetails = new DataTable();
        //                DataTable dtAssginedVehicles = new DataTable();
        //                DataTable dtLoginInfo = DBUtilities.LoginRepository.DigiSMALoginInfo(username, 5);
        //                int RoleID = 0;
        //                int BusinessType = 0;
        //                if (dtLoginInfo.Rows.Count > 0)
        //                {
        //                    RoleID = Convert.ToInt16(dtLoginInfo.Rows[0]["RoleID"]);
        //                    BusinessType = Convert.ToInt16(dtLoginInfo.Rows[0]["BusinessType"]);
        //                }

        //                dt = DBUtilities.DriverRepository.DriverProfileDetails(username, Convert.ToInt32(driverid), BusinessType);

        //                DriverUpdate objDriver = new DriverUpdate();

        //                Type type = typeof(DriverUpdate);

        //                PropertyInfo[] properties = type.GetProperties();

        //                foreach (PropertyInfo property in properties)
        //                {
        //                    if (property.Name.ToLower() == "idproof".ToLower())
        //                    {
        //                        if (!Convert.IsDBNull(dt.Rows[0][property.Name]))
        //                        {
        //                            property.SetValue(objDriver, (byte[])dt.Rows[0][property.Name]);
        //                        }
        //                        else
        //                        {
        //                            property.SetValue(objDriver, null);
        //                        }

        //                    }
        //                    else
        //                    {
        //                        property.SetValue(objDriver, dt.Rows[0][property.Name].ToString());
        //                    }
        //                    foreach (dynamic item in objDriverAttributeInfo)
        //                    {

        //                        if (((string)item.field).ToLower() == "idproof".ToLower())
        //                        {
        //                            property.SetValue(objDriver, (byte[])item.value);
        //                        }
        //                        else if (property.Name.ToLower() == ((string)item.field).ToLower())
        //                        {
        //                            property.SetValue(objDriver, (string)item.value);
        //                        }

        //                    }

        //                }

        //                if (ModelState.IsValid)
        //                {

        //                    if (dt.Rows.Count > 0)
        //                    {


        //                        dtDetails = DBUtilities.DriverRepository.DriverProfileWithDriverIdUpdate(username, objDriver, BusinessType);

        //                        dtDetailsRank = DBUtilities.DriverRepository.GetDriverRanking(username, Convert.ToDateTime(DateTime.Now), Convert.ToDateTime(DateTime.Now.AddDays(-120)), BusinessType);

        //                        dtDetails.Columns.Add(new DataColumn("Rank", typeof(System.String)));

        //                        dtDetails.Columns.Add(new DataColumn("AssignedVehicles", typeof(System.String)));
        //                        var rows = from row in dtDetailsRank.AsEnumerable()
        //                                   // where row.Field<string>("firstname").Trim() == dtDetails.Rows[0]["firstname"].ToString()
        //                                   where row.Field<Int32>("driverid") == Convert.ToInt32(dtDetails.Rows[0]["id"].ToString())
        //                                   select row;
        //                        if (rows.Any())
        //                        //if(!string.IsNullOrEmpty(str))
        //                        {
        //                            DataTable dataTable = rows.CopyToDataTable();

        //                            foreach (DataRow row in dtDetails.Rows)
        //                            {
        //                                row["Rank"] = dataTable.Rows[0]["Rank"].ToString();   // or set it to some other value
        //                            }
        //                        }
        //                        else
        //                        {
        //                            dtDetails.Rows[0]["Rank"] = "";
        //                        }
        //                        dtAssginedVehicles = DBUtilities.DriverRepository.DriverAssignVehiclesDetails(username, BusinessType);
        //                        var rowsAssgined = from row in dtAssginedVehicles.AsEnumerable()
        //                                           // where row.Field<string>("firstname").Trim() == dtDetails.Rows[0]["firstname"].ToString()
        //                                           where row.Field<Int32>("id") == Convert.ToInt32(dtDetails.Rows[0]["id"].ToString())
        //                                           select row;
        //                        if (rowsAssgined.Any())
        //                        {
        //                            DataTable dataTableAssgined = rowsAssgined.CopyToDataTable();

        //                            dtDetails.Rows[0]["AssignedVehicles"] = dataTableAssgined.Rows[0]["AssignedVehicles"].ToString();   // or set it to some other value
        //                        }
        //                        else
        //                        {
        //                            dtDetails.Rows[0]["AssignedVehicles"] = "";
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //                }
        //                if (dtDetails.Rows.Count > 0)
        //                {
        //                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Driver_BL.DriverResponse(dtDetails));
        //                }

        //                else
        //                {
        //                    return Request.CreateResponse(HttpStatusCode.OK, BLUtilities.Common_BL.Response("Records not updated."));
        //                }
        //            }
        //            else
        //            {
        //                return Request.CreateResponse(HttpStatusCode.Unauthorized, BLUtilities.Common_BL.Response("Invalid Token."));
        //            }
        //        }


        //        else
        //        {
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response("Invalid Token."));
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message);
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, BLUtilities.Common_BL.Response(ex.Message));

        //    }
        //}
        #endregion
    }
}

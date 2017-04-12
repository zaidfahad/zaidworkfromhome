using System;
using Npgsql;
using DigisensePlatformAPIs.Utilities;
using DigisensePlatformAPIs.JsonResponseModel;
using Newtonsoft.Json;
using DigisensePlatformAPIs.Models;

namespace DigisensePlatformAPIs.DBUtilities
{
    public class BuisnessLogic
    {

        #region DigiSMALoginValidation
        /// <summary>
        /// Digisense Mobile App Login Validation
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool DigiSMALoginValidation(string userName, string password, bool rememberMe, int buinessId)
        {
            NpgsqlConnection connection = null;
            bool IsValidLogin = false;
            try
            {
                RandomPasswordGenerator objRadomPasswordGenerator = null;
                objRadomPasswordGenerator = new RandomPasswordGenerator();
                string decryptedPassword = string.Empty;
                decryptedPassword = objRadomPasswordGenerator.Encrypt(password, true);


                object[] oParameters = new object[3];
                oParameters[0] = userName;
                oParameters[1] = decryptedPassword;
                oParameters[2] = rememberMe;
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                IsValidLogin = Convert.ToBoolean(NpgsqlHelper.ExecuteScalar(connection, "usp_mobileapi_session_validation", oParameters));

            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return IsValidLogin;
        }
        #endregion
        #region Forgot Password
        public static string DigiSMAForgotPassword(string username)
        {
            try
            {
                return "Techm@123";
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
                return ex.Message;
            }
            finally
            {
            }
        }
        #endregion


        #region  Vehicle Location History
        public static string[] DigiSMAVehicleList()
        {
            string[] vehicle = new string[4];
            return vehicle;
        }
        #endregion

        #region  Vehicle Location History
        public static string[] DigiSMAVehicleLocationHistory(string vehicleregno, string startdate, string enddate)
        {
            string[] vehicle = new string[4];
            return vehicle;
        }
        #endregion


        #region  Vehicle Alerts 
        public static string[] DigiSMAVehicleAlerts(string vehicleregno)
        {
            string[] vehicle = new string[4];
            return vehicle;
        }
        #endregion


        #region Dealers
        #region  Vehicle Location History
        public static string[] DigiSMADealers(string vehicleregno)
        {
            string[] vehicle = new string[4];
            return vehicle;
        }
        #endregion
        #endregion

        #region Response And Error
        #region Resposne for Login 
        public static string LoginJsonResponse(string token)
        {
            string JsonResponse = "";
            try
            {
                LoginJsonModel loginJsonmodel = new LoginJsonModel();
                loginJsonmodel.code = "200";
                loginJsonmodel.description = "The login credentials";
                loginJsonmodel.jwt = token;
                loginJsonmodel.serviceAvailable = null;
                JsonResponse = JsonConvert.SerializeObject(loginJsonmodel);
                return JsonResponse;
            }
            catch (Exception)
            {
                return JsonResponse;
            }
        }
        #endregion
        #region Login Error Response
        public static string ErrorResponse(string code, string errorname, string messages)
        {
            string JsonResponse = "";
            try
            {
                ErrorResponseModel loginError = new ErrorResponseModel();
                loginError.code = code;
                loginError.description = "Error";
                loginError.messages.Add(errorname, messages);
                JsonResponse = JsonConvert.SerializeObject(loginError);
                return JsonResponse;
            }
            catch (Exception ex)
            {
                return JsonResponse;
            }
        }
        #endregion
        #region Forgot Password Response
        public static string ForgotPasswordJsonResponse(string message)
        {
            string JsonResponse = "";
            try
            {
                ForgotPasswordResponse forgotpasswordResponse = new ForgotPasswordResponse();
                forgotpasswordResponse.code = "200";
                forgotpasswordResponse.description = "The login credentials";
                forgotpasswordResponse.message = message;
                JsonResponse = JsonConvert.SerializeObject(forgotpasswordResponse);
                return JsonResponse;
            }
            catch (Exception)
            {
                return JsonResponse;
            }
        }
        #endregion
        #region Vehicle History Location 
        public static string VehicleLocationHistoryJsonResponse(string []vehicleData)
        {
            string jsonResponse = "";
            try
            {
                VehicleLocationHistoryModel vehicleResponse = new VehicleLocationHistoryModel();
                vehicleResponse.code = "200";
                vehicleResponse.address = "Tech Mahindra ,HiTech City Hydrabad";
                vehicleResponse.description = "success";
                vehicleResponse.speed = "200 K/H";
                vehicleResponse.timestamp = Convert.ToString(DateTime.Now);
                vehicleResponse.locations.Add(null);
                jsonResponse = JsonConvert.SerializeObject(vehicleResponse);
                return jsonResponse;
            }
            catch (Exception)
            {
                return jsonResponse=null;
            }
           
        }
        #endregion


        #region Vehicle List Json Response 
        public static string VehicleListJsonResponse(string[] vehicleData)
        {
            string jsonResponse = "";
            try
            {
                VehicleJsonResponse vehiclelistResponse = new VehicleJsonResponse();
                vehiclelistResponse.code = "200";
                vehiclelistResponse.description = "suucess";
                vehiclelistResponse.registrationumber = "2122233-939932-2222";
                vehiclelistResponse.vehiclemodel = "Mercedes";
                vehiclelistResponse.vehicleplatform="HiTech City Hydrabad";
                vehiclelistResponse.status = "Active";
                jsonResponse = JsonConvert.SerializeObject(vehiclelistResponse);
                return jsonResponse;
            }
            catch (Exception)
            {
                return jsonResponse = null;
            }

        }
        #endregion

        #region Dealers
        public static string DealersJsonResponse(string[] vehicleData)
        {
            string jsonResponse = "";
            try
            {
                DealersModel dealersJson = new DealersModel();
                dealersJson.code = "200";
                dealersJson.description = "success";
                dealersJson.dealerid = "Techm123";
                dealersJson.contactnumber = "9855666";
                dealersJson.location = "Tech Mahindra Hydrabad Bhadurpally";
                dealersJson.name = "Mr. Krishanan";
                dealersJson.spares.Add(null);
                jsonResponse = JsonConvert.SerializeObject(dealersJson);
                return jsonResponse;
            }
            catch (Exception)
            {
                return jsonResponse = null;
            }

        }
        #endregion
        #endregion
    }
}
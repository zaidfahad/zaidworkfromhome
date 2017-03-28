using DigisensePlatformAPIs.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.DBUtilities
{
    public class LoginRepository
    {

        #region  LoginValidation
        /// <summary>
        /// Digisense Mobile App Login Validation
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool  LoginValidation(string username, string password, bool rememberme, int buinessId)
        {
            NpgsqlConnection connection = null;
            bool isValidLogin = false;
            try
            {
                RandomPasswordGenerator objRadomPasswordGenerator = null;
                objRadomPasswordGenerator = new RandomPasswordGenerator();
                string decryptedPassword = string.Empty;
                decryptedPassword = objRadomPasswordGenerator.Encrypt(password, true);


                object[] oParameters = new object[3];
                oParameters[0] = username;
                oParameters[1] = decryptedPassword;
                oParameters[2] = rememberme;
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                isValidLogin = Convert.ToBoolean(NpgsqlHelper.ExecuteScalar(connection, "usp_mobileapi_session_validation", oParameters));

            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return isValidLogin;
        }

        #endregion


        #region  Token Registration
        /// <summary>
        /// Digisense Mobile App -  Token Registration
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static string TokenRegistration(string username, string token, bool rememberme, int buinessId)
        {
            NpgsqlConnection connection = null;
            //bool isTokenRegister = false;
            string result = string.Empty;
            try
            {
               


                object[] oParameters = new object[3];
                oParameters[0] = username;
                oParameters[1] = token;
                oParameters[2] = rememberme;
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                result = (string)NpgsqlHelper.ExecuteScalar(connection, "usp_mobileapi_session_update_multiuser", oParameters);

            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return result;
        }

        #endregion


        #region old Token Registration return true / false
        /// <summary>
        /// Digisense Mobile App -  Token Registration
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool TokenRegistration_old(string username, string token, bool rememberme, int buinessId)
        {
            NpgsqlConnection connection = null;
            bool isTokenRegister = false;
            try
            {



                object[] oParameters = new object[3];
                oParameters[0] = username;
                oParameters[1] = token;
                oParameters[2] = rememberme;
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                isTokenRegister = Convert.ToBoolean(NpgsqlHelper.ExecuteScalar(connection, "usp_mobileapi_session_update_new", oParameters));

            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return isTokenRegister;
        }

        #endregion

        #region  Token Validtion
        /// <summary>
        /// Digisense Mobile App -  Token Validtion
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static DataTable TokenValidation(string token, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtTokenData = new DataTable();
            try
            {


                 

                object[] oParameters = new object[1];

                oParameters[0] = token;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];

                oNpgsqlParameter[0] = new NpgsqlParameter("_gwt_token", DbType.String);
               
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtTokenData = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_token_validation", oParameters, oNpgsqlParameter);

            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtTokenData;
        }


        public static DataTable TokenValidation_(string token, int buinessId)
        {
            //Declaring Variables
            NpgsqlConnection connection = null;
            DataSet dsOwnerDeviceTypeDtls = null;
            try
            {
                dsOwnerDeviceTypeDtls = new DataSet();


                //Get database connection
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));


                NpgsqlTransaction tr = (NpgsqlTransaction)connection.BeginTransaction();

                NpgsqlCommand cursCmd = new NpgsqlCommand("usp_mobileapi_token_validation",
                                                        (NpgsqlConnection)connection);


                cursCmd.Transaction = tr;



                NpgsqlParameter rfuserID = new NpgsqlParameter("_gwt_token",
                                                      token);
                rfuserID.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(rfuserID);



                NpgsqlParameter _userid = new NpgsqlParameter("_userid",
                                                      NpgsqlTypes.NpgsqlDbType.Refcursor);
                _userid.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(_userid);


                NpgsqlParameter _username = new NpgsqlParameter("_username",
                                                      NpgsqlTypes.NpgsqlDbType.Refcursor);
                _username.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(_username);

 


                cursCmd.CommandType = CommandType.StoredProcedure;

                var adapter = new NpgsqlDataAdapter(cursCmd);

                adapter.Fill(dsOwnerDeviceTypeDtls);

                tr.Commit();
                  
            }
            catch (Exception ex)
            {
             
            }
            finally
            {
                // close connection
                if (connection != null)
                    connection.Close();
            }
            return dsOwnerDeviceTypeDtls.Tables[0];
        }

        #endregion


        #region LoginInfo
        public static DataTable DigiSMALoginInfo(string username, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtLoginInfo = new DataTable();
            string result = string.Empty;
            try
            {

                object[] oParameters = new object[1];

                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];

                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);


                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtLoginInfo = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_logininfo", oParameters, oNpgsqlParameter);


            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtLoginInfo;
        }
        #endregion

        #region Forgot Password
        public static DataTable DigiSMAForgotPassword(string username, int roleid, string phonenumber, int buinessId, string email)
        {
            NpgsqlConnection connection = null;

            DataTable dtForgotPassword = new DataTable();
            try
            {


                object[] oParameters = new object[4];

                oParameters[0] = username;
                oParameters[1] = roleid;
                oParameters[2] = phonenumber;
                oParameters[3] = email;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[4];

                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("roleid", DbType.Int32);
                oNpgsqlParameter[2] = new NpgsqlParameter("phonenumber", DbType.String);
                oNpgsqlParameter[3] = new NpgsqlParameter("email", DbType.String);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                // dtForgotPassword = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_forgotpassword", oParameters);
                dtForgotPassword = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_forgotpassword", oParameters, oNpgsqlParameter);




            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtForgotPassword;
        }
        #endregion

        #region Reset Password
        public static bool DigiSMAResetPassword(string username, string phonenumber, string email, int roleid, string otp, string newpassword, int buinessId)
        {
            NpgsqlConnection connection = null;

            bool result = false;
            try
            {
                object[] oParameters = new object[6];
                oParameters[0] = username;
                oParameters[1] = phonenumber;
                oParameters[2] = email;
                oParameters[3] = roleid;
                oParameters[4] = otp;
                oParameters[5] = newpassword;
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                result = Convert.ToBoolean(NpgsqlHelper.ExecuteScalar(connection, "usp_mobileapi_resetpassword", oParameters));

            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return result;
        }
        #endregion

        #region Change Password
        public static bool DigiSMAChangePassword(string username, string phonenumber, string email, int roleid, string oldpassword, string newpassword, int buinessId)
        {
            NpgsqlConnection connection = null;

            bool result = false;
            try
            {
                object[] oParameters = new object[6];
                oParameters[0] = username;
                oParameters[1] = phonenumber;
                oParameters[2] = email;
                oParameters[3] = roleid;
                oParameters[4] = oldpassword;
                oParameters[5] = newpassword;
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                result = Convert.ToBoolean(NpgsqlHelper.ExecuteScalar(connection, "usp_mobileapi_changepassword", oParameters));

            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return result;
        }
        #endregion

    }
}
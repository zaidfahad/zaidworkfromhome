using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.DBUtilities
{
    public class ProfileRepository
    {

        #region Profiles
        #region Profile Get 
        public static DataTable ProfileDetails(string username, int buinessId,int RoleId)
        {
            NpgsqlConnection connection = null;
            DataTable dtProfileDetails = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[2];
                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[2];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("roleid", DbType.Int32);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtProfileDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_user_info", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtProfileDetails;
        }
        #endregion

        #region Profile For Post Type Request
        public static DataTable ProfileDetailsPost(string username, int buinessId,string []userProfiles)
        {
            NpgsqlConnection connection = null;
            DataTable dtProfileDetailsPost = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[2];
                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtProfileDetailsPost = NpgsqlHelper.ExecuteDataTable(connection, "PROCEDRUE NAME ", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dtProfileDetailsPost;
        }
        #endregion

        #region Profile Get  With UserId
        public static DataTable ProfileForSpecificUser(string username, int buinessId,string userId)
        {
            NpgsqlConnection connection = null;
            DataTable dtProfileForSpecificUser = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[2];
                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtProfileForSpecificUser = NpgsqlHelper.ExecuteDataTable(connection, "Procedure Need Here", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dtProfileForSpecificUser;
        }
        #endregion

        #region Profile Get  With UserId Patch
        public static DataTable ProfileForSpecificUserPatch(string username, int buinessId, string []userInformation)
        {
            NpgsqlConnection connection = null;
            DataTable dtProfileForSpecificUserPatch = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[2];
                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtProfileForSpecificUserPatch = NpgsqlHelper.ExecuteDataTable(connection, "Procedure Need Here", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dtProfileForSpecificUserPatch;
        }
        #endregion

        #region Profile Delete
        public static DataTable UserProfileDelete(string username, int buinessId,string userId)
        {
            NpgsqlConnection connection = null;
            DataTable dtUserProfileDelete = new DataTable();
            string result = string.Empty;
            try
            {

                object[] oParameters = new object[2];

                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtUserProfileDelete = NpgsqlHelper.ExecuteDataTable(connection, "Procedure Name", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtUserProfileDelete;
        }
        #endregion

        #endregion

        #region Driver Profiles

        #region Driver Profile for Get Request Type
        public static DataTable DriverProfile(string username, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtDriverProfile = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[2];
                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtDriverProfile = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_driver_profile", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dtDriverProfile;
        }
        #endregion

        #region Driver Profile for Get Request Type with DriverId
        public static DataTable DriverProfilewithDriverId(string username, int buinessId,string driverId)
        {
            NpgsqlConnection connection = null;
            DataTable dtDriverProfilewithDriverId = new DataTable();
            string result = string.Empty;
            try
            {

                object[] oParameters = new object[2];

                oParameters[0] = username;
                oParameters[1] = driverId;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[2];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("driverid", DbType.Int32);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtDriverProfilewithDriverId = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_driver_profile", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtDriverProfilewithDriverId;
        }
        #endregion

      

        #region Driver Profile for Post Request Type
        public static DataTable DriverProfilePost(string username, int buinessId,string[]driverDetails)
        {
            NpgsqlConnection connection = null;
            DataTable dtDriverProfilePost = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[2];
                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtDriverProfilePost = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_insert_driver_details", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dtDriverProfilePost;
        }
        #endregion
        #endregion

    }
}
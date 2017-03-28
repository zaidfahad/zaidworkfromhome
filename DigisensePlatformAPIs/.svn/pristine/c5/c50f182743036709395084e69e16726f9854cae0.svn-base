using DigisensePlatformAPIs.Models;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.DBUtilities
{
    public class UserRepository
    {

        #region Profile Details
        public static DataTable ProfileDetails(string username,int roleid, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtProfileDetails = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[2];
                oParameters[0] = username;
                oParameters[1] = roleid;
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

        #region Driver Profile for Patch Request
        public static DataTable ProfileDetailsUpdate(string username, UserUpdate objUser, int buinessId, int roleid)
        {
            // Declaring Variables
            NpgsqlConnection connection = null;

            DataTable dtDriverDetails = new DataTable();
            try
            {
                object[] oParameters = new object[7];
                oParameters[0] = username;
                oParameters[1] = roleid;
                oParameters[2] = objUser.firstName;
                oParameters[3] = objUser.lastName;
                oParameters[4] = objUser.contactNumber;
                oParameters[5] = objUser.address;
                oParameters[6] = objUser.email;
               
                
               

                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[7];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", NpgsqlDbType.Text);
                oNpgsqlParameter[1] = new NpgsqlParameter("roleid", NpgsqlDbType.Integer);
                oNpgsqlParameter[2] = new NpgsqlParameter("_firstname", NpgsqlDbType.Text);
                oNpgsqlParameter[3] = new NpgsqlParameter("_lastname", NpgsqlDbType.Text);
                oNpgsqlParameter[4] = new NpgsqlParameter("_phonenum", NpgsqlDbType.Text);
                oNpgsqlParameter[5] = new NpgsqlParameter("_address", NpgsqlDbType.Text);
                oNpgsqlParameter[6] = new NpgsqlParameter("_email", NpgsqlDbType.Text);
                
               

                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtDriverDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_update_user_details", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
            }
            return dtDriverDetails;
        }
        #endregion
    }
}
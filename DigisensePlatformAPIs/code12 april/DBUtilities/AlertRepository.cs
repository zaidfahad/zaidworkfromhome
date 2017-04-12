using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.DBUtilities
{
    public class AlertRepository
    {
        #region   Alerts
        public static DataTable Alerts(string username, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtalerts = new DataTable();
            string result = string.Empty;
            try
            {

                object[] oParameters = new object[1];

                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];

                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);


                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtalerts = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_activealerts", oParameters, oNpgsqlParameter);


            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtalerts;
        }
        #endregion
    }
}
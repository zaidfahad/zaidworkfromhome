using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.DBUtilities
{
    public class VehicleLocationHistoryRepository
    {
        #region   VehicleLocationHistory
        public static DataTable VehicleLocationHistory(string username,string vehregno, string startdate, string enddate, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtalerts = new DataTable();
            string result = string.Empty;
            try
            {

                object[] oParameters = new object[4];

                oParameters[0] = username;
                oParameters[1] = vehregno;
                oParameters[2] = startdate;
                oParameters[3] = enddate;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[4];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("vehregno", DbType.String);
                oNpgsqlParameter[2] = new NpgsqlParameter("startdate", DbType.String);
                oNpgsqlParameter[3] = new NpgsqlParameter("enddate", DbType.String);

                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtalerts = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_location_history", oParameters, oNpgsqlParameter);


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
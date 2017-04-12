using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.DBUtilities
{
    public class DealerRepository
    {
        #region Dealer  Alerts
        public static DataTable DealerDetails(string username, string vehregno, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtDealerDetails = new DataTable();
            string result = string.Empty;
            try
            {

                object[] oParameters = new object[2];

                oParameters[0] = username;
                oParameters[1] = vehregno;
            
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[2];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("vehregno", DbType.String);
           

                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtDealerDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_dealer_location", oParameters, oNpgsqlParameter);



            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtDealerDetails;
        }
        #endregion
    }
}
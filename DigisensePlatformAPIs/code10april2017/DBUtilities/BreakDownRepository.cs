using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.DBUtilities
{
    public class BreakDownRepository
    {

        #region  BreakDown Details
        public static DataTable BreakDownDetails(string username, string vehregno, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtBreakDownDetails = new DataTable();
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
                dtBreakDownDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_breakdown", oParameters, oNpgsqlParameter);



            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtBreakDownDetails;
        }
        #endregion


        public static DataTable BreakDown(string username, string vehicleid, int buinessId)
        {
            DataTable dataDs = new DataTable();
            NpgsqlConnection connection = null;
            try
            {
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                NpgsqlTransaction tr = (NpgsqlTransaction)connection.BeginTransaction();
                NpgsqlCommand cursCmd = new NpgsqlCommand("usp_mobileapi_insert_breakdown_details", (NpgsqlConnection)connection);
                cursCmd.Transaction = tr;

                NpgsqlParameter intusername = new NpgsqlParameter("username", username);
                intusername.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(intusername);

                NpgsqlParameter intvehicleid = new NpgsqlParameter("vehicleid", vehicleid);
                intvehicleid.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(intvehicleid);


                //NpgsqlParameter refcursor = new NpgsqlParameter("refcursor", NpgsqlTypes.NpgsqlDbType.Refcursor);
                //refcursor.Direction = ParameterDirection.InputOutput;
                //cursCmd.Parameters.Add(refcursor);

          


                cursCmd.CommandType = CommandType.StoredProcedure;
                var adapter = new NpgsqlDataAdapter(cursCmd);
                adapter.Fill(dataDs);
                tr.Commit();
            }
            catch (Exception ex)
            {

                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dataDs;
        }

        public static DataTable getBreakDown(string username, string vehicleid, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtBreakDownDetails = new DataTable();
            string result = string.Empty;
            try
            {

                object[] oParameters = new object[2];

                oParameters[0] = username;
                oParameters[1] = vehicleid;


                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[2];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("vehicleid", DbType.String);


                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtBreakDownDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_breakdown_details_new", oParameters, oNpgsqlParameter);



            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
              return dtBreakDownDetails;
            
           
         
        }


        public static DataTable InsertBreakDown(string username, string vehicleid, int buinessId)
        {
            DataTable dataDs = new DataTable();
            NpgsqlConnection connection = null;
            try
            {
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                NpgsqlTransaction tr = (NpgsqlTransaction)connection.BeginTransaction();
                NpgsqlCommand cursCmd = new NpgsqlCommand("usp_mobileapi_insert_breakdown_details_new", (NpgsqlConnection)connection);
                cursCmd.Transaction = tr;

                NpgsqlParameter intusername = new NpgsqlParameter("username", username);
                intusername.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(intusername);

                NpgsqlParameter intvehicleid = new NpgsqlParameter("vehicleid", vehicleid);
                intvehicleid.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(intvehicleid);

                NpgsqlParameter flag = new NpgsqlParameter("flag", NpgsqlTypes.NpgsqlDbType.Integer);
                flag.Direction = ParameterDirection.Output;
                cursCmd.Parameters.Add(flag);

             

                cursCmd.CommandType = CommandType.StoredProcedure;
                var adapter = new NpgsqlDataAdapter(cursCmd);
                adapter.Fill(dataDs);
                tr.Commit();
            }
            catch (Exception ex)
            {

                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dataDs;
        }
    }
}
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
    public class GeofenceRepository
    {


        #region  Insert Geofence details
        public static DataTable InsertGeofence(string geofencename, string geofenceboundary, string geoboundarydata, string username, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtGeofenceDetails = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[4];
                oParameters[0] = geofencename;
                oParameters[1] = geofenceboundary;
                oParameters[2] = geoboundarydata;
                oParameters[3] = username;

                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[4];
                oNpgsqlParameter[0] = new NpgsqlParameter("_geofencename", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("_geofenceboundary", DbType.String);
                oNpgsqlParameter[2] = new NpgsqlParameter("_geoboundarydata", DbType.String);
                oNpgsqlParameter[3] = new NpgsqlParameter("_username", DbType.String);

                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtGeofenceDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_insert_geofencedata", oParameters, oNpgsqlParameter);

            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtGeofenceDetails;
        }
        #endregion

        #region  Get Geofence details
        public static DataTable Geofence(string username, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtGeofenceDetails = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[1];
                oParameters[0] = username;

                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];
                oNpgsqlParameter[0] = new NpgsqlParameter("_username", DbType.String);

                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtGeofenceDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_geofence_data_basedonuser", oParameters, oNpgsqlParameter);

            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtGeofenceDetails;
        }
        #endregion

        #region  Delete the Geofence
        public static bool DeleteGeofence(string username, string geofencename, int buinessId)
        {
            // Declaring Variables
            NpgsqlConnection connection = null;
            bool result = false;
            try
            {
                object[] oParameters = new object[2];
                oParameters[0] = geofencename;
                oParameters[1] = username;
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                result = Convert.ToBoolean(NpgsqlHelper.ExecuteScalar(connection, "usp_mobileapi_delete_geofence", oParameters));
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        #endregion


        #region  Update Geofence details
        public static DataTable UpdateGeofence(string geofencename, string geofenceboundary, string geoboundarydata, string username, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtGeofenceDetails = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[4];
                oParameters[0] = geofencename;
                oParameters[1] = geofenceboundary;
                oParameters[2] = geoboundarydata;
                oParameters[3] = username;

                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[4];
                oNpgsqlParameter[0] = new NpgsqlParameter("_geofencename", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("_geofenceboundary", DbType.String);
                oNpgsqlParameter[2] = new NpgsqlParameter("_geoboundarydata", DbType.String);
                oNpgsqlParameter[3] = new NpgsqlParameter("_username", DbType.String);

                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtGeofenceDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_update_geofencedata", oParameters, oNpgsqlParameter);

            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtGeofenceDetails;
        }
        #endregion


        #region  Get vehicles mapped to a given geofence with dates.
        public static DataTable GeofenceVehicleMapping(string username, string geofencename, DateTime startdate, DateTime enddate, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtGeofenceDetails = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[4];
                oParameters[0] = username;
                oParameters[1] = geofencename;
                oParameters[2] = startdate;
                oParameters[3] = enddate;

                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[4];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", NpgsqlDbType.Text);
                oNpgsqlParameter[1] = new NpgsqlParameter("_geofencename", NpgsqlDbType.Text);
                oNpgsqlParameter[2] = new NpgsqlParameter("_startdate", NpgsqlDbType.Timestamp);
                oNpgsqlParameter[3] = new NpgsqlParameter("_enddate", NpgsqlDbType.Timestamp);

                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtGeofenceDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_mapped_to_geofence", oParameters, oNpgsqlParameter);

            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtGeofenceDetails;
        }
        #endregion


        #region  Lists currently active geofences
        public static DataTable ListsActiveGeofences(string username, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtGeofenceDetails = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[1];
                oParameters[0] = username;


                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", NpgsqlDbType.Text);


                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtGeofenceDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_active_geofence_mapped_to_vehicle", oParameters, oNpgsqlParameter);

            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtGeofenceDetails;
        }
        #endregion

        #region  Insert Geofence details 9.04
        public static DataTable InsertVehicleGeoFence(string username, int buinessId, string geofenceName, List<GeoFencePutRequest> geofenceRequest)
        {
            NpgsqlConnection connection = null;
            /*usp_mobileapi_insert_geofence_vehmapping(      username varchar, 
            geofence varchar,         vehicleid varchar,         _startdate timestamp with time zone, 
            _enddate timestamp with time zone,         _type varchar         ) 
           RETURNS TABLE ("GeofenceID" integer, "RegistrationNumber" varchar, geofencename varchar, "StartDate" timestamp with time zone,      "EndDate" timestamp with time zone, "Type" text) */
            // Create Cust Id column which Reprence Cust Id from
            // The cust Table
            // Create Description column.
            //dtColumn = new DataColumn();
            //dtColumn.DataType = System.Type.GetType("System.String");
            //dtColumn.ColumnName = "Description";
            //dtColumn.Caption = "DescriptionName";
            //ordersTable.Columns.Add(dtColumn);
            //customTable.Columns.Add("GeofenceID");
            //customTable.Columns.Add("RegistrationNumber");
            //customTable.Columns.Add("geofencename");
            //customTable.Columns.Add("StartDate");
            //customTable.Columns.Add("EndDate");
            //customTable.Columns.Add("Type");
            //DataTable dt = new DataTable();
            //DataRow _ravi = dt.NewRow();
            //_ravi["Name"] = "ravi";
            //_ravi["Marks"] = "500";
            //dt.Rows.Add(_ravi);
            DataTable dtGeofenceDetails = new DataTable();
            try
            {
                foreach (object geofen in geofenceRequest)
                {
                    GeoFencePutRequest _geofence = (GeoFencePutRequest)geofen;
                    string paramtoPass = string.Empty;
                    //object[] oParameters = new object[6];
                    //oParameters[0] = username;
                    //oParameters[1] = geofenceName;
                    paramtoPass = paramtoPass + _geofence.vehicleRegNo + "||" + _geofence.startDate + "||" + _geofence.endDate + "||" + _geofence.type;
                    paramtoPass = paramtoPass + "|||";
                }
                    //oParameters[3] = _geofence.startDate;
                    //oParameters[4] = _geofence.endDate;
                    //oParameters[5] = _geofence.type;
                    /*
                  username->  KingKhan   password->Srk@0211
                  kingkhan: n@n.com 
                  Phone Number -> 9820548180  
                  mtbdowner password Info@123 email= n1@n.com  phone number 9894539409
                    */
                    //NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[6];
                    //oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                    //oNpgsqlParameter[1] = new NpgsqlParameter("geofence", DbType.String);
                    //oNpgsqlParameter[2] = new NpgsqlParameter("vehicleid", DbType.String);
                    //oNpgsqlParameter[3] = new NpgsqlParameter("_startdate", DbType.DateTime);
                    //oNpgsqlParameter[4] = new NpgsqlParameter("_enddate", DbType.DateTime);
                    //oNpgsqlParameter[5] = new NpgsqlParameter("_type", DbType.String);
                    connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                    //dtGeofenceDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_insert_geofence_vehmapping", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtGeofenceDetails;
        }
        #endregion
    }
}
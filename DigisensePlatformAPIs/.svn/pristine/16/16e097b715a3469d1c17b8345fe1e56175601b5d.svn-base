using DigisensePlatformAPIs.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.DBUtilities
{
    public class RoutePlanRepository
    {

        #region   Route Plan Get All Route Plan[VerNo - 10.01]
        public static DataTable GetAllRoutePlan(string username, int buinessId)
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
                dtalerts = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_available_routes", oParameters, oNpgsqlParameter);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

            }
            return dtalerts;
        }
        #endregion

        #region   Route Plan Get All Route Plan[VerNo - 10.02]
        public static DataTable CreateRoutePlanPost(string username, int buinessId, RoutePlanRequestPost routeplanPostrequest)
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
                dtalerts = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_available_routes", oParameters, oNpgsqlParameter);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

            }
            return dtalerts;
        }
        #endregion

        #region   Route Plan Get All Route Plan[VerNo - 10.03]
        public static DataTable RoutePlanAssignToVehicles(string username, int buinessId, List<RoutePlanAssginRoute> routePlanAssignroute)
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
                dtalerts = NpgsqlHelper.ExecuteDataTable(connection, "Procedure needed", oParameters, oNpgsqlParameter);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

            }
            return dtalerts;
        }
        #endregion

        #region VeiwAssigned Trip For Vehicle 10.04
        public static DataTable ViewAssignTripForVehicle(string username, int buinessId, string vehicleRegNo)
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
                dtalerts = NpgsqlHelper.ExecuteDataTable(connection, "Procedure needed", oParameters, oNpgsqlParameter);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

            }
            return dtalerts;
        }
        #endregion

        #region   Route Plan [VerNo - 10.05]
        public static DataTable RoutePlan(string username, string _routename, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtalerts = new DataTable();
            string result = string.Empty;
            try
            {

                object[] oParameters = new object[2];

                oParameters[0] = username;
                oParameters[1] = _routename;


                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[2];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("_routename", DbType.String);


                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtalerts = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_routes", oParameters, oNpgsqlParameter);


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

        #region   Route Plan [VerNo - 10.06]
        public static DataTable UpdateOnGoingTrip(string username, int buinessId, List<UpdateOnGoingTripRequest> updateongoingTrip)
        {
            NpgsqlConnection connection = null;
            DataTable dtalerts = new DataTable();
            string result = string.Empty;
            try
            {

                object[] oParameters = new object[1];

                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[2];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("_routename", DbType.String);


                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtalerts = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_routes", oParameters, oNpgsqlParameter);


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
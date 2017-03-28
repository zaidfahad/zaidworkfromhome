﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.DBUtilities
{
    public class VehicleRepository
    {

        #region Vehicles Details 
        public static DataTable VehicleDetails(string username, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtVehicleDetails = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[1];
                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                //Akbar clearification Need here for error
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtVehicleDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_list_mtbd", oParameters, oNpgsqlParameter);
                
               // dtVehicleDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_list_generic", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtVehicleDetails;
        }
        #endregion


        #region Vehicles mapping driver Details
        public static DataTable VehicleDriverMapping(string username, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtVehicleDetails = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[1];
                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                //Akbar clearification Need here for error
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtVehicleDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_driver_list_mtbd", oParameters, oNpgsqlParameter);

                // dtVehicleDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_list_generic", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtVehicleDetails;
        }
        #endregion

        #region Vehicles Details MTBD
        public static DataTable VehicleDetailsMTBD(string username, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtVehicleDetails = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[1];
                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));//usp_mobileapi_get_vehicle_list_generic  [Need to ask Nilesh Sir]
                dtVehicleDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_list_mtbd", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dtVehicleDetails;
        }
        #endregion

        #region MTBD Vehicles Details
        public static DataTable MTBDVehicleDetails(string username, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtVehicleDetails = new DataTable();
            string result = string.Empty;
            try
            {

                object[] oParameters = new object[1];

                oParameters[0] = username;


                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);


                //Akbar changes done I need to verify
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtVehicleDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_list_mtbd", oParameters, oNpgsqlParameter);



            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtVehicleDetails;
        }
        #endregion


        #region  Vehicles Summary Details
        public static DataTable  VehicleSummaryDetails(string username,string vehregno , int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtVehicleSummaryDetails = new DataTable();
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
                dtVehicleSummaryDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_summary_mtbd", oParameters, oNpgsqlParameter);



            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtVehicleSummaryDetails;
        }
        #endregion


        #region  MTBD Vehicles Summary Details
        public static DataTable MTBDVehicleSummaryDetails(string username, string vehregno, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtVehicleSummaryDetails = new DataTable();
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
                dtVehicleSummaryDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_summary_mtbd", oParameters, oNpgsqlParameter);



            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtVehicleSummaryDetails;
        }
        #endregion


        #region    Vehicles Information
        public static DataTable VehicleInformation(string username, string vehregno, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtVehicleInformation = new DataTable();
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
                dtVehicleInformation = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_info_generic", oParameters, oNpgsqlParameter);



            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtVehicleInformation;
        }
        #endregion


        #region  MTBD  Vehicles Information
        public static DataTable MTBDVehicleInformation(string username, string vehregno, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtMTBDVehicleInformation = new DataTable();
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
                dtMTBDVehicleInformation = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_info_mtbd", oParameters, oNpgsqlParameter);



            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtMTBDVehicleInformation;
        }
        #endregion

        #region   VehicleLocationHistory
        public static DataTable VehicleLocationHistory(string username, string vehregno, DateTime startdate, DateTime enddate, int buinessId)
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
                oNpgsqlParameter[2] = new NpgsqlParameter("startdate", DbType.Date);
                oNpgsqlParameter[3] = new NpgsqlParameter("enddate", DbType.Date);

                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                //Akbar need to change

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


        #region   Vehicle Alerts
        public static DataTable VehicleAlerts(string username, DateTime startdate, DateTime enddate, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtalerts = new DataTable();
            string result = string.Empty;
            try
            {

                object[] oParameters = new object[3];

                oParameters[0] = username;
                oParameters[1] = startdate;
                oParameters[2] = enddate;

                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[3];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("startdate", DbType.Date);
                oNpgsqlParameter[2] = new NpgsqlParameter("enddate", DbType.Date);

                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtalerts = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_activealerts_forperiod", oParameters, oNpgsqlParameter);


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

        #region   Vehicle Alerts with perticular Vehicle
        public static DataTable SingleVehicleAlerts(string username, string vehregno, DateTime startdate, DateTime enddate, int buinessId)
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
                oNpgsqlParameter[2] = new NpgsqlParameter("startdate", DbType.Date);
                oNpgsqlParameter[3] = new NpgsqlParameter("enddate", DbType.Date);

                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtalerts = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehiclealerts_forperiod", oParameters, oNpgsqlParameter);


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

        #region   Mapping  driver Vehicle Details
        public static bool DriverVehicleMapping(string username,string vehicleregnum, Int32 _driverid, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtVehicleDetails = new DataTable();
            bool result = false;
            try
            {
                object[] oParameters = new object[3];
                oParameters[0] = username;
                oParameters[1] = vehicleregnum;
                oParameters[2] = _driverid;
                //NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[2];

                //oNpgsqlParameter[0] = new NpgsqlParameter("vehicleregnum", DbType.String);
                //oNpgsqlParameter[1] = new NpgsqlParameter("_driverid", DbType.Int32);
                //Akbar clearification Need here for error
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                result = Convert.ToBoolean(NpgsqlHelper.ExecuteScalar(connection, "usp_mobileapi_drivervehicle_unmapping", oParameters));


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

        #region   UNMapping  driver Vehicle Details
        public static bool DriverVehicleUNMapping(string username, string vehicleregnum, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtVehicleDetails = new DataTable();
            bool result = false;
            try
            {
                object[] oParameters = new object[2];
                oParameters[0] = username;
                oParameters[1] = vehicleregnum;
               
                //NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[2];

                //oNpgsqlParameter[0] = new NpgsqlParameter("vehicleregnum", DbType.String);
                //oNpgsqlParameter[1] = new NpgsqlParameter("_driverid", DbType.Int32);
                //Akbar clearification Need here for error
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                result = Convert.ToBoolean(NpgsqlHelper.ExecuteScalar(connection, "usp_mobileapi_vehicle_unmappingfromdriver", oParameters));


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
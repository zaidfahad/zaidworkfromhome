﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.DBUtilities
{
    public class ReportRepository
    {
        #region  Report Summary 8.02 
        public static DataTable ReportSummaryPlatformMTBD(string username, int buinessId)
        {
            DataTable dt = new DataTable();
            return dt;
        }
        #endregion

        #region  Report Summary 8.03
        public static DataTable ReportSummaryForSpecificVehicle(string username, int buinessId)
        {
            DataTable dt = new DataTable();
            return dt;
        }
        #endregion

        #region Vehicle running status for a given platform
        public static DataTable VehicleStatus(string username, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtVehicleStatus = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[1];
                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);

                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtVehicleStatus = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehiclestatus", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtVehicleStatus;
        }
        #endregion

        #region Vehicle health status for a given platform

        public static DataSet VehicleHealthStatus(string username, int buinessId)
        {
            DataSet dataDs = new DataSet();
            NpgsqlConnection connection = null;
            try
            {
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                NpgsqlTransaction tr = (NpgsqlTransaction)connection.BeginTransaction();
                NpgsqlCommand cursCmd = new NpgsqlCommand("usp_mobileapi_health_report", (NpgsqlConnection)connection);
                cursCmd.Transaction = tr;

                NpgsqlParameter intusername = new NpgsqlParameter("username", username);
                intusername.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(intusername);


                NpgsqlParameter refvehiclehealth = new NpgsqlParameter("refvehiclehealth", NpgsqlTypes.NpgsqlDbType.Refcursor);
                refvehiclehealth.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(refvehiclehealth);

                NpgsqlParameter refbreakdowncount = new NpgsqlParameter("refbreakdowncount", NpgsqlTypes.NpgsqlDbType.Refcursor);
                refbreakdowncount.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(refbreakdowncount);

                NpgsqlParameter refbrkdownalert = new NpgsqlParameter("refbrkdownalert", NpgsqlTypes.NpgsqlDbType.Refcursor);
                refbrkdownalert.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(refbrkdownalert);


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


        #endregion

        #region Other Report Summary From Swagger

        #region api/reportsummary/platform/mtbd/vehiclemovement/speeddata/{vehicleRegNo}

        public static DataTable PlatformVehilceMovementSpeedData(string username, int buinessId, string vehicleRegNo, DateTime startDate, DateTime endDate)
        {
            NpgsqlConnection connection = null;
            DataTable dtVehicleDetails = new DataTable();
            try
            {

                string result = string.Empty;

                object[] oParameters = new object[4];
                oParameters[0] = username;
                oParameters[1] = vehicleRegNo;
                oParameters[2] = startDate;
                oParameters[3] = endDate;
                /*
                        usp_mobileapi_get_vehicle_speedreport( 
                     IN username character varying, 
                IN vehregno character varying, 
                    IN fromdate timestamp with time zone, 
                    IN todate timestamp with time zone) 
              RETURNS TABLE("1-30" bigint, "31-50" bigint, "51-70" bigint, "71+" bigint) 
            12:03 PM 

             */
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[4];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("vehregno", DbType.String);
                oNpgsqlParameter[2] = new NpgsqlParameter("fromdate", DbType.DateTime);
                oNpgsqlParameter[3] = new NpgsqlParameter("todate", DbType.DateTime);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtVehicleDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_speedreport", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {

            }
            return dtVehicleDetails;
        }

        #endregion

        #region /reportsummary/platform/mtbd/vehiclemovement/usagetime/{vehicleRegNo}

        public static DataTable VehicleMovementUsageTime(string username, int buinessId, string vehicleRegNo, DateTime startDate, DateTime endDate)
        {
            NpgsqlConnection connection = null;
            DataTable dtresult = new DataTable();
            try
            {

                string result = string.Empty;

                object[] oParameters = new object[4];
                oParameters[0] = username;
                oParameters[1] = vehicleRegNo;
                oParameters[2] = startDate;
                oParameters[3] = endDate;
                /*
                usp_mobileapi_get_vehicle_usagetime( 
                IN username character varying, 
                IN vehregno character varying, 
                IN fromdate timestamp with time zone, 
                IN todate timestamp with time zone) 
                RETURNS TABLE("DrivingTime" double precision, "HaltTime" double precision, "IdleTime" double precision) 
              */
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[4];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("vehregno", DbType.String);
                oNpgsqlParameter[2] = new NpgsqlParameter("fromdate", DbType.DateTime);
                oNpgsqlParameter[3] = new NpgsqlParameter("todate", DbType.DateTime);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtresult = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_usagetime", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {

            }
            return dtresult;
        }

        #endregion

        #region GET /reportsummary/platform/mtbd/vehiclemovement/enginerpm/{vehicleRegNo}

        public static DataTable VehicleMovementEngineRpm(string username, int buinessId, string vehicleRegNo, DateTime startDate, DateTime endDate)
        {
            NpgsqlConnection connection = null;
            DataTable dtresult = new DataTable();
            try
            {

                string result = string.Empty;
                object[] oParameters = new object[4];
                oParameters[0] = username;
                oParameters[1] = vehicleRegNo;
                oParameters[2] = startDate;
                oParameters[3] = endDate;
                /*
                    usp_mobileapi_get_vehicle_engineepm( 
            IN username character varying, 
            IN vehregno character varying, 
                IN fromdate timestamp with time zone, 
                IN todate timestamp with time zone) 
          RETURNS TABLE("RPM1001To1500" double precision, "RPM1501To2000" double precision, "RPM2000To2500" double precision, "AboveRPM2500" double precision) AS

              */
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[4];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("vehregno", DbType.String);
                oNpgsqlParameter[2] = new NpgsqlParameter("fromdate", DbType.DateTime);
                oNpgsqlParameter[3] = new NpgsqlParameter("todate", DbType.DateTime);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtresult = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_engineepm", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {

            }
            return dtresult;
        }

        #endregion

        #region /reportsummary/platform/mtbd/vehiclemovement/vehiclemovementsummary/{vehicleRegNo}

        public static DataTable VehicleMovementSummary(string username, int buinessId, string vehicleRegNo, DateTime startDate, DateTime endDate)
        {
            NpgsqlConnection connection = null;
            DataTable dtresult = new DataTable();
            try
            {

                string result = string.Empty;
                object[] oParameters = new object[4];
                oParameters[0] = username;
                oParameters[1] = vehicleRegNo;
                oParameters[2] = startDate;
                oParameters[3] = endDate;
                /*
                             usp_mobileapi_get_vehicle_reportsummary( 
                IN username character varying, 
                IN vehregno character varying, 
                    IN fromdate timestamp with time zone, 
                    IN todate timestamp with time zone) 
              RETURNS TABLE("StartTime" text, "EndTime" text, "Duration" double precision, "AverageSpeed" double precision, "DistanceTravelled" double precision, "IdleDuration" double precision,
              "StartedFrom" varchar, "ArrivedAt" varchar, "StartFuel" double precision, "EndFuel" double precision, 
              "FE Trip A"  double precision, "FE Trip B" double precision, "VehicleRegNo" varchar, fuel_refill boolean, 
              refill_quantity double precision, refill_time timestamp with time zone) 


              */
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[4];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("vehregno", DbType.String);
                oNpgsqlParameter[2] = new NpgsqlParameter("fromdate", DbType.DateTime);
                oNpgsqlParameter[3] = new NpgsqlParameter("todate", DbType.DateTime);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtresult = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_reportsummary", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {

            }
            return dtresult;
        }

        #endregion

        #region  /reportsummary/platform/mtbd/vehiclemovement/vehiclemovementreport/{vehicleRegNo}

        public static DataTable VehicleMovementReport(string username, int buinessId)
        {
            DataTable dt = new DataTable();
            return dt;
        }

        #endregion

        #region  GET /reportsummary/platform/mtbd/alerts/vehiclealerts/{vehicleRegNo}

        public static DataTable VehicleAlerts(string username, int buinessId)
        {
            DataTable dt = new DataTable();
            return dt;
        }

        #endregion

        #region GET /reportsummary/platform/mtbd/alerts/violation/{vehicleRegNo}
        public static DataTable AlertsViolation(string username, int buinessId)
        {
            DataTable dt = new DataTable();
            return dt;
        }
        #endregion

        #region GET /reportsummary/platform/mtbd/alerts/alertssummary/{vehicleRegNo}
        public static DataTable AlertsSummary(string username, int buinessId)
        {
            DataTable dt = new DataTable();
            return dt;
        }
        #endregion

        #region GET /reportsummary/platform/mtbd/delivery/vehicleusage/{vehicleRegNo}
        public static DataTable VehicleUsage(string username, int buinessId)
        {
            DataTable dt = new DataTable();
            return dt;
        }
        #endregion

        #region GET /reportsummary/platform/mtbd/delivery/vehicleusagesummary/{vehicleRegNo}
        public static DataTable VehicleUsageSummary(string username, int buinessId)
        {
            DataTable dt = new DataTable();
            return dt;
        }

        #endregion

        #region GET /reportsummary/platform/mtbd/vehiclehealth/vehiclehealthsummary/{vehicleRegNo}
        public static DataTable VehicleHealthSummary(string username, int buinessId)
        {
            DataTable dt = new DataTable();
            return dt;
        }

        #endregion

        #region GET /reportsummary/platform/mtbd/driver/distancecovered
        public static DataTable DistanceCovered(string username, int buinessId)
        {
            DataTable dt = new DataTable();
            return dt;
        }

        #endregion

        #region report/delivery/{vehicleRegNo}/{delivery}
        public static DataTable ReportSummaryDeliveryVehicle(string buinessId, int BusinessType)
        {
            DataTable dt = new DataTable();
            return dt;
        }
        #endregion

        #region /report/vehiclehealth/{vehicleRegNo}/{vehiclehealth}
        public static DataTable VehicleHealth(string buinessId, int BusinessType)
        {
            DataTable dt = new DataTable();
            return dt;
        }
        #endregion

        #region /report/alerts/{vehicleRegNo}/{alerts}
        public static DataTable ReportAlerts(string buinessId, int BusinessType)
        {
            DataTable dt = new DataTable();
            return dt;
        }
        #endregion
        #endregion
    }
}
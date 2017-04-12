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

        #region  Report Summary 8.03  api/report/{vehicleRegNo}
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

        #region api/report/platform/mtbd/vehiclemovement/speeddata/{vehicleRegNo}

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

        #region /report/platform/mtbd/vehiclemovement/usagetime/{vehicleRegNo}

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

        #region GET/report/platform/mtbd/vehiclemovement/enginerpm/{vehicleRegNo}

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

        #region /report/platform/mtbd/vehiclemovement/vehiclemovementsummary/{vehicleRegNo}

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

        #region    ///report/platform/mtbd/vehiclemovement/vehiclemovementreport/{vehicleRegNo}

        public static DataTable VehicleMovementReport(string username, int buinessId, string vehicleRegNo, DateTime startDate, DateTime endDate)
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
                /*usp_mobileapi_vehicle_movement_report(
                username varchar,
                vehicle varchar,
                fromdate timestamp with time zone,
                todate timestamp with time zone
                )
                RETURNS TABLE ("Date" date, "DistanceTravelled" double precision, "DrivingTime" double precision, "IdleTime" double precision)
                */
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[4];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("vehregno", DbType.String);
                oNpgsqlParameter[2] = new NpgsqlParameter("fromdate", DbType.DateTime);
                oNpgsqlParameter[3] = new NpgsqlParameter("todate", DbType.DateTime);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtresult = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_vehicle_movement_report", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
            }
            return dtresult;
        }

        #endregion

        #region  GET /report/platform/mtbd/alerts/vehiclealerts/{vehicleRegNo}

        public static DataSet VehicleAlerts(string username, int buinessId, string vehicleRegNo, DateTime startDate, DateTime endDate)
        {
            /*
                usp_mobileapi_vehicle_alert_report(
                username varchar,
                vehicle varchar,
                fromDate timestamp with time zone,
                toDate timestamp with time zone,
                refbrkdownalert refcursor,
                refhighenginetemp refcursor,
                refTamperDetection refcursor,
                refBatteryDisconnected refcursor,
                refserviceduealert refcursor,
                refFitnessCertification refcursor,
                refInsurancePayment refcursor
                )
                RETURNS SETOF refcursor
            */
            DataSet dataDs = new DataSet();
            NpgsqlConnection connection = null;
            try
            {
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                NpgsqlTransaction tr = (NpgsqlTransaction)connection.BeginTransaction();
                NpgsqlCommand cursCmd = new NpgsqlCommand("usp_mobileapi_vehicle_alert_report", (NpgsqlConnection)connection);
                cursCmd.Transaction = tr;

                NpgsqlParameter intusername = new NpgsqlParameter("username", username);
                intusername.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(intusername);

                NpgsqlParameter vehicle = new NpgsqlParameter("vehicle", vehicleRegNo);
                vehicle.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(vehicle);

                NpgsqlParameter fromDate = new NpgsqlParameter("fromDate", startDate);
                fromDate.DbType = DbType.Date;
                fromDate.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(fromDate);

                NpgsqlParameter toDate = new NpgsqlParameter("toDate", endDate);
                toDate.DbType = DbType.Date;
                toDate.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(toDate);


                NpgsqlParameter refbrkdownalert = new NpgsqlParameter("refbrkdownalert", NpgsqlTypes.NpgsqlDbType.Refcursor);
                refbrkdownalert.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(refbrkdownalert);

                NpgsqlParameter refhighenginetemp = new NpgsqlParameter("refhighenginetemp", NpgsqlTypes.NpgsqlDbType.Refcursor);
                refhighenginetemp.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(refhighenginetemp);


                NpgsqlParameter refTamperDetection = new NpgsqlParameter("refTamperDetection", NpgsqlTypes.NpgsqlDbType.Refcursor);
                refTamperDetection.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(refTamperDetection);

                NpgsqlParameter refBatteryDisconnected = new NpgsqlParameter("refBatteryDisconnected", NpgsqlTypes.NpgsqlDbType.Refcursor);
                refBatteryDisconnected.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(refBatteryDisconnected);


                NpgsqlParameter refserviceduealert = new NpgsqlParameter("refserviceduealert", NpgsqlTypes.NpgsqlDbType.Refcursor);
                refserviceduealert.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(refserviceduealert);



                NpgsqlParameter refFitnessCertification = new NpgsqlParameter("refFitnessCertification", NpgsqlTypes.NpgsqlDbType.Refcursor);
                refFitnessCertification.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(refFitnessCertification);


                NpgsqlParameter refInsurancePayment = new NpgsqlParameter("refInsurancePayment", NpgsqlTypes.NpgsqlDbType.Refcursor);
                refInsurancePayment.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(refInsurancePayment);



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

        #region GET /report/platform/mtbd/alerts/violation/{vehicleRegNo}
        public static DataSet AlertsViolation(string username, int buinessId,string vehicleRegNo,DateTime startDate,DateTime endDate)
        {
            /*
                 usp_mobileapi_vehicle_violation_report(
                 username varchar,
                 vehicle varchar,
                 fromdate timestamp with time zone,
                 todate timestamp with time zone,
                 refgeofencealert refcursor,
                 refexcessiveidiling refcursor,
                 reoverspeeding refcursor,
                 reffueltheft refcursor,
                 refNightDriving refcursor
                 ) 
            */
            DataSet dataDs = new DataSet();
            NpgsqlConnection connection = null;
            try
            {
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                NpgsqlTransaction tr = (NpgsqlTransaction)connection.BeginTransaction();
                NpgsqlCommand cursCmd = new NpgsqlCommand("usp_mobileapi_vehicle_violation_report", (NpgsqlConnection)connection);
                cursCmd.Transaction = tr;

                NpgsqlParameter intusername = new NpgsqlParameter("username", username);
                intusername.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(intusername);

                NpgsqlParameter vehicle = new NpgsqlParameter("vehicle", vehicleRegNo);
                vehicle.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(vehicle);

                NpgsqlParameter fromDate = new NpgsqlParameter("fromDate", startDate);
                fromDate.DbType = DbType.Date;
                fromDate.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(fromDate);

                NpgsqlParameter toDate = new NpgsqlParameter("toDate", endDate);
                toDate.DbType = DbType.Date;
                toDate.Direction = ParameterDirection.Input;
                cursCmd.Parameters.Add(toDate);

                // 1 refgeofencealert
                NpgsqlParameter refgeofencealert = new NpgsqlParameter("refgeofencealert", NpgsqlTypes.NpgsqlDbType.Refcursor);
                refgeofencealert.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(refgeofencealert);
                //2 refgeofencealert
                NpgsqlParameter refexcessiveidiling = new NpgsqlParameter("refexcessiveidiling", NpgsqlTypes.NpgsqlDbType.Refcursor);
                refexcessiveidiling.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(refexcessiveidiling);

                //3 reoverspeeding
                NpgsqlParameter reoverspeeding = new NpgsqlParameter("reoverspeeding", NpgsqlTypes.NpgsqlDbType.Refcursor);
                reoverspeeding.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(reoverspeeding);

                // 4 reffueltheft
                NpgsqlParameter reffueltheft = new NpgsqlParameter("reffueltheft", NpgsqlTypes.NpgsqlDbType.Refcursor);
                reffueltheft.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(reffueltheft);

                // 4 refNightDriving
                NpgsqlParameter refNightDriving = new NpgsqlParameter("refNightDriving", NpgsqlTypes.NpgsqlDbType.Refcursor);
                refNightDriving.Direction = ParameterDirection.InputOutput;
                cursCmd.Parameters.Add(refNightDriving);


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

        #region GET /reportsummary/platform/mtbd/alerts/alertssummary/{vehicleRegNo}
        public static DataTable AlertsSummary(string username, int buinessId,string vehicleRegNo,DateTime startDate,DateTime endDate)
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
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[4];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("vehregno", DbType.String);
                oNpgsqlParameter[2] = new NpgsqlParameter("fromdate", DbType.DateTime);
                oNpgsqlParameter[3] = new NpgsqlParameter("todate", DbType.DateTime);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtresult = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_alertsummary", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
            }
            return dtresult;
        }
        #endregion
        //report/platform/mtbd/delivery/vehicleusage/
        #region GET /report/platform/mtbd/delivery/vehicleusage/{vehicleRegNo}
        public static DataTable VehicleUsage(string username, int buinessId, string vehicleRegNo, DateTime startDate, DateTime endDate)
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
                */
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[4];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("vehregno", DbType.String);
                oNpgsqlParameter[2] = new NpgsqlParameter("fromdate", DbType.DateTime);
                oNpgsqlParameter[3] = new NpgsqlParameter("todate", DbType.DateTime);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtresult = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_vehicle_usage_report", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
            }
            return dtresult;
        }
        #endregion

        #region GET /report/platform/mtbd/delivery/vehicleusagesummary/{vehicleRegNo}
        public static DataTable VehicleUsageSummary(string username, int buinessId)
        {
            DataTable dt = new DataTable();
            return dt;
        }

        #endregion

        #region GET /reportsummary/platform/mtbd/vehiclehealth/vehiclehealthsummary/{vehicleRegNo}
        public static DataTable VehicleHealthSummary(string username, int buinessId,string vehicleRegNo,DateTime startDate,DateTime endDate)
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
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[4];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("vehregno", DbType.String);
                oNpgsqlParameter[2] = new NpgsqlParameter("fromdate", DbType.DateTime);
                oNpgsqlParameter[3] = new NpgsqlParameter("todate", DbType.DateTime);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtresult = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_vehicle_healthsummary", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
            }
            return dtresult;
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
﻿using DigisensePlatformAPIs.Models;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.DBUtilities
{
    public class DriverRepository
    {

        #region Driver Details
        public static DataTable DriverDetails(string username, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtDriverDetails = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[1];
                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtDriverDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_driver_info", oParameters, oNpgsqlParameter);
               
            
                                                                                  
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtDriverDetails;
        }
        #endregion

        #region Driver assign vehicles Details
        public static DataTable DriverAssignVehiclesDetails(string username, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtDriverAssignVehiclesDetails = new DataTable();
            string result = string.Empty;
            try
            {
                object[] oParameters = new object[1];
                oParameters[0] = username;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[1];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtDriverAssignVehiclesDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_driver_assigned_vehicles", oParameters, oNpgsqlParameter);



            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtDriverAssignVehiclesDetails;
        }
        #endregion

        #region Driver Profile Details
        public static DataTable DriverProfileDetails(string username, int driverid, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtDriverDetails = new DataTable();
            string result = string.Empty;
            try
            {

                object[] oParameters = new object[2];
                oParameters[0] = username;
                oParameters[1] = driverid;

                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[2];
                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("driverid", DbType.Int32);
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtDriverDetails = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_driver_profile", oParameters, oNpgsqlParameter);
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtDriverDetails;
        }
        #endregion

        #region Get Driver Ranking Data
        public static DataTable GetDriverRanking(string username, DateTime startdate, DateTime enddate, int buinessId)
        {
            NpgsqlConnection connection = null;
            DataTable dtDriverRanking = new DataTable();
            try
            {


                object[] oParameters = new object[3];

                oParameters[0] = username;
                oParameters[1] = startdate;
                oParameters[2] = enddate;
                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[3];

                oNpgsqlParameter[0] = new NpgsqlParameter("username", DbType.String);
                oNpgsqlParameter[1] = new NpgsqlParameter("startdate", DbType.DateTime);
                oNpgsqlParameter[2] = new NpgsqlParameter("enddate", DbType.DateTime);

                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                dtDriverRanking = NpgsqlHelper.ExecuteDataTable(connection, "usp_mobileapi_get_driverranking", oParameters, oNpgsqlParameter);
                


            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return dtDriverRanking;
        }
        #endregion

        /// <summary>
        /// Insert Driver details  
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="usd"></param>
        /// <returns></returns>

        #region Insert Driver Details
        public static string InsertDriverDetails(string username, Driver objDriver, int buinessId)
        {
            // Declaring Variables
            NpgsqlConnection connection = null;
            string isCreated = "";
            try
            {
                object[] oParameters = new object[12];
                oParameters[0] = objDriver.firstName;
                oParameters[1] = objDriver.lastName;
                oParameters[2] = objDriver.address;
                oParameters[3] = objDriver.email;
                oParameters[4] = objDriver.contactNumber;
                oParameters[5] =  Convert.FromBase64String(objDriver.idProof);
                oParameters[6] = username;
                oParameters[7] = objDriver.idprooftypeid;
                oParameters[8] = objDriver.idproofnumber;
                oParameters[9] = objDriver.idproofpath;
                oParameters[10] = objDriver.benchmarkFE;
                oParameters[11] = objDriver.benchmarkDistance;
           
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
               // isCreated = Convert.ToString(NpgsqlHelper.ExecuteScalar(connection, "usp_mobileapi_insert_driver_details", oParameters));
                isCreated = Convert.ToString(NpgsqlHelper.ExecuteScalar(connection, "usp_mobileapi_insert_driver_details_validation", oParameters));
            }
            catch (Exception ex)
            {
            }
            return isCreated;
        }
        #endregion

        #region Driver Profile for Patch Request
        public static string DriverProfileWithDriverIdUpdate(string username, DriverUpdate objDriver, int buinessId)
        {
            // Declaring Variables
            NpgsqlConnection connection = null;
            string isCreated = "";
            //DataTable dtDriverDetails = new DataTable();
            try
            {
                object[] oParameters = new object[12];
                oParameters[0] = objDriver.firstName;
                oParameters[1] = objDriver.lastName;
                oParameters[2] = objDriver.address;
                oParameters[3] = objDriver.email;
                oParameters[4] = objDriver.contactNumber;
                oParameters[5] = objDriver.idProof;
                oParameters[6] = objDriver.id;
                oParameters[7] = objDriver.idprooftypeid;
                oParameters[8] = objDriver.idproofnumber;
                oParameters[9] = objDriver.benchmarkFE;
                oParameters[10] = objDriver.benchmarkDistance;
                oParameters[11] = username;

                NpgsqlParameter[] oNpgsqlParameter = new NpgsqlParameter[12];
                oNpgsqlParameter[0] = new NpgsqlParameter("firstname", NpgsqlDbType.Text);
                oNpgsqlParameter[1] = new NpgsqlParameter("lastname", NpgsqlDbType.Text);
                oNpgsqlParameter[2] = new NpgsqlParameter("Address", NpgsqlDbType.Text);
                oNpgsqlParameter[3] = new NpgsqlParameter("inputemail", NpgsqlDbType.Text);
                oNpgsqlParameter[4] = new NpgsqlParameter("mobilenumber", NpgsqlDbType.Text);
                oNpgsqlParameter[5] = new NpgsqlParameter("idproofdata", NpgsqlDbType.Bytea);
                oNpgsqlParameter[6] = new NpgsqlParameter("driverid", NpgsqlDbType.Integer);
                oNpgsqlParameter[7] = new NpgsqlParameter("idprooftypeid", NpgsqlDbType.Text);
                oNpgsqlParameter[8] = new NpgsqlParameter("idproofnumber", NpgsqlDbType.Text);
                oNpgsqlParameter[9] = new NpgsqlParameter("benchmarkfe", NpgsqlDbType.Text);
                oNpgsqlParameter[10] = new NpgsqlParameter("benchmarkkmspermonth", NpgsqlDbType.Text);
                oNpgsqlParameter[11] = new NpgsqlParameter("username", NpgsqlDbType.Text);

                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                isCreated = Convert.ToString(NpgsqlHelper.ExecuteScalar(connection, "usp_mobileapi_update_driver_details_validation", oParameters));
               // isCreated = Convert.ToString(NpgsqlHelper.ExecuteScalar(connection,"usp_mobileapi_update_driver_details_validation", oParameters, oNpgsqlParameter));
            }
            catch (Exception ex)
            {
            }
            return isCreated;
        }
        #endregion


        #region Driver Profile for Delete Request
        public static string DriverProfileDelete(string username, string driveId, int buinessId)
        {
            // Declaring Variables
            NpgsqlConnection connection = null;
            string isCreated = "2";
            try
            {
                object[] oParameters = new object[2];
                oParameters[0] = username;
                oParameters[1] = driveId;
                connection = DBConnection.GetConnection(Convert.ToInt16(buinessId));
                isCreated = Convert.ToString(NpgsqlHelper.ExecuteScalar(connection, "usp_mobileapi_delete_driver_details", oParameters));
            }
            catch (Exception ex)
            {
            }
            return isCreated;
        }
        #endregion

       
    }
}
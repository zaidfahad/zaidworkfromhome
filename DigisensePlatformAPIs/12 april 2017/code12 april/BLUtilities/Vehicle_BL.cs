﻿using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using DigisensePlatformAPIs.Utilities;
namespace DigisensePlatformAPIs.BLUtilities
{
    public class Vehicle_BL
    {

        #region    Vehicle Response
        public static List<VehicleResponse> VehicleResponse(DataTable dt)
        {
            List<VehicleResponse> list = new List<VehicleResponse>();
            list.Clear();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //VehicleResponse clsVehicleResponse = new VehicleResponse();
                     
                    //clsVehicleResponse.lastknownlocation = new Vehiclelocation { latitude = dt.Rows[i]["latitude"].ToString(), longitude = dt.Rows[i]["longitude"].ToString() };
                    //clsVehicleResponse.vehicleModel = dt.Rows[i]["Model"].ToString();
                    //clsVehicleResponse.vehicleVariant = dt.Rows[i]["variant_name"].ToString();
                   
                    //clsVehicleResponse.vehicleRegNo = dt.Rows[i]["RegistrationNumber"].ToString();
                    //clsVehicleResponse.status = dt.Rows[i]["Status"].ToString();
                    //clsVehicleResponse.lastupdated = Convert.ToDateTime(dt.Rows[i]["VehicleLastUsed"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    //clsVehicleResponse.priorityAlertStatus = dt.Rows[i]["PriorityAlertStatus"].ToString();
                    //list.Add(clsVehicleResponse);
                    VehicleResponse clsVehicleResponse = new VehicleResponse();

                    clsVehicleResponse.vehiclePlatform = dt.Rows[i]["platform"].ToString();
                    clsVehicleResponse.vehicleModel = dt.Rows[i]["Model"].ToString();
                    clsVehicleResponse.vehicleVariant = dt.Rows[i]["variant_name"].ToString();
                    // clsMTBDVehicleResponse.lastknownlocation.Add(dt.Rows[i]["latitude"].ToString(),dt.Rows[i]["longitude"].ToString());
                    clsVehicleResponse.lastknownlocation = new Vehiclelocation { latitude = dt.Rows[i]["latitude"].ToString() == "" ? 180 : Convert.ToDouble(dt.Rows[i]["latitude"].ToString()), longitude = dt.Rows[i]["longitude"].ToString() == "" ? 180 : Convert.ToDouble(dt.Rows[i]["longitude"].ToString()) };
                   // clsVehicleResponse.lastknownlocation = new Vehiclelocation { latitude =Convert.ToDouble(dt.Rows[i]["latitude"].ToString()), longitude = Convert.ToDouble(dt.Rows[i]["longitude"].ToString()) };
                    clsVehicleResponse.vehicleRegNo = dt.Rows[i]["RegistrationNumber"].ToString();
                    clsVehicleResponse.status = dt.Rows[i]["Status"].ToString();
                    if (dt.Rows[i]["VehicleLastUsed"].ToString() != "")
                    {
                       // clsVehicleResponse.lastupdated = String.Format(" {0:zzz}", "2017-02-20 01:52:53.482".ToString());
                        clsVehicleResponse.lastupdated = Convert.ToDateTime(dt.Rows[i]["VehicleLastUsed"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                         //clsVehicleResponse.lastupdated = Convert.ToDateTime(dt.Rows[i]["VehicleLastUsed"].ToString()).ToString("yyyy-MM-dd'T'HH:mm:ss.zzz'Z'");

                         
                    }
                    else
                    {
                        clsVehicleResponse.lastupdated = Convert.ToDateTime("1900-01-01 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    clsVehicleResponse.priorityAlertStatus = Convert.ToBoolean(dt.Rows[i]["PriorityAlertStatus"].ToString());
                    clsVehicleResponse.address = "Not available";
                    //Akbar will update procedure for these values
                    clsVehicleResponse.driverName = dt.Rows[i]["DriverName"].ToString();

                    clsVehicleResponse.speed = dt.Rows[i]["VehicleSpeed"].ToString() == "" ? "0" : dt.Rows[i]["VehicleSpeed"].ToString();
                    clsVehicleResponse.runningHours = dt.Rows[i]["runninghours"].ToString() == "" ? "0" : dt.Rows[i]["runninghours"].ToString();
                    list.Add(clsVehicleResponse);
                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        #endregion

        #region  MTBD Vehicle Response
        public static List<MTBDVehicleResponse> MTBDVehicleResponse(DataTable dt)
        {
            MTBDVehicleResponse clsMTBDVehicleResponse = null;
            List<MTBDVehicleResponse> list = new List<MTBDVehicleResponse>();
           // location clslocation = null;
           // List<location> sublocationlist = null;
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //sublocationlist = new List<location>();
                    //clslocation = new location();
                    //clslocation.latitude = dt.Rows[i]["latitude"].ToString();
                    //clslocation.longitude = dt.Rows[i]["longitude"].ToString();
                    //sublocationlist.Add(clslocation);

                    clsMTBDVehicleResponse = new MTBDVehicleResponse();
                    clsMTBDVehicleResponse.vehiclePlatform = dt.Rows[i]["platform"].ToString();
                    clsMTBDVehicleResponse.vehicleModel = dt.Rows[i]["Model"].ToString();
                    clsMTBDVehicleResponse.vehicleVariant = dt.Rows[i]["variant_name"].ToString();
                   // clsMTBDVehicleResponse.lastknownlocation.Add(dt.Rows[i]["latitude"].ToString(),dt.Rows[i]["longitude"].ToString());
                    clsMTBDVehicleResponse.lastknownlocation = new Vehiclelocation { latitude = dt.Rows[i]["latitude"].ToString() == "" ? 180 : Convert.ToDouble(dt.Rows[i]["latitude"].ToString()), longitude = dt.Rows[i]["longitude"].ToString() == "" ? 180 : Convert.ToDouble(dt.Rows[i]["longitude"].ToString()) };
                    //clsMTBDVehicleResponse.lastknownlocation = new Vehiclelocation { latitude = Convert.ToDouble(dt.Rows[i]["latitude"].ToString()), longitude = Convert.ToDouble(dt.Rows[i]["longitude"].ToString()) };
                    clsMTBDVehicleResponse.vehicleRegNo = dt.Rows[i]["RegistrationNumber"].ToString();
                    clsMTBDVehicleResponse.status = dt.Rows[i]["Status"].ToString();
                    if (dt.Rows[i]["VehicleLastUsed"].ToString() != "")
                    {
                        clsMTBDVehicleResponse.lastupdated = Convert.ToDateTime(dt.Rows[i]["VehicleLastUsed"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                      
                    }
                    else
                    {
                        clsMTBDVehicleResponse.lastupdated = Convert.ToDateTime("1900-01-01 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    clsMTBDVehicleResponse.priorityAlertStatus = Convert.ToBoolean(dt.Rows[i]["PriorityAlertStatus"].ToString());
                    //Akbar will update procedure for these values
                    clsMTBDVehicleResponse.driverName = dt.Rows[i]["DriverName"].ToString();
                    clsMTBDVehicleResponse.address = "Not available";
                   // clsMTBDVehicleResponse.speed = dt.Rows[i]["VehicleSpeed"].ToString();
                   // clsMTBDVehicleResponse.runningHours = dt.Rows[i]["runninghours"].ToString();
                    clsMTBDVehicleResponse.speed = dt.Rows[i]["VehicleSpeed"].ToString() == "" ? "0" : dt.Rows[i]["VehicleSpeed"].ToString();
                    clsMTBDVehicleResponse.runningHours = dt.Rows[i]["runninghours"].ToString() == "" ? "0" : dt.Rows[i]["runninghours"].ToString();
                    list.Add(clsMTBDVehicleResponse);

                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        #endregion

        #region  Vehicle Summary Response
        public static List<VehicleSummaryResponse> VehicleSummaryResponse(DataTable dt)
        {
            VehicleSummaryResponse clsVehicleSummaryResponse = null;
            List<VehicleSummaryResponse> list = new List<VehicleSummaryResponse>();
            try
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsVehicleSummaryResponse = new VehicleSummaryResponse();
                    clsVehicleSummaryResponse.vehicleRegNo = dt.Rows[i]["RegistrationNumber"].ToString();
                   // clsVehicleSummaryResponse.vehicleLastUsed = Convert.ToDateTime(dt.Rows[i]["VehicleLastUsed"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    if (dt.Rows[i]["VehicleLastUsed"].ToString() != "")
                    {
                        clsVehicleSummaryResponse.vehicleLastUsed = Convert.ToDateTime(dt.Rows[i]["VehicleLastUsed"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        clsVehicleSummaryResponse.vehicleLastUsed = Convert.ToDateTime("1900-01-01 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    clsVehicleSummaryResponse.runninghours = dt.Rows[i]["runninghours"].ToString() == "" ? "0" : Convert.ToDouble(dt.Rows[i]["runninghours"].ToString()).ConvertSecondsintoHHMMSSFormat();
                    clsVehicleSummaryResponse.idlehours = dt.Rows[i]["idlehours"].ToString() == "" ? "0" : Convert.ToDouble(dt.Rows[i]["idlehours"].ToString()).ConvertSecondsintoHHMMSSFormat();
                    clsVehicleSummaryResponse.TotalHours = dt.Rows[i]["TotalHours"].ToString() == "" ? "0" : Convert.ToDouble(dt.Rows[i]["TotalHours"].ToString()).ConvertSecondsintoHHMMSSFormat(); 
                    list.Add(clsVehicleSummaryResponse);

                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        #endregion

        #region  MTBD Vehicle Summary Response
        public static List<MTBDVehicleSummaryResponse> MTBDVehicleSummaryResponse(DataTable dt)
        {
            MTBDVehicleSummaryResponse clsMTBDVehicleSummaryResponse = null;
            List<MTBDVehicleSummaryResponse> list = new List<MTBDVehicleSummaryResponse>();
            try
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsMTBDVehicleSummaryResponse = new MTBDVehicleSummaryResponse();
                    clsMTBDVehicleSummaryResponse.vehicleRegNo = dt.Rows[i]["RegistrationNumber"].ToString();
                    //clsMTBDVehicleSummaryResponse.vehicleLastUsed = dt.Rows[i]["VehicleLastUsed"].ToString();
                   // clsMTBDVehicleSummaryResponse.vehicleLastUsed = Convert.ToDateTime(dt.Rows[i]["VehicleLastUsed"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    if (dt.Rows[i]["VehicleLastUsed"].ToString() != "")
                    {
                        clsMTBDVehicleSummaryResponse.vehicleLastUsed = Convert.ToDateTime(dt.Rows[i]["VehicleLastUsed"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        clsMTBDVehicleSummaryResponse.vehicleLastUsed = Convert.ToDateTime("1900-01-01 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
                    }
                   // clsMTBDVehicleSummaryResponse.runninghours = dt.Rows[i]["runninghours"].ToString();
                  //  clsMTBDVehicleSummaryResponse.idlehours = dt.Rows[i]["idlehours"].ToString();
                  //  clsMTBDVehicleSummaryResponse.TotalHours = dt.Rows[i]["TotalHours"].ToString();

                    clsMTBDVehicleSummaryResponse.runninghours = dt.Rows[i]["runninghours"].ToString() == "" ? "0" : Convert.ToDouble(dt.Rows[i]["runninghours"]).ConvertSecondsintoHHMMSSFormat();
                    clsMTBDVehicleSummaryResponse.idlehours = dt.Rows[i]["idlehours"].ToString() == "" ? "0" : Convert.ToDouble(dt.Rows[i]["idlehours"].ToString()).ConvertSecondsintoHHMMSSFormat();
                    clsMTBDVehicleSummaryResponse.TotalHours = dt.Rows[i]["TotalHours"].ToString() == "" ? "0" : Convert.ToDouble(dt.Rows[i]["TotalHours"].ToString()).ConvertSecondsintoHHMMSSFormat(); 
                    list.Add(clsMTBDVehicleSummaryResponse);

                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        #endregion

        #region  VehicleInformation Response
        public static List<VehicleInformationResponse> VehicleInformationResponse(DataTable dt)
        {
            VehicleInformationResponse clsVehicleInformationResponse = null;
            List<VehicleInformationResponse> list = new List<VehicleInformationResponse>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsVehicleInformationResponse = new VehicleInformationResponse();
                    //clsVehicleInformationResponse.vehicleModel = dt.Rows[i]["Model"].ToString();
                    //clsVehicleInformationResponse.vehicleVariant = dt.Rows[i]["variant_name"].ToString();
                    clsVehicleInformationResponse.vehicleRegNo = dt.Rows[i]["RegistrationNumber"].ToString();
                    //Akbar will do this status only
                    clsVehicleInformationResponse.vehicleStatus = dt.Rows[i]["Status"].ToString();
                   // clsVehicleInformationResponse.lastUpdated = dt.Rows[i]["VehicleLastUsed"].ToString();
                  //  clsVehicleInformationResponse.lastUpdated = Convert.ToDateTime(dt.Rows[i]["VehicleLastUsed"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    if (dt.Rows[i]["VehicleLastUsed"].ToString() != "")
                    {
                        clsVehicleInformationResponse.lastUpdated = Convert.ToDateTime(dt.Rows[i]["VehicleLastUsed"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        clsVehicleInformationResponse.lastUpdated = Convert.ToDateTime("1900-01-01 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    list.Add(clsVehicleInformationResponse);
                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        #endregion

        #region   MTBD VehicleInformation Response
        public static List<MTBDVehicleInformationResponse> MTBDVehicleInformationResponse(DataTable dt)
        {
            MTBDVehicleInformationResponse clsMTBDVehicleInformationResponse = null;
            List<MTBDVehicleInformationResponse> list = new List<MTBDVehicleInformationResponse>();
            try
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsMTBDVehicleInformationResponse = new MTBDVehicleInformationResponse();
                    clsMTBDVehicleInformationResponse.vehiclePlatform = dt.Rows[i]["Platform"].ToString();
                    clsMTBDVehicleInformationResponse.vehicleModel = dt.Rows[i]["Model"].ToString();
                    clsMTBDVehicleInformationResponse.vehicleVariant = dt.Rows[i]["variant_name"].ToString();
                    clsMTBDVehicleInformationResponse.vehicleRegNo = dt.Rows[i]["RegistrationNumber"].ToString();
                    clsMTBDVehicleInformationResponse.vehicleStatus = dt.Rows[i]["Status"].ToString();
                   // clsMTBDVehicleInformationResponse.vehicleLastUsed = dt.Rows[i]["VehicleLastUsed"].ToString();
                    if (dt.Rows[i]["VehicleLastUsed"].ToString() != "")
                    {
                        clsMTBDVehicleInformationResponse.lastupdated = Convert.ToDateTime(dt.Rows[i]["VehicleLastUsed"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        clsMTBDVehicleInformationResponse.lastupdated = Convert.ToDateTime("1900-01-01 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    clsMTBDVehicleInformationResponse.highEngineTemperature = dt.Rows[i]["EngineTemperature"].ToString();
                    clsMTBDVehicleInformationResponse.engineRPM = Convert.ToInt32(dt.Rows[i]["Engine_RPM"].ToString());
                    clsMTBDVehicleInformationResponse.fuelLevel = dt.Rows[i]["FuelLevel"].ToString();
                    clsMTBDVehicleInformationResponse.vehicleHealth = dt.Rows[i]["VehicleHealth"].ToString();
                    clsMTBDVehicleInformationResponse.fuelEfficiencyA = dt.Rows[i]["FE_Trip_A"].ToString();
                    clsMTBDVehicleInformationResponse.fuelEfficiencyB = dt.Rows[i]["FE_Trip_B"].ToString();
                    clsMTBDVehicleInformationResponse.averageVehicleSpeed = dt.Rows[i]["AvgVehicleSpeed"].ToString() == "" ? "0" : dt.Rows[i]["AvgVehicleSpeed"].ToString();
                    clsMTBDVehicleInformationResponse.engineOilPressure = dt.Rows[i]["EngineOilPressure"].ToString() == "" ? "0" : dt.Rows[i]["EngineOilPressure"].ToString();
                    clsMTBDVehicleInformationResponse.driverName = dt.Rows[i]["DriverName"].ToString();
                    list.Add(clsMTBDVehicleInformationResponse);

                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        #endregion

        #region   Vehicle LocationHistory Response
        public static List<VehicleLocationHistoryResponse> VehicleLocationHistoryResponse(DataTable dt)
        {
            VehicleLocationHistoryResponse clsVehicleLocationHistoryResponse = null;
            List<VehicleLocationHistoryResponse> list = new List<VehicleLocationHistoryResponse>();

            //location clslocation = null;
            //List<location> sublocationlist = null;
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //sublocationlist = new List<location>();
                    //clslocation = new location();
                    //clslocation.latitude = dt.Rows[i]["latitude"].ToString();
                    //clslocation.longitude = dt.Rows[i]["longitude"].ToString();
                    //sublocationlist.Add(clslocation);
                    clsVehicleLocationHistoryResponse = new VehicleLocationHistoryResponse();
                   // clsVehicleLocationHistoryResponse.registrationNumber = dt.Rows[i]["registrationnumber"].ToString();
                    clsVehicleLocationHistoryResponse.speed = dt.Rows[i]["vehiclespeed"].ToString();
                    clsVehicleLocationHistoryResponse.address = "Not available";
                    //clsVehicleLocationHistoryResponse.location = sublocationlist;
                    clsVehicleLocationHistoryResponse.location = new Vehiclelocation { latitude = dt.Rows[i]["latitude"].ToString() == "" ? 180 : Convert.ToDouble(dt.Rows[i]["latitude"].ToString()), longitude = dt.Rows[i]["longitude"].ToString() == "" ? 180 : Convert.ToDouble(dt.Rows[i]["longitude"].ToString()) };
                   // clsVehicleLocationHistoryResponse.location= new Vehiclelocation { latitude = Convert.ToDouble(dt.Rows[i]["latitude"].ToString()), longitude = Convert.ToDouble(dt.Rows[i]["longitude"].ToString()) };
                   // clsVehicleLocationHistoryResponse.location.Add(dt.Rows[i]["latitude"].ToString(), dt.Rows[i]["longitude"].ToString());
                    //clsVehicleLocationHistoryResponse.timeStamp = dt.Rows[i]["timestamp"].ToString();
                   // clsVehicleLocationHistoryResponse.timeStamp = Convert.ToDateTime(dt.Rows[i]["timestamp"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    if (dt.Rows[i]["timestamp"].ToString() != "")
                    {
                        clsVehicleLocationHistoryResponse.timeStamp = Convert.ToDateTime(dt.Rows[i]["timestamp"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        clsVehicleLocationHistoryResponse.timeStamp = Convert.ToDateTime("1900-01-01 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    list.Add(clsVehicleLocationHistoryResponse);
                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        #endregion
        
        #region   Vehicle Alerts Response
        public static List<SingleVehicleAlertsResponse> SingleVehicleAlertsResponse(DataTable dt)
        {
            SingleVehicleAlertsResponse clsSingleVehicleAlertsResponse = null;
            List<SingleVehicleAlertsResponse> list = new List<SingleVehicleAlertsResponse>();

            //location clslocation = null;
            //List<location> sublocationlist = null;

            try
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //sublocationlist = new List<location>();
                    //clslocation = new location();
                    //clslocation.latitude = dt.Rows[i]["latitude"].ToString();
                    //clslocation.longitude = dt.Rows[i]["longitude"].ToString();
                    //sublocationlist.Add(clslocation);

                    clsSingleVehicleAlertsResponse = new SingleVehicleAlertsResponse();
                    clsSingleVehicleAlertsResponse.priority = dt.Rows[i]["priority"].ToString();
                    clsSingleVehicleAlertsResponse.alertName = dt.Rows[i]["alertdescription"].ToString();
                    clsSingleVehicleAlertsResponse.alertId= dt.Rows[i]["alertID"].ToString();
                   // clsSingleVehicleAlertsResponse.location = sublocationlist;
                    clsSingleVehicleAlertsResponse.location = new Vehiclelocation { latitude = dt.Rows[i]["latitude"].ToString() == "" ? 180 : Convert.ToDouble(dt.Rows[i]["latitude"].ToString()), longitude = dt.Rows[i]["longitude"].ToString() == "" ? 180 : Convert.ToDouble(dt.Rows[i]["longitude"].ToString()) };
                   // clsSingleVehicleAlertsResponse.location = new Vehiclelocation { latitude = Convert.ToDouble(dt.Rows[i]["latitude"].ToString()), longitude = Convert.ToDouble(dt.Rows[i]["longitude"].ToString()) };
                   // clsSingleVehicleAlertsResponse.dateTime = Convert.ToDateTime(dt.Rows[i]["Alert_Time"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"); 
                    if (dt.Rows[i]["Alert_Time"].ToString() != "")
                    {
                        clsSingleVehicleAlertsResponse.dateTime = Convert.ToDateTime(dt.Rows[i]["Alert_Time"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        clsSingleVehicleAlertsResponse.dateTime = Convert.ToDateTime("1900-01-01 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    list.Add(clsSingleVehicleAlertsResponse);

                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        #endregion

        #region  Single Vehicle Alerts Response
        public static List<VehicleAlertsResponse> VehicleAlertsResponse(DataTable dt)
        {
            SingleVehicleAlertsResponse clsSingleVehicleAlertsResponse = null;
            List<SingleVehicleAlertsResponse> sublist = null;

            VehicleAlertsResponse clsVehicleAlertsResponse = null;
            List<VehicleAlertsResponse> list = new List<VehicleAlertsResponse>();

            //location clslocation = null;
            //List<location> sublocationlist = null;

            try
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    //sublocationlist = new List<location>();
                    //clslocation = new location();
                    //clslocation.latitude = dt.Rows[i]["latitude"].ToString();
                    //clslocation.longitude = dt.Rows[i]["longitude"].ToString();
                    //sublocationlist.Add(clslocation);

                    sublist=  new List<SingleVehicleAlertsResponse>();
                    clsVehicleAlertsResponse = new VehicleAlertsResponse();

                    clsSingleVehicleAlertsResponse = new SingleVehicleAlertsResponse();
                    clsSingleVehicleAlertsResponse.priority = dt.Rows[i]["priority"].ToString();
                    clsSingleVehicleAlertsResponse.alertName = dt.Rows[i]["alertdescription"].ToString();
                    clsSingleVehicleAlertsResponse.alertId= dt.Rows[i]["alertID"].ToString();
                   // clsSingleVehicleAlertsResponse.location = sublocationlist;
                    clsSingleVehicleAlertsResponse.location = new Vehiclelocation { latitude = dt.Rows[i]["latitude"].ToString() == "" ? 180 : Convert.ToDouble(dt.Rows[i]["latitude"].ToString()), longitude = dt.Rows[i]["longitude"].ToString() == "" ? 180 : Convert.ToDouble(dt.Rows[i]["longitude"].ToString()) };
                   // clsSingleVehicleAlertsResponse.location = new Vehiclelocation { latitude = Convert.ToDouble(dt.Rows[i]["latitude"].ToString()), longitude = Convert.ToDouble(dt.Rows[i]["longitude"].ToString()) };
                    //clsSingleVehicleAlertsResponse.dateTime = Convert.ToDateTime(dt.Rows[i]["Alert_Time"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"); 
                    if (dt.Rows[i]["Alert_Time"].ToString() != "")
                    {
                        clsSingleVehicleAlertsResponse.dateTime = Convert.ToDateTime(dt.Rows[i]["Alert_Time"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        clsSingleVehicleAlertsResponse.dateTime = Convert.ToDateTime("1900-01-01 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    sublist.Add(clsSingleVehicleAlertsResponse);

                    clsVehicleAlertsResponse.vehicleRegNo = dt.Rows[i]["RegistrationNumber"].ToString();
                    clsVehicleAlertsResponse.SingleVehicleAlertsResponse = sublist;
                    list.Add(clsVehicleAlertsResponse);
                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        #endregion


    
    }
}
﻿using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.BLUtilities
{
    public class Report_BL
    {

        #region Report Summary 8.02
        public static List<ReportSummaryMTBDResponse> ReportSummaryPlatformMTBD(DataTable dt)
        {
            List<ReportSummaryMTBDResponse> reportsummaryMTBD = new List<ReportSummaryMTBDResponse>();
            return reportsummaryMTBD;
        }
        #endregion

        #region Report Summary 8.03
        public static List<ReportSummaryForSpecificVehicle> ReportSummaryForSpecificVehicle(DataTable dt)
        {
            List<ReportSummaryForSpecificVehicle> reportsummaryMTBD = new List<ReportSummaryForSpecificVehicle>();
            return reportsummaryMTBD;
        }
        #endregion

        #region    Vehicle Status Response 8.06
        public static List<VehicleStatusResponse> VehicleStatusResponse(DataTable dt)
        {
            List<VehicleStatusResponse> list = new List<VehicleStatusResponse>();
            list.Clear();
            try
            {
                VehicleStatusResponse clsVehicleResponse = new VehicleStatusResponse();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (Convert.ToInt32(dt.Rows[i]["status"]) == 0)
                    {
                        clsVehicleResponse.unknown = Convert.ToInt32(dt.Rows[i]["statuscount"]);
                    }
                    else if (Convert.ToInt32(dt.Rows[i]["status"]) == 1)
                    {
                        clsVehicleResponse.running = Convert.ToInt32(dt.Rows[i]["statuscount"]);
                    }
                    else if (Convert.ToInt32(dt.Rows[i]["status"]) == 2)
                    {
                        clsVehicleResponse.stopped = Convert.ToInt32(dt.Rows[i]["statuscount"]);
                    }
                    else if (Convert.ToInt32(dt.Rows[i]["status"]) == 3)
                    {
                        clsVehicleResponse.idle = Convert.ToInt32(dt.Rows[i]["statuscount"]);
                    }
                    else if (Convert.ToInt32(dt.Rows[i]["status"]) == 5)
                    {
                        clsVehicleResponse.notused = Convert.ToInt32(dt.Rows[i]["statuscount"]);
                    }


                }
                list.Add(clsVehicleResponse);
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        #endregion

        #region    Vehicle Health Status Response 8.05
        public static List<VehicleHealthStatusResponse> VehicleHealthStatusResponse(DataSet dt)
        {
            List<VehicleHealthStatusResponse> list = new List<VehicleHealthStatusResponse>();
            list.Clear();
            try
            {
                VehicleHealthStatusResponse clsVehicleHealthStatusResponse = new VehicleHealthStatusResponse();


                vehiclehealth clsvehiclehealth = new vehiclehealth();

                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {

                    if (dt.Tables[0].Rows[i]["vehiclehealth"].ToString() == "Good")
                    {
                        clsvehiclehealth.good = Convert.ToInt32(dt.Tables[0].Rows[i]["COUNT"]);
                    }
                    else if (dt.Tables[0].Rows[i]["vehiclehealth"].ToString() == "Bad")
                    {
                        clsvehiclehealth.bad = Convert.ToInt32(dt.Tables[0].Rows[i]["COUNT"]);
                    }
                    else if (dt.Tables[0].Rows[i]["vehiclehealth"].ToString() == "Warning")
                    {
                        clsvehiclehealth.warning = Convert.ToInt32(dt.Tables[0].Rows[i]["COUNT"]);
                    }

                }
                clsVehicleHealthStatusResponse.vehiclehealth = clsvehiclehealth;
                clsVehicleHealthStatusResponse.totalBreakdownsOccurred = Convert.ToInt32(dt.Tables[1].Rows[0][0].ToString() == "" ? 0 : Convert.ToInt32(dt.Tables[1].Rows[0][0].ToString()));
                clsVehicleHealthStatusResponse.totalBreakdownsClosed = Convert.ToInt32(dt.Tables[2].Rows[0][0].ToString() == "" ? 0 : Convert.ToInt32(dt.Tables[2].Rows[0][0].ToString()));

                list.Add(clsVehicleHealthStatusResponse);
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        #endregion

        #region Other Reports From Swagger

        #region /reportsummary/platform/mtbd/vehiclemovement/speeddata/{vehicleRegNo}
        public static VehicleMovementSpeed PlatformVehilceMovementSpeedResponse(DataTable dt)
        {
            VehicleMovementSpeed vehiclemovementSpeed = new VehicleMovementSpeed();
            VehicleMovementSpeedApplicationJson vehilcesppedAppjson = new VehicleMovementSpeedApplicationJson();
            VehicleMovementSpeedOptions vehicleSppeedoptions = new VehicleMovementSpeedOptions();
            VehicleMovementSpeedData vehicleSpeeddata = new VehicleMovementSpeedData();
            VehicleMovementSpeedDataset datasets = new VehicleMovementSpeedDataset();
            try
            {
                for (int icount = 0; icount < dt.Rows.Count; icount++)
                {
                    #region vehicleusageTimedata.data list 
                    vehicleSpeeddata.labels.Add("1-30");
                    vehicleSpeeddata.labels.Add("31-50");
                    vehicleSpeeddata.labels.Add("51-70");
                    vehicleSpeeddata.labels.Add("71+");
                    if (dt.Rows[icount]["1-30"].ToString() != "")
                    {
                        datasets.data.Add(Convert.ToInt32(dt.Rows[icount]["1-30"]));
                    }
                    if (dt.Rows[icount]["31-50"].ToString() != "")
                    {

                        datasets.data.Add(Convert.ToInt32(dt.Rows[icount]["31-50"]));
                    }

                    if (dt.Rows[icount]["51-70"].ToString() != "")
                    {
                        datasets.data.Add(Convert.ToInt32(dt.Rows[icount]["51-70"]));
                    }
                    
                    if (dt.Rows[icount]["71+"].ToString() != "")
                    {
                        datasets.data.Add(Convert.ToInt32(dt.Rows[icount]["71+"]));
                    }

                    #endregion
                    #region  datasets
                    datasets.backgroundColor.Add("#00b300");
                    datasets.backgroundColor.Add("#00b300");
                    datasets.backgroundColor.Add("#ff8000");
                    datasets.backgroundColor.Add("#ff0000");
                    datasets.label = "SpeedReport";
                    //datasets.data.Add(65);
                   // datasets.data.Add(59);
                   // datasets.data.Add(80);
                    //datasets.data.Add(75);
                    #endregion
                    #region   vehicleusageTimedata.datasets.Add(datasets);
                    vehicleSpeeddata.datasets.Add(datasets);
                    #endregion
                    vehicleSppeedoptions.maintainAspectRatio = false;
                    vehicleSppeedoptions.responsive = true;
                    vehilcesppedAppjson.data = vehicleSpeeddata;
                    vehilcesppedAppjson.chartType = "bar";
                    vehilcesppedAppjson.options = vehicleSppeedoptions;
                    vehiclemovementSpeed.application = vehilcesppedAppjson;
                }
            }
            catch (Exception ex)
            {
            }
            return vehiclemovementSpeed;
        }
        #endregion

        #region /reportsummary/platform/mtbd/vehiclemovement/usagetime/{vehicleRegNo}
        public static VehicleMovementUsageTime VehilceMovementUsageTime(DataTable dt)
        {

            VehicleMovementUsageTime vehiclemovementUsageTime = new VehicleMovementUsageTime();
            VehicleMovementUsageTimeApplicationJson vehilceuagetimeAppjson = new VehicleMovementUsageTimeApplicationJson();
            VehicleMovementUsageTimeOptions vehicleusageTimeoptions = new VehicleMovementUsageTimeOptions();
            VehicleMovementUsageTimeData vehicleusageTimedata = new VehicleMovementUsageTimeData();
            VehicleMovementUsageTimeDataset datasets = new VehicleMovementUsageTimeDataset();
            try
            {
                for (int icount = 0; icount < dt.Rows.Count; icount++)
                {
                    #region vehicleusageTimedata.data list 
                    vehicleusageTimedata.labels.Add("DrivingTime");
                    vehicleusageTimedata.labels.Add("HaltTime");
                    vehicleusageTimedata.labels.Add("IdleTime");

                  //  if (dt.Rows[icount]["DrivingTime"].ToString() != "" && dt.Rows[icount]["DrivingTime"].ToString() != "0")
                    if (dt.Rows[icount]["DrivingTime"].ToString() != "")
                    {
                       // var result = TimeSpan.FromMinutes(Convert.ToInt32(dt.Rows[icount]["DrivingTime"]));
                        var result =  Convert.ToInt32(dt.Rows[icount]["DrivingTime"]);
                        //vehicleusageTimedata.labels.Add(result.ToString());
                        datasets.data.Add(result);
                    }

                    //   if (dt.Rows[icount]["HaltTime"].ToString() != "" && dt.Rows[icount]["HaltTime"].ToString() != "0")
                    if (dt.Rows[icount]["HaltTime"].ToString() != "")
                    {
                        //var result = TimeSpan.FromMinutes(Convert.ToInt32(dt.Rows[icount]["HaltTime"]));
                        var result = Convert.ToInt32(dt.Rows[icount]["HaltTime"]);
                        //vehicleusageTimedata.labels.Add(result.ToString());
                        datasets.data.Add(result);
                    }
                    

                    //if (dt.Rows[icount]["IdleTime"].ToString() != "" && dt.Rows[icount]["IdleTime"].ToString() != "0")
                    if (dt.Rows[icount]["IdleTime"].ToString() != "")
                    {
                       // var result = TimeSpan.FromMinutes(Convert.ToInt32(dt.Rows[icount]["IdleTime"]));
                        var result = Convert.ToInt32(dt.Rows[icount]["IdleTime"]);
                        //vehicleusageTimedata.labels.Add(result.ToString());
                        datasets.data.Add(result);
                    }
                  
                    //vehicleusageTimedata.data list end here 
                    #endregion
                    #region  datasets
                    datasets.backgroundColor.Add("#0066ff");
                    datasets.backgroundColor.Add("#ff8000");
                    datasets.backgroundColor.Add("#e60000");
                    datasets.label = "UsageReport";
                   // datasets.data.Add(65);
                   // datasets.data.Add(59);
                   // datasets.data.Add(80);
                    #endregion
                    #region   vehicleusageTimedata.datasets.Add(datasets);
                    vehicleusageTimedata.datasets.Add(datasets);
                    #endregion
                    vehicleusageTimeoptions.maintainAspectRatio = false;
                    vehicleusageTimeoptions.responsive = true;
                    vehilceuagetimeAppjson.data = vehicleusageTimedata;
                    vehilceuagetimeAppjson.chartType = "pie";
                    vehilceuagetimeAppjson.options = vehicleusageTimeoptions;
                    vehiclemovementUsageTime.application = vehilceuagetimeAppjson;
                }
            }
            catch (Exception ex)
            {
            }
            return vehiclemovementUsageTime;
        }
        #endregion

        #region GET /reportsummary/platform/mtbd/vehiclemovement/enginerpm/{vehicleRegNo}
        public static VehicleMovementEngineRpm VehilceMovementEngineRpm(DataTable dt)
        {
            VehicleMovementEngineRpm vehiclemovementEnginerpm = new VehicleMovementEngineRpm();
            VehicleMovementEngineRpmApplicationJson vehiclemovementEnginerpmAppjson = new VehicleMovementEngineRpmApplicationJson();
            VehicleMovementEngineRpmOptions vehiclemovementEnginerpmoptions = new VehicleMovementEngineRpmOptions();
            VehicleMovementEngineRpmData vehiclemovementEnginerpmdata = new VehicleMovementEngineRpmData();
            VehicleMovementEngineRpmDataset vehiclemovementEnginerpmdatasets = new VehicleMovementEngineRpmDataset();
            try
            {
                for (int icount = 0; icount < dt.Rows.Count; icount++)
                {

                    #region vehicleusageTimedata.data list 
                    vehiclemovementEnginerpmdata.labels.Add("RPM1501To2000");
                    vehiclemovementEnginerpmdata.labels.Add("RPM1501To2000");
                    vehiclemovementEnginerpmdata.labels.Add("RPM2001To2500");
                    vehiclemovementEnginerpmdata.labels.Add("AboveRPM2500");
                    if (dt.Rows[icount]["RPM1001To1500"].ToString() != "")
                    {
                        vehiclemovementEnginerpmdatasets.data.Add(Convert.ToInt32(dt.Rows[icount]["RPM1001To1500"]));
                    }
                   
                    if (dt.Rows[icount]["RPM1501To2000"].ToString() != "")
                    {
                        vehiclemovementEnginerpmdatasets.data.Add(Convert.ToInt32(dt.Rows[icount]["RPM1501To2000"]));

                    }
                    if (dt.Rows[icount]["RPM2001To2500"].ToString() != "")
                    {
                        vehiclemovementEnginerpmdatasets.data.Add(Convert.ToInt32(dt.Rows[icount]["RPM2001To2500"]));

                    }
                    if (dt.Rows[icount]["AboveRPM2500"].ToString() != "")
                    {
                        vehiclemovementEnginerpmdatasets.data.Add(Convert.ToInt32(dt.Rows[icount]["AboveRPM2500"]));
                    }
                    //vehicleusageTimedata.data list end here 
                    #endregion
                    #region  datasets
                    vehiclemovementEnginerpmdatasets.backgroundColor.Add("#00b300");
                    vehiclemovementEnginerpmdatasets.backgroundColor.Add("#ff8000");
                    vehiclemovementEnginerpmdatasets.backgroundColor.Add("#ff0000");
                    vehiclemovementEnginerpmdatasets.label = "EngineReport";
                   // vehiclemovementEnginerpmdatasets.data.Add(65);
                   // vehiclemovementEnginerpmdatasets.data.Add(59);
                   // vehiclemovementEnginerpmdatasets.data.Add(80);
                    #endregion
                    vehiclemovementEnginerpmdata.datasets.Add(vehiclemovementEnginerpmdatasets);
                    vehiclemovementEnginerpmoptions.maintainAspectRatio = false;
                    vehiclemovementEnginerpmoptions.responsive = true;
                    vehiclemovementEnginerpmAppjson.data = vehiclemovementEnginerpmdata;
                    vehiclemovementEnginerpmAppjson.chartType = "pie";
                    vehiclemovementEnginerpmAppjson.options = vehiclemovementEnginerpmoptions;
                    vehiclemovementEnginerpm.application = vehiclemovementEnginerpmAppjson;
                }
            }
            catch (Exception ex)
            {
            }
            return vehiclemovementEnginerpm;
        }

        #endregion

        #region GET /reportsummary/platform/mtbd/vehiclemovement/vehiclemovementsummary/{vehicleRegNo}
        public static List<ReportSummaryCommonReponse> VehilceMovementSummary(DataTable dt)
        {
            List<ReportSummaryCommonReponse> vehicleSummary = new List<ReportSummaryCommonReponse>();
            try
            {
                for (int icount = 0; icount < dt.Rows.Count; icount++)
                {

                    for (int ycount = 0; ycount < dt.Columns.Count; ycount++)
                    {
                        ReportSummaryCommonReponse reportSummary = new ReportSummaryCommonReponse();
                        reportSummary.name = dt.Columns[ycount].ColumnName.ToString();
                        if(dt.Columns[ycount].ColumnName.ToString()== "refill_time")
                        {
                            reportSummary.value = Convert.ToDateTime(dt.Rows[icount][ycount]).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        else
                        {
                            if (dt.Rows[icount][ycount] != null && Convert.ToString(dt.Rows[icount][ycount]) != "")
                            {
                                reportSummary.value = Convert.ToString(dt.Rows[icount][ycount]);


                            }
                            else
                            {
                                reportSummary.value = "no values";
                            }
                           
                        }
                        vehicleSummary.Add(reportSummary);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return vehicleSummary;
        }

        #endregion

        #region /reportsummary/platform/mtbd/vehiclemovement/vehiclemovementreport/{vehicleRegNo}
        public static VehilceMovementReport VehicleMovementReport(DataTable dt)
        {
            return null;
        }
        #endregion

        #region  /reportsummary/platform/mtbd/alerts/vehiclealerts/{vehicleRegNo}
        public static List<ReportSumamryVehicleAlerts> VehicleAlerts(DataTable dt)
        {

            return null;
        }
        #endregion

        #region GET /reportsummary/platform/mtbd/alerts/violation/{vehicleRegNo}
        public static AlertsViolation AlertsViolation(DataTable dt)
        {
            return null;
        }
        #endregion

        #region /reportsummary/platform/mtbd/alerts/alertssummary/{vehicleRegNo}

        public static List<ReportSummaryCommonReponse> AlertsSummaryResponse(DataTable dt)
        {
            return null;
        }
        #endregion

        #region GET /reportsummary/platform/mtbd/delivery/vehicleusage/{vehicleRegNo}
        public static List<ReportSummaryCommonResponse> VehicleUsage(DataTable dt)
        {
            return null;
        }
        #endregion

        #region GET /reportsummary/platform/mtbd/delivery/vehicleusagesummary/{vehicleRegNo}
        public static List<ReportSummaryCommonReponse> VehicleReportSummary(DataTable dt)
        {
            return null;
        }
        #endregion

        #region GET /reportsummary/platform/mtbd/vehiclehealth/vehiclehealthsummary/{vehicleRegNo}
        public static List<ReportSummaryCommonReponse> VehicleHealthSummary(DataTable dt)
        {
            return null;
        }
        #endregion

        #region GET /reportsummary/platform/mtbd/driver/distancecovered
        public static List<ReportSummaryDistanceCovered> DistanceCovered(DataTable dt)
        {
            return null;
        }
        #endregion

        #region GET /report/delivery/{vehicleRegNo}/{delivery}
        public static List<VehicleSummary> ReportSummaryDeliveryVehicle(DataTable dt)
        {
            return null;
        }

        #endregion

        #region  /report/vehiclehealth/{vehicleRegNo}/{vehiclehealth}
        public static List<VehicleSummary> VehicleHealth(DataTable dt)
        {
            return null;
        }

        #endregion

        #region /report/alerts/{vehicleRegNo}/{alerts}
        public static List<VehicleSummary> ReportAlerts(DataTable dt)
        {
            return null;
        }
        #endregion


        #endregion
    }
}
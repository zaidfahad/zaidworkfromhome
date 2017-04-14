﻿using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DigisensePlatformAPIs.Utilities;
namespace DigisensePlatformAPIs.BLUtilities
{

    public class Report_BL
    {

        #region Report Summary 8.02
        public static ReportSummaryMTBD ReportSummaryPlatformMTBD()
        {
            ReportSummaryMTBD reportsummarymtbd = new ReportSummaryMTBD();
            List<ReportSummaryMTBDApplicationJson> reportsummaryappjsonList = new List<ReportSummaryMTBDApplicationJson>();
            reportsummaryappjsonList.Clear();
            ReportSummaryMTBDApplicationJson reportsummaryappjson;
            ReportSummaryMTBDCategory reportsummarycategory;

            #region First Row
            reportsummaryappjson = new ReportSummaryMTBDApplicationJson();
            reportsummarycategory = new ReportSummaryMTBDCategory();
            reportsummaryappjson.displayName = "Vehicle Movement";

            reportsummarycategory.displayName = "Speed Data";
            reportsummarycategory.url = "/report/mtbd/vehiclemovement/speeddata/{vehicleRegNo}";
            reportsummaryappjson.categories.Add(reportsummarycategory);

            reportsummarycategory = new ReportSummaryMTBDCategory();
            reportsummarycategory.displayName = "Usage Time";
            reportsummarycategory.url = "/report/mtbd/vehiclemovement/usagetime/{vehicleRegNo}";
            reportsummaryappjson.categories.Add(reportsummarycategory);

            reportsummarycategory = new ReportSummaryMTBDCategory();
            reportsummarycategory.displayName = "Engine Rpm";
            reportsummarycategory.url = "/report/mtbd/vehiclemovement/enginerpm/{vehicleRegNo}";
            reportsummaryappjson.categories.Add(reportsummarycategory);


            reportsummarycategory = new ReportSummaryMTBDCategory();
            reportsummarycategory.displayName = "Vehicle Movement Report";
            reportsummarycategory.url = "/report/mtbd/vehiclemovement/vehiclemovementreport/{vehicleRegNo}";
            reportsummaryappjson.categories.Add(reportsummarycategory);

            reportsummarycategory = new ReportSummaryMTBDCategory();
            reportsummarycategory.displayName = "Vehicle Movement Summary";
            reportsummarycategory.url = "/report/mtbd/vehiclemovement/vehiclemovementsummary/{vehicleRegNo}";
            reportsummaryappjson.categories.Add(reportsummarycategory);
            reportsummaryappjsonList.Add(reportsummaryappjson);
            #endregion

            #region Second Row
            reportsummaryappjson = new ReportSummaryMTBDApplicationJson();
            reportsummarycategory = new ReportSummaryMTBDCategory();
            reportsummaryappjson.displayName = "Vehicle Health";

            reportsummarycategory.displayName = "Breakdown Alert";
            reportsummarycategory.url = "/report/mtbd/vehiclehealth/breakdownalert/{vehicleRegNo}";
            reportsummaryappjson.categories.Add(reportsummarycategory);

            reportsummarycategory = new ReportSummaryMTBDCategory();
            reportsummarycategory.displayName = "Vehicle Health Summary";
            reportsummarycategory.url = "/report/mtbd/vehiclehealth/vehiclehealthsummary/{vehicleRegNo}";
            reportsummaryappjson.categories.Add(reportsummarycategory);
            reportsummaryappjsonList.Add(reportsummaryappjson);
            #endregion

            #region Third Row
            reportsummaryappjson = new ReportSummaryMTBDApplicationJson();
            reportsummarycategory = new ReportSummaryMTBDCategory();
            reportsummaryappjson.displayName = "Alerts";

            reportsummarycategory.displayName = "Vehicle Alerts";
            reportsummarycategory.url = "/report/mtbd/alerts/vehiclealerts/{vehicleRegNo}";
            reportsummaryappjson.categories.Add(reportsummarycategory);

            reportsummarycategory = new ReportSummaryMTBDCategory();
            reportsummarycategory.displayName = "Violations Alerts";
            reportsummarycategory.url = "/report/mtbd/alerts/violations/{vehicleRegNo}";
            reportsummaryappjson.categories.Add(reportsummarycategory);

            reportsummarycategory = new ReportSummaryMTBDCategory();
            reportsummarycategory.displayName = "Alerts Summary";
            reportsummarycategory.url = "/report/mtbd/alerts/alertssummary/{vehicleRegNo}";
            reportsummaryappjson.categories.Add(reportsummarycategory);

            reportsummaryappjsonList.Add(reportsummaryappjson);
            #endregion

            #region Fourth Row

            reportsummaryappjson = new ReportSummaryMTBDApplicationJson();
            reportsummarycategory = new ReportSummaryMTBDCategory();
            reportsummaryappjson.displayName = "Delivery";

            reportsummarycategory.displayName = "Vehicle Usage Report";
            reportsummarycategory.url = "/report/mtbd/delivery/vehicleusage/{vehicleRegNo}";
            reportsummaryappjson.categories.Add(reportsummarycategory);

            reportsummarycategory = new ReportSummaryMTBDCategory();
            reportsummarycategory.displayName = "Vehicle Usage Summary";
            reportsummarycategory.url = "/report/mtbd/delivery/vehicleusagesummary/{vehicleRegNo}";
            reportsummaryappjson.categories.Add(reportsummarycategory);

            reportsummaryappjsonList.Add(reportsummaryappjson);

            #endregion

            reportsummarymtbd.applicationjson = reportsummaryappjsonList;
            return reportsummarymtbd;
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

        #region /report/platform/mtbd/vehiclemovement/speeddata/{vehicleRegNo}
        public static VehicleMovementSpeed PlatformVehilceMovementSpeedResponse(DataTable dt)
        {
            VehicleMovementSpeed vehiclemovementSpeed = new VehicleMovementSpeed();
          //  VehicleMovementSpeedApplicationJson vehilcesppedAppjson = new VehicleMovementSpeedApplicationJson();
            VehicleMovementSpeedOptions vehicleSppeedoptions = new VehicleMovementSpeedOptions();
            VehicleMovementSpeedData vehicleSpeeddata = new VehicleMovementSpeedData();
            VehicleMovementSpeedDataset datasets = new VehicleMovementSpeedDataset();
            try
            {
                vehicleSpeeddata.labels.Add("1-30");
                vehicleSpeeddata.labels.Add("31-50");
                vehicleSpeeddata.labels.Add("51-70");
                vehicleSpeeddata.labels.Add("71+");
                for (int icount = 0; icount < dt.Rows.Count; icount++)
                {
                    #region vehicleusageTimedata.data list 

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
                }
                #region  datasets
                datasets.backgroundColor.Add("#00b300");
                datasets.backgroundColor.Add("#00b300");
                datasets.backgroundColor.Add("#ff8000");
                datasets.backgroundColor.Add("#ff0000");
                datasets.label = "SpeedReport";
                #endregion

                #region   vehicleusageTimedata.datasets.Add(datasets);
                vehicleSpeeddata.datasets.Add(datasets);
                #endregion

                vehicleSppeedoptions.maintainAspectRatio = false;
                vehicleSppeedoptions.responsive = true;
                vehiclemovementSpeed.data = vehicleSpeeddata;
                vehiclemovementSpeed.chartType = "bar";
                vehiclemovementSpeed.options = vehicleSppeedoptions;
                //vehiclemovementSpeed.application = vehilcesppedAppjson;
            }
            catch (Exception ex)
            {
            }
            return vehiclemovementSpeed;
        }
        #endregion

        #region /report/platform/mtbd/vehiclemovement/usagetime/{vehicleRegNo}
        public static VehicleMovementUsageTime VehilceMovementUsageTime(DataTable dt)
        {
            VehicleMovementUsageTime vehiclemovementUsageTime = new VehicleMovementUsageTime();
            //VehicleMovementUsageTimeApplicationJson vehilceuagetimeAppjson = new VehicleMovementUsageTimeApplicationJson(); swagger 2.0
            VehicleMovementUsageTimeOptions vehicleusageTimeoptions = new VehicleMovementUsageTimeOptions();
            VehicleMovementUsageTimeData vehicleusageTimedata = new VehicleMovementUsageTimeData();
            VehicleMovementUsageTimeDataset datasets = new VehicleMovementUsageTimeDataset();
            try
            {
                vehicleusageTimedata.labels.Add("DrivingTime");
                vehicleusageTimedata.labels.Add("HaltTime");
                vehicleusageTimedata.labels.Add("IdleTime");
                for (int icount = 0; icount < dt.Rows.Count; icount++)
                {
                    #region vehicleusageTimedata.data list 
                    if (dt.Rows[icount]["DrivingTime"].ToString() != "")
                    {
                        var result = Convert.ToInt32(dt.Rows[icount]["DrivingTime"]);
                        datasets.data.Add(result);
                    }
                    if (dt.Rows[icount]["HaltTime"].ToString() != "")
                    {
                        var result = Convert.ToInt32(dt.Rows[icount]["HaltTime"]);
                        datasets.data.Add(result);
                    }
                    if (dt.Rows[icount]["IdleTime"].ToString() != "")
                    {
                        var result = Convert.ToInt32(dt.Rows[icount]["IdleTime"]);
                        datasets.data.Add(result);
                    }
                    //vehicleusageTimedata.data list end here 
                    #endregion

                }
                #region  datasets
                datasets.backgroundColor.Add("#0066ff");
                datasets.backgroundColor.Add("#e60000");
                datasets.backgroundColor.Add("#ff8000");
                datasets.label = "UsageReport";

                #endregion
                #region   vehicleusageTimedata.datasets.Add(datasets);
                vehicleusageTimedata.datasets.Add(datasets);
                #endregion
                vehicleusageTimeoptions.maintainAspectRatio = false;
                vehicleusageTimeoptions.responsive = true;
                vehiclemovementUsageTime.data = vehicleusageTimedata;
                vehiclemovementUsageTime.chartType = "pie";
                vehiclemovementUsageTime.options = vehicleusageTimeoptions;
            }
            catch (Exception ex)
            {
            }
            return vehiclemovementUsageTime;
        }
        #endregion

        #region GET /report/platform/mtbd/vehiclemovement/enginerpm/{vehicleRegNo}
        public static VehicleMovementEngineRpm VehilceMovementEngineRpm(DataTable dt)
        {
            VehicleMovementEngineRpm vehiclemovementEnginerpm = new VehicleMovementEngineRpm();
             /*
             swagger 2.0
             VehicleMovementEngineRpmApplicationJson vehiclemovementEnginerpmAppjson = new VehicleMovementEngineRpmApplicationJson();
            */
            VehicleMovementEngineRpmOptions vehiclemovementEnginerpmoptions = new VehicleMovementEngineRpmOptions();
            VehicleMovementEngineRpmData vehiclemovementEnginerpmdata = new VehicleMovementEngineRpmData();
            VehicleMovementEngineRpmDataset vehiclemovementEnginerpmdatasets = new VehicleMovementEngineRpmDataset();
            try
            {
                vehiclemovementEnginerpmdata.labels.Add("RPM1001To1500");
                vehiclemovementEnginerpmdata.labels.Add("RPM1501To2500");
               // vehiclemovementEnginerpmdata.labels.Add("RPM2001To2500");
                vehiclemovementEnginerpmdata.labels.Add("AboveRPM2501");
                for (int icount = 0; icount < dt.Rows.Count; icount++)
                {
                    #region vehicleusageTimedata.data list 

                    if (dt.Rows[icount]["RPM1001To1500"].ToString() != "")
                    {
                        vehiclemovementEnginerpmdatasets.data.Add(Convert.ToInt32(dt.Rows[icount]["RPM1001To1500"]));
                    }

                    if (dt.Rows[icount]["RPM1501To2500"].ToString() != "")
                    {
                        vehiclemovementEnginerpmdatasets.data.Add(Convert.ToInt32(dt.Rows[icount]["RPM1501To2500"]));

                    }
                    //if (dt.Rows[icount]["RPM2001To2500"].ToString() != "")
                    //{
                    //    vehiclemovementEnginerpmdatasets.data.Add(Convert.ToInt32(dt.Rows[icount]["RPM2001To2500"]));
                    //}
                    if (dt.Rows[icount]["AboveRPM2501"].ToString() != "")
                    {
                        vehiclemovementEnginerpmdatasets.data.Add(Convert.ToInt32(dt.Rows[icount]["AboveRPM2501"]));
                    }
                    //vehicleusageTimedata.data list end here 
                    #endregion
                }
                #region  datasets
                vehiclemovementEnginerpmdatasets.backgroundColor.Add("#00b300");
                vehiclemovementEnginerpmdatasets.backgroundColor.Add("#ff8000");
                vehiclemovementEnginerpmdatasets.backgroundColor.Add("#ff0000");
                vehiclemovementEnginerpmdatasets.label = "EngineReport";
                #endregion
                vehiclemovementEnginerpmdata.datasets.Add(vehiclemovementEnginerpmdatasets);
                vehiclemovementEnginerpmoptions.maintainAspectRatio = false;
                vehiclemovementEnginerpmoptions.responsive = true;
                vehiclemovementEnginerpm.data = vehiclemovementEnginerpmdata;
                vehiclemovementEnginerpm.chartType = "pie";
                vehiclemovementEnginerpm.options = vehiclemovementEnginerpmoptions;
            }
            catch (Exception ex)
            {
            }
            return vehiclemovementEnginerpm;
        }

        #endregion

        #region GET /report/platform/mtbd/vehiclemovement/vehiclemovementsummary/{vehicleRegNo}
        public static ReportSummaryVehicleMovementSummary VehilceMovementSummary(DataTable dt)
        {
            ReportSummaryVehicleMovementSummary vehicleSummary = new ReportSummaryVehicleMovementSummary();
            List<VehicleMovementSummary> summaryList=new List<VehicleMovementSummary>();
            summaryList.Clear();
            try
            {
                for (int icount = 0; icount < dt.Rows.Count; icount++)
                {

                    for (int ycount = 0; ycount < dt.Columns.Count; ycount++)
                    {
                        VehicleMovementSummary summary = new VehicleMovementSummary();
                        summary.title = dt.Columns[ycount].ColumnName.ToString();
                        if (dt.Columns[ycount].ColumnName.ToString() == "Last Used On")
                        {
                            summary.value = Convert.ToDateTime(dt.Rows[icount][ycount]).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        else
                        {
                            if (dt.Rows[icount][ycount] != null && Convert.ToString(dt.Rows[icount][ycount]) != "")
                            {
                                summary.value = Convert.ToString(dt.Rows[icount][ycount]);
                            }
                            else
                            {
                                summary.value = "0";
                            }
                        }
                        summaryList.Add(summary);
                    }
                }
                vehicleSummary.summary = summaryList;
            }
            catch (Exception ex)
            {
            }
            return vehicleSummary;
        }

        #endregion

        #region   /report/platform/mtbd/vehiclemovement/vehiclemovementreport/{vehicleRegNo}
        public static VehilceMovementReport VehicleMovementReport(DataTable dt)
        {

            VehilceMovementReport vehiclemovementReport = new VehilceMovementReport();
            VehilceMovementReportData vehiclemovementreportData = new VehilceMovementReportData();
            VehilceMovementReportOptions vehiclereportOptions = new VehilceMovementReportOptions();
            try
            {
                VehilceMovementReportDataset vehiclemovementreportDataset;
                //Notice : in swagger Data is given as int but we need to bind time So I made it as string 
                List<string> dataDistanceTravelled = new List<string>();
                List<string> dataDrivingTime = new List<string>();
                List<string> dataIdleTime = new List<string>();
                for (int icount = 0; icount < dt.Rows.Count; icount++)
                {
                    if (dt.Rows[icount]["Date"] != null && Convert.ToString(dt.Rows[icount]["Date"]) != "")
                    {
                        vehiclemovementreportData.labels.Add(Convert.ToDateTime(dt.Rows[icount]["Date"]).ToString("yyyy-MM-dd"));
                    }

                    if (Convert.ToString(dt.Rows[icount]["DistanceTravelled"]) != "" && dt.Rows[icount]["DistanceTravelled"] != null)
                    {
                        dataDistanceTravelled.Add(Convert.ToInt32(dt.Rows[icount]["DistanceTravelled"]).ToString());
                    }

                    if (Convert.ToString(dt.Rows[icount]["DrivingTime"]) != "" && dt.Rows[icount]["DrivingTime"] != null)
                    {
                        dataDrivingTime.Add(Convert.ToDouble(dt.Rows[icount]["DrivingTime"]).ConvertSecondsintoHHMMSSFormat());
                    }

                    if (Convert.ToString(dt.Rows[icount]["IdleTime"]) != "" && dt.Rows[icount]["IdleTime"] != null)
                    {
                        dataIdleTime.Add(Convert.ToDouble(dt.Rows[icount]["IdleTime"]).ConvertSecondsintoHHMMSSFormat());
                    }
                }
                //First Row for DataSet
                vehiclemovementreportDataset = new VehilceMovementReportDataset();
                vehiclemovementreportDataset.data = dataDistanceTravelled;
                vehiclemovementreportDataset.backgroundColor = "#39ac39";
                vehiclemovementreportDataset.label = "DistanceTravelled";
                vehiclemovementreportData.datasets.Add(vehiclemovementreportDataset);

                //Second Row For DataSet
                vehiclemovementreportDataset = new VehilceMovementReportDataset();
                vehiclemovementreportDataset.data = dataDrivingTime;
                vehiclemovementreportDataset.backgroundColor = "#0000ff";
                vehiclemovementreportDataset.label = "DrivingTime";
                vehiclemovementreportData.datasets.Add(vehiclemovementreportDataset);

                //Third Row For DataSet
                vehiclemovementreportDataset = new VehilceMovementReportDataset();
                vehiclemovementreportDataset.data = dataIdleTime;
                vehiclemovementreportDataset.backgroundColor = "#ff8000";
                vehiclemovementreportDataset.label = "IdleTime";
                vehiclemovementreportData.datasets.Add(vehiclemovementreportDataset);

                //App-Json Data 
                vehiclereportOptions.maintainAspectRatio = false;
                vehiclereportOptions.responsive = true;
                vehiclemovementReport.options = vehiclereportOptions;
                vehiclemovementReport.data = vehiclemovementreportData;
                vehiclemovementReport.chartType = "line";
            }
            catch (Exception ex)
            {
            }
            return vehiclemovementReport;
        }
        #endregion

        #region  /report/platform/mtbd/alerts/vehiclealerts/{vehicleRegNo}
        public static ReportSumamryVehicleAlerts VehicleAlerts(DataSet ds)
        {
            ReportSumamryVehicleAlerts reportsummaryVehiclealets = new ReportSumamryVehicleAlerts();
            List<VehicleAlertDataset> datasetsList = new List<VehicleAlertDataset>();
            VehicleAlertDataset vehiclealertDataSet;
            VehicleAlertData vehiclealertData = new VehicleAlertData();
            VehicleAlertOptions vehicleOptions = new VehicleAlertOptions();

            List<string> vehiclealertdataLabel = new List<string>();
            //DataSet There are 7 table start with 0 and fall in same sequence given below

            //Data set Table 0
            List<int> dataBreakdownAlerts = new List<int>();
            //Data set Table 1
            List<int> dataHighEngineAlerts = new List<int>();
            //Data set Table 2
            List<int> dataTamperAlerts = new List<int>();
            //Data set Table 3
            List<int> dataBatteryDisconnectedAlerts = new List<int>();
            //Data set Table 4
            List<int> dataServiceDueAlerts = new List<int>();
            //Data set Table 5
            List<int> dataFitnessCertificationAlerts = new List<int>();
            //Data set Table 6
            List<int> dataInsurancePaymentAlerts = new List<int>();
            datasetsList.Clear();
            try
            {
                #region Binding datasetsList

                #region BreakdownAlerts
                vehiclealertDataSet = new VehicleAlertDataset();
                vehiclealertDataSet.label = "BreakdownAlerts";
                vehiclealertDataSet.backgroundColor = "#e6005c";
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int t0 = 0; t0 < ds.Tables[0].Rows.Count; t0++)
                    {
                        if (ds.Tables[0].Rows[t0]["Date"] != null && Convert.ToString(ds.Tables[0].Rows[t0]["Date"]) != "")
                        {
                            vehiclealertdataLabel.Add(Convert.ToDateTime(ds.Tables[0].Rows[t0]["Date"]).ToString("yyyy-MM-dd"));
                            if (ds.Tables[0].Rows[t0][1] != null && Convert.ToString(ds.Tables[0].Rows[t0][1]) != "")
                            {
                                dataBreakdownAlerts.Add(Convert.ToInt32(ds.Tables[0].Rows[t0][1]));
                            }
                            else
                            {
                                dataBreakdownAlerts.Add(Convert.ToInt32(0));
                            }
                        }
                    }
                }

                vehiclealertDataSet.data = dataBreakdownAlerts;
                datasetsList.Add(vehiclealertDataSet);
                #endregion

                #region  HighEngineAlerts
                vehiclealertDataSet = new VehicleAlertDataset();
                vehiclealertDataSet.label = "HighEngineAlerts";
                vehiclealertDataSet.backgroundColor = "#669999";
                if (ds.Tables[1].Rows.Count > 0)
                {

                    for (int t1 = 0; t1 < ds.Tables[1].Rows.Count; t1++)
                    {
                        if (ds.Tables[1].Rows[t1]["Date"] != null && Convert.ToString(ds.Tables[1].Rows[t1]["Date"]) != "")
                        {
                            //  vehiclealertdataLabel.Add(Convert.ToDateTime(ds.Tables[1].Rows[t1]["Date"]).ToString("yyyy-MM-dd"));
                            if (ds.Tables[1].Rows[t1][1] != null && Convert.ToString(ds.Tables[1].Rows[t1][1]) != "")
                            {
                                dataHighEngineAlerts.Add(Convert.ToInt32(ds.Tables[1].Rows[t1][1]));
                            }
                            else
                            {
                                dataHighEngineAlerts.Add(Convert.ToInt32(0));
                            }
                        }
                    }

                }

                vehiclealertDataSet.data = dataHighEngineAlerts;
                datasetsList.Add(vehiclealertDataSet);
                #endregion

                #region TamperAlerts
                vehiclealertDataSet = new VehicleAlertDataset();
                vehiclealertDataSet.label = "TamperAlerts";
                vehiclealertDataSet.backgroundColor = "#3333cc";
                if (ds.Tables[2].Rows.Count > 0)
                {

                    for (int t2 = 0; t2 < ds.Tables[2].Rows.Count; t2++)
                    {
                        if (ds.Tables[2].Rows[t2]["Date"] != null && Convert.ToString(ds.Tables[2].Rows[t2]["Date"]) != "")
                        {
                            // vehiclealertdataLabel.Add(Convert.ToDateTime(ds.Tables[2].Rows[t2]["Date"]).ToString("yyyy-MM-dd"));
                            if (ds.Tables[2].Rows[t2][1] != null && Convert.ToString(ds.Tables[2].Rows[t2][1]) != "")
                            {
                                dataTamperAlerts.Add(Convert.ToInt32(ds.Tables[1].Rows[t2][1]));
                            }
                            else
                            {
                                dataTamperAlerts.Add(Convert.ToInt32(0));
                            }
                        }
                    }

                }

                vehiclealertDataSet.data = dataTamperAlerts;
                datasetsList.Add(vehiclealertDataSet);
                #endregion

                #region BatteryDisconnectedAlerts
                vehiclealertDataSet = new VehicleAlertDataset();
                vehiclealertDataSet.label = "BatteryDisconnectedAlerts";
                vehiclealertDataSet.backgroundColor = "#b300b3";
                if (ds.Tables[3].Rows.Count > 0)
                {

                    for (int t3 = 0; t3 < ds.Tables[3].Rows.Count; t3++)
                    {
                        if (ds.Tables[3].Rows[t3]["Date"] != null && Convert.ToString(ds.Tables[3].Rows[t3]["Date"]) != "")
                        {
                            //   vehiclealertdataLabel.Add(Convert.ToDateTime(ds.Tables[3].Rows[t3]["Date"]).ToString("yyyy-MM-dd"));
                            if (ds.Tables[3].Rows[t3][1] != null && Convert.ToString(ds.Tables[3].Rows[t3][1]) != "")
                            {
                                dataBatteryDisconnectedAlerts.Add(Convert.ToInt32(ds.Tables[3].Rows[t3][1]));
                            }
                            else
                            {
                                dataBatteryDisconnectedAlerts.Add(Convert.ToInt32(0));
                            }
                        }
                    }

                }

                vehiclealertDataSet.data = dataBatteryDisconnectedAlerts;
                datasetsList.Add(vehiclealertDataSet);
                #endregion

                #region ServiceDueAlerts
                vehiclealertDataSet = new VehicleAlertDataset();
                vehiclealertDataSet.label = "ServiceDueAlerts";
                vehiclealertDataSet.backgroundColor = "#996600";
                if (ds.Tables[4].Rows.Count > 0)
                {

                    for (int t4 = 0; t4 < ds.Tables[4].Rows.Count; t4++)
                    {
                        if (ds.Tables[4].Rows[t4]["Date"] != null && Convert.ToString(ds.Tables[4].Rows[t4]["Date"]) != "")
                        {
                            //    vehiclealertdataLabel.Add(Convert.ToDateTime(ds.Tables[1].Rows[t4]["Date"]).ToString("yyyy-MM-dd"));
                            if (ds.Tables[4].Rows[t4][1] != null && Convert.ToString(ds.Tables[4].Rows[t4][1]) != "")
                            {
                                dataServiceDueAlerts.Add(Convert.ToInt32(ds.Tables[4].Rows[t4][1]));
                            }
                            else
                            {
                                dataServiceDueAlerts.Add(Convert.ToInt32(0));
                            }
                        }
                    }

                }


                vehiclealertDataSet.data = dataServiceDueAlerts;
                datasetsList.Add(vehiclealertDataSet);
                #endregion

                #region FitnessCertificationAlerts
                vehiclealertDataSet = new VehicleAlertDataset();
                vehiclealertDataSet.label = "FitnessCertificationAlerts";
                vehiclealertDataSet.backgroundColor = "#ff0000";
                if (ds.Tables[5].Rows.Count > 0)
                {

                    for (int t5 = 0; t5 < ds.Tables[5].Rows.Count; t5++)
                    {
                        if (ds.Tables[5].Rows[t5]["Date"] != null && Convert.ToString(ds.Tables[5].Rows[t5]["Date"]) != "")
                        {
                            //  vehiclealertdataLabel.Add(Convert.ToDateTime(ds.Tables[1].Rows[t5]["Date"]).ToString("yyyy-MM-dd"));
                            if (ds.Tables[5].Rows[t5][1] != null && Convert.ToString(ds.Tables[5].Rows[t5][1]) != "")
                            {
                                dataFitnessCertificationAlerts.Add(Convert.ToInt32(ds.Tables[5].Rows[t5][1]));
                            }
                            else
                            {
                                dataFitnessCertificationAlerts.Add(Convert.ToInt32(0));
                            }
                        }
                    }
                }

                vehiclealertDataSet.data = dataFitnessCertificationAlerts;
                datasetsList.Add(vehiclealertDataSet);
                #endregion

                #region InsurancePaymentAlerts
                vehiclealertDataSet = new VehicleAlertDataset();
                vehiclealertDataSet.label = "InsurancePaymentAlerts";
                vehiclealertDataSet.backgroundColor = "#9900ff";
                if (ds.Tables[6].Rows.Count > 0)
                {

                    for (int t6 = 0; t6 < ds.Tables[6].Rows.Count; t6++)
                    {
                        if (ds.Tables[6].Rows[t6]["Date"] != null && Convert.ToString(ds.Tables[6].Rows[t6]["Date"]) != "")
                        {
                            //   vehiclealertdataLabel.Add(Convert.ToDateTime(ds.Tables[1].Rows[t6]["Date"]).ToString("yyyy-MM-dd"));
                            if (ds.Tables[6].Rows[t6][1] != null && Convert.ToString(ds.Tables[6].Rows[t6][1]) != "")
                            {
                                dataInsurancePaymentAlerts.Add(Convert.ToInt32(ds.Tables[6].Rows[t6][1]));
                            }
                            else
                            {
                                dataInsurancePaymentAlerts.Add(Convert.ToInt32(0));
                            }
                        }
                    }
                }

                vehiclealertDataSet.data = dataInsurancePaymentAlerts;
                datasetsList.Add(vehiclealertDataSet);
                #endregion

                #endregion

                #region  Fixed Values
                reportsummaryVehiclealets.chartType = "bar";
                vehicleOptions.maintainAspectRatio = false;
                vehicleOptions.responsive = true;
                #endregion

                #region Assigning Data 
                vehiclealertData.datasets = datasetsList;
                vehiclealertData.labels = vehiclealertdataLabel;
                reportsummaryVehiclealets.options = vehicleOptions;

                reportsummaryVehiclealets.data = vehiclealertData;
      
                #endregion

                return reportsummaryVehiclealets;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region GET /report/platform/mtbd/alerts/violation/{vehicleRegNo}
        public static AlertsViolation AlertsViolation(DataSet ds)
        {
            AlertsViolation alertVoilation = new AlertsViolation();
            List<AlertsViolationDataset> datasetsList = new List<AlertsViolationDataset>();
            AlertsViolationDataset vehiclevoilationtDataSet;
            AlertsViolationData vehiclevoilationData = new AlertsViolationData();
            AlertsViolationOptions vehicleOptions = new AlertsViolationOptions();

            List<string> vehiclevoilationdataLabel = new List<string>();
            //DataSet There are 6 table start with 0 and fall in same sequence given below

            //Data set Table 0
            List<int> dataGeofenceAlerts = new List<int>();
            //Data set Table 1
            List<int> dataExcessiveIdlingAlerts = new List<int>();
            //Data set Table 2
            List<int> dataOverSpeedAlerts = new List<int>();
            //Data set Table 3
            List<int> dataFuelTheftAlerts = new List<int>();
            //Data set Table 4
            List<int> dataNightDrivingAlerts = new List<int>();
            //Data set Table 5
            List<int> dataNeedHelpAlerts = new List<int>();

            datasetsList.Clear();
            try
            {
                #region Binding datasetsList

                #region GeofenceAlerts
                vehiclevoilationtDataSet = new AlertsViolationDataset();
                vehiclevoilationtDataSet.label = "GeofenceAlerts";
                vehiclevoilationtDataSet.backgroundColor = "#ff9966";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int t0 = 0; t0 < ds.Tables[0].Rows.Count; t0++)
                    {
                        if (ds.Tables[0].Rows[t0]["Date"] != null && Convert.ToString(ds.Tables[0].Rows[t0]["Date"]) != "")
                        {
                            vehiclevoilationdataLabel.Add(Convert.ToDateTime(ds.Tables[0].Rows[t0]["Date"]).ToString("yyyy-MM-dd"));
                            if (ds.Tables[0].Rows[t0][1] != null && Convert.ToString(ds.Tables[0].Rows[t0][1]) != "")
                            {
                                dataGeofenceAlerts.Add(Convert.ToInt32(ds.Tables[0].Rows[t0][1]));
                            }
                        }
                    }
                }

                vehiclevoilationtDataSet.data = dataGeofenceAlerts;
                datasetsList.Add(vehiclevoilationtDataSet);
                #endregion

                #region  ExcessiveIdlingAlerts
                vehiclevoilationtDataSet = new AlertsViolationDataset();
                vehiclevoilationtDataSet.label = "ExcessiveIdlingAlerts";
                vehiclevoilationtDataSet.backgroundColor = "#ccff66";
                if (ds.Tables[1].Rows.Count > 0)
                {

                    for (int t1 = 0; t1 < ds.Tables[1].Rows.Count; t1++)
                    {

                        if (ds.Tables[1].Rows[t1]["Date"] != null && Convert.ToString(ds.Tables[1].Rows[t1]["Date"]) != "")
                        {
                            if (ds.Tables[1].Rows[t1][1] != null && Convert.ToString(ds.Tables[1].Rows[t1][1]) != "")
                            {
                                dataExcessiveIdlingAlerts.Add(Convert.ToInt32(ds.Tables[1].Rows[t1][1]));
                            }
                        }

                    }
                }
                vehiclevoilationtDataSet.data = dataExcessiveIdlingAlerts;
                datasetsList.Add(vehiclevoilationtDataSet);
                #endregion

                #region OverSpeedAlerts
                vehiclevoilationtDataSet = new AlertsViolationDataset();
                vehiclevoilationtDataSet.label = "OverSpeedAlerts";
                vehiclevoilationtDataSet.backgroundColor = "#ffc266";
                if (ds.Tables[2].Rows.Count > 0)
                {

                    for (int t2 = 0; t2 < ds.Tables[2].Rows.Count; t2++)
                    {

                        if (ds.Tables[2].Rows[t2]["Date"] != null && Convert.ToString(ds.Tables[2].Rows[t2]["Date"]) != "")
                        {

                            if (ds.Tables[2].Rows[t2][1] != null && Convert.ToString(ds.Tables[2].Rows[t2][1]) != "")
                            {
                                dataOverSpeedAlerts.Add(Convert.ToInt32(ds.Tables[1].Rows[t2][1]));
                            }

                        }
                    }
                }
                vehiclevoilationtDataSet.data = dataOverSpeedAlerts;
                datasetsList.Add(vehiclevoilationtDataSet);
                #endregion

                #region FuelTheftAlerts
                vehiclevoilationtDataSet = new AlertsViolationDataset();
                vehiclevoilationtDataSet.label = "FuelTheftAlerts";
                vehiclevoilationtDataSet.backgroundColor = "#996600";
                if (ds.Tables[3].Rows.Count > 0)
                {

                    for (int t3 = 0; t3 < ds.Tables[3].Rows.Count; t3++)
                    {

                        if (ds.Tables[3].Rows[t3]["Date"] != null && Convert.ToString(ds.Tables[3].Rows[t3]["Date"]) != "")
                        {

                            if (ds.Tables[3].Rows[t3][1] != null && Convert.ToString(ds.Tables[3].Rows[t3][1]) != "")
                            {
                                dataFuelTheftAlerts.Add(Convert.ToInt32(ds.Tables[3].Rows[t3][1]));
                            }

                        }
                    }
                }
                vehiclevoilationtDataSet.data = dataFuelTheftAlerts;
                datasetsList.Add(vehiclevoilationtDataSet);
                #endregion

                #region NightDrivingAlerts
                vehiclevoilationtDataSet = new AlertsViolationDataset();
                vehiclevoilationtDataSet.label = "NightDrivingAlerts";
                vehiclevoilationtDataSet.backgroundColor = "#3333cc";
                if (ds.Tables[4].Rows.Count > 0)
                {

                    for (int t4 = 0; t4 < ds.Tables[4].Rows.Count; t4++)
                    {

                        if (ds.Tables[4].Rows[t4]["Date"] != null && Convert.ToString(ds.Tables[4].Rows[t4]["Date"]) != "")
                        {

                            if (ds.Tables[4].Rows[t4][1] != null && Convert.ToString(ds.Tables[4].Rows[t4][1]) != "")
                            {
                                dataNightDrivingAlerts.Add(Convert.ToInt32(ds.Tables[4].Rows[t4][1]));
                            }

                        }
                    }
                }

                vehiclevoilationtDataSet.data = dataNightDrivingAlerts;
                datasetsList.Add(vehiclevoilationtDataSet);
                #endregion

                #region NeedHelpAlerts
                vehiclevoilationtDataSet = new AlertsViolationDataset();
                vehiclevoilationtDataSet.label = "NeedHelpAlerts";
                vehiclevoilationtDataSet.backgroundColor = "#669999";
                if (ds.Tables.Count == 6)
                {
                    if (ds.Tables[5].Rows.Count > 0)
                    {

                        for (int t5 = 0; t5 < ds.Tables[5].Rows.Count; t5++)
                        {

                            if (ds.Tables[5].Rows[t5]["Date"] != null && Convert.ToString(ds.Tables[5].Rows[t5]["Date"]) != "")
                            {

                                if (ds.Tables[5].Rows[t5][1] != null && Convert.ToString(ds.Tables[5].Rows[t5][1]) != "")
                                {
                                    dataNeedHelpAlerts.Add(Convert.ToInt32(ds.Tables[5].Rows[t5][1]));
                                }
                            }
                        }
                    }
                }
                vehiclevoilationtDataSet.data = dataNeedHelpAlerts;
                datasetsList.Add(vehiclevoilationtDataSet);
                #endregion

                #endregion

                #region  Fixed Values
                alertVoilation.chartType = "bar";
                vehicleOptions.maintainAspectRatio = false;
                vehicleOptions.responsive = true;
                #endregion

                #region Assigning Data 
                vehiclevoilationData.datasets = datasetsList;
                vehiclevoilationData.labels = vehiclevoilationdataLabel;
                alertVoilation.options = vehicleOptions;

                alertVoilation.data = vehiclevoilationData;
                #endregion

                return alertVoilation;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region /reportsummary/platform/mtbd/alerts/alertssummary/{vehicleRegNo}

        public static ReportSummaryAlertsSummary AlertsSummaryResponse(DataTable dt)
        {
            ReportSummaryAlertsSummary vehicleSummary = new ReportSummaryAlertsSummary();
            List<AlertsSummary> summaryList = new List<AlertsSummary>();
            summaryList.Clear();
            try
            {
                for (int icount = 0; icount < dt.Rows.Count; icount++)
                {

                    for (int ycount = 0; ycount < dt.Columns.Count; ycount++)
                    {
                        AlertsSummary summary = new AlertsSummary();
                        summary.title = dt.Columns[ycount].ColumnName.ToString();
                        if (dt.Columns[ycount].ColumnName.ToString() == "Last Used On")
                        {
                            summary.value = Convert.ToDateTime(dt.Rows[icount][ycount]).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        else
                        {
                            if (dt.Rows[icount][ycount] != null && Convert.ToString(dt.Rows[icount][ycount]) != "")
                            {
                                summary.value = Convert.ToString(dt.Rows[icount][ycount]);
                            }
                            else
                            {
                                summary.value = "0";
                            }
                        }
                        summaryList.Add(summary);
                    }
                }
                vehicleSummary.summary = summaryList;
            }
            catch (Exception ex)
            {
            }
            return vehicleSummary;
        }
        #endregion

        #region GET /report/platform/mtbd/delivery/vehicleusage/{vehicleRegNo}
        public static ReportSummaryCommonResponse VehicleUsage(DataTable dt)
        {
            ReportSummaryCommonResponse reportsummaryCommon = new ReportSummaryCommonResponse();
          
            ReportSummaryCommonData reposesummaryData = new ReportSummaryCommonData();
            ReportSummaryCommonOptions remportsummaryOptions = new ReportSummaryCommonOptions();
            ReportSummaryCommonDataset reportsummaryDataSet = new ReportSummaryCommonDataset();
            reposesummaryData.labels.Add("UsedDays");
            reposesummaryData.labels.Add("NotUsedDays");
            reportsummaryDataSet.backgroundColor.Add("#0066ff");
            reportsummaryDataSet.backgroundColor.Add("#ff8000");
            reportsummaryDataSet.label = "UsageReport";
            List<int> data = new List<int>();
            // only one rows and two columns UsedDays And NotUsed Days 
            if (dt.Columns["UsedDays"] != null && Convert.ToString(dt.Rows[0]["UsedDays"]) != "")
            {
                data.Add(Convert.ToInt32(dt.Rows[0]["UsedDays"]));
            }
            else
            {
                data.Add(Convert.ToInt32(0));
            }
            if (dt.Columns["NotUsedDays"] != null && Convert.ToString(dt.Rows[0]["NotUsedDays"]) != "")
            {
                data.Add(Convert.ToInt32(dt.Rows[0]["NotUsedDays"]));
            }
            else
            {
                data.Add(Convert.ToInt32(0));
            }
            reportsummaryDataSet.data = data;
            reposesummaryData.datasets.Add(reportsummaryDataSet);
            remportsummaryOptions.maintainAspectRatio = false;
            remportsummaryOptions.responsive = true;
            reportsummaryCommon.options = remportsummaryOptions;
            reportsummaryCommon.data = reposesummaryData;
            reportsummaryCommon.chartType = "pie";
      
            return reportsummaryCommon;
        }
        #endregion

        #region GET /report/platform/mtbd/delivery/vehicleusagesummary/{vehicleRegNo}
        public static List<ReportSummaryCommonReponse> VehicleReportSummary(DataTable dt)
        {
            return null;
        }
        #endregion

        #region GET /reportsummary/platform/mtbd/vehiclehealth/vehiclehealthsummary/{vehicleRegNo}
        public static ReportSummaryVehicleHealthSummary VehicleHealthSummary(DataTable dt)
        {
            ReportSummaryVehicleHealthSummary vehicleSummary = new ReportSummaryVehicleHealthSummary();
            List<VehicleHealthSummary> summaryList = new List<VehicleHealthSummary>();
            summaryList.Clear();
            try
            {
                for (int icount = 0; icount < dt.Rows.Count; icount++)
                {

                    for (int ycount = 0; ycount < dt.Columns.Count; ycount++)
                    {
                        VehicleHealthSummary summary = new VehicleHealthSummary();
                        summary.title = dt.Columns[ycount].ColumnName.ToString();
                        if (dt.Columns[ycount].ColumnName.ToString() == "Last Used On")
                        {
                            summary.value = Convert.ToDateTime(dt.Rows[icount][ycount]).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        else
                        {
                            if (dt.Rows[icount][ycount] != null && Convert.ToString(dt.Rows[icount][ycount]) != "")
                            {
                                summary.value = Convert.ToString(dt.Rows[icount][ycount]);
                            }
                            else
                            {
                                summary.value = "0";
                            }
                        }
                        summaryList.Add(summary);
                    }
                }
                vehicleSummary.summary = summaryList;
            }
            catch (Exception ex)
            {
            }
            return vehicleSummary;
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
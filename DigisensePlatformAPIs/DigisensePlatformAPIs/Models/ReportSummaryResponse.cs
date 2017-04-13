﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class ReportSummaryResponse
    {

    }

    #region Report Summary 8.02
        public class ReportSummaryMTBD
        {
         public ReportSummaryMTBD()
        {
            applicationjson = new List<ReportSummaryMTBDApplicationJson>();
        }
           [JsonProperty("application/json")]
            public List<ReportSummaryMTBDApplicationJson> applicationjson { get; set; }
        }
        public class ReportSummaryMTBDApplicationJson
       {
        public ReportSummaryMTBDApplicationJson()
        {
            categories = new List<ReportSummaryMTBDCategory>();
        }
            public string displayName { get; set; }
            public List<ReportSummaryMTBDCategory> categories { get; set; }
        }
        public class ReportSummaryMTBDCategory
       {
            public string url { get; set; }
            public string displayName { get; set; }
        }

#endregion

   #region Report Summary 8.03
public class ReportSummaryForSpecificVehicle
{
    public ReportSummaryForSpecificVehicle()
    {
        summary = new List<Summary>();
        detailed = new List<Detailed>();
    }
    public List<Summary> summary { get; set; }
    public List<Detailed> detailed { get; set; }
}
public class Summary
{
    public string name { get; set; }
    public string value { get; set; }
}

public class Datasets
{
    public Datasets()
    {
        background = new List<string>();
        data = new List<int>();
    }
    public List<string> background { get; set; }
    public string label { get; set; }
    public List<int> data { get; set; }
}

public class Options
{
    public bool responsive { get; set; }
    public bool maintainAspectRatio { get; set; }
}

public class Detailed
{
    public Detailed()
    {
        labels = new List<string>();
        datasets = new List<Datasets>();
    }
    public List<string> labels { get; set; }
    [JsonProperty("dataset")]
    public List<Datasets> datasets { get; set; }
    public string chartType { get; set; }
    public Options options { get; set; }
}

    #endregion

    #region Report Summary 

    #region GET/report/platform/mtbd/vehiclemovement/speeddata/{vehicleRegNo}


    public class VehicleMovementSpeed
   {
        public VehicleMovementSpeedData data { get; set; }
        public string chartType { get; set; }
        public VehicleMovementSpeedOptions options { get; set; }
    }

    public class VehicleMovementSpeedOptions
    {
        public bool responsive { get; set; }
        public bool maintainAspectRatio { get; set; }
    }


    public class VehicleMovementSpeedData
    {
        public VehicleMovementSpeedData()
        {
            labels = new List<string>();
            datasets = new List<VehicleMovementSpeedDataset>();
        }
        public List<string> labels { get; set; }
        public List<VehicleMovementSpeedDataset> datasets { get; set; }
    }
    public class VehicleMovementSpeedDataset
    {
        public VehicleMovementSpeedDataset()
        {
            backgroundColor = new List<string>();
            data = new List<int>();
        }
        public List<string> backgroundColor { get; set; }
        public string label { get; set; }
        public List<int> data { get; set; }
    }


    #endregion

    #region GET /report/platform/mtbd/vehiclemovement/usagetime/{vehicleRegNo}

    public class VehicleMovementUsageTime
   {
        public VehicleMovementUsageTimeData data { get; set; }
        public string chartType { get; set; }
        public VehicleMovementUsageTimeOptions options { get; set; }
    }
    public class VehicleMovementUsageTimeOptions
    {
        public bool responsive { get; set; }
        public bool maintainAspectRatio { get; set; }
    }
        public class VehicleMovementUsageTimeData
        {
            public VehicleMovementUsageTimeData()
            {
                labels = new List<string>();
                datasets = new List<VehicleMovementUsageTimeDataset>();
            }
            public List<string> labels { get; set; }
            public List<VehicleMovementUsageTimeDataset> datasets { get; set; }
        }
    public class VehicleMovementUsageTimeDataset
    {
        public VehicleMovementUsageTimeDataset()
        {
            backgroundColor = new List<string>();
            data = new List<Int32>();
        }
        public List<string> backgroundColor { get; set; }
        public string label { get; set; }
        public List<Int32> data { get; set; }
    }

    #endregion

    #region GET /report/platform/mtbd/vehiclemovement/enginerpm/{vehicleRegNo}

    public class VehicleMovementEngineRpm
   {
        public VehicleMovementEngineRpmData data { get; set; }
        public string chartType { get; set; }
        public VehicleMovementEngineRpmOptions options { get; set; }
    }
public class VehicleMovementEngineRpmOptions
{
    public bool responsive { get; set; }
    public bool maintainAspectRatio { get; set; }
}


public class VehicleMovementEngineRpmData
{
    public VehicleMovementEngineRpmData()
    {
        labels = new List<string>();
        datasets = new List<VehicleMovementEngineRpmDataset>();
    }
    public List<string> labels { get; set; }
    public List<VehicleMovementEngineRpmDataset> datasets { get; set; }
}
public class VehicleMovementEngineRpmDataset
{
    public VehicleMovementEngineRpmDataset()
    {
        backgroundColor = new List<string>();
        data = new List<int>();
    }
    public List<string> backgroundColor { get; set; }
    public string label { get; set; }
    public List<int> data { get; set; }
}

    #endregion

    #region /report/platform/mtbd/vehiclemovement/vehiclemovementreport/{vehicleRegNo}

    public class VehilceMovementReport
    {
        public VehilceMovementReportData data { get; set; }
        public string chartType { get; set; }
        public VehilceMovementReportOptions options { get; set; }
    }
        public class VehilceMovementReportOptions
        {
            public bool responsive { get; set; }
            public bool maintainAspectRatio { get; set; }
        }
        public class VehilceMovementReportData
        {
            public VehilceMovementReportData()
            {
                labels = new List<string>();
                datasets = new List<VehilceMovementReportDataset>();
            }
            public List<string> labels { get; set; }
            public List<VehilceMovementReportDataset> datasets { get; set; }
        }
    public class VehilceMovementReportDataset
    {
        public VehilceMovementReportDataset()
        {
            data = new List<string>();
        }
        public string label { get; set; }
       //Data wwas given in swagger as int but we need to send the time to Zaid made it string
        public List<string> data { get; set; }
        public string backgroundColor { get; set; }
    }

    #endregion
  
    #region /report/platform/mtbd/alerts/vehiclealerts/{vehicleRegNo}

    public class ReportSumamryVehicleAlerts
{
        public VehicleAlertData data { get; set; }
        public string chartType { get; set; }
        public VehicleAlertOptions options { get; set; }
    }
   
    public class VehicleAlertOptions
    {
        public bool responsive { get; set; }
        public bool maintainAspectRatio { get; set; }
    }

    public class VehicleAlertData
    {
        public VehicleAlertData()
        {
            labels = new List<string>();
            datasets = new List<VehicleAlertDataset>();
        }
        public List<string> labels { get; set; }
        public List<VehicleAlertDataset> datasets { get; set; }
    }
  
    public class VehicleAlertDataset
    {
    public VehicleAlertDataset()
    {
            data = new List<int>();
    }
    public string label { get; set; }
    public List<int> data { get; set; }
    public string backgroundColor { get; set; }
   }

    #endregion

    #region /report/platform/mtbd/alerts/violation/{vehicleRegNo}

    public class AlertsViolation
    {
        public AlertsViolationData data { get; set; }
        public string chartType { get; set; }
        public AlertsViolationOptions options { get; set; }
    }

        public class AlertsViolationDataset
{
        public AlertsViolationDataset()
        {
            data = new List<int>();
        }
    public string label { get; set; }
    public List<int> data { get; set; }
    public string backgroundColor { get; set; }
}

public class AlertsViolationData
{
        public AlertsViolationData()
        {
            labels = new List<string>();
            datasets = new List<AlertsViolationDataset>();
        }
    public List<string> labels { get; set; }
    public List<AlertsViolationDataset> datasets { get; set; }
}

public class AlertsViolationOptions
{
    public bool responsive { get; set; }
    public bool maintainAspectRatio { get; set; }
}





#endregion

    #region GET /reportsummary/platform/mtbd/driver/distancecovered
public class ReportSummaryDistanceCovered
{
    public ReportSummaryDistanceCovered()
    {
        labels = new List<string>();
        datasets = new List<DistanceCoveredDataset>();
    }
    public List<string> labels { get; set; }
    public List<DistanceCoveredDataset> datasets { get; set; }
    public string chartType { get; set; }
    public Options options { get; set; }
}
public class DistanceCoveredDataset
{
    public DistanceCoveredDataset()
    {
        data = new List<int>();
    }
    public string label { get; set; }
    public List<int> data { get; set; }
    public string background { get; set; }
}

public class DistanceCoveredOptions
{
    public bool responsive { get; set; }
    public bool maintainAspectRatio { get; set; }
}


    #endregion

    #region /report/platform/mtbd/vehiclemovement/vehiclemovementsummary/{vehicleRegNo}
    public class VehicleMovementSummary
    {
        public string title { get; set; }
        public string value { get; set; }
    }
    public class ReportSummaryVehicleMovementSummary
    {
        public ReportSummaryVehicleMovementSummary()
        {
            summary = new List<VehicleMovementSummary>();
        }
        public List<VehicleMovementSummary> summary { get; set; }
    }
    #endregion

    #region /report/platform/mtbd/alerts/alertssummary/{vehicleRegNo}
    public class AlertsSummary
    {
        public string title { get; set; }
        public string value { get; set; }
    }

    public class ReportSummaryAlertsSummary
    {
        public ReportSummaryAlertsSummary()
        {
            summary = new List<AlertsSummary>();
        }
        public List<AlertsSummary> summary { get; set; }
    }
    #endregion


    #region /report/platform/mtbd/alerts/alertssummary/{vehicleRegNo}
    public class VehicleHealthSummary
    {
        public string title { get; set; }
        public string value { get; set; }
    }

    public class ReportSummaryVehicleHealthSummary
    {
        public ReportSummaryVehicleHealthSummary()
        {
            summary = new List<VehicleHealthSummary>();
        }
        public List<VehicleHealthSummary> summary { get; set; }
    }
    #endregion

    #endregion

    #region Report Summary Common Response

    #region Report Common Response 
    /// <summary>

    /// GET /reportsummary/platform/mtbd/vehiclehealth/vehiclehealthsummary/{vehicleRegNo}
    /// Get /report/platform/mtbd/delivery/vehicleusagesummary/{vehicleRegNo}
    /// </summary>
    public class ReportSummaryCommonReponse
    {
        public string name { get; set; }
        public string value { get; set; }
    }
     #endregion

    #region Report Summary Common Response

    /// <summary>
    /// GET /report/platform/mtbd/delivery/vehicleusage/{vehicleRegNo}
    /// 
    /// 
    /// </summary>
    public class ReportSummaryCommonResponse
   {
        public ReportSummaryCommonData data { get; set; }
        public string chartType { get; set; }
        public ReportSummaryCommonOptions options { get; set; }
    }
    public class ReportSummaryCommonOptions
    {
        public bool responsive { get; set; }
        public bool maintainAspectRatio { get; set; }
    }
    public class ReportSummaryCommonData
    { 
        public ReportSummaryCommonData()
        {
            datasets = new List<ReportSummaryCommonDataset>();
            labels = new List<string>();
        }
        public List<string> labels { get; set; }
        public List<ReportSummaryCommonDataset> datasets { get; set; }
    }
    public class ReportSummaryCommonDataset
{
    public ReportSummaryCommonDataset()
    {
        data = new List<int>();
        backgroundColor = new List<string>();
    }
    public List<string> backgroundColor { get; set; }
    public string label { get; set; }
    public List<int> data { get; set; }
}

#endregion

#region Common Summary 
/// <summary>
///  GET /report/delivery/{vehicleRegNo}/{delivery}
///  GET /report/vehiclehealth/{vehicleRegNo}/{vehiclehealth}
/// </summary>

public class VehicleSummary
{
    public VehicleSummary()
    {
        summary = new List<CommonSummary>();
    }
    [JsonProperty("summary")]
    public List<CommonSummary> summary { get; set; }
}
public class CommonSummary
{
    public string name { get; set; }
    public string value { get; set; }
}

    #endregion

    #endregion
}
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
    public class Category
    {
        public string url { get; set; }
        public string displayName { get; set; }
    }

    public class ApplicationJson
    {
        public ApplicationJson()
        {
            categories = new List<Category>();
        }
        public string displayName { get; set; }
        public List<Category> categories { get; set; }
    }

    public class ReportSummaryMTBDResponse
    {
        public ReportSummaryMTBDResponse()
        {
            applicationjsons = new List<ApplicationJson>();
        }
        [JsonProperty("application/json")]
        public List<ApplicationJson> applicationjsons { get; set; }
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

    #region GET /reportsummary/platform/mtbd/vehiclemovement/speeddata/{vehicleRegNo}
    public class VehicleMovementSpeed
    {
        [JsonProperty("application/json")]
        public VehicleMovementSpeedApplicationJson application { get; set; }
    }
    public class VehicleMovementSpeedApplicationJson
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

    #region GET /reportsummary/platform/mtbd/vehiclemovement/usagetime/{vehicleRegNo}

    public class VehicleMovementUsageTime
    {
        [JsonProperty("application/json")]
        public VehicleMovementUsageTimeApplicationJson application { get; set; }
    }
    public class VehicleMovementUsageTimeApplicationJson
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

    #region GET /reportsummary/platform/mtbd/vehiclemovement/enginerpm/{vehicleRegNo}

    public class VehicleMovementEngineRpm
    {
        [JsonProperty("application/json")]
        public VehicleMovementEngineRpmApplicationJson application { get; set; }
    }
    public class VehicleMovementEngineRpmApplicationJson
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

    #region /reportsummary/platform/mtbd/vehiclemovement/vehiclemovementreport/{vehicleRegNo}

    public class VehilceMovementReport
    {
        [JsonProperty("application/json")]
        public ApplicationJson applicationjson { get; set; }
        public class VehilceMovementReportDataset
        {
            public string label { get; set; }
            public List<int> data { get; set; }
            public string backgroundColor { get; set; }
        }

        public class VehilceMovementReportData
        {
            public List<string> labels { get; set; }
            public List<VehilceMovementReportDataset> datasets { get; set; }
        }

        public class VehilceMovementReportOptions
        {
            public bool responsive { get; set; }
            public bool maintainAspectRatio { get; set; }
        }

        public class VehilceMovementReportApplicationJson
        {
            public VehilceMovementReportData data { get; set; }
            public string chartType { get; set; }
            public Options options { get; set; }
        }


    }
    #endregion

    #region /reportsummary/platform/mtbd/alerts/vehiclealerts/{vehicleRegNo}

    public class ReportSumamryVehicleAlerts
    {
        [JsonProperty("application/json")]
        public VehicleAlertApplicationJson applicationjson { get; set; }
    }

    public class VehicleAlertDataset
    {
        public string label { get; set; }
        public List<int> data { get; set; }
        public string backgroundColor { get; set; }
    }

    public class VehicleAlertData
    {
        public List<string> labels { get; set; }
        public List<VehicleAlertDataset> datasets { get; set; }
    }

    public class VehicleAlertOptions
    {
        public bool responsive { get; set; }
        public bool maintainAspectRatio { get; set; }
    }

    public class VehicleAlertApplicationJson
    {
        public VehicleAlertData data { get; set; }
        public string chartType { get; set; }
        public Options options { get; set; }
    }


    #endregion

    #region  /reportsummary/platform/mtbd/alerts/violation/{vehicleRegNo}

    public class AlertsViolation
    {
        [JsonProperty("application/json")]
        public AlertsViolationApplicationJson applicationjson { get; set; }
    }
    public class AlertsViolationDataset
    {
        public string label { get; set; }
        public List<int> data { get; set; }
        public string backgroundColor { get; set; }
    }

    public class AlertsViolationData
    {
        public List<string> labels { get; set; }
        public List<AlertsViolationDataset> datasets { get; set; }
    }

    public class AlertsViolationOptions
    {
        public bool responsive { get; set; }
        public bool maintainAspectRatio { get; set; }
    }

    public class AlertsViolationApplicationJson
    {
        public AlertsViolationData data { get; set; }
        public string chartType { get; set; }
        public AlertsViolationOptions options { get; set; }
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

    #endregion

    #region Report Summary Common Response

    #region Report Common Response 
    /// <summary>
    /// GET /reportsummary/platform/mtbd/vehiclemovement/vehiclemovementsummary/{vehicleRegNo}
    /// GET /reportsummary/platform/mtbd/alerts/alertssummary/{vehicleRegNo}
    /// GET /reportsummary/platform/mtbd/delivery/vehicleusagesummary/{vehicleRegNo}
    /// GET /reportsummary/platform/mtbd/vehiclehealth/vehiclehealthsummary/{vehicleRegNo}
    /// </summary>
    public class ReportSummaryCommonReponse
    {
        public string name { get; set; }
        public string value { get; set; }
    }
    #endregion

    #region Report Summary Common Response

    /// <summary>
    /// GET /reportsummary/platform/mtbd/delivery/vehicleusage/{vehicleRegNo}
    /// 
    /// 
    /// </summary>
    public class ReportSummaryCommonResponse
    {
        [JsonProperty("application/json")]
        public ApplicationJson applicationjson { get; set; }
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

    public class ReportSummaryCommonOptions
    {
        public bool responsive { get; set; }
        public bool maintainAspectRatio { get; set; }
    }

    public class ReportSummaryCommonApplicationJson
    {
        public ReportSummaryCommonData data { get; set; }
        public string chartType { get; set; }
        public Options options { get; set; }
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
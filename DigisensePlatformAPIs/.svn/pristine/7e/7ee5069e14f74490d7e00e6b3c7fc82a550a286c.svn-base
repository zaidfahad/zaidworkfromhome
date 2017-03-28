using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    
    #region    Vehicle Response
    public class VehicleResponse
    {
        //public VehicleResponse()
        //{
        //    lastknownlocation = new List<location>();
        //}
        public string vehiclePlatform { get; set; }
        public string vehicleModel { get; set; }
        public string vehicleVariant { get; set; }
        public string vehicleRegNo { get; set; }
        public string status { get; set; }
        public string lastupdated { get; set; }
        public Vehiclelocation lastknownlocation { get; set; }
       // public Dictionary<string, string> lastknownlocation = new Dictionary<string, string>();
        //public List<location> lastknownlocation { get; set; } //= new List<location>();
        public Boolean priorityAlertStatus { get; set; }
        public string address { get; set; }
        public string speed { get; set; }
        public string runningHours { get; set; }
        public string driverName { get; set; }
    }
    public class location
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
       
    }
    #endregion




    #region  MTBD Vehicle Response


    public class MTBDVehicleResponse
    {
        //public MTBDVehicleResponse()
        //{
        //    lastknownlocation = new List<location>();
        //}
        public string vehiclePlatform { get; set; }
        public string vehicleModel { get; set; }
        public string vehicleVariant { get; set; }
        public string vehicleRegNo { get; set; }
        public string status { get; set; }
        public string lastupdated { get; set; }
       // public Dictionary<string, string> lastknownlocation = new Dictionary<string, string>();
        public Vehiclelocation lastknownlocation { get; set; }
       // public List<location> lastknownlocation  {   get; set; }
        public Boolean priorityAlertStatus { get; set; }
        public string address { get; set; }
        public string speed { get; set; }
        public string runningHours { get; set; }
        public string driverName { get; set; }
    }
    #endregion

    #region  Vehicle Summary Response
    public class VehicleSummaryResponse
    {
    
        public string vehicleRegNo { get; set; }
        [JsonProperty(PropertyName = "vehicleLastUsedOn")]
        public string vehicleLastUsed { get; set; }
        [JsonProperty(PropertyName = "totalUsage")]
        public string TotalHours { get; set; }

        [JsonProperty(PropertyName = "vehicleRunningHours")]
        public string runninghours { get; set; }

        [JsonProperty(PropertyName = "vehicleIdleHours")]
        public string idlehours { get; set; }
        
    }
    #endregion

    #region  MTBD Vehicle Summary Response
    public class MTBDVehicleSummaryResponse
    {

        public string vehicleRegNo { get; set; }

        [JsonProperty(PropertyName = "vehicleLastUsedOn")]
        public string vehicleLastUsed { get; set; }

        [JsonProperty(PropertyName = "totalUsage")]
        public string TotalHours { get; set; }

        [JsonProperty(PropertyName = "vehicleRunningHours")]
        public string runninghours { get; set; }

        [JsonProperty(PropertyName = "vehicleIdleHours")]
        public string idlehours { get; set; }
        
     
 
    }
    #endregion

    #region  VehicleInformation Response
    public class VehicleInformationResponse
    {

        //public string vehiclePlatform { get; set; }
        //public string vehicleModel { get; set; }
        //public string vehicleVariant { get; set; }
        public string vehicleRegNo { get; set; }
        public string vehicleStatus { get; set; }
        public string lastUpdated { get; set; }
 

    }
    #endregion

    #region   MTBD VehicleInformation Response
    public class MTBDVehicleInformationResponse
    {

        public string vehiclePlatform { get; set; }
        public string vehicleModel { get; set; }
        public string vehicleVariant { get; set; }
        public string vehicleRegNo { get; set; }
        public string vehicleStatus { get; set; }
        public string lastupdated { get; set; }

        public string highEngineTemperature { get; set; }
        public Int32 engineRPM { get; set; }
        public string fuelLevel { get; set; }
        public string vehicleHealth { get; set; }
        public string fuelEfficiencyA { get; set; }
        public string fuelEfficiencyB { get; set; }
        public string averageVehicleSpeed { get; set; }
        public string engineOilPressure { get; set; }
        public string driverName { get; set; }


    }
    #endregion

    #region   Vehicle LocationHistory Response
    public class VehicleLocationHistoryResponse
    {
       // public string registrationNumber { get; set; }
        public string speed { get; set; }
       // public Dictionary<string, string> location = new Dictionary<string, string>();
        public string address { get; set; }
        public Vehiclelocation location  { get; set; }
       // public List<location> location = new List<location>();
      // [JsonProperty(PropertyName = "dateTime")]
        public string timeStamp { get; set; }
       
    }
    #endregion

    #region Single  Vehicle Alerts Response
    public class SingleVehicleAlertsResponse
    {
       
        //public SingleVehicleAlertsResponse()
        //{
        //    location = new List<Models.location>();
        //}
        public string alertId { get; set; }
        public string alertName { get; set; }
       // public Dictionary<string, string> location = new Dictionary<string, string>();
       // public List<location> location { get; set; }
        public Vehiclelocation location { get; set; }
        public string priority { get; set; }
        public string dateTime { get; set; }
   
    }
    #endregion

    #region   Vehicle Alerts Response
    public class VehicleAlertsResponse
    {
        public string vehicleRegNo { get; set; }
        [JsonProperty(PropertyName = "alerts")]
       // public SingleVehicleAlertsResponse SingleVehicleAlertsResponse { get; set; }
        public List<SingleVehicleAlertsResponse> SingleVehicleAlertsResponse = new List<SingleVehicleAlertsResponse>();
    }
    #endregion

    #region   location
    public class Vehiclelocation
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
       
        
    }
    #endregion

#region Vehicle Status

    public class VehicleStatusResponse
    {

        private int _unknown = 0;   
        public int unknown
        {
            get
            {
                return _unknown;
            }
            set
            {
                _unknown = value;

            }
        }

        private int _running = 0;  
        public int running
        {
            get
            {
                return _running;
            }
            set
            {
                _running = value;

            }
        }

        private int _stopped = 0;   
        public int stopped
        {
            get
            {
                return _stopped;
            }
            set
            {
                _stopped = value;

            }
        }

        private int _idle = 0;  
        public int idle
        {
            get
            {
                return _idle;
            }
            set
            {
                _idle = value;

            }
        }

        private int _notused = 0;   
        public int notused
        {
            get
            {
                return _notused;
            }
            set
            {
                _notused = value;

            }
        }

         
      
       
      
    }


  
#endregion
    #region vehicle Health
    public class VehicleHealthStatusResponse
    {  

        private int _totalBreakdownsOccurred = 0;
        public int totalBreakdownsOccurred
        {
            get
            {
                return _totalBreakdownsOccurred;
            }
            set
            {
                _totalBreakdownsOccurred = value;

            }
        }


        private int _totalBreakdownsClosed = 0;
        public int totalBreakdownsClosed
        {
            get
            {
                return _totalBreakdownsClosed;
            }
            set
            {
                _totalBreakdownsClosed = value;

            }
        }

        public vehiclehealth vehiclehealth { get; set; }

 
    }
    public class vehiclehealth
    {

        private int _good = 0;
        public int good
        {
            get
            {
                return _good;
            }
            set
            {
                _good = value;

            }
        }

        private int _bad = 0;
        public int bad
        {
            get
            {
                return _bad;
            }
            set
            {
                _bad = value;

            }
        }

        private int _warning = 0;
        public int warning
        {
            get
            {
                return _warning;
            }
            set
            {
                _warning = value;

            }
        }


    }
    #endregion
}
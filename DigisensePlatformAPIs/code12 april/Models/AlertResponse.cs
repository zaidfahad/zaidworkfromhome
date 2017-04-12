using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class AlertResponse
    {
        public AlertResponse()
        {
            Alert = new List<Alert>();
        }
        public string vehicleRegNo { get; set; }
        public List<Alert> Alert{ get; set; }
    }
    public class Alert
    {
        //public Alert()
        //{
        //    location = new List<Locations>();
        //}
        public string alertId { get; set; }
        public string priority { get; set; }
        public string alertName { get; set; }
        public string dateTime { get; set; }
       // public List<Locations> location { get; set; }
        public Locations location { get; set; }
    }
    public class Locations
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
       
    }
}

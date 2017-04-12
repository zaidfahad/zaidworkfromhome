using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class VehicleLocationHistoryModel
    {
        public string code { get; set; }
        public string description { get; set; }
        public string speed { get; set; }
        public string address { get; set; }
        public List<Location> locations { get; set; }
        public string timestamp { get; set; }
    }

    public class Location
    {
        public string latitude { get; set; }
        public string  longitude { get; set; }
    }
}
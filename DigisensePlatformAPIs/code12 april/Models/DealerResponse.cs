using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class DealerResponse
    {
        //public DealerResponse()
        //{
        //    localtions = new List<Location>();
        //}
        public string dealerId { get; set; }
        public string name { get; set; }
        //public List<Location> locations { get; set; }
        //public Dictionary<string, string> location = new Dictionary<string, string>();
        public Location location { get; set; }
        public string address { get; set; }
        public Int64 contactNumber { get; set; }
    }

    public class Location
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
        
       
    }
}
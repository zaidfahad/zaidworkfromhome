using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class GeofenceResponse
    {
        public string name { get; set; }
        public List<points> points { get; set; }
    }

    public class GeofencePointsListResponse
    {
        public   points  points { get; set; }
    }

    public class GeofenceVehicleMappingResponse
    {
        public string id { get; set; }
        public string vehicleRegNo { get; set; }
        public string geoFenceName { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string type { get; set; }
    }
}
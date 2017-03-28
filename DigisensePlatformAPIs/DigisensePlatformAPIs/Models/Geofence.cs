using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class Geofence
    {
        public string name { get; set; }
        public List<points> points { get; set; }
    }
        public class points
     {
        public double longitude { get; set; }
        public double latitude { get; set; }
       
    }

    public class GeoFencePutRequest
    {
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Vehicle reg no length should not be less than 5 char")]
        public string vehicleRegNo { get; set; }
        [Required]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$", ErrorMessage = "Start date is not the correct format. Should be yyyy-MM-dd HH:mm:ss")]
        public string startDate { get; set; }
        [Required]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$", ErrorMessage = "End date is not the correct format. Should be yyyy-MM-dd HH:mm:ss")]
        public string endDate { get; set; }
        [Required]
        public string type { get; set; }
    }
}
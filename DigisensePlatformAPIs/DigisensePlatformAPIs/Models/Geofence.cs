﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class Geofence
    {
        public string name { get; set; }
        public List<point> points { get; set; }
    }
    public class point
     {
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
       
    }
    public class GeoFencePutRequest
    {
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Vehicle reg no length should not be less than 5 char")]
        public string vehicleRegNo { get; set; }
        [Required]
        [RegularExpression(@"^\d{4}[-/.]\d{1,2}[-/.]\d{1,2}$", ErrorMessage = "Start date is not the correct format. Should be yyyy-MM-dd")]
        public string startDate { get; set; }
        [Required]
        [RegularExpression(@"^\d{4}[-/.]\d{1,2}[-/.]\d{1,2}$", ErrorMessage = "End date is not the correct format. Should be yyyy-MM-dd")]
        public string endDate { get; set; }
        [Required]
        public string type { get; set; }
    }
}
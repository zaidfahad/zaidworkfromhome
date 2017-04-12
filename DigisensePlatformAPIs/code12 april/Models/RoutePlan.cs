using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{

    #region Route Plan 10.05
    public class RoutePlan
    {
    }
    #endregion

    #region Route Plan 10.03
    public class RoutePlanAssginRoute
     {
        public string vehicleRegNo { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string type { get; set; }
    }
    #endregion

    #region Route Plan Request 10.02 and 10.04

    public class Point
    {
        public string routePointId { get; set; }
        public int longitude { get; set; }
        public int latitude { get; set; }
        public string priority { get; set; }
        public string activity { get; set; }
        public string address { get; set; }
        public int contactNumber { get; set; }
    }

    public class RoutePlanRequestPost
    {
        public string routeId { get; set; }
        public string name { get; set; }
        public List<string> routeOption { get; set; }
        public List<Point> points { get; set; }
    }
    #endregion

    #region RoutePlan 10.06 PUT
    public class UpdateOnGoingTripRequest
    {
        public string routePointId { get; set; }
        public int longitude { get; set; }
        public int latitude { get; set; }
        public string priority { get; set; }
        public string activity { get; set; }
        public string address { get; set; }
        public int contactNumber { get; set; }
    }
    #endregion
    public class RoutePlanDelete
    {

    } 
}


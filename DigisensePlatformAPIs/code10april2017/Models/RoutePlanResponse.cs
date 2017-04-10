using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    #region Route Plan 10.01 Get

    public class RoutePlanDetailsResponse
    {
        public string routeId { get; set; }
        public string name { get; set; }
    }
    #endregion

    #region Route Plan 10.02 Post & Put Type 10.04 Specific RouteName
    /// <summary>
    /// 10.02 Post & Put Type 10.04 Specific RouteName &  Delete 10.03 & Route Plan 10.05
    /// </summary>

    public class RoutePlanResponses
    {
        public RoutePlanResponses()
        {
            points = new List<RoutePoints>();
            routeOption = new List<string>();
        }
        public string routeId { get; set; }
        public string name { get; set; }
        public List<string> routeOption { get; set; }
        [JsonProperty("point")]
        public List<RoutePoints> points { get; set; }
    }
    #endregion

    #region  10.03
    public class AssignRouteToVehicles
    {
        public string id { get; set; }
        public string vehicleRegNo { get; set; }
        public string geoFenceName { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string type { get; set; }
    }
    #endregion
    #region Route plan 10.04
    public class ViewAssignTripPoint
    {
        public string routePointId { get; set; }
        public int longitude { get; set; }
        public int latitude { get; set; }
        public string priority { get; set; }
        public string activity { get; set; }
        public string address { get; set; }
        public int contactNumber { get; set; }
    }

    public class ViewAssignTripPoint2
    {
        public int longitude { get; set; }
        public int latitude { get; set; }
    }

    public class ViewAssignTripGeofence
    {
        public string name { get; set; }
        public List<ViewAssignTripPoint2> points { get; set; }
    }

    public class ViewAssignTripRouteDetail
    {
        public string id { get; set; }
        public string name { get; set; }
        public string period { get; set; }
        public List<string> routeOption { get; set; }
        public List<Point> points { get; set; }
        public List<Geofence> geofences { get; set; }
    }

    public class ViewAssignTripPlannedLocation
    {
        public int longitude { get; set; }
        public int latitude { get; set; }
    }

    public class ViewAssignTripCompleted
    {
        public string activityId { get; set; }
        public string activity { get; set; }
        public ViewAssignTripPlannedLocation plannedLocation { get; set; }
        public string address { get; set; }
        public string status { get; set; }
    }

    public class ViewAssignTripPlannedLocation2
    {
        public int longitude { get; set; }
        public int latitude { get; set; }
    }

    public class ViewAssignTripToComplete
    {
        public string activityId { get; set; }
        public string activity { get; set; }
        public ViewAssignTripPlannedLocation2 plannedLocation { get; set; }
        public string address { get; set; }
        public string status { get; set; }
    }

    public class ViewAssignTripCurrentLocation
    {
        public int longitude { get; set; }
        public int latitude { get; set; }
    }

    public class ViewAssignTrip
    {
        public string tripName { get; set; }
        public string tripstatus { get; set; }
        public List<ViewAssignTripCompleted> completed { get; set; }
        public List<ViewAssignTripToComplete> toComplete { get; set; }
        public ViewAssignTripCurrentLocation currentLocation { get; set; }
    }

    public class ViewAssignTripForVehilces
    {
        public ViewAssignTripRouteDetail routeDetail { get; set; }
        public ViewAssignTrip trip { get; set; }
    }
    #endregion

    #region Route Plan 10.05
    //Need to make Some Changes 


    public class RoutePlanResponse
    {
        public RoutePlanResponse()
        {
            routeOption = new List<string>();
            points = new List<RoutePoints>();
        }
        public string routeId { get; set; }
        public string name { get; set; }
        public List<string> routeOption { get; set; }
        [JsonProperty("point")]
        public List<RoutePoints> points { get; set; }
    }
    #endregion

    #region OnGoingTrip 10.06

    public class OnGoingTripResponse
    {
        public OnGoingTripResponse()
        {
            points = new List<RoutePoints>();
            routeOption = new List<string>();
        }
        public string routeId { get; set; }
        public string name { get; set; }
        public List<string> routeOption { get; set; }
        [JsonProperty("point")]
        public List<RoutePoints> points { get; set; }
    }
    #endregion

    #region Common Class
    public class RoutePoints
    {
        public string routePointId { get; set; }
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
        public string priority { get; set; }
        public string activity { get; set; }
        public string address { get; set; }
        public double contactNumber { get; set; }
    }
    #endregion
}
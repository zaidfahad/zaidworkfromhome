﻿using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.BLUtilities
{
    public class RoutePlan_BL
    {

        #region  Route Plan Response   [VerNo - 10.01]
        public static List<RoutePlanDetailsResponse> ListAllRoutePlanResponse(DataTable dt)
        {
            RoutePlanDetailsResponse routeplanDetails = null;
            List<RoutePlanDetailsResponse> routeplanDetailslist = new List<RoutePlanDetailsResponse>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    routeplanDetails = new RoutePlanDetailsResponse();
                    routeplanDetails.routeId = dt.Rows[i]["RouteID"].ToString();
                    routeplanDetails.name = dt.Rows[i]["RouteName"].ToString();
                    routeplanDetailslist.Add(routeplanDetails);
                }
                return routeplanDetailslist;
            }
            catch (Exception ex)
            {
                return routeplanDetailslist;
            }
        }
        #endregion

        #region  Route Plan Response   [VerNo - 10.02]
        public static List<RoutePlanResponses> RoutePlanPostResponse(DataTable dt)
        {
            RoutePlanResponses routeplanDetails = null;
            List<RoutePlanResponses> routeplanDetailslist = new List<RoutePlanResponses>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    routeplanDetails = new RoutePlanResponses();

                    routeplanDetailslist.Add(routeplanDetails);
                }
                return routeplanDetailslist;
            }
            catch (Exception ex)
            {
                return routeplanDetailslist;
            }
        }
        #endregion

        #region  Route Plan Response   [VerNo - 10.03]
        public static List<AssignRouteToVehicles> RoutePlanDelete(DataTable dt)
        {
            AssignRouteToVehicles routeplanDetails = new AssignRouteToVehicles();
            List<AssignRouteToVehicles> routeplanDetailslist = new List<AssignRouteToVehicles>();
            try
            {
                return routeplanDetailslist;
            }
            catch (Exception ex)
            {
                return routeplanDetailslist;
            }
        }
        #endregion

        #region  Route Plan Response   [VerNo - 10.04]
        public static List<ViewAssignTripForVehilces> ViewAssignTripForVehicleResponse(DataTable dt)
        {
            ViewAssignTripForVehilces routeplanDetails = null;
            List<ViewAssignTripForVehilces> routeplanDetailslist = new List<ViewAssignTripForVehilces>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    routeplanDetails = new ViewAssignTripForVehilces();
                }
                return routeplanDetailslist;
            }
            catch (Exception ex)
            {
                return routeplanDetailslist;
            }
        }
        #endregion

        #region  Route Plan Response  [VerNo - 10.05]
        public static List<RoutePlanResponse> RoutePlanResponse(DataTable dt)
        {
            RoutePoints clsRoutePointResponse = null;
            List<RoutePoints> sublist = new List<RoutePoints>();
            RoutePlanResponse clsRoutePlanResponse = null;
            List<RoutePlanResponse> list = new List<RoutePlanResponse>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsRoutePlanResponse = new RoutePlanResponse();
                    clsRoutePlanResponse.routeId = dt.Rows[i]["RouteID"].ToString();
                    clsRoutePlanResponse.name = dt.Rows[i]["RouteName"].ToString();
                    clsRoutePlanResponse.routeOption.Add(dt.Rows[i]["RouteOption"].ToString());
                    clsRoutePlanResponse.points = sublist;
                    clsRoutePointResponse = new RoutePoints();
                    clsRoutePointResponse.routePointId = dt.Rows[i]["JobLocationID"].ToString();
                    clsRoutePointResponse.latitude = Convert.ToDecimal(dt.Rows[i]["Latitude"].ToString());
                    clsRoutePointResponse.longitude = Convert.ToDecimal(dt.Rows[i]["Longitude"].ToString());
                    clsRoutePointResponse.priority = dt.Rows[i]["Priority"].ToString();
                    clsRoutePointResponse.activity = dt.Rows[i]["Activity"].ToString();
                    clsRoutePointResponse.address = dt.Rows[i]["Address"].ToString();
                    clsRoutePointResponse.contactNumber = Convert.ToInt64(dt.Rows[i]["ContactMobileNo"].ToString());
                    sublist.Add(clsRoutePointResponse);
                    list.Add(clsRoutePlanResponse);
                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        #endregion

        #region On Going Trip View 10.06
        public static List<OnGoingTripResponse> OnGoingTripsResponse(DataTable dt)
        {
            List<RoutePoints> sublist = new List<RoutePoints>();
            OnGoingTripResponse clsRoutePlanResponse = null;
            List<OnGoingTripResponse> list = new List<OnGoingTripResponse>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
        #endregion

    }
}
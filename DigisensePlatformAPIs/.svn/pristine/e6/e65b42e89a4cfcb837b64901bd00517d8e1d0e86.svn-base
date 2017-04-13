using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.BLUtilities
{
    public class Geofence_BL
    {

        #region  Geofence Response
        public static GeofenceResponse  GeofenceResponse(DataTable dt)
        {
            GeofenceResponse clsGeofenceResponse = null;


            points clsGeofencePointsListResponse = null;
            List<points> list;

 
            try
            {
                clsGeofenceResponse = new GeofenceResponse();
             
                clsGeofenceResponse.name = dt.Rows[0]["geofence_name"].ToString();
                string[] latlng = dt.Rows[0]["geo_boundary_data"].ToString().Split(',');
                list = new List<points>();
                for (int i = 0; i < latlng.Length; i=i+2)
                {
                    clsGeofencePointsListResponse = new points();
                    clsGeofencePointsListResponse.latitude= latlng[i].ToString() == "" ? 180 : Convert.ToDouble(latlng[i].ToString());
                    clsGeofencePointsListResponse.longitude = latlng[i + 1].ToString() == "" ? 180 : Convert.ToDouble(latlng[i + 1].ToString());

                    list.Add(clsGeofencePointsListResponse);
                }
                clsGeofenceResponse.points = list;
                return clsGeofenceResponse;
            }
            catch (Exception ex)
            {
                return clsGeofenceResponse;
            }
        }
        #endregion

        #region List Geofence Response
        public static List<GeofenceResponse> GeofenceAllResponse(DataTable dt)
        {
            GeofenceResponse clsGeofenceResponse = null;

            List<GeofenceResponse> finallist = new List<GeofenceResponse>();
            points clsGeofencePointsListResponse = null;
            List<points> list;


            try
            {
             
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    clsGeofenceResponse = new GeofenceResponse();
                    list = new List<points>();
                    clsGeofenceResponse.name = dt.Rows[n]["geofence_name"].ToString();
                    string[] latlng = dt.Rows[n]["geo_boundary_data"].ToString().Split(',');

                    for (int i = 0; i < latlng.Length; i = i + 2)
                    {
                        clsGeofencePointsListResponse = new points();
                        clsGeofencePointsListResponse.latitude = latlng[i].ToString() == "" ? 180 : Convert.ToDouble(latlng[i].ToString());
                        clsGeofencePointsListResponse.longitude = latlng[i + 1].ToString() == "" ? 180 : Convert.ToDouble(latlng[i + 1].ToString());

                        list.Add(clsGeofencePointsListResponse);
                    }
                    clsGeofenceResponse.points = list;

                    finallist.Add(clsGeofenceResponse);
                }
                return finallist;
            }
            catch (Exception ex)
            {
                return finallist;
            }
        }
        #endregion


        #region List Geofence Vehicle Mapping Response
        public static List<GeofenceVehicleMappingResponse> GeofenceVehicleMappingResponse(DataTable dt)
        {
            GeofenceVehicleMappingResponse clsGeofenceVehicleMappingResponse = null;

            List<GeofenceVehicleMappingResponse> finallist = new List<GeofenceVehicleMappingResponse>();
           
            try
            {

                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    clsGeofenceVehicleMappingResponse = new GeofenceVehicleMappingResponse();

                    clsGeofenceVehicleMappingResponse.id = dt.Rows[n]["GeofenceID"].ToString();
                    clsGeofenceVehicleMappingResponse.vehicleRegNo = dt.Rows[n]["RegistrationNumber"].ToString();
                    clsGeofenceVehicleMappingResponse.geoFenceName = dt.Rows[n]["geofencename"].ToString();
                    clsGeofenceVehicleMappingResponse.startDate = Convert.ToDateTime(dt.Rows[n]["StartDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    clsGeofenceVehicleMappingResponse.endDate = Convert.ToDateTime(dt.Rows[n]["EndDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    clsGeofenceVehicleMappingResponse.type = dt.Rows[n]["Type"].ToString();

                    finallist.Add(clsGeofenceVehicleMappingResponse);
                }
                return finallist;
            }
            catch (Exception ex)
            {
                return finallist;
            }
        }
        #endregion
    }
}
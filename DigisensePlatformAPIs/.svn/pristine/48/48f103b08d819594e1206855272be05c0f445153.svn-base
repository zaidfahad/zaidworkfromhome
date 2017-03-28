using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.BLUtilities
{
    public class Alert_BL
    {
        public static List<AlertResponse> AlertResponse(DataTable dt)
        {
            List<AlertResponse> alertResponselist = new List<Models.AlertResponse>();
            alertResponselist.Clear();
            try {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Alert alert = new Alert();

                    AlertResponse clsAlertResponse = new Models.AlertResponse();
                    
                    //Locations localtions = new Locations();
                    //localtions.latitude = dt.Rows[i]["latitude"].ToString();
                    //localtions.longitude = dt.Rows[i]["longitude"].ToString();
                    clsAlertResponse.vehicleRegNo = dt.Rows[i]["registrationNumber"].ToString();
                  
                    alert.alertName = dt.Rows[i]["alertDescription"].ToString();
                    alert.alertId = dt.Rows[i]["alertId"].ToString();
                    if (dt.Rows[i]["alert_Time"].ToString() != "")
                    {
                        alert.dateTime = Convert.ToDateTime(dt.Rows[i]["alert_Time"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        alert.dateTime = Convert.ToDateTime("1900-01-01 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    alert.priority = dt.Rows[i]["priority"].ToString();
                    //alert.location.Add(localtions);
                    alert.location = new Locations { latitude = dt.Rows[i]["latitude"].ToString() == "" ? 180 : Convert.ToDouble(dt.Rows[i]["latitude"].ToString()), longitude = dt.Rows[i]["longitude"].ToString() == "" ? 180 : Convert.ToDouble(dt.Rows[i]["longitude"].ToString()) };
                    clsAlertResponse.Alert.Add(alert);
                    alertResponselist.Add(clsAlertResponse);
                }
                return alertResponselist;
            }catch(Exception ex)
            {
                return alertResponselist;
            }
        }
    }
}
using System;
using Npgsql;
using DigisensePlatformAPIs.Utilities;
using DigisensePlatformAPIs.Models;
using Newtonsoft.Json;
 
using System.Data;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace DigisensePlatformAPIs.BLUtilities
{
    public class BuisnessLogic
    {
         


        #region Response And Error

        #region Resposne for Login in Case of 200
        


        public static LoginResponse LoginResponse(string token)
        {
            LoginResponse clsLoginResponse = null;
      
            try
            {
                clsLoginResponse = new LoginResponse();

                clsLoginResponse.jwt = token;
                clsLoginResponse.serviceAvailable = "";

                return clsLoginResponse;
            }
            catch (Exception ex)
            {
                return clsLoginResponse;
            }
        }

        #endregion

        #region  Response
    
        public static Response Response( string messages)
        {
            Response clsResponse = null;
            try
            {
                clsResponse = new Response();
          
                clsResponse.Message = messages;
                return clsResponse;
            }
            catch (Exception ex)
            {
                return clsResponse;
            }
        }
        #endregion


        public static AlertResponse AlertResponse(DataTable dt)
        {
            AlertResponse clsAlertResponse = null;

            try
            {
                

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsAlertResponse = new AlertResponse();
                    clsAlertResponse.vehicleID = dt.Rows[i]["vehicleID"].ToString();
                    clsAlertResponse.registrationNumber = dt.Rows[i]["registrationNumber"].ToString();
                    clsAlertResponse.alertId = dt.Rows[i]["alertId"].ToString();
                    clsAlertResponse.alertDescription = dt.Rows[i]["alertDescription"].ToString();
                    clsAlertResponse.priority = dt.Rows[i]["priority"].ToString();
                    clsAlertResponse.alert_Time = dt.Rows[i]["alert_Time"].ToString();
                    clsAlertResponse.location.Add(dt.Rows[i]["latitude"].ToString(), dt.Rows[i]["longitude"].ToString());
                    
                }
                    return clsAlertResponse;
            }
            catch (Exception ex)
            {
                return clsAlertResponse;
            }
        }
        public static VehicleLocationHistoryResponse VehicleLocationHistoryResponse(DataTable dt)
        {
            VehicleLocationHistoryResponse clsVehicleLocationHistoryResponse = null;

            try
            {
                

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsVehicleLocationHistoryResponse = new VehicleLocationHistoryResponse();
                    clsVehicleLocationHistoryResponse.registrationNumber = dt.Rows[i]["registrationNumber"].ToString();
                    clsVehicleLocationHistoryResponse.vehicleSpeed = dt.Rows[i]["vehicleSpeed"].ToString();
                    clsVehicleLocationHistoryResponse.vehicleLocation.Add(dt.Rows[i]["latitude"].ToString(), dt.Rows[i]["longitude"].ToString());
                    clsVehicleLocationHistoryResponse.vehicleLocationTime = dt.Rows[i]["vehicleLocationTime"].ToString();
           
                   
                    
                }
                return clsVehicleLocationHistoryResponse;
            }
            catch (Exception ex)
            {
                return clsVehicleLocationHistoryResponse;
            }
        }

        
        #endregion


        


    }
}
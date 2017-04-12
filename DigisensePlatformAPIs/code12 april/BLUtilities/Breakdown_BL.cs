﻿using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.BLUtilities
{
    public class Breakdown_BL
    {
        #region  Breakdown Response
        public static List<BreakdownResponse> BreakdownResponse(DataTable dt)
        {
            List<BreakdownResponse> clsBreakdownResponseList = new List<Models.BreakdownResponse>();
            BreakdownResponse clsBreakdownResponse = null;
            clsBreakdownResponseList.Clear();
            //List<BreakdownResponse> list = new List<BreakdownResponse>();
            try
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsBreakdownResponse = new BreakdownResponse();
                   clsBreakdownResponse.longitude = Convert.ToDouble(dt.Rows[0]["Longitude"].ToString());
                    clsBreakdownResponse.latitude = Convert.ToDouble(dt.Rows[0]["Latitude"].ToString());
                    //
                    if (dt.Rows[0]["EventTime"].ToString() != "")
                    {
                        clsBreakdownResponse.timestamp = Convert.ToDateTime(dt.Rows[0]["EventTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        clsBreakdownResponse.timestamp = Convert.ToDateTime("1900-01-01 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    // clsBreakdownResponse.timestamp = Convert.ToDateTime(dt.Rows[0]["EventTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");


                    //  list.Add(clsBreakdownResponse);
                    clsBreakdownResponseList.Add(clsBreakdownResponse);
                }
                return clsBreakdownResponseList;
            }
            catch (Exception ex)
            {
                return clsBreakdownResponseList;
            }
        }
        #endregion
    }
}
using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.BLUtilities
{
    public class Dealer_BL
    {
        public static List<DealerResponse> DealerResponse(DataTable dt)
        {
            DealerResponse clsDealerResponse = null;
            List<DealerResponse> list = new List<DealerResponse>();
            Location localtions = new Location();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsDealerResponse = new DealerResponse();
                    clsDealerResponse.dealerId = dt.Rows[i]["dealerCode"].ToString();
                    clsDealerResponse.name = dt.Rows[i]["dealerName"].ToString();
                   // localtions.latitude = dt.Rows[i]["latitude"].ToString();
                   // localtions.longitude= dt.Rows[i]["longitude"].ToString();
                   // clsDealerResponse.localtions.Add(localtions);
                   // clsDealerResponse.location.Add( dt.Rows[i]["latitude"].ToString(),  dt.Rows[i]["longitude"].ToString());
                    clsDealerResponse.location = new Location { latitude = dt.Rows[i]["latitude"].ToString() == "" ? 180 : Convert.ToDouble(dt.Rows[i]["latitude"].ToString()), longitude = dt.Rows[i]["longitude"].ToString() == "" ? 180 : Convert.ToDouble(dt.Rows[i]["longitude"].ToString()) };
                   // clsDealerResponse.location = new Location { latitude = Convert.ToDouble(dt.Rows[i]["latitude"].ToString()), longitude = Convert.ToDouble(dt.Rows[i]["longitude"].ToString()) };
                    clsDealerResponse.address = dt.Rows[i]["dealerAddress"].ToString();
                    clsDealerResponse.contactNumber = Convert.ToInt64(dt.Rows[i]["dealerPhnNo"].ToString());
                    list.Add(clsDealerResponse);

                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }
    }
}
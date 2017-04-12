using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace DigisensePlatformAPIs.BLUtilities
{
    public class Driver_BL
    {
      

        #region    Driver Response
        public static List<DriverResponse> DriverResponse(DataTable dt)
        {
            DriverResponse clsDriverResponse = null;

            

            List<DriverResponse> list = new List<DriverResponse>();

            byte[] emptyByte = { };
            try
            {
                  for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsDriverResponse = new DriverResponse();


                    clsDriverResponse.id = new AttributeInfo { value = dt.Rows[i]["id"].ToString(), type = "", editable = false };
                    clsDriverResponse.firstName = new AttributeInfo { value = dt.Rows[i]["firstName"].ToString(), type = "", editable = true };
                    clsDriverResponse.lastName = new AttributeInfo { value = dt.Rows[i]["lastName"].ToString(), type = "", editable = true };
                    clsDriverResponse.contactNumber = new AttributeInfo { value = dt.Rows[i]["contactNumber"].ToString(), type = "", editable = true };
                    clsDriverResponse.address = new AttributeInfo { value = dt.Rows[i]["address"].ToString(), type = "", editable = true };
                   // clsDriverResponse.idProof = new AttributeInfoidProof { value = (byte[])(dt.Rows[i]["idProof"].ToString() == "" ? emptyByte : dt.Rows[i]["idProof"]), type = "", editable = true };
                    clsDriverResponse.idProofTypeId = new AttributeInfo { value = dt.Rows[i]["idprooftypeid"].ToString(), type = "", editable = true };
                    clsDriverResponse.idProofNumber = new AttributeInfo { value = dt.Rows[i]["idproofnumber"].ToString(), type = "", editable = true }; 
                    clsDriverResponse.fileUrl = new AttributeInfo { value = "", type = "", editable = false };
                    clsDriverResponse.email = new AttributeInfo { value = dt.Rows[i]["email"].ToString(), type = "", editable = true };
                    clsDriverResponse.benchmarkFE = new AttributeInfo { value = dt.Rows[i]["benchmarkFE"].ToString(), type = "", editable = true };
                    clsDriverResponse.benchmarkDistance = new AttributeInfo { value = dt.Rows[i]["benchmarkDistance"].ToString(), type = "", editable = true };
                    clsDriverResponse.ranking = new AttributeInfo { value = dt.Rows[i]["Rank"].ToString().Trim(), type = "", editable = false };
                    clsDriverResponse.assignedVehicles = dt.Rows[i]["AssignedVehicles"].ToString()=="" ?  new string[] {}:new string[] { dt.Rows[i]["AssignedVehicles"].ToString() };
 
                    list.Add(clsDriverResponse);

                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }

        
        //public static List<DriverResponse> DriverResponse_old(DataTable dt)
        //{
        //    DriverResponse clsDriverResponse = null;



        //    List<DriverResponse> list = new List<DriverResponse>();

        //    byte[] emptyByte = { };
        //    try
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            clsDriverResponse = new DriverResponse();


        //            clsDriverResponse.driverid = dt.Rows[i]["driverid"].ToString();
        //            clsDriverResponse.firstname = dt.Rows[i]["firstname"].ToString();
        //            clsDriverResponse.lastname = dt.Rows[i]["lastname"].ToString();
        //            clsDriverResponse.mobilenumber = dt.Rows[i]["mobilenumber"].ToString();
        //            clsDriverResponse.address = dt.Rows[i]["Address"].ToString();
        //            clsDriverResponse.idProof = (byte[])(dt.Rows[i]["idproofdata"].ToString() == "" ? emptyByte : dt.Rows[i]["idproofdata"]);
        //            //iif( DBNull (byte[])(dt.Rows[i]["idproofdata"]);
        //            clsDriverResponse.fileUrl = "";
        //            clsDriverResponse.email = dt.Rows[i]["email"].ToString();
        //            clsDriverResponse.benchmarkFE = "3.5";
        //            clsDriverResponse.benchmarkDistance = "7000";
        //            clsDriverResponse.ranking = "1";
        //            clsDriverResponse.assignedVehicles = new[] { "1", "2", "3" };


        //            list.Add(clsDriverResponse);

        //        }
        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
        //        return list;
        //    }
        //}
        #endregion


        #region    Driver Request
        //public static Driver  DriverRequest(List<DriverAttributeInfo> objDriverAttributeInfo)
        //{
        //  Driver clsDriver = null;
        //  clsDriver = new Driver();
        // try
        // {
        //    foreach (var item in objDriverAttributeInfo)
        //    {
        //        //clsDriver. = item.value;
        //    }
        // }
 
        //    catch (Exception ex)
        //    {
        //        return clsDriver;
        //    }
        //}
         
        #endregion
    }
}
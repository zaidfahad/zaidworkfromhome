using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.BLUtilities
{
    public class User_BL
    {
        #region    Driver Response
        public static List<UserResponse> UserResponse(DataTable dt)
        {
            UserResponse clsUserResponse = null;



            List<UserResponse> list = new List<UserResponse>();

            byte[] emptyByte = { };
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsUserResponse = new UserResponse();


                    clsUserResponse.id = new AttributeInfo { value = dt.Rows[i]["id"].ToString(), type = "", editable = false };
                    clsUserResponse.firstName = new AttributeInfo { value = dt.Rows[i]["firstname"].ToString(), type = "", editable = true };
                    clsUserResponse.lastName = new AttributeInfo { value = dt.Rows[i]["lastname"].ToString(), type = "", editable = true };
                    clsUserResponse.contactNumber = new AttributeInfo { value = dt.Rows[i]["contactNumber"].ToString(), type = "", editable = true };
                    clsUserResponse.address = new AttributeInfo { value = dt.Rows[i]["Address"].ToString(), type = "", editable = true };
                    clsUserResponse.idProof = new AttributeInfo { value = "", type = "", editable = false };
                    clsUserResponse.fileUrl = new AttributeInfo { value = "", type = "", editable = false };
                    clsUserResponse.email = new AttributeInfo { value = dt.Rows[i]["email"].ToString(), type = "", editable = true };

                    list.Add(clsUserResponse);

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
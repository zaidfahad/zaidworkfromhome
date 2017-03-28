using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.BLUtilities
{
    public class Profile_BL
    {
        #region User Profile Repsonses

        #region Profile Response For GET TYPE , Post Type ,for specific User and Patch Request 
        public static List<UserProfileInformationResponse> UserProfileInformationResponse(DataTable dt)
        {
            List<UserProfileInformationResponse> userprofileInformationlist = new List<Models.UserProfileInformationResponse>();
            userprofileInformationlist.Clear();
            try
            {
            }
            catch
            {
            }
           return userprofileInformationlist;
        }
        #endregion

        #endregion

        #region Driver Profile Responses

        #region Driver Response For Get TYPE , Get type for Specific Drivers and Patch Request and Post Request also  

        public static List<DriverProfileInformationResponse> DriverProfileResponse(DataTable dt)
        {
            return null;
        }
        #endregion


        #region will delete if not needed after Having Procedure
        #region Driver Details for Specific Drivers

        public static List<DriverProfileInformationResponse> DriverProfileForSpecificDriverResponse(DataTable dt)
        {
            return null;
        }
        #endregion


        #region Driver Profile Response For Post  TYPE
        public static List<DriverProfileInformationResponse> DriverProfilePostTypeResponse(DataTable dt)
        {
            return null;
        }



        #endregion

        #endregion




        #endregion
        
        
        #region Profile Configuration

        #region Profile Configuration Get Type
        public static List<ProfileConfigurationResponse> ProfileConfigurationGet(DataTable dt)
        {
            return null;
        }
        #endregion

        #region Profile Configuration Patch Type
        public static List<ProfileConfigurationResponse> ProfileConfigurationPatch(DataTable dt)
        {
            return null;
        }
        #endregion

        #endregion
    }
}
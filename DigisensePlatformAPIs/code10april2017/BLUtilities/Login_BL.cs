using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.BLUtilities
{
    public class Login_BL
    {
        public static LoginResponse LoginResponse(string token)
        {
            LoginResponse clsLoginResponse = null;

            try
            {
                string[] strserviceAvailable = new string[0];
                clsLoginResponse = new LoginResponse();

                clsLoginResponse.jwt = token;
                clsLoginResponse.serviceId = "";
                clsLoginResponse.serviceAvailable = strserviceAvailable;

                return clsLoginResponse;
            }
            catch (Exception ex)
            {
                return clsLoginResponse;
            }
        }
    }
}
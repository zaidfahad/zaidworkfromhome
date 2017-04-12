using DigisensePlatformAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.BLUtilities
{
    public class Common_BL
    {
        public static Response Response(string messages)
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

        public static DefaultResponse DefaultResponse(int code,string messages)
        {
            DefaultResponse clsResponse = null;
            try
            {
                clsResponse = new DefaultResponse();
                clsResponse.code = code;
                clsResponse.message = messages;
              
                return clsResponse;
            }
            catch (Exception ex)
            {
                return clsResponse;
            }
        }
    }
}
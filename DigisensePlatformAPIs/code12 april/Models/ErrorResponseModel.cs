using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.JsonResponseModel
{
    public class ErrorResponseModel
    {
        public string code { get; set; }
        public string description { get; set; }
        public Dictionary<string, string> messages = new Dictionary<string, string>();

    }
}
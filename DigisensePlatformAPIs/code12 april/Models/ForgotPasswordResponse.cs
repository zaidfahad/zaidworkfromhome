using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class ForgotPasswordResponse
    {
        public string code { get; set; }
        public string description { get; set; }
        public string message { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class Response
    {
        public string Message { get; set; }
    }
    public class DefaultResponse
    {
        public int code { get; set; }
        public string message { get; set; }

    }
}
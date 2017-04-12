using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class LoginResponse
    {

        public string jwt { get; set; }
        public string serviceId { get; set; }
        public string[] serviceAvailable { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class UserProfileInformationResponse
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string contactNumber { get; set; }
        public string address { get; set; }
        public string idProof { get; set; }
        public string fileUrl { get; set; }
        public string email { get; set; }
    }
}
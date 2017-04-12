using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class UserResponse
    {

        public AttributeInfo id { get; set; }
        public AttributeInfo firstName { get; set; }
        public AttributeInfo lastName { get; set; }
        public AttributeInfo contactNumber { get; set; }
        public AttributeInfo address { get; set; }
        public AttributeInfo idProof { get; set; }
        public AttributeInfo fileUrl { get; set; }
        public AttributeInfo email { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class DealersModel
    {
        public string code { get; set; }
        public string  description { get; set; }
        public string dealerid { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string contactnumber { get; set; }
        public List<Spares> spares = new List<Spares>();
    }

    public class Spares
    {
        public string id { get; set; }
        public string sparesname { get; set; }
        public string details { get; set; }
        public string available { get; set; }
        public string description { get; set; }
    }
}
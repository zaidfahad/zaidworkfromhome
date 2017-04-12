using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    #region    Driver Response
    public class DriverResponse
    {
        public AttributeInfo id { get; set; }
        public AttributeInfo firstName { get; set; }
        public AttributeInfo lastName { get; set; }
        public AttributeInfo contactNumber { get; set; }
        public AttributeInfo address { get; set; }
      //  public AttributeInfoidProof idProof { get; set; }
        public AttributeInfo fileUrl { get; set; }
        public AttributeInfo email { get; set; }
        public AttributeInfo idProofTypeId { get; set; }

        public AttributeInfo idProofNumber { get; set; }
        public AttributeInfo benchmarkFE { get; set; }
        public AttributeInfo benchmarkDistance { get; set; }
        public AttributeInfo ranking { get; set; }
        public string[] assignedVehicles { get; set; }
    }
    #endregion

    public class AttributeInfo
    {
        public string value { get; set; }
        public string type { get; set; }
        public Boolean editable { get; set; }
    }

    public class AttributeInfoidProof
    {
        public byte[] value { get; set; }
        public string type { get; set; }
        public Boolean editable { get; set; }
    }

    public class AttributeInfoAssignedVehicles
    {
        public string[] value { get; set; }
       // public List<string> value { get; set; }
        public string type { get; set; }
        public Boolean editable { get; set; }
    }
}
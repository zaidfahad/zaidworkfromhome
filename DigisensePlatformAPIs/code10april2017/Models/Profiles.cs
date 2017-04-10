using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    #region ProfilePost  api/Profile
    public class Profiles
    {
        [Required]
        public string id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public int contactNumber { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string idProof { get; set; }
        [Required]
        public string file { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string email { get; set; }

    }

    #endregion
    public class ProfileInforamtion
    {
        [Required]
        public string field { get; set; }
        [Required]
        public string value { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public bool? editable { get; set; }
    }

    public class DriverProfileInformation
    {
        public DriverProfileInformation()
        {
            assignedVehicles = new List<AssignedVehicle>();
        }
        [Required]
        public string id { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public int contactNumber { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string idProof { get; set; }
        [Required]
        public string file { get; set; }
        [Required]
        public string email { get; set; }

        [Required]
        public string benchmarkFE { get; set; }

        [Required]
        public string benchmarkDistance { get; set; }

        [Required]
        public string ranking { get; set; }
        [Required]
        public List<AssignedVehicle> assignedVehicles { get; set; }

    }

    public class AssignedVehicle
    {
        public string vehicleRegNo { get; set; }
    }

}

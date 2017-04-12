using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class RequesCreateDriverProfilet
    {
        [Required]
        public string id { get; set; }

        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        public string contactNumber { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string  idProof { get; set; }
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
        public List<string> assignedVehicles { get; set; }

    }
}
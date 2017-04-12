using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class User
    {
        [Required]
        public string id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Please enter correct firstname")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Please enter correct firstname")]
        public string firstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Please enter lastname")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Please enter correct lastname")]
        public string lastName { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Please enter address")]
        public string address { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please enter correct contact number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter correct contact number")]
        public string contactNumber { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please enter correct email address")]
        public string email { get; set; }
     
   
        public string fileUrl { get; set; }
     
        public string idProof { get; set; }
    }

    public class UserUpdate
    {

        [StringLength(30, MinimumLength = 1, ErrorMessage = "Please enter correct firstname")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Please enter correct firstname")]
        public string firstName { get; set; }

        [StringLength(30, MinimumLength = 1, ErrorMessage = "Please enter correct lastname")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Please enter correct lastname")]
        public string lastName { get; set; }

        [StringLength(500, MinimumLength = 1, ErrorMessage = "Please enter address")]
        public string address { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please enter correct contact number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter correct contact number")]
        public string contactNumber { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please enter correct email address")]
        public string email { get; set; }

 
    }
}
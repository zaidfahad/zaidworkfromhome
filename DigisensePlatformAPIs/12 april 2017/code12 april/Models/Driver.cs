using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    #region Driver Details
    public class Driver
    {
        //[Required]
        //public string id { get; set; }
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

        [Required(ErrorMessage = "Please enter email address")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please enter correct email address")]
         public string email { get; set; }

         [JsonProperty(PropertyName = "idproof")]
       // public byte[] idProof { get; set; }
         [Required]
        
         private string _idProof;
         public string    idProof
         {
           

             get
             {
                 
                 return _idProof;
             }
             set
             {
                 //String s = Convert.ToBase64String(idProof);
                // return Convert.FromBase64String(s);
                 _idProof = value;

             }
         }

        [Required]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Please enter correct idprooftypeid")]
        [RegularExpression(@"^[0-6]+$", ErrorMessage = "Please enter correct idprooftypeid")]
        public string idprooftypeid { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Please enter correct idproofnumber")]
        public string idproofnumber { get; set; }
        
        public string idproofpath { get; set; }
        [Required]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Please enter correct benchmarkFE")]
        public string benchmarkFE { get; set; }
        [Required]
        [StringLength(7, MinimumLength = 1, ErrorMessage = "Please enter correct benchmarkDistance")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter correct benchmarkDistance")]
        [JsonProperty(PropertyName = "benchmarkDistance")]
        public string benchmarkDistance { get; set; }
    }
    public class DriverUpdate
    {
        
        public string id { get; set; }

        [StringLength(30, MinimumLength = 1, ErrorMessage = "Please enter correct firstname")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Please enter correct firstname")]
        public string firstName { get; set; }

        [StringLength(30, MinimumLength = 1, ErrorMessage = "Please enter lastname")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Please enter correct lastname")]
        public string lastName { get; set; }

        [StringLength(500, MinimumLength = 1, ErrorMessage = "Please enter address")]
        public string address { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please enter correct mobile number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter correct mobile number")]
        public string contactNumber { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please enter correct email address")]
        public string email { get; set; }

        public byte[] idProof { get; set; }

        [StringLength(1, MinimumLength = 1, ErrorMessage = "Please enter correct idprooftypeid")]
        [RegularExpression(@"^[0-6]+$", ErrorMessage = "Please enter correct idprooftypeid")]
        public string idprooftypeid { get; set; }

        [StringLength(30, MinimumLength = 1, ErrorMessage = "Please enter correct idproofnumber")]
        public string idproofnumber { get; set; }
       
        public string idproofpath { get; set; }

        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Please enter correct benchmarkFE")]
        public string benchmarkFE { get; set; }

        [StringLength(7, MinimumLength = 1, ErrorMessage = "Please enter correct benchmarkDistance")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter correct benchmarkDistance")]
        public string benchmarkDistance { get; set; }
    } 
    #endregion
     
}
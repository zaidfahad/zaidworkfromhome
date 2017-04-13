using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigisensePlatformAPIs.Models
{
    public class Login
    {
        [Required]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Please enter correct username")]
        public string username { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Please enter correct password")]
        public string password { get; set; }
        [Required]
        public Boolean remember_me { get; set; }

        public string token { get; set; }
    }

    public class ForgotPassword
    {
        [Required]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Please enter correct username")]
        public string username { get; set; }
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter correct phone number")]
        public string phonenumber { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please enter correct email address")]
        public string email { get; set; }
    }

    public class ResetPassword
    {
        [Required]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Please enter correct username")]
        public string username { get; set; }
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter correct phone number")]
        public string phonenumber { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please enter correct email address")]
        public string email { get; set; }

        public string otp { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Password should not be more than 15 chars.")]
        public string newpassword { get; set; }
    }

    public class ChangePassword
    {
        [Required]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Please enter correct username")]
        public string username { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please enter correct phone number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter correct phone number")]
        public string phonenumber { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please enter correct email address")]
        public string email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Please enter correct password")]
        public string oldpassword { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Password should not be more than 15 chars.")]
        public string newpassword { get; set; }
    }

   
}
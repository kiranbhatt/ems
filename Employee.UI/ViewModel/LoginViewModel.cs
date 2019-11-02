using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee.UI.ViewModel
{
    public class LoginViewModel
    {
        [Display(Name = "Email address:")]
        [Required(ErrorMessage = "Enter your Email")]
        [EmailAddress(ErrorMessage = "Enter valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your Password")]
        [Display(Name = "Password:")]
        public string Password { get; set; }
    }
}
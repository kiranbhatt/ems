using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Employee.UI.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter your Email")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your Email")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter your Email")]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string RepeatPassword { get; set; }
        [Required(ErrorMessage = "Enter your DateOfBirth")]

        //[DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string PrimaryPhone { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string SecondaryPhone { get; set; }
        [Required(ErrorMessage = "Enter Your Current State")]

        public string CurrentState { get; set; }
        [Required(ErrorMessage = "Enter Your Current City")]
        public string CurrentCity { get; set; }
        [Required(ErrorMessage = "Enter Your Current Address")]

        public string CurrentAddress { get; set; }

        public bool IsAddressSame { get; set; }
        [Required(ErrorMessage = "Enter your Permanent State")]
        public string PermanentState { get; set; }
        [Required(ErrorMessage = "Enter your Permanent City")]
        public string PermanentCity { get; set; }
        [Required(ErrorMessage = "Enter your Permanent Address")]
        public string PermanentAddress { get; set; }
        [Required(ErrorMessage = "Enter your AadhaarNumber")]
        [Display(Name = "Enter aadhaar number")]
        public long AadhaarNumber { get; set; }
       [Required(ErrorMessage ="Enter your Pan Card Number")]
       [RegularExpression(@"[A-Z]{5}\d{4}[A-Z]{1}", ErrorMessage = "* Invalid PAN Number")]
        public string PanCardNumber { get; set; }
        [Required(ErrorMessage = "Please select file.")]
        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        [Display(Name = "Upload aadhaar")]
        public HttpPostedFileBase AadhaarFile { get; set; }

        public string AadhaarFileName { get; set; }
        [Display(Name = "Upload PanCard")]
        public HttpPostedFileBase UploadPanCard { get; set; }
        public string PanCardFileName { get; set; }


    }
}
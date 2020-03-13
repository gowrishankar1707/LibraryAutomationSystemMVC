using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryAutomationSystem.Models
{
   
    public class UserModel
    {


        [Required(ErrorMessage = "Name is requrired")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Name should be in 5 to 25 Characters")]
        [RegularExpression("^[A-Z][a-z]*$", ErrorMessage = "first Letter of the Name should be in Capital letter")]
        [Display(Name = "Name")]
        public string memberName { get; set; }


        [Required(ErrorMessage = "UserName is required")]
        //[RegularExpression(@"(\D)",ErrorMessage ="User Name should not contains Space")]
        [Display(Name = "UserName")]
        public string memberUserName { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("password")]
        public string memberPassword { get; set; }


        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date of Birth")]
        public DateTime memberDOB { get; set; }


        [Required(ErrorMessage = "Date of Joining is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date of Joining")]
        public DateTime memberDOJ { get; set; }


        [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender")]
        public string memberSex { get; set; }


        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression("^[6-9][0-9]{9}$")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string memberPhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E mail")]
        public string e_Mail { get; set; }


        [Required(ErrorMessage = "Address is required")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Address")]
        public string memberAddress { get; set; }

      public string role { get; set; }



    }
}
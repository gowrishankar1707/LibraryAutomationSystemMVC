using System;
using System.ComponentModel.DataAnnotations;
namespace LibraryAutomationSystem.Models
{

  
    public enum Role
    {
        user,
        admin,
    }
    

    public class UserModel
    {


        [Required(ErrorMessage = "Name is requrired")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Name should be in 5 to 25 Characters")]
        [RegularExpression("^[A-Z][a-z]*$", ErrorMessage = "first Letter of the Name should be in Capital letter")]
        [Display(Name = "Name")]
        public string MemberName { get; set; }


        [Required(ErrorMessage = "UserName is required")]
        //[RegularExpression(@"(\D)",ErrorMessage ="User Name should not contains Space")]
        [Display(Name = "UserName")]
        public string MemberUserName { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string MemberPassword { get; set; }


        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date of Birth")]
        public DateTime MemberDOB { get; set; }


        [Required(ErrorMessage = "Date of Joining is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date of Joining")]
        public DateTime MemberDOJ { get; set; }


        [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender")]
        public string MemberSex { get; set; }


        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression("^[6-9][0-9]{9}$")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string MemberPhoneNumber { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E mail")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Address is required")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Address")]
        public string MemberAddress { get; set; }

        public Role Role { get; set; }

        public int BookRequest { get; set; }



    }
}
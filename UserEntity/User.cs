using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomationSystem.Entity
{
    public class User
    {
        [Required(ErrorMessage = "Name is requrired")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Name should be in 5 to 25 Characters")]
        [RegularExpression("^[A-Z][a-z]*$", ErrorMessage = "first Letter of the Name should be in Capital letter")]
        public string memberName { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        //[RegularExpression(@"(\D)",ErrorMessage ="User Name should not contains Space")]
        public string memberUserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Key]
        [DataType(DataType.Password)]
        public string memberPassword { get; set; }
        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.DateTime)]
        public DateTime memberDOB { get; set; }
        [Required(ErrorMessage = "Date of Joining is required")]
        [DataType(DataType.DateTime)]
        public DateTime memberDOJ { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string memberSex { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        public string memberPhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        //[DataType(DataType.EmailAddress)]
        public string e_Mail { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [DataType(DataType.MultilineText)]
        public string memberAddress { get; set; }
    }


    //public User(string memberName, string memberUserName, string memberPassword, DateTime memberDOB, DateTime memberDOJ, string memberSex, string memberPhoneNumber, string e_Mail, string memberAddress)
    //{

    //    this.memberName = memberName;
    //    this.memberUserName = memberUserName;
    //    this.memberPassword = memberPassword;
    //    this.memberDOB = memberDOB;
    //    this.memberDOJ = memberDOJ;
    //    this.memberSex = memberSex;
    //    this.memberPhoneNumber = memberPhoneNumber;
    //    this.e_Mail = e_Mail;
    //    this.memberAddress = memberAddress;
    //}
    //public User(string memberUserName, string memberPassword)
    //{
    //    this.memberUserName = memberUserName;
    //    this.memberPassword = memberPassword;
    //}
    //public User(string memberName, string memberUserName, DateTime memberDOB, DateTime memberDOJ, string memberSex, string memberPhoneNumber, string e_Mail, string memberAddress)
    //{

    //    this.memberName = memberName;
    //    this.memberUserName = memberUserName;
    //    this.memberDOB = memberDOB;
    //    this.memberDOJ = memberDOJ;
    //    this.memberSex = memberSex;
    //    this.memberPhoneNumber = memberPhoneNumber;
    //    this.e_Mail = e_Mail;
    //    this.memberAddress = memberAddress;
    //}

}

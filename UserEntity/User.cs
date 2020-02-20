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
        [Required]
        public string memberName { get; set; }
        [Required]
        public string memberUserName { get; set; }
        [Required]
        public string memberPassword { get; set; }
        [Required]
        public DateTime memberDOB { get; set; }
        [Required]
        public DateTime memberDOJ { get; set; }
        [Required]
        public string memberSex { get; set; }
        [Required]
        public string memberPhoneNumber { get; set; }
        [Required]
        public string e_Mail { get; set; }
        [Required]
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

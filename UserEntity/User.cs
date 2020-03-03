using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomationSystem.Entity
{
  
    public class User
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("Name")]
        [MaxLength(30)]
        public string memberName { get; set; }
        [Required]
        [Column("UserName")]
        [Index(IsUnique =true)]
        [MaxLength(25)]
        public string memberUserName { get; set; }
        [Required]
        [Column("Password")]
        [MaxLength(25)]
        public string memberPassword { get; set; }
        [Required]
        [Column("DOB")]
        public DateTime memberDOB { get; set; }
        [Required]
        [Column("DOJ")]
        public DateTime memberDOJ { get; set; }
        [Required]
        [Column("Gender")]
        public string memberSex { get; set; }
        [Required]
        [Column("PhoneNumber")]
        [Index(IsUnique =true)]
        
        public long memberPhoneNumber { get; set; }
        [Required]
        [Column("Email")]
        [Index(IsUnique =true)]
        [MaxLength(250)]
        public string e_Mail { get; set; }
        [Required]
        [Column("Address")]
        [MaxLength(50)]
        public string memberAddress { get; set; }
        [Column("Role")]
        public string role { get; set; }

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

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
        [Required]
        public string role { get; set; }
        [Required]
        [Range(0,5)]
        public byte BookRequest { get; set; }

    }

}

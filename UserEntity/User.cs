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
        public string MemberName { get; set; }
        [Required]
        [Column("UserName")]
        [Index(IsUnique =true)]
        [MaxLength(25)]
        public string MemberUserName { get; set; }
        [Required]
        [Column("Password")]
        [MaxLength(25)]
        public string MemberPassword { get; set; }
        [Required]
        [Column("DOB")]
        public DateTime MemberDOB { get; set; }
        [Required]
        [Column("DOJ")]
        public DateTime MemberDOJ { get; set; }
        [Required]
        [Column("Gender")]
        public string MemberSex { get; set; }
        [Required]
        [Column("PhoneNumber")]
        [Index(IsUnique = true)]
        [MaxLength(15)]
        public string MemberPhoneNumber { get; set; }
        [Required]
        [Column("Email")]
        [Index(IsUnique =true)]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required]
        [Column("Address")]
        [MaxLength(50)]
        public string MemberAddress { get; set; }
        [Column("Role")]
        [Required]
        public string Role { get; set; }
        [Required]
        [Range(0,5)]
        public byte BookRequest { get; set; }

    }

}

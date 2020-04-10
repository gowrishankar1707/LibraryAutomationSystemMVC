using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryAutomationSystem.Entity;
using System.ComponentModel.DataAnnotations;

namespace LibraryAutomationSystem.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name ="UserName")]
        public string MemberUserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string MemberPassword { get; set; }
    }
}
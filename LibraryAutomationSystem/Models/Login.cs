using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryAutomationSystem.Entity;
using System.ComponentModel.DataAnnotations;

namespace LibraryAutomationSystem.Models
{
    public class Login
    {
        [Required]
        [Display(Name ="UserName")]
        public string userName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}
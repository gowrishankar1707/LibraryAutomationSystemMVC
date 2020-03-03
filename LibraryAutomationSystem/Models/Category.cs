using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryAutomationSystem.Models
{
    public class Category
    {
        [Required(ErrorMessage ="CategoryName is Required")]
        [MaxLength(50)]
        [Display(Name ="CategoryName")]
        [RegularExpression("^[A-Z][a-zA-Z]*",ErrorMessage ="Invalid format")]
        public string CategoryName { get; set; }
    }
}
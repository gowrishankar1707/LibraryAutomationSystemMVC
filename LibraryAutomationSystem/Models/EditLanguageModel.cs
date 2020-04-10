using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryAutomationSystem.Models
{
    public class EditLanguageModel
    {
        public int BookLanguageId { get; set; }
        [Required]
        [Display(Name ="Language Name")]
        [RegularExpression("^[A-Z][a-zA-Z]*$",ErrorMessage ="BookLanguage should be in correct format")]
        public string BookLanguageName { get; set; }


    }
}
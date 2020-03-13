using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace LibraryAutomationSystem.Models
{
    public class BookLanguage
    {
        public int BookLanguageId { get; set; }
        [Required]
        [RegularExpression("^[A-Z][A-Za-z]*$",ErrorMessage ="BookLanguage Name not in correct format")]
        public string BookLanguageName { get; set; }
    }
}
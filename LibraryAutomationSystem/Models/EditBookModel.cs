using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryAutomationSystem.Models
{
    public class EditBookModel
    {

        public int BookId { get; set; }
        [Required]
        public string BookTittle { get; set; }
        [Required(ErrorMessage ="Category should be select")]
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        [Required(ErrorMessage ="BookLanguage should be select")]
        public int BookLanguageId { get; set; }
        public BookLanguageModel BookLanguage { get; set; }
        [Required]
        [RegularExpression("^[A-Z][A-Za-z]*$",ErrorMessage ="Author Name first letter should be in capital letter and it does'nt accept numbers")]
        public string AuthorName { get; set; }
        [Required]
        [RegularExpression("[1-100]",ErrorMessage ="Book count should be in number")]
        public byte BookCount { get; set; }
        [Required]
        public BookType BookType { get; set; }
    }
}
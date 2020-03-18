using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryAutomationSystem.Models
{
    public class Edit_Book
    {
      
        public int BookId { get; set; }
        [Required]
        public string BookTittle { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BookLanguageId { get; set; }
        public BookLanguage BookLanguage { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]

        public byte BookCount { get; set; }
        [Required]
        public  BookType BookType { get; set; }
    }
}
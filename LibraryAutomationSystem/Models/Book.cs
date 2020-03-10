using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryAutomationSystem.Models
{
    public class Book
    {

        public int BookID { get; set; }
        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Book name should no be in correct format")]
        public string BookName { get; set; }
        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Author Name not be in correct format")]
        public string AuthorName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
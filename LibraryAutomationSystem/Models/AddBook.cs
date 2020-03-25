using System.ComponentModel.DataAnnotations;

namespace LibraryAutomationSystem.Models
{
    public enum BookType
    {
        Normal=1,
        Reference,
    }
    public class AddBook
    {

        [Required]

        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Book name should no be in correct format")]
        public string BookTittle { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BookLanguageId { get; set; }
        public BookLanguage BookLanguage { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Author Name not be in correct format")]
        public string AuthorName { get; set; }
        [Required]
        public byte BookCount { get; set; }
        [Required]
        public BookType BookType { get; set; }

    }
}
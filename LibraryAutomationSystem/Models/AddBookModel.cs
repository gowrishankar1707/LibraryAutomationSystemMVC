using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web;

namespace LibraryAutomationSystem.Models
{
    public enum BookType
    {
        Normal=1,
        Reference,
    }
    public class AddBookModel
    {

        [Required]

        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Book name should be in letters and First letter should be in cappital")]
        public string BookTittle { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        [Required]
        public int BookLanguageId { get; set; }
        public BookLanguageModel BookLanguage { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Author name should be in letters and First letter should be in cappital")]
        public string AuthorName { get; set; }
        [Required]
        [Range(0,20,ErrorMessage ="BookShould be within 0 to 20")]
        public byte BookCount { get; set; }
        [Required(ErrorMessage ="Booktype should not be select category")]
        public BookType BookType { get; set; }
        [DisplayName("Upload path")]
        public string BookImagePath { get; set; }
        

        public HttpPostedFileBase ImageFile { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LibraryAutomationSystem.Entity
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [MaxLength(50)]
        public string BookTittle { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BookLanguageId { get; set; }
        public BookLanguage BookLanguage { get; set; }
        [Required]
        [Index(IsUnique =true)]
        [MaxLength(25)]
        public string AuthorName { get; set; }
        [Required]
        [Range(0,20)]
        public byte BookCount { get; set; }
        [MaxLength(10)]
        public string BookType { get; set; }
        public string BookImagePath { get; set; }
       

    }
}

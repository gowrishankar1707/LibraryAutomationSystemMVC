using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LibraryAutomationSystem.Entity;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserEntity
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        [MaxLength(50)]
        public string BookName { get; set; }
        [Required]
        [MaxLength(50)]
        public string AuthorName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category category { get; set; }
    }
}

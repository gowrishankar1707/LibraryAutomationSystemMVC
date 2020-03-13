using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomationSystem.Entity
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [MaxLength(50)]
        public string BookName { get; set; }
        [Required]
        [MaxLength(50)]
        public string AuthorName { get; set; }
       

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAutomationSystem.Entity
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
     
        [Index(IsUnique =true)]
        [MaxLength(50)]
        [Required]
        public string CategoryName { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAutomationSystem.Entity
{
    public class Category
    {
        [Key]
        [Column("CategoryId")]
        public int CategoryId { get; set; }
     
        [Index(IsUnique =true)]
        [MaxLength(50)]
        public string CategoryName { get; set; }
    }
}

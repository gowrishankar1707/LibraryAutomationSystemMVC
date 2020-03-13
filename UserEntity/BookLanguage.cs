using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomationSystem.Entity
{
    public class BookLanguage
    {
        [Key]
        [Column("Language_Id")]
        public int BookLanguageId { get; set; }
        [Required]
        [MaxLength(15)]
        [Index(IsUnique =true)]
        [Column("Language_Name")]
        public string BookLanguageName { get; set; }


    }
}

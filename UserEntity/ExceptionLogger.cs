using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomationSystem.Entity
{
    public class ExceptionLogger
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string ExceptionMessage { get; set; }
        [Required]
        public string ExceptionStackTrack { get; set; }
        [Required]
        public string ControllerName { get; set; }
        [Required]
        public string ActionName { get; set; }
        [Required]
        public DateTime ExceptionLogTime { get; set; }
    }
}

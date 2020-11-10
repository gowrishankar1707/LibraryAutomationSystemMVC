using LibraryAutomationSystem.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserEntity
{
   public  class BookOrder
    {
        [Key]
        public int BookOrderId { get; set; }
  
        public int Id { get; set; }
        public User User { get; set; }//User Id FK
        public int BookId { get; set; }
        public Book Book { get; set; }//Book Id FK
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string BookTittle { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string AuthorName { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string ImagePath { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public Nullable< DateTime> RequestedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public Nullable<DateTime> BookReceivedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public Nullable<DateTime> ExpectedReturnDate { get; set; }
        [Column(TypeName = "datetime2")]
        public Nullable<DateTime> ReturnDate { get; set; }

    }
}

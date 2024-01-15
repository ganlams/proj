using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proj.Models
{
    public class Borrowing
    {
        [Key]
        public int BorrowingId { get; set; }

        [Required]
        public DateTime BorrowDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        // Relationship with Member
        public int MemberId { get; set; }
        public Member Member { get; set; }

        // Relationship with Book
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
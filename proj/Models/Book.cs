using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proj.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public int ISBN { get; set; }

        public string Availability { get; set; }


        // Relationship with Librarian
        public int LibrarianId { get; set; }
        public Librarian Librarian { get; set; }

        // Relationship with Borrowing
        public ICollection<Borrowing> Borrowings { get; set; }
    }
}
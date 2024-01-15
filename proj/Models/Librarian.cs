using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proj.Models
{
    public class Librarian 
    {
        [Key]
        public int LibrarianId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Contact Details")]

        public string ContactDetails { get; set; }

        public string Email { get; set; }

        // Relationship with Book
        public ICollection<Book> Books { get; set; }
    }
}
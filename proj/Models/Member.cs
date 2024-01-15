using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proj.Models
{
    public class Member
    {
        [Key]
        [Display(Name = "Member ID")]
        public int MemberId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Contact Details")]
        public string ContactDetails { get; set; }

        // Other properties for Member information

        // Relationship with Borrowing
        public ICollection<Borrowing> Borrowings { get; set; }

    }
}
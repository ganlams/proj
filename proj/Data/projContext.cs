using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace proj.Data
{
    public class projContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public projContext() : base("name=projContext")
        {
        }

        public System.Data.Entity.DbSet<proj.Models.Librarian> Librarians { get; set; }

        public System.Data.Entity.DbSet<proj.Models.Borrowing> Borrowings { get; set; }

        public System.Data.Entity.DbSet<proj.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<proj.Models.Member> Members { get; set; }
    }
}

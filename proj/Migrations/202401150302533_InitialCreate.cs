namespace proj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        ISBN = c.Int(nullable: false),
                        Availability = c.String(),
                        LibrarianId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Librarians", t => t.LibrarianId, cascadeDelete: true)
                .Index(t => t.LibrarianId);
            
            CreateTable(
                "dbo.Borrowings",
                c => new
                    {
                        BorrowingId = c.Int(nullable: false, identity: true),
                        BorrowDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(),
                        MemberId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BorrowingId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ContactDetails = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Librarians",
                c => new
                    {
                        LibrarianId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ContactDetails = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.LibrarianId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "LibrarianId", "dbo.Librarians");
            DropForeignKey("dbo.Borrowings", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Borrowings", "BookId", "dbo.Books");
            DropIndex("dbo.Borrowings", new[] { "BookId" });
            DropIndex("dbo.Borrowings", new[] { "MemberId" });
            DropIndex("dbo.Books", new[] { "LibrarianId" });
            DropTable("dbo.Librarians");
            DropTable("dbo.Members");
            DropTable("dbo.Borrowings");
            DropTable("dbo.Books");
        }
    }
}

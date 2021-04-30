namespace Audiobooks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Book_Add_Customer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Books", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Customer_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Genres", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Readers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Authors", "ApplicationUser_Id");
            CreateIndex("dbo.Books", "Customer_Id");
            CreateIndex("dbo.Genres", "ApplicationUser_Id");
            CreateIndex("dbo.Readers", "ApplicationUser_Id");
            AddForeignKey("dbo.Authors", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Books", "Customer_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Genres", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Readers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Readers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Genres", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Books", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Authors", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Readers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Genres", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Books", new[] { "Customer_Id" });
            DropIndex("dbo.Authors", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.Readers", "ApplicationUser_Id");
            DropColumn("dbo.Genres", "ApplicationUser_Id");
            DropColumn("dbo.Books", "Customer_Id");
            DropColumn("dbo.Books", "CustomerId");
            DropColumn("dbo.Authors", "ApplicationUser_Id");
        }
    }
}

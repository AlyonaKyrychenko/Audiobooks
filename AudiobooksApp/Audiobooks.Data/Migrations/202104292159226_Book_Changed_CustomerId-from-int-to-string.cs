namespace Audiobooks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Book_Changed_CustomerIdfrominttostring : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Books", new[] { "Customer_Id" });
            DropColumn("dbo.Books", "CustomerId");
            RenameColumn(table: "dbo.Books", name: "Customer_Id", newName: "CustomerId");
            AlterColumn("dbo.Books", "CustomerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Books", "CustomerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Books", new[] { "CustomerId" });
            AlterColumn("dbo.Books", "CustomerId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Books", name: "CustomerId", newName: "Customer_Id");
            AddColumn("dbo.Books", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "Customer_Id");
        }
    }
}

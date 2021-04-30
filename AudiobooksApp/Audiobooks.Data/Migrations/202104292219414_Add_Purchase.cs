namespace Audiobooks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Purchase : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Books", name: "CustomerId", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Books", name: "IX_CustomerId", newName: "IX_ApplicationUser_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Books", name: "IX_ApplicationUser_Id", newName: "IX_CustomerId");
            RenameColumn(table: "dbo.Books", name: "ApplicationUser_Id", newName: "CustomerId");
        }
    }
}

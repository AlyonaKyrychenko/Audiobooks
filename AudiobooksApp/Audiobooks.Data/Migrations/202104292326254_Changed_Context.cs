namespace Audiobooks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changed_Context : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.String(),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUserPurchases",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Purchase_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Purchase_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.Purchase_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Purchase_Id);
            
            AddColumn("dbo.Books", "Purchase_Id", c => c.Int());
            CreateIndex("dbo.Books", "Purchase_Id");
            AddForeignKey("dbo.Books", "Purchase_Id", "dbo.Purchases", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserPurchases", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.ApplicationUserPurchases", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Books", "Purchase_Id", "dbo.Purchases");
            DropIndex("dbo.ApplicationUserPurchases", new[] { "Purchase_Id" });
            DropIndex("dbo.ApplicationUserPurchases", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Books", new[] { "Purchase_Id" });
            DropColumn("dbo.Books", "Purchase_Id");
            DropTable("dbo.ApplicationUserPurchases");
            DropTable("dbo.Purchases");
        }
    }
}

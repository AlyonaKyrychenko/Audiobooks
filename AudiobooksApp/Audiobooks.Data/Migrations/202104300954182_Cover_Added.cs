namespace Audiobooks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cover_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilePath = c.String(),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            AddColumn("dbo.Books", "CoverId", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Cover");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Cover", c => c.String());
            DropForeignKey("dbo.Covers", "BookId", "dbo.Books");
            DropIndex("dbo.Covers", new[] { "BookId" });
            DropColumn("dbo.Books", "CoverId");
            DropTable("dbo.Covers");
        }
    }
}

namespace Audiobooks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Archive_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Archives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilePath = c.String(),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            AddColumn("dbo.Books", "ArchivePath", c => c.String());
            AddColumn("dbo.Books", "ArchiveId", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "ArchivePath", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Archives", "BookId", "dbo.Books");
            DropIndex("dbo.Archives", new[] { "BookId" });
            DropColumn("dbo.Purchases", "ArchivePath");
            DropColumn("dbo.Books", "ArchiveId");
            DropColumn("dbo.Books", "ArchivePath");
            DropTable("dbo.Archives");
        }
    }
}

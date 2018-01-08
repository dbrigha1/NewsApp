namespace NewsAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        Author_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Authors", t => t.Author_ID)
                .Index(t => t.Author_ID);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Article_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Articles", t => t.Article_ID)
                .Index(t => t.Article_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "Article_ID", "dbo.Articles");
            DropForeignKey("dbo.Articles", "Author_ID", "dbo.Authors");
            DropIndex("dbo.Topics", new[] { "Article_ID" });
            DropIndex("dbo.Articles", new[] { "Author_ID" });
            DropTable("dbo.Topics");
            DropTable("dbo.Authors");
            DropTable("dbo.Articles");
        }
    }
}

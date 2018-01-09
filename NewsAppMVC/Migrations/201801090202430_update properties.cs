namespace NewsAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateproperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Topics", "Article_ID", "dbo.Articles");
            DropIndex("dbo.Topics", new[] { "Article_ID" });
            CreateTable(
                "dbo.TopicArticles",
                c => new
                    {
                        Topic_ID = c.Int(nullable: false),
                        Article_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Topic_ID, t.Article_ID })
                .ForeignKey("dbo.Topics", t => t.Topic_ID, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.Article_ID, cascadeDelete: true)
                .Index(t => t.Topic_ID)
                .Index(t => t.Article_ID);
            
            DropColumn("dbo.Topics", "Article_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Topics", "Article_ID", c => c.Int());
            DropForeignKey("dbo.TopicArticles", "Article_ID", "dbo.Articles");
            DropForeignKey("dbo.TopicArticles", "Topic_ID", "dbo.Topics");
            DropIndex("dbo.TopicArticles", new[] { "Article_ID" });
            DropIndex("dbo.TopicArticles", new[] { "Topic_ID" });
            DropTable("dbo.TopicArticles");
            CreateIndex("dbo.Topics", "Article_ID");
            AddForeignKey("dbo.Topics", "Article_ID", "dbo.Articles", "ID");
        }
    }
}

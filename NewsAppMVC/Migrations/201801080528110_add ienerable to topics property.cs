namespace NewsAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addienerabletotopicsproperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Topics", "Article_ID", "dbo.Articles");
            DropIndex("dbo.Topics", new[] { "Article_ID" });
            DropColumn("dbo.Topics", "Article_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Topics", "Article_ID", c => c.Int());
            CreateIndex("dbo.Topics", "Article_ID");
            AddForeignKey("dbo.Topics", "Article_ID", "dbo.Articles", "ID");
        }
    }
}

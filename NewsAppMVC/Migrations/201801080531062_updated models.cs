namespace NewsAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Topics", "Article_ID", c => c.Int());
            CreateIndex("dbo.Topics", "Article_ID");
            AddForeignKey("dbo.Topics", "Article_ID", "dbo.Articles", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "Article_ID", "dbo.Articles");
            DropIndex("dbo.Topics", new[] { "Article_ID" });
            DropColumn("dbo.Topics", "Article_ID");
        }
    }
}

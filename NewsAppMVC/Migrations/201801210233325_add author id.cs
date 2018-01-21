namespace NewsAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addauthorid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "Author_ID", "dbo.Authors");
            DropIndex("dbo.Articles", new[] { "Author_ID" });
            RenameColumn(table: "dbo.Articles", name: "Author_ID", newName: "AuthorID");
            AlterColumn("dbo.Articles", "AuthorID", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "AuthorID");
            AddForeignKey("dbo.Articles", "AuthorID", "dbo.Authors", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Articles", new[] { "AuthorID" });
            AlterColumn("dbo.Articles", "AuthorID", c => c.Int());
            RenameColumn(table: "dbo.Articles", name: "AuthorID", newName: "Author_ID");
            CreateIndex("dbo.Articles", "Author_ID");
            AddForeignKey("dbo.Articles", "Author_ID", "dbo.Authors", "ID");
        }
    }
}

namespace NewsAppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedDateCreatedfromTopicsclass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Topics", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Topics", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}

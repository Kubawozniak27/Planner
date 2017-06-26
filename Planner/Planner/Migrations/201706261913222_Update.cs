namespace Planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Events", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Events", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Events", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Events", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "CategoryId");
            AddForeignKey("dbo.Events", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Events", new[] { "CategoryId" });
            AlterColumn("dbo.Events", "CategoryId", c => c.Int());
            AlterColumn("dbo.Events", "Venue", c => c.String());
            AlterColumn("dbo.Events", "Name", c => c.String());
            RenameColumn(table: "dbo.Events", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Events", "Category_Id");
            AddForeignKey("dbo.Events", "Category_Id", "dbo.Categories", "Id");
        }
    }
}

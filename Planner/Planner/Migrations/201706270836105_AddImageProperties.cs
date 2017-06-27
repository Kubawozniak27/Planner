namespace Planner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Events", "ImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "ImageId");
            AddForeignKey("dbo.Events", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "ImageId", "dbo.Images");
            DropIndex("dbo.Events", new[] { "ImageId" });
            DropColumn("dbo.Events", "ImageId");
            DropTable("dbo.Images");
        }
    }
}

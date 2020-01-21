namespace MvcLabPractice.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelAdded1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodItemId = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        Qauntity = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodItems", t => t.FoodItemId, cascadeDelete: true)
                .Index(t => t.FoodItemId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        ContactNo = c.String(),
                        TypeId = c.String(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "Type_Id", "dbo.Types");
            DropForeignKey("dbo.Orders", "FoodItemId", "dbo.FoodItems");
            DropIndex("dbo.Members", new[] { "Type_Id" });
            DropIndex("dbo.Orders", new[] { "FoodItemId" });
            DropTable("dbo.Types");
            DropTable("dbo.Members");
            DropTable("dbo.Orders");
            DropTable("dbo.FoodItems");
        }
    }
}

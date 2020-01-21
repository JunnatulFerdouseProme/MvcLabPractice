namespace MvcLabPractice.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderModelAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "MemberItemId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Member_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Member_Id");
            AddForeignKey("dbo.Orders", "Member_Id", "dbo.Members", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Member_Id", "dbo.Members");
            DropIndex("dbo.Orders", new[] { "Member_Id" });
            DropColumn("dbo.Orders", "Member_Id");
            DropColumn("dbo.Orders", "MemberItemId");
        }
    }
}

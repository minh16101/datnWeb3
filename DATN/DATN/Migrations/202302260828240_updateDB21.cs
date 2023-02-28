namespace DATN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookingRooms", "OrderDetailId", "dbo.OrderDetails");
            DropIndex("dbo.BookingRooms", new[] { "OrderDetailId" });
            DropColumn("dbo.BookingRooms", "OrderDetailId");
            DropColumn("dbo.OrderDetails", "BookingRoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "BookingRoomId", c => c.Int(nullable: false));
            AddColumn("dbo.BookingRooms", "OrderDetailId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookingRooms", "OrderDetailId");
            AddForeignKey("dbo.BookingRooms", "OrderDetailId", "dbo.OrderDetails", "Id", cascadeDelete: true);
        }
    }
}

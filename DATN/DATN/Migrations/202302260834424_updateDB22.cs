namespace DATN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "BookingRoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "BookingRoomId");
            AddForeignKey("dbo.OrderDetails", "BookingRoomId", "dbo.BookingRooms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "BookingRoomId", "dbo.BookingRooms");
            DropIndex("dbo.OrderDetails", new[] { "BookingRoomId" });
            DropColumn("dbo.OrderDetails", "BookingRoomId");
        }
    }
}

namespace DATN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingRooms", "DayBookingRoom", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "BookingRoomId", c => c.Int(nullable: false));
            DropColumn("dbo.BookingRooms", "DayOfMonthBookingRoom");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingRooms", "DayOfMonthBookingRoom", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetails", "BookingRoomId");
            DropColumn("dbo.BookingRooms", "DayBookingRoom");
        }
    }
}

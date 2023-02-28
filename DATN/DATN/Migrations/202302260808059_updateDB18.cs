namespace DATN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookingRooms", "DayOfMonthBookingRoom", c => c.Int(nullable: false));
            DropColumn("dbo.BookingRooms", "DayBookingRoom");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingRooms", "DayBookingRoom", c => c.Int(nullable: false));
            DropColumn("dbo.BookingRooms", "DayOfMonthBookingRoom");
        }
    }
}

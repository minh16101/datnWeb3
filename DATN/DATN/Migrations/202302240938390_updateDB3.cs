namespace DATN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingHotels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameBookingHotel = c.String(nullable: false, maxLength: 150),
                        LikeBookingHotel = c.Int(nullable: false),
                        CityBookingHotel = c.String(),
                        AddressBookingHotel = c.String(),
                        NotiBookingHotel = c.String(),
                        QuanBookingHotel = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookingRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameBookingRoom = c.String(nullable: false, maxLength: 150),
                        PeopleBookingRoom = c.Int(nullable: false),
                        PriceBookingRoom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DayBookingRoom = c.Int(nullable: false),
                        MonthBookingRoom = c.Int(nullable: false),
                        YearBookingRoom = c.Int(nullable: false),
                        DuringBookingRoom = c.Int(nullable: false),
                        IsBookingRoom = c.Int(nullable: false),
                        IsUserBookingRoom = c.Int(nullable: false),
                        BookingHotel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookingHotels", t => t.BookingHotel_Id)
                .Index(t => t.BookingHotel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingRooms", "BookingHotel_Id", "dbo.BookingHotels");
            DropIndex("dbo.BookingRooms", new[] { "BookingHotel_Id" });
            DropTable("dbo.BookingRooms");
            DropTable("dbo.BookingHotels");
        }
    }
}

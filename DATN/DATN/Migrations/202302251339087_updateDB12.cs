namespace DATN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageHotels", "BookingHotel_Id", "dbo.BookingHotels");
            DropForeignKey("dbo.ImageRooms", "BookingRoom_Id", "dbo.BookingRooms");
            DropIndex("dbo.ImageRooms", new[] { "BookingRoom_Id" });
            DropIndex("dbo.ImageHotels", new[] { "BookingHotel_Id" });
            RenameColumn(table: "dbo.ImageHotels", name: "BookingHotel_Id", newName: "BookingHotelId");
            RenameColumn(table: "dbo.ImageRooms", name: "BookingRoom_Id", newName: "BookingRoomId");
            AlterColumn("dbo.ImageRooms", "BookingRoomId", c => c.Int(nullable: false));
            AlterColumn("dbo.ImageHotels", "BookingHotelId", c => c.Int(nullable: false));
            CreateIndex("dbo.ImageRooms", "BookingRoomId");
            CreateIndex("dbo.ImageHotels", "BookingHotelId");
            AddForeignKey("dbo.ImageHotels", "BookingHotelId", "dbo.BookingHotels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ImageRooms", "BookingRoomId", "dbo.BookingRooms", "Id", cascadeDelete: true);
            DropColumn("dbo.ImageRooms", "RoomId");
            DropColumn("dbo.ImageHotels", "HotelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageHotels", "HotelId", c => c.Int(nullable: false));
            AddColumn("dbo.ImageRooms", "RoomId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ImageRooms", "BookingRoomId", "dbo.BookingRooms");
            DropForeignKey("dbo.ImageHotels", "BookingHotelId", "dbo.BookingHotels");
            DropIndex("dbo.ImageHotels", new[] { "BookingHotelId" });
            DropIndex("dbo.ImageRooms", new[] { "BookingRoomId" });
            AlterColumn("dbo.ImageHotels", "BookingHotelId", c => c.Int());
            AlterColumn("dbo.ImageRooms", "BookingRoomId", c => c.Int());
            RenameColumn(table: "dbo.ImageRooms", name: "BookingRoomId", newName: "BookingRoom_Id");
            RenameColumn(table: "dbo.ImageHotels", name: "BookingHotelId", newName: "BookingHotel_Id");
            CreateIndex("dbo.ImageHotels", "BookingHotel_Id");
            CreateIndex("dbo.ImageRooms", "BookingRoom_Id");
            AddForeignKey("dbo.ImageRooms", "BookingRoom_Id", "dbo.BookingRooms", "Id");
            AddForeignKey("dbo.ImageHotels", "BookingHotel_Id", "dbo.BookingHotels", "Id");
        }
    }
}

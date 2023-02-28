namespace DATN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookingRooms", "BookingHotel_Id", "dbo.BookingHotels");
            DropForeignKey("dbo.BookingRooms", "OrderDetail_Id", "dbo.OrderDetails");
            DropIndex("dbo.BookingRooms", new[] { "BookingHotel_Id" });
            DropIndex("dbo.BookingRooms", new[] { "OrderDetail_Id" });
            RenameColumn(table: "dbo.BookingRooms", name: "BookingHotel_Id", newName: "BookingHotelId");
            RenameColumn(table: "dbo.BookingRooms", name: "OrderDetail_Id", newName: "OrderDetailId");
            AlterColumn("dbo.BookingRooms", "BookingHotelId", c => c.Int(nullable: false));
            AlterColumn("dbo.BookingRooms", "OrderDetailId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookingRooms", "BookingHotelId");
            CreateIndex("dbo.BookingRooms", "OrderDetailId");
            AddForeignKey("dbo.BookingRooms", "BookingHotelId", "dbo.BookingHotels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookingRooms", "OrderDetailId", "dbo.OrderDetails", "Id", cascadeDelete: true);
            DropColumn("dbo.BookingRooms", "HotelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookingRooms", "HotelId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BookingRooms", "OrderDetailId", "dbo.OrderDetails");
            DropForeignKey("dbo.BookingRooms", "BookingHotelId", "dbo.BookingHotels");
            DropIndex("dbo.BookingRooms", new[] { "OrderDetailId" });
            DropIndex("dbo.BookingRooms", new[] { "BookingHotelId" });
            AlterColumn("dbo.BookingRooms", "OrderDetailId", c => c.Int());
            AlterColumn("dbo.BookingRooms", "BookingHotelId", c => c.Int());
            RenameColumn(table: "dbo.BookingRooms", name: "OrderDetailId", newName: "OrderDetail_Id");
            RenameColumn(table: "dbo.BookingRooms", name: "BookingHotelId", newName: "BookingHotel_Id");
            CreateIndex("dbo.BookingRooms", "OrderDetail_Id");
            CreateIndex("dbo.BookingRooms", "BookingHotel_Id");
            AddForeignKey("dbo.BookingRooms", "OrderDetail_Id", "dbo.OrderDetails", "Id");
            AddForeignKey("dbo.BookingRooms", "BookingHotel_Id", "dbo.BookingHotels", "Id");
        }
    }
}

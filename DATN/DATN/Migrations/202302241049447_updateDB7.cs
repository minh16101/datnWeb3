namespace DATN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookingRooms", "Id", "dbo.OrderDetails");
            DropIndex("dbo.BookingRooms", new[] { "Id" });
            DropPrimaryKey("dbo.BookingRooms");
            CreateTable(
                "dbo.ImageRooms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        src = c.String(),
                        BookingRoom_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.BookingRooms", t => t.BookingRoom_Id)
                .Index(t => t.BookingRoom_Id);
            
            CreateTable(
                "dbo.ImageHotels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        HotelId = c.Int(nullable: false),
                        src = c.String(),
                        BookingHotel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.BookingHotels", t => t.BookingHotel_Id)
                .Index(t => t.BookingHotel_Id);
            
            AddColumn("dbo.BookingRooms", "HotelId", c => c.Int(nullable: false));
            AddColumn("dbo.BookingRooms", "OrderDetail_Id", c => c.Int());
            AddColumn("dbo.OrderDetails", "RoomId", c => c.Int(nullable: false));
            AlterColumn("dbo.BookingRooms", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.BookingRooms", "Id");
            CreateIndex("dbo.BookingRooms", "OrderDetail_Id");
            AddForeignKey("dbo.BookingRooms", "OrderDetail_Id", "dbo.OrderDetails", "Id");
            DropColumn("dbo.OrderDetails", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BookingRooms", "OrderDetail_Id", "dbo.OrderDetails");
            DropForeignKey("dbo.ImageHotels", "BookingHotel_Id", "dbo.BookingHotels");
            DropForeignKey("dbo.ImageRooms", "BookingRoom_Id", "dbo.BookingRooms");
            DropIndex("dbo.ImageHotels", new[] { "BookingHotel_Id" });
            DropIndex("dbo.ImageRooms", new[] { "BookingRoom_Id" });
            DropIndex("dbo.BookingRooms", new[] { "OrderDetail_Id" });
            DropPrimaryKey("dbo.BookingRooms");
            AlterColumn("dbo.BookingRooms", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetails", "RoomId");
            DropColumn("dbo.BookingRooms", "OrderDetail_Id");
            DropColumn("dbo.BookingRooms", "HotelId");
            DropTable("dbo.ImageHotels");
            DropTable("dbo.ImageRooms");
            AddPrimaryKey("dbo.BookingRooms", "Id");
            CreateIndex("dbo.BookingRooms", "Id");
            AddForeignKey("dbo.BookingRooms", "Id", "dbo.OrderDetails", "Id");
        }
    }
}

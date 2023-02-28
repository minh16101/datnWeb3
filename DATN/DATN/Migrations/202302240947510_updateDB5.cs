namespace DATN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB5 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BookingRooms");
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            AlterColumn("dbo.BookingRooms", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.BookingRooms", "Id");
            CreateIndex("dbo.BookingRooms", "Id");
            AddForeignKey("dbo.BookingRooms", "Id", "dbo.OrderDetails", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingRooms", "Id", "dbo.OrderDetails");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.BookingRooms", new[] { "Id" });
            DropPrimaryKey("dbo.BookingRooms");
            AlterColumn("dbo.BookingRooms", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.OrderDetails");
            AddPrimaryKey("dbo.BookingRooms", "Id");
        }
    }
}

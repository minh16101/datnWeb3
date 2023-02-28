namespace DATN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InformationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstNameInformationUser = c.String(nullable: false, maxLength: 150),
                        LastNameInformationUser = c.String(nullable: false, maxLength: 150),
                        NumberInformationUser = c.String(nullable: false, maxLength: 15),
                        AvatarInformationUser = c.String(nullable: false, maxLength: 200),
                        AddressInformationUser = c.String(nullable: false, maxLength: 200),
                        EmailInformationUser = c.String(nullable: false, maxLength: 100),
                        IsBookingInformationUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InformationUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Id", "dbo.InformationUsers");
            DropIndex("dbo.Orders", new[] { "Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.InformationUsers");
        }
    }
}

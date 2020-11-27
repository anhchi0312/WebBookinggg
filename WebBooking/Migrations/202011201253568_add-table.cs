namespace WebBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Address = c.String(),
                        Date = c.DateTime(nullable: false),
                        Note = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.DatGois",
                c => new
                    {
                        SoPhieu = c.Int(nullable: false, identity: true),
                        GoiId = c.Int(nullable: false),
                        GoiName = c.String(),
                        CustomerId = c.Int(nullable: false),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Note = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.SoPhieu)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DatGois", "CustomerId", "dbo.Customers");
            DropIndex("dbo.DatGois", new[] { "CustomerId" });
            DropTable("dbo.DatGois");
            DropTable("dbo.Customers");
        }
    }
}

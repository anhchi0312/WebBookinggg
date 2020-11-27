namespace WebBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetablekhachhang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Tel", c => c.String());
            AddColumn("dbo.Customers", "email", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "password", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "Date");
            DropColumn("dbo.Customers", "Note");
            DropColumn("dbo.Customers", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "State", c => c.String());
            AddColumn("dbo.Customers", "Note", c => c.String());
            AddColumn("dbo.Customers", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "password");
            DropColumn("dbo.Customers", "email");
            DropColumn("dbo.Customers", "Tel");
        }
    }
}

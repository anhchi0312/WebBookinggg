namespace WebBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NhanViens", "emailNV", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanViens", "emailNV", c => c.String());
        }
    }
}

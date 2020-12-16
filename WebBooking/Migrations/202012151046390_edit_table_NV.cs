namespace WebBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_table_NV : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanViens", "emailNV", c => c.String());
            AddColumn("dbo.NhanViens", "passwordNV", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanViens", "passwordNV");
            DropColumn("dbo.NhanViens", "emailNV");
        }
    }
}

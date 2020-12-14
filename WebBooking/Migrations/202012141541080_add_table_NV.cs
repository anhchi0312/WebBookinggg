namespace WebBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table_NV : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        IDNhanVien = c.Int(nullable: false, identity: true),
                        TenNhanVien = c.String(),
                        SDT = c.String(),
                    })
                .PrimaryKey(t => t.IDNhanVien);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NhanViens");
        }
    }
}

namespace WebBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gois",
                c => new
                    {
                        GoiId = c.Int(nullable: false, identity: true),
                        GoiName = c.String(),
                        Note = c.String(),
                        Img = c.String(),
                    })
                .PrimaryKey(t => t.GoiId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        imgUml = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.NewId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.News");
            DropTable("dbo.Gois");
        }
    }
}

namespace WebBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_table : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DatGois", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DatGois", "Name", c => c.String());
        }
    }
}

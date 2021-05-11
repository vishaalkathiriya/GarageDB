namespace GarageDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMOTTestDateAndTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MOTs", "TestDateAndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MOTs", "TestDateAndTime");
        }
    }
}

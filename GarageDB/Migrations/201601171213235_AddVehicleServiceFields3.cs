namespace GarageDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleServiceFields3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleServices", "ReplaceCoolant", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "ReplaceSparkPlugs", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleServices", "ReplaceSparkPlugs");
            DropColumn("dbo.VehicleServices", "ReplaceCoolant");
        }
    }
}

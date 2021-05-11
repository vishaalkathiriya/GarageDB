namespace GarageDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleServiceFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleServices", "DrainOilAndRefill", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "ReplaceOilFilter", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "ExcessiveOilLeakCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "TimingBeltCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "RadiatorConditionCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "CoolantCapSealCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "CoolantHoseCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "CoolingFanCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "FanAlternatorBeltCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "AuxiliaryDriveBeltCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "ReplaceAirFilter", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "SparkPlugReplacementMileageCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "AntifreezeCheckTopup", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "UndertrayCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "EngineComments", c => c.String());
            AddColumn("dbo.VehicleServices", "FuelCapSealCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "FuelLineVisualCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "ReplaceFuelFilter", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "FuelComments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleServices", "FuelComments");
            DropColumn("dbo.VehicleServices", "ReplaceFuelFilter");
            DropColumn("dbo.VehicleServices", "FuelLineVisualCheck");
            DropColumn("dbo.VehicleServices", "FuelCapSealCheck");
            DropColumn("dbo.VehicleServices", "EngineComments");
            DropColumn("dbo.VehicleServices", "UndertrayCheck");
            DropColumn("dbo.VehicleServices", "AntifreezeCheckTopup");
            DropColumn("dbo.VehicleServices", "SparkPlugReplacementMileageCheck");
            DropColumn("dbo.VehicleServices", "ReplaceAirFilter");
            DropColumn("dbo.VehicleServices", "AuxiliaryDriveBeltCheck");
            DropColumn("dbo.VehicleServices", "FanAlternatorBeltCheck");
            DropColumn("dbo.VehicleServices", "CoolingFanCheck");
            DropColumn("dbo.VehicleServices", "CoolantHoseCheck");
            DropColumn("dbo.VehicleServices", "CoolantCapSealCheck");
            DropColumn("dbo.VehicleServices", "RadiatorConditionCheck");
            DropColumn("dbo.VehicleServices", "TimingBeltCheck");
            DropColumn("dbo.VehicleServices", "ExcessiveOilLeakCheck");
            DropColumn("dbo.VehicleServices", "ReplaceOilFilter");
            DropColumn("dbo.VehicleServices", "DrainOilAndRefill");
        }
    }
}

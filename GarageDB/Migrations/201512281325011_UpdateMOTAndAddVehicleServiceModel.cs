namespace GarageDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMOTAndAddVehicleServiceModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleServices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VehicleId = c.Guid(nullable: false),
                        ServiceDateAndTime = c.DateTime(nullable: false),
                        ServiceType = c.Int(nullable: false),
                        AddedByUserId = c.String(maxLength: 128),
                        DeletedByUserId = c.String(maxLength: 128),
                        CompanyId = c.Guid(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MOTs", "BrakePerformance", c => c.Boolean());
            AddColumn("dbo.MOTs", "BrakePerformanceDefectComments", c => c.String());
            DropColumn("dbo.MOTs", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MOTs", "CustomerId", c => c.Guid(nullable: false));
            DropColumn("dbo.MOTs", "BrakePerformanceDefectComments");
            DropColumn("dbo.MOTs", "BrakePerformance");
            DropTable("dbo.VehicleServices");
        }
    }
}

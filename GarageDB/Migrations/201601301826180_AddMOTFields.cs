namespace GarageDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMOTFields : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                        Name = c.String(),
                        IsCustom = c.Boolean(nullable: false),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MOTs", "TestExpiryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MOTs", "PreviousMOTExpiryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MOTs", "FirstUseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MOTs", "PreviousSeatBeltCheckDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MOTs", "SeatBeltsInstallCheckNumber", c => c.Int(nullable: false));
            AddColumn("dbo.MOTs", "SeriouslyDamagedMarker", c => c.String());
            AddColumn("dbo.MOTs", "PreviousTestNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MOTs", "PreviousTestNumber");
            DropColumn("dbo.MOTs", "SeriouslyDamagedMarker");
            DropColumn("dbo.MOTs", "SeatBeltsInstallCheckNumber");
            DropColumn("dbo.MOTs", "PreviousSeatBeltCheckDate");
            DropColumn("dbo.MOTs", "FirstUseDate");
            DropColumn("dbo.MOTs", "PreviousMOTExpiryDate");
            DropColumn("dbo.MOTs", "TestExpiryDate");
            DropTable("dbo.Reports");
        }
    }
}

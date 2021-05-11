namespace GarageDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentUpdates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointmentStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Appointments", "AppointmentStatus", c => c.Int());
            AddColumn("dbo.Appointments", "WorkType", c => c.Int());
            AlterColumn("dbo.Appointments", "CustomerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Appointments", "StatusEnum");
            DropColumn("dbo.Appointments", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Type", c => c.Int());
            AddColumn("dbo.Appointments", "StatusEnum", c => c.Int());
            AlterColumn("dbo.Appointments", "CustomerId", c => c.Guid());
            DropColumn("dbo.Appointments", "WorkType");
            DropColumn("dbo.Appointments", "AppointmentStatus");
            DropTable("dbo.WorkTypes");
            DropTable("dbo.AppointmentStatus");
        }
    }
}

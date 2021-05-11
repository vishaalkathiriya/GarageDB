namespace GarageDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentStaffMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "StaffMember_Id", c => c.Guid());
            CreateIndex("dbo.Appointments", "StaffMember_Id");
            AddForeignKey("dbo.Appointments", "StaffMember_Id", "dbo.StaffMembers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "StaffMember_Id", "dbo.StaffMembers");
            DropIndex("dbo.Appointments", new[] { "StaffMember_Id" });
            DropColumn("dbo.Appointments", "StaffMember_Id");
        }
    }
}

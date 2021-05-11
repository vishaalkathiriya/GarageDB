namespace GarageDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStaffMembersAndRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StaffMembers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        GarageId = c.Guid(nullable: false),
                        AddedByUserId = c.String(maxLength: 128),
                        DeletedByUserId = c.String(maxLength: 128),
                        CompanyId = c.Guid(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StaffRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StaffRoleStaffMembers",
                c => new
                    {
                        StaffRole_Id = c.Int(nullable: false),
                        StaffMember_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.StaffRole_Id, t.StaffMember_Id })
                .ForeignKey("dbo.StaffRoles", t => t.StaffRole_Id, cascadeDelete: true)
                .ForeignKey("dbo.StaffMembers", t => t.StaffMember_Id, cascadeDelete: true)
                .Index(t => t.StaffRole_Id)
                .Index(t => t.StaffMember_Id);
            
            AlterColumn("dbo.AppointmentStatus", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.WorkTypes", "Name", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.AspNetUsers", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            DropForeignKey("dbo.StaffRoleStaffMembers", "StaffMember_Id", "dbo.StaffMembers");
            DropForeignKey("dbo.StaffRoleStaffMembers", "StaffRole_Id", "dbo.StaffRoles");
            DropIndex("dbo.StaffRoleStaffMembers", new[] { "StaffMember_Id" });
            DropIndex("dbo.StaffRoleStaffMembers", new[] { "StaffRole_Id" });
            AlterColumn("dbo.WorkTypes", "Name", c => c.String(maxLength: 20));
            AlterColumn("dbo.AppointmentStatus", "Name", c => c.String(maxLength: 20));
            DropTable("dbo.StaffRoleStaffMembers");
            DropTable("dbo.StaffRoles");
            DropTable("dbo.StaffMembers");
        }
    }
}

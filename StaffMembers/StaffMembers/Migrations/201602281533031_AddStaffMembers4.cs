namespace StaffMembers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStaffMembers4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetRoles", "StaffMember_Id", "dbo.StaffMembers");
            DropIndex("dbo.AspNetRoles", new[] { "StaffMember_Id" });
            CreateTable(
                "dbo.StaffRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StaffRoleStaffMembers",
                c => new
                    {
                        StaffRole_Id = c.Int(nullable: false),
                        StaffMember_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StaffRole_Id, t.StaffMember_Id })
                .ForeignKey("dbo.StaffRoles", t => t.StaffRole_Id, cascadeDelete: true)
                .ForeignKey("dbo.StaffMembers", t => t.StaffMember_Id, cascadeDelete: true)
                .Index(t => t.StaffRole_Id)
                .Index(t => t.StaffMember_Id);
            
            DropColumn("dbo.AspNetRoles", "StaffMember_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetRoles", "StaffMember_Id", c => c.Int());
            DropForeignKey("dbo.StaffRoleStaffMembers", "StaffMember_Id", "dbo.StaffMembers");
            DropForeignKey("dbo.StaffRoleStaffMembers", "StaffRole_Id", "dbo.StaffRoles");
            DropIndex("dbo.StaffRoleStaffMembers", new[] { "StaffMember_Id" });
            DropIndex("dbo.StaffRoleStaffMembers", new[] { "StaffRole_Id" });
            DropTable("dbo.StaffRoleStaffMembers");
            DropTable("dbo.StaffRoles");
            CreateIndex("dbo.AspNetRoles", "StaffMember_Id");
            AddForeignKey("dbo.AspNetRoles", "StaffMember_Id", "dbo.StaffMembers", "Id");
        }
    }
}

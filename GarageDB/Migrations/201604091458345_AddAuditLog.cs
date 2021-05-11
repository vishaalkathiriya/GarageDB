namespace GarageDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuditLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditLogEntries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AddedByUserId = c.String(maxLength: 128),
                        DeletedByUserId = c.String(maxLength: 128),
                        CompanyId = c.Guid(),
                        EntryType = c.Int(nullable: false),
                        AuditLogAction = c.Int(nullable: false),
                        EntryId = c.Guid(),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AuditLogEntries");
        }
    }
}

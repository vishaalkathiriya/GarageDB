namespace GarageDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddErrorCodes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ErrorCodes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(maxLength: 5),
                        Description = c.String(),
                        Solution = c.String(),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true, name: "IX_ErrorCode");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ErrorCodes", "IX_ErrorCode");
            DropTable("dbo.ErrorCodes");
        }
    }
}

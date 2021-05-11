namespace GarageDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMOTPassFail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MOTs", "Pass", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MOTs", "Pass");
        }
    }
}

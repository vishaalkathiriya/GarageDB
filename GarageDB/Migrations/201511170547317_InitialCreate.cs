namespace GarageDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Notes = c.String(),
                        ReminderSent = c.DateTime(),
                        Arrived = c.DateTime(),
                        StatusEnum = c.Int(),
                        Type = c.Int(),
                        StationName = c.String(),
                        AddedByUserId = c.String(maxLength: 128),
                        DeletedByUserId = c.String(maxLength: 128),
                        CompanyId = c.Guid(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        Filename = c.String(nullable: false),
                        Comment = c.String(),
                        AddedByUserId = c.String(maxLength: 128),
                        DeletedByUserId = c.String(maxLength: 128),
                        CompanyId = c.Guid(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Colours",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 30),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_Colour");
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        Postcode = c.String(),
                        TelephoneNumber = c.String(nullable: false),
                        Email = c.String(),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(maxLength: 500),
                        Postcode = c.String(maxLength: 10),
                        TelephoneNumber = c.String(nullable: false, maxLength: 20),
                        Email = c.String(maxLength: 50),
                        AddedByUserId = c.String(maxLength: 128),
                        DeletedByUserId = c.String(maxLength: 128),
                        CompanyId = c.Guid(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ExpenseDate = c.DateTime(nullable: false),
                        GarageId = c.Guid(nullable: false),
                        Payee = c.String(nullable: false),
                        Description = c.String(maxLength: 100),
                        ReferenceNumber = c.String(),
                        VATRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddedByUserId = c.String(maxLength: 128),
                        DeletedByUserId = c.String(maxLength: 128),
                        CompanyId = c.Guid(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Garages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Postcode = c.String(nullable: false),
                        TelephoneNumber = c.String(nullable: false),
                        Email = c.String(),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InvoiceId = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        Title = c.String(maxLength: 100),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        AddedByUserId = c.String(maxLength: 128),
                        DeletedByUserId = c.String(maxLength: 128),
                        CompanyId = c.Guid(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GarageId = c.Guid(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        InvoiceNumber = c.String(),
                        Notes = c.String(),
                        AddedByUserId = c.String(maxLength: 128),
                        DeletedByUserId = c.String(maxLength: 128),
                        CompanyId = c.Guid(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LicenceKeys",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GarageId = c.Guid(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MakeModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Make = c.String(maxLength: 30),
                        Model = c.String(maxLength: 30),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.Make, t.Model }, unique: true, name: "IX_MakeModel");
            
            CreateTable(
                "dbo.MOTs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        VehicleId = c.Guid(nullable: false),
                        TestNumber = c.String(),
                        SeatsAndSeatBelts = c.Boolean(),
                        WarningLamps = c.Boolean(),
                        Switches = c.Boolean(),
                        FrontViewWipersWashers = c.Boolean(),
                        BrakeControlsServo = c.Boolean(),
                        SteeringWheelAndColumn = c.Boolean(),
                        DoorsMirrorsHorn = c.Boolean(),
                        SpeedometerDriverControls = c.Boolean(),
                        InteriorChecksDefectsComments = c.String(),
                        RegistrationPlates = c.Boolean(),
                        LampsAndRegistrationPlateLamps = c.Boolean(),
                        IndicatorsHazards = c.Boolean(),
                        HeadlampsAndAim = c.Boolean(),
                        StopLampsFogLampsReflectors = c.Boolean(),
                        WheelsTyres = c.Boolean(),
                        ShockAbsorbers = c.Boolean(),
                        MirrorsWiperBladesFuelTankCap = c.Boolean(),
                        Glazing = c.Boolean(),
                        DoorsBootLidLoadingDoorsBonnet = c.Boolean(),
                        Towbars = c.Boolean(),
                        GeneralConditionOfBody = c.Boolean(),
                        ExteriorChecksDefectsComments = c.String(),
                        VehicleStructure = c.Boolean(),
                        BrakingSystems = c.Boolean(),
                        ExhaustSystemsFuelSystem = c.Boolean(),
                        SpeedLimiter = c.Boolean(),
                        SteeringAndPowerSterringComponents = c.Boolean(),
                        SuspensionComponents = c.Boolean(),
                        UnderBonnetChecksDefectsComments = c.String(),
                        SteeringIncludingPowerSteering = c.Boolean(),
                        DriveShafts = c.Boolean(),
                        SuspensionShockAbsorbers = c.Boolean(),
                        WheelBearings = c.Boolean(),
                        WheelsAndTyres = c.Boolean(),
                        BrakeSystemsAndMechanicalComponents = c.Boolean(),
                        ExhaustSystem = c.Boolean(),
                        FuelSystemAndFuelTank = c.Boolean(),
                        StructureGeneralVehicleCondition = c.Boolean(),
                        UnderVehichleChecksDefectsComments = c.String(),
                        Emissions = c.Boolean(),
                        EmissionsDefectsComments = c.String(),
                        AddedByUserId = c.String(maxLength: 128),
                        DeletedByUserId = c.String(maxLength: 128),
                        CompanyId = c.Guid(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Text = c.String(),
                        AddedByUserId = c.String(maxLength: 128),
                        DeletedByUserId = c.String(maxLength: 128),
                        CompanyId = c.Guid(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        When = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        AddedByUserId = c.String(maxLength: 128),
                        DeletedByUserId = c.String(maxLength: 128),
                        CompanyId = c.Guid(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        CompanyId = c.Guid(),
                        TagTypeEnum = c.Int(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ClientUserId = c.String(maxLength: 128),
                        SupportPersonUsername = c.String(),
                        Title = c.String(),
                        Description = c.String(nullable: false),
                        Due = c.DateTime(),
                        Priority = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        AddedByUserId = c.String(maxLength: 128),
                        DeletedByUserId = c.String(maxLength: 128),
                        CompanyId = c.Guid(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        RegistrationNumber = c.String(nullable: false),
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Colour = c.String(),
                        VIN = c.String(),
                        AddedByUserId = c.String(maxLength: 128),
                        DeletedByUserId = c.String(maxLength: 128),
                        CompanyId = c.Guid(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        GarageId = c.Guid(nullable: false),
                        LicenceKey = c.Guid(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.MakeModels", "IX_MakeModel");
            DropIndex("dbo.Colours", "IX_Colour");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Tickets");
            DropTable("dbo.Tags");
            DropTable("dbo.Reminders");
            DropTable("dbo.Notes");
            DropTable("dbo.MOTs");
            DropTable("dbo.MakeModels");
            DropTable("dbo.LicenceKeys");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Garages");
            DropTable("dbo.Expenses");
            DropTable("dbo.Customers");
            DropTable("dbo.Companies");
            DropTable("dbo.Colours");
            DropTable("dbo.Attachments");
            DropTable("dbo.Appointments");
        }
    }
}

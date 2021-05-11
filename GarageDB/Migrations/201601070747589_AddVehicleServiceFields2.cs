namespace GarageDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleServiceFields2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VehicleServices", "ClutchOperationCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "GearboxOperationCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "ClutchFluidCheckTopup", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "DriveShaftGaitorCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "GreasePropShaft", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "AxleTransaxleOilCheckTopup", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "GearboxFluidTopup", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "DriveSystemComments", c => c.String());
            AddColumn("dbo.VehicleServices", "ExteriorLightOperationCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "HornCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "DashboardWarningLightCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "BatteryHeldSecurelyCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "BatteryConditionCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "TopUpNonSealedBattery", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "VisuallyInspectHTLeads", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "StarterMotorEffectivenessTest", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "AlternatorChargingRateTest", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "ElectricalComments", c => c.String());
            AddColumn("dbo.VehicleServices", "PowerSteeringReservoirTopUpCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "SteeringSuspensionComponentWearCorrosionCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "SteeringRackGaiterConditionCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "WheelBearingCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "GreaseSteeringSuspensionComponents", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "SteeringAndSuspensionComments", c => c.String());
            AddColumn("dbo.VehicleServices", "ExhaustSystemInspection", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "ExhaustSmokeVisualCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "ExhaustComments", c => c.String());
            AddColumn("dbo.VehicleServices", "BrakePadWearDamageCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "BrakeCalliperCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "BrakeShoesWearDamageCheckCleanAdjust", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "WheelCylinderInspectionReportLeaks", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "BrakeHydraulicSystemPipeHoseLeakChafingCorrosionCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "HandbrakeLinkageTravelCheckLubricateAdjust", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "BrakeDiscDrumWearCracksCorrosionScoringPittingCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "BrakeFluidTopUpCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "BrakeServoCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "BrakeFluidBoilTest", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "ReplaceBrakeFluidBleed", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "BrakeComments", c => c.String());
            AddColumn("dbo.VehicleServices", "RemoveRoadWheels", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "TyreSizeFittedCorrectly", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "TyreConditionThreadDepth", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "TyrePressureAdjustCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "SetWheelNutTorqueToManufacturer", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "WheelBalanceCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "TyresAndWheelsComments", c => c.String());
            AddColumn("dbo.VehicleServices", "WindscreenWiperConditionOperationCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "RearWindscreenWiperConditionOperationCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "WindscreenWasherOperationAlignJetsTopUpCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "WindscreenChipCrackCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "MirrorConditionCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "NumberPlateConditionCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "VisionComments", c => c.String());
            AddColumn("dbo.VehicleServices", "CabinFilterCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "SeatbeltCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "DoorLockOperationCheck", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "LubricateDoorHinges", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "InternalComments", c => c.String());
            AddColumn("dbo.VehicleServices", "ResetServiceLight", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "RoadTest", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "LubricateBonnetCatch", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "StampServiceBook", c => c.Boolean());
            AddColumn("dbo.VehicleServices", "GeneralComments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleServices", "GeneralComments");
            DropColumn("dbo.VehicleServices", "StampServiceBook");
            DropColumn("dbo.VehicleServices", "LubricateBonnetCatch");
            DropColumn("dbo.VehicleServices", "RoadTest");
            DropColumn("dbo.VehicleServices", "ResetServiceLight");
            DropColumn("dbo.VehicleServices", "InternalComments");
            DropColumn("dbo.VehicleServices", "LubricateDoorHinges");
            DropColumn("dbo.VehicleServices", "DoorLockOperationCheck");
            DropColumn("dbo.VehicleServices", "SeatbeltCheck");
            DropColumn("dbo.VehicleServices", "CabinFilterCheck");
            DropColumn("dbo.VehicleServices", "VisionComments");
            DropColumn("dbo.VehicleServices", "NumberPlateConditionCheck");
            DropColumn("dbo.VehicleServices", "MirrorConditionCheck");
            DropColumn("dbo.VehicleServices", "WindscreenChipCrackCheck");
            DropColumn("dbo.VehicleServices", "WindscreenWasherOperationAlignJetsTopUpCheck");
            DropColumn("dbo.VehicleServices", "RearWindscreenWiperConditionOperationCheck");
            DropColumn("dbo.VehicleServices", "WindscreenWiperConditionOperationCheck");
            DropColumn("dbo.VehicleServices", "TyresAndWheelsComments");
            DropColumn("dbo.VehicleServices", "WheelBalanceCheck");
            DropColumn("dbo.VehicleServices", "SetWheelNutTorqueToManufacturer");
            DropColumn("dbo.VehicleServices", "TyrePressureAdjustCheck");
            DropColumn("dbo.VehicleServices", "TyreConditionThreadDepth");
            DropColumn("dbo.VehicleServices", "TyreSizeFittedCorrectly");
            DropColumn("dbo.VehicleServices", "RemoveRoadWheels");
            DropColumn("dbo.VehicleServices", "BrakeComments");
            DropColumn("dbo.VehicleServices", "ReplaceBrakeFluidBleed");
            DropColumn("dbo.VehicleServices", "BrakeFluidBoilTest");
            DropColumn("dbo.VehicleServices", "BrakeServoCheck");
            DropColumn("dbo.VehicleServices", "BrakeFluidTopUpCheck");
            DropColumn("dbo.VehicleServices", "BrakeDiscDrumWearCracksCorrosionScoringPittingCheck");
            DropColumn("dbo.VehicleServices", "HandbrakeLinkageTravelCheckLubricateAdjust");
            DropColumn("dbo.VehicleServices", "BrakeHydraulicSystemPipeHoseLeakChafingCorrosionCheck");
            DropColumn("dbo.VehicleServices", "WheelCylinderInspectionReportLeaks");
            DropColumn("dbo.VehicleServices", "BrakeShoesWearDamageCheckCleanAdjust");
            DropColumn("dbo.VehicleServices", "BrakeCalliperCheck");
            DropColumn("dbo.VehicleServices", "BrakePadWearDamageCheck");
            DropColumn("dbo.VehicleServices", "ExhaustComments");
            DropColumn("dbo.VehicleServices", "ExhaustSmokeVisualCheck");
            DropColumn("dbo.VehicleServices", "ExhaustSystemInspection");
            DropColumn("dbo.VehicleServices", "SteeringAndSuspensionComments");
            DropColumn("dbo.VehicleServices", "GreaseSteeringSuspensionComponents");
            DropColumn("dbo.VehicleServices", "WheelBearingCheck");
            DropColumn("dbo.VehicleServices", "SteeringRackGaiterConditionCheck");
            DropColumn("dbo.VehicleServices", "SteeringSuspensionComponentWearCorrosionCheck");
            DropColumn("dbo.VehicleServices", "PowerSteeringReservoirTopUpCheck");
            DropColumn("dbo.VehicleServices", "ElectricalComments");
            DropColumn("dbo.VehicleServices", "AlternatorChargingRateTest");
            DropColumn("dbo.VehicleServices", "StarterMotorEffectivenessTest");
            DropColumn("dbo.VehicleServices", "VisuallyInspectHTLeads");
            DropColumn("dbo.VehicleServices", "TopUpNonSealedBattery");
            DropColumn("dbo.VehicleServices", "BatteryConditionCheck");
            DropColumn("dbo.VehicleServices", "BatteryHeldSecurelyCheck");
            DropColumn("dbo.VehicleServices", "DashboardWarningLightCheck");
            DropColumn("dbo.VehicleServices", "HornCheck");
            DropColumn("dbo.VehicleServices", "ExteriorLightOperationCheck");
            DropColumn("dbo.VehicleServices", "DriveSystemComments");
            DropColumn("dbo.VehicleServices", "GearboxFluidTopup");
            DropColumn("dbo.VehicleServices", "AxleTransaxleOilCheckTopup");
            DropColumn("dbo.VehicleServices", "GreasePropShaft");
            DropColumn("dbo.VehicleServices", "DriveShaftGaitorCheck");
            DropColumn("dbo.VehicleServices", "ClutchFluidCheckTopup");
            DropColumn("dbo.VehicleServices", "GearboxOperationCheck");
            DropColumn("dbo.VehicleServices", "ClutchOperationCheck");
        }
    }
}

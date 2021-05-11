using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class VehicleService : ClientRow
    {
        public Guid VehicleId { get; set; }

        public DateTime ServiceDateAndTime { get; set; }

        public Enums.ServiceType ServiceType { get; set; }

        // engine
        [DisplayName("Drain oil and refill")]
        public bool? DrainOilAndRefill { get; set; }

        [DisplayName("Replace oil filter")]
        public bool? ReplaceOilFilter { get; set; }

        [DisplayName("Excessive oil leak check")]
        public bool? ExcessiveOilLeakCheck { get; set; }

        [DisplayName("Timing belt check")]
        public bool? TimingBeltCheck { get; set; }

        [DisplayName("Radiator condition check")]
        public bool? RadiatorConditionCheck { get; set; }

        [DisplayName("Coolant cap seal check")]
        public bool? CoolantCapSealCheck { get; set; }

        [DisplayName("Coolant hose check")]
        public bool? CoolantHoseCheck { get; set; }

        [DisplayName("Cooling fan check")]
        public bool? CoolingFanCheck { get; set; }

        [DisplayName("Fan / alternator belt check")]
        public bool? FanAlternatorBeltCheck { get; set; }

        [DisplayName("Auxiliary drive belt check")]
        public bool? AuxiliaryDriveBeltCheck { get; set; }

        [DisplayName("Replace air filter")]
        public bool? ReplaceAirFilter { get; set; }

        [DisplayName("Spark plug replacement due check")]
        public bool? SparkPlugReplacementMileageCheck { get; set; }

        [DisplayName("Antifreeze check / top up")]
        public bool? AntifreezeCheckTopup { get; set; }

        [DisplayName("Drain and replace coolant to correct specification")]
        public bool? ReplaceCoolant { get; set; }

        [DisplayName("Replace spark plugs (petrol engines only)")]
        public bool? ReplaceSparkPlugs { get; set; }

        [DisplayName("Undertray check")]
        public bool? UndertrayCheck { get; set; }

        public string EngineComments { get; set; }

        // fuel
        [DisplayName("Fuel cap seal check")]
        public bool? FuelCapSealCheck { get; set; }

        [DisplayName("Fuel line visual check")]
        public bool? FuelLineVisualCheck { get; set; }

        [DisplayName("Replace fuel filter")]
        public bool? ReplaceFuelFilter { get; set; }

        public string FuelComments { get; set; }

        // drive system
        [DisplayName("Clutch operation check")]
        public bool? ClutchOperationCheck { get; set; }

        [DisplayName("Gearbox operation check")]
        public bool? GearboxOperationCheck { get; set; }

        [DisplayName("Clutch fluid check / top up")]
        public bool? ClutchFluidCheckTopup { get; set; }

        [DisplayName("Drive shaft gaitor check")]
        public bool? DriveShaftGaitorCheck { get; set; }

        [DisplayName("Grease prop/shaft (if applicable)")]
        public bool? GreasePropShaft { get; set; }

        [DisplayName("Axle / transaxle oil check / top up")]
        public bool? AxleTransaxleOilCheckTopup { get; set; }

        [DisplayName("Gearbox fluid top up (if applicable)")]
        public bool? GearboxFluidTopup { get; set; }

        public string DriveSystemComments { get; set; }

        // electrical
        [DisplayName("Exterior light operation check")]
        public bool? ExteriorLightOperationCheck { get; set; }

        [DisplayName("Horn check")]
        public bool? HornCheck { get; set; }

        [DisplayName("Dashboard warning light check")]
        public bool? DashboardWarningLightCheck { get; set; }

        [DisplayName("Battery held securely check")]
        public bool? BatteryHeldSecurelyCheck { get; set; }

        [DisplayName("Battery condition check")]
        public bool? BatteryConditionCheck { get; set; }

        [DisplayName("Top up non-sealed battery")]
        public bool? TopUpNonSealedBattery { get; set; }

        [DisplayName("Visually inspect HT (high tension) leads")]
        public bool? VisuallyInspectHTLeads { get; set; }

        [DisplayName("Starter motor effectiveness test")]
        public bool? StarterMotorEffectivenessTest { get; set; }

        [DisplayName("Alternator charging rate test")]
        public bool? AlternatorChargingRateTest { get; set; }

        public string ElectricalComments { get; set; }

        // steering and suspension
        [DisplayName("Power steering reservoir top up / check (if applicable)")]
        public bool? PowerSteeringReservoirTopUpCheck { get; set; }

        [DisplayName("Steer / suspension component check for wear and corrosion")]
        public bool? SteeringSuspensionComponentWearCorrosionCheck { get; set; }

        [DisplayName("Steering rack gaiter condition check")]
        public bool? SteeringRackGaiterConditionCheck { get; set; }

        [DisplayName("Wheel bearing check for excessive play or corrosion")]
        public bool? WheelBearingCheck { get; set; }

        [DisplayName("Grease steering wheel and suspension components (where applicable)")]
        public bool? GreaseSteeringSuspensionComponents { get; set; }

        public string SteeringAndSuspensionComments { get; set; }

        // exhaust
        [DisplayName("Exhaust system (including any catalyst) inspection for leaks, security and noise")]
        public bool? ExhaustSystemInspection { get; set; }

        [DisplayName("Exhaust smoke visual check")]
        public bool? ExhaustSmokeVisualCheck { get; set; }

        public string ExhaustComments { get; set; }

        // brakes
        [DisplayName("Brake pad wear / damage check")]
        public bool? BrakePadWearDamageCheck { get; set; }

        [DisplayName("Brake calliper check for leaks and security")]
        public bool? BrakeCalliperCheck { get; set; }

        [DisplayName("Brake shoe check for wear or damage. Clean and adjust if required (excludes internal handbrake shoes)")]
        public bool? BrakeShoesWearDamageCheckCleanAdjust { get; set; }
        
        [DisplayName("Wheel cylinder inspection. Report any leaks")]
        public bool? WheelCylinderInspectionReportLeaks { get; set; }

        [DisplayName("Brake hydraulic system pipe / hose visual check for leaks / chafing / corrosion check")]
        public bool? BrakeHydraulicSystemPipeHoseLeakChafingCorrosionCheck { get; set; }

        [DisplayName("Handbrake linkage / travel check. Lubricate / adjust if required")]
        public bool? HandbrakeLinkageTravelCheckLubricateAdjust { get; set; }

        [DisplayName("Brake disc, drum wear / cracks / corrosion scoring pitting check (excluding internal drums)")]
        public bool? BrakeDiscDrumWearCracksCorrosionScoringPittingCheck { get; set; }

        [DisplayName("Brake fluid top up / check")]
        public bool? BrakeFluidTopUpCheck { get; set; }

        [DisplayName("Brake servo operation check")]
        public bool? BrakeServoCheck { get; set; }

        [DisplayName("Brake fluid boil test")]
        public bool? BrakeFluidBoilTest { get; set; }

        [DisplayName("Replace brake fluid and bleed system")]
        public bool? ReplaceBrakeFluidBleed { get; set; }

        public string BrakeComments { get; set; }

        // tyres and wheels
        [DisplayName("Remove road wheels")]
        public bool? RemoveRoadWheels { get; set; }

        [DisplayName("Tyre size and fitting complies with side wall instructions")]
        public bool? TyreSizeFittedCorrectly { get; set; }

        [DisplayName("Tyre condition and thread depth check (including spare)")]
        public bool? TyreConditionThreadDepth { get; set; }

        [DisplayName("Tyre pressure check / adjust (including spare)")]
        public bool? TyrePressureAdjustCheck { get; set; }

        [DisplayName("Set the wheel nuts to manufacturer's recommended torque")]
        public bool? SetWheelNutTorqueToManufacturer { get; set; }

        [DisplayName("Wheel balance check (including spare)")]
        public bool? WheelBalanceCheck { get; set; }

        public string TyresAndWheelsComments { get; set; }

        // vision
        [DisplayName("Windscreen wiper condition / operation check")]
        public bool? WindscreenWiperConditionOperationCheck { get; set; }

        [DisplayName("Rear windscreen wiper condition / operation check")]
        public bool? RearWindscreenWiperConditionOperationCheck { get; set; }

        [DisplayName("Windscreen washer operation check. Align jets / top up if required")]
        public bool? WindscreenWasherOperationAlignJetsTopUpCheck { get; set; }

        [DisplayName("Windscreen chip crack check")]
        public bool? WindscreenChipCrackCheck { get; set; }

        [DisplayName("Mirror condition check")]
        public bool? MirrorConditionCheck { get; set; }

        [DisplayName("Number plate condition check")]
        public bool? NumberPlateConditionCheck { get; set; }

        public string VisionComments { get; set; }

        // internal
        [DisplayName("Cabin filter check (advise if required based on age / mileage and last change)")]
        public bool? CabinFilterCheck { get; set; }

        [DisplayName("Seatbelt check")]
        public bool? SeatbeltCheck { get; set; }

        [DisplayName("Door lock operation check")]
        public bool? DoorLockOperationCheck { get; set; }

        [DisplayName("Lubricate door hinges (with grease)")]
        public bool? LubricateDoorHinges { get; set; }

        public string InternalComments { get; set; }

        // general
        [DisplayName("Reset service light (if applicable)")]
        public bool? ResetServiceLight { get; set; }

        [DisplayName("Road test")]
        public bool? RoadTest { get; set; }

        [DisplayName("Lubricate bonnet catch")]
        public bool? LubricateBonnetCatch { get; set; }

        [DisplayName("Stamp service book")]
        public bool? StampServiceBook { get; set; }

        public string GeneralComments { get; set; }
    }
}
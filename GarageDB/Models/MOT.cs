using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class MOT : ClientRow
    {
        public Guid VehicleId { get; set; }

        [DisplayName("Test date / time")]
        public DateTime TestDateAndTime { get; set; }

        [DisplayName("Test expiry date")]
        public DateTime TestExpiryDate { get; set; }

        [DisplayName("Last MOT expiry date")]
        public DateTime PreviousMOTExpiryDate { get; set; }

        [DisplayName("Date of first use")]
        public DateTime FirstUseDate { get; set; }

        [DisplayName("Date of previous seat belt check")]
        public DateTime PreviousSeatBeltCheckDate { get; set; }

        [DisplayName("No. of seat belts install check")]
        public int SeatBeltsInstallCheckNumber { get; set; }

        [DisplayName("Seriously damaged marker (DVLA)")]
        public string SeriouslyDamagedMarker { get; set; }

        public bool Pass { get; set; }

        [DisplayName("MOT test number")]
        public string TestNumber { get; set; }

        [DisplayName("Previous test certificate number")]
        public string PreviousTestNumber { get; set; }

        // Interior checks
        [DisplayName("Seats and seat belts")]
        public bool? SeatsAndSeatBelts { get; set; }

        [DisplayName("Warning lamps")]
        public bool? WarningLamps { get; set; }

        [DisplayName("Switches")]
        public bool? Switches { get; set; }

        [DisplayName("View to front, wipers & washers")]
        public bool? FrontViewWipersWashers { get; set; }

        [DisplayName("Brake controls, servo operation")]
        public bool? BrakeControlsServo { get; set; }

        [DisplayName("Steering wheel & column")]
        public bool? SteeringWheelAndColumn { get; set; }

        [DisplayName("Doors, mirrors, horn")]
        public bool? DoorsMirrorsHorn { get; set; }

        [DisplayName("Speedometer, driver controls (Class 5 only)")]
        public bool? SpeedometerDriverControls { get; set; }

        public string InteriorChecksDefectsComments { get; set; }

        // Exterior checks
        public bool? RegistrationPlates { get; set; }

        public bool? LampsAndRegistrationPlateLamps { get; set; }

        public bool? IndicatorsHazards { get; set; }

        public bool? HeadlampsAndAim { get; set; }

        public bool? StopLampsFogLampsReflectors { get; set; }

        public bool? WheelsTyres { get; set; }

        public bool? ShockAbsorbers { get; set; }

        public bool? MirrorsWiperBladesFuelTankCap { get; set; }

        public bool? Glazing { get; set; }

        public bool? DoorsBootLidLoadingDoorsBonnet { get; set; }

        public bool? Towbars { get; set; }

        public bool? GeneralConditionOfBody { get; set; }

        public string ExteriorChecksDefectsComments { get; set; }

        // Under bonnet checks
        public bool? VehicleStructure { get; set; }

        public bool? BrakingSystems { get; set; }

        public bool? ExhaustSystemsFuelSystem { get; set; }

        public bool? SpeedLimiter { get; set; }

        public bool? SteeringAndPowerSterringComponents { get; set; }

        public bool? SuspensionComponents { get; set; }

        public string UnderBonnetChecksDefectsComments { get; set; }

        // Under vehicle checks
        public bool? SteeringIncludingPowerSteering { get; set; }

        public bool? DriveShafts { get; set; }

        public bool? SuspensionShockAbsorbers { get; set; }

        public bool? WheelBearings { get; set; }

        public bool? WheelsAndTyres { get; set; }

        public bool? BrakeSystemsAndMechanicalComponents { get; set; }

        public bool? ExhaustSystem { get; set; }

        public bool? FuelSystemAndFuelTank { get; set; }

        public bool? StructureGeneralVehicleCondition { get; set; }

        public string UnderVehichleChecksDefectsComments { get; set; }

        // Emissions
        public bool? Emissions { get; set; }

        public string EmissionsDefectsComments { get; set; }

        //Brake performance
        public bool? BrakePerformance { get; set; }

        public string BrakePerformanceDefectComments { get; set; }

        public override string ToString()
        {
            return string.Format("MOT {0} on {1}", PassText.ToLower(), TestDateAndTime.ToString(Constants.RecordDateFormat));
        }

        public string PassText
        {
            get
            {
                return Pass ? "Passed" : "Failed";
            }
        }

        public string Colour
        {
            get
            {
                return Pass ? RowColour.lightgreen : RowColour.lightpink;
            }
        }
    }
}
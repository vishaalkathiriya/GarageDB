using GarageDB.Helpers;
using GarageDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageDB.Controllers
{
    [Authorize]
    public class ServicingController : Controller
    {
        public ActionResult Interim(Guid Id)
        {
            return ViewService(Id);
        }

        [HttpGet]
        public ActionResult AddInterim(Guid VehicleId)
        {
            return AddService(VehicleId);
        }

        [HttpPost]
        public ActionResult AddInterim(VehicleService vehicleService, FormCollection formCollection)
        {
            return AddService(vehicleService, formCollection, Enums.ServiceType.Interim);
        }

        [HttpGet]
        public ActionResult EditInterim(Guid Id)
        {
            return EditService(Id);
        }

        [HttpPost]
        public ActionResult EditInterim(VehicleService vehicleService, FormCollection formCollection)
        {
            return EditService(vehicleService, formCollection, Enums.ServiceType.Interim);
        }

        public ActionResult Full(Guid Id)
        {
            return ViewService(Id);
        }

        [HttpGet]
        public ActionResult AddFull(Guid VehicleId)
        {
            return AddService(VehicleId);
        }

        [HttpPost]
        public ActionResult AddFull(VehicleService vehicleService, FormCollection formCollection)
        {
            return AddService(vehicleService, formCollection, Enums.ServiceType.Full);
        }

        [HttpGet]
        public ActionResult EditFull(Guid Id)
        {
            return EditService(Id);
        }

        [HttpPost]
        public ActionResult EditFull(VehicleService vehicleService, FormCollection formCollection)
        {
            return EditService(vehicleService, formCollection, Enums.ServiceType.Full);
        }

        public ActionResult Major(Guid Id)
        {
            return ViewService(Id);
        }

        [HttpGet]
        public ActionResult AddMajor(Guid VehicleId)
        {
            return AddService(VehicleId);
        }

        [HttpPost]
        public ActionResult AddMajor(VehicleService vehicleService, FormCollection formCollection)
        {
            return AddService(vehicleService, formCollection, Enums.ServiceType.Major);
        }

        [HttpGet]
        public ActionResult EditMajor(Guid Id)
        {
            return EditService(Id);
        }

        [HttpPost]
        public ActionResult EditMajor(VehicleService vehicleService, FormCollection formCollection)
        {
            return EditService(vehicleService, formCollection, Enums.ServiceType.Major);
        }

        private ActionResult ViewService(Guid Id)
        {
            var db = new GarageContext();

            var VehicleService = db.VehicleServices.Find(Id);

            PopulateVehicleAndCustomerViewBags(db, VehicleService);

            return View(VehicleService);
        }

        /// <summary>
        /// HttpGet action
        /// </summary>
        /// <param name="VehicleId"></param>
        /// <returns></returns>
        private ActionResult AddService(Guid VehicleId)
        {
            var VehicleService = new VehicleService();
            VehicleService.VehicleId = VehicleId;

            var db = new GarageContext();
            var Vehicle = db.Vehicles.Find(VehicleService.VehicleId);
            ViewBag.Vehicle = Vehicle;
            return View(VehicleService);
        }

        /// <summary>
        /// HttpPost action
        /// </summary>
        /// <param name="vehicleService"></param>
        /// <param name="formCollection"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        private ActionResult AddService(VehicleService vehicleService, FormCollection formCollection, Enums.ServiceType serviceType)
        {
            var db = new GarageContext();

            var GarageId = ((ApplicationUser)HttpContext.Session["user"]).GarageId;

            var CompanyId = db.Garages.Where(o => o.Id == GarageId).First().CompanyId;

            vehicleService.CompanyId = CompanyId;
            vehicleService.ServiceDateAndTime = DateTime.Now;
            vehicleService.ServiceType = serviceType;

            PopulateServiceSelections(vehicleService, formCollection);

            db.VehicleServices.Add(vehicleService);

            if (ModelState.IsValid)
            {
                db.SaveChanges();

                var Vehicle = db.Vehicles.Find(vehicleService.VehicleId);

                var message = string.Format("{0} service added for vehicle {1}", serviceType.ToString(), Vehicle.ToString());
                TempData["Message"] = message;

                return RedirectToAction(serviceType.ToString(), new { vehicleService.Id });
            }

            return View();
        }

        /// <summary>
        /// HttpGet action
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private ActionResult EditService(Guid Id)
        {
            var db = new GarageContext();

            var VehicleService = db.VehicleServices.Find(Id);

            PopulateVehicleAndCustomerViewBags(db, VehicleService);

            return View(VehicleService);
        }

        /// <summary>
        /// HttpPost action
        /// </summary>
        /// <param name="vehicleService"></param>
        /// <param name="formCollection"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        private ActionResult EditService(VehicleService vehicleService, FormCollection formCollection, Enums.ServiceType serviceType)
        {
            var db = new GarageContext();

            var GarageId = ((ApplicationUser)HttpContext.Session["user"]).GarageId;

            var CompanyId = db.Garages.Where(o => o.Id == GarageId).First().CompanyId;

            var ExistingVehicleService = db.VehicleServices.Find(vehicleService.Id);

            PopulateServiceSelections(ExistingVehicleService, formCollection);

            ExistingVehicleService.EngineComments = vehicleService.EngineComments;
            ExistingVehicleService.FuelComments = vehicleService.FuelComments;
            ExistingVehicleService.DriveSystemComments = vehicleService.DriveSystemComments;
            ExistingVehicleService.ElectricalComments = vehicleService.ElectricalComments;
            ExistingVehicleService.SteeringAndSuspensionComments = vehicleService.SteeringAndSuspensionComments;
            ExistingVehicleService.ExhaustComments = vehicleService.ExhaustComments;
            ExistingVehicleService.BrakeComments = vehicleService.BrakeComments;
            ExistingVehicleService.TyresAndWheelsComments = vehicleService.TyresAndWheelsComments;
            ExistingVehicleService.VisionComments = vehicleService.VisionComments;
            ExistingVehicleService.InternalComments = vehicleService.InternalComments;
            ExistingVehicleService.GeneralComments = vehicleService.GeneralComments;

            if (ModelState.IsValid)
            {
                db.SaveChanges();

                var Vehicle = db.Vehicles.Find(ExistingVehicleService.VehicleId);

                var message = string.Format("{0} service updated for vehicle {1}", serviceType.ToString(), Vehicle.ToString());
                TempData["Message"] = message;

                return RedirectToAction(serviceType.ToString(), new { ExistingVehicleService.Id });
            }

            return View();
        }

        /// <summary>
        /// Used to populate ViewBag.Vehicle and ViewBag.Customer for use in breadcrumb trail
        /// </summary>
        /// <param name="db"></param>
        /// <param name="VehicleService"></param>
        private void PopulateVehicleAndCustomerViewBags(GarageContext db, VehicleService VehicleService)
        {
            var Vehicle = db.Vehicles.Find(VehicleService.VehicleId);
            ViewBag.Vehicle = Vehicle;

            var Customer = db.Customers.Find(Vehicle.CustomerId);
            ViewBag.Customer = Customer;
        }

        private void PopulateServiceSelections(VehicleService vehicleService, FormCollection formCollection)
        {
            const string suffix = "Switch";

            vehicleService.DrainOilAndRefill = PassFailHelper.GetSwitchSelection(formCollection["DrainOilAndRefill" + suffix]);
            vehicleService.ReplaceOilFilter = PassFailHelper.GetSwitchSelection(formCollection["ReplaceOilFilter" + suffix]);
            vehicleService.ExcessiveOilLeakCheck = PassFailHelper.GetSwitchSelection(formCollection["ExcessiveOilLeakCheck" + suffix]);
            vehicleService.TimingBeltCheck = PassFailHelper.GetSwitchSelection(formCollection["TimingBeltCheck" + suffix]);
            vehicleService.RadiatorConditionCheck = PassFailHelper.GetSwitchSelection(formCollection["RadiatorConditionCheck" + suffix]);
            vehicleService.CoolantCapSealCheck = PassFailHelper.GetSwitchSelection(formCollection["CoolantCapSealCheck" + suffix]);
            vehicleService.CoolantHoseCheck = PassFailHelper.GetSwitchSelection(formCollection["CoolantHoseCheck" + suffix]);
            vehicleService.CoolingFanCheck = PassFailHelper.GetSwitchSelection(formCollection["CoolingFanCheck" + suffix]);
            vehicleService.FanAlternatorBeltCheck = PassFailHelper.GetSwitchSelection(formCollection["FanAlternatorBeltCheck" + suffix]);
            vehicleService.AuxiliaryDriveBeltCheck = PassFailHelper.GetSwitchSelection(formCollection["AuxiliaryDriveBeltCheck" + suffix]);
            vehicleService.ReplaceAirFilter = PassFailHelper.GetSwitchSelection(formCollection["ReplaceAirFilter" + suffix]);
            vehicleService.SparkPlugReplacementMileageCheck = PassFailHelper.GetSwitchSelection(formCollection["SparkPlugReplacementMileageCheck" + suffix]);
            vehicleService.AntifreezeCheckTopup = PassFailHelper.GetSwitchSelection(formCollection["AntifreezeCheckTopup" + suffix]);
            vehicleService.ReplaceCoolant = PassFailHelper.GetSwitchSelection(formCollection["ReplaceCoolant" + suffix]);
            vehicleService.ReplaceSparkPlugs = PassFailHelper.GetSwitchSelection(formCollection["ReplaceSparkPlugs" + suffix]);
            vehicleService.UndertrayCheck = PassFailHelper.GetSwitchSelection(formCollection["UndertrayCheck" + suffix]);
            vehicleService.FuelCapSealCheck = PassFailHelper.GetSwitchSelection(formCollection["FuelCapSealCheck" + suffix]);
            vehicleService.FuelLineVisualCheck = PassFailHelper.GetSwitchSelection(formCollection["FuelLineVisualCheck" + suffix]);
            vehicleService.ReplaceFuelFilter = PassFailHelper.GetSwitchSelection(formCollection["ReplaceFuelFilter" + suffix]);
            vehicleService.ClutchOperationCheck = PassFailHelper.GetSwitchSelection(formCollection["ClutchOperationCheck" + suffix]);
            vehicleService.GearboxOperationCheck = PassFailHelper.GetSwitchSelection(formCollection["GearboxOperationCheck" + suffix]);
            vehicleService.ClutchFluidCheckTopup = PassFailHelper.GetSwitchSelection(formCollection["ClutchFluidCheckTopup" + suffix]);
            vehicleService.DriveShaftGaitorCheck = PassFailHelper.GetSwitchSelection(formCollection["DriveShaftGaitorCheck" + suffix]);
            vehicleService.GreasePropShaft = PassFailHelper.GetSwitchSelection(formCollection["GreasePropShaft" + suffix]);
            vehicleService.AxleTransaxleOilCheckTopup = PassFailHelper.GetSwitchSelection(formCollection["AxleTransaxleOilCheckTopup" + suffix]);
            vehicleService.GearboxFluidTopup = PassFailHelper.GetSwitchSelection(formCollection["GearboxFluidTopup" + suffix]);
            vehicleService.ExteriorLightOperationCheck = PassFailHelper.GetSwitchSelection(formCollection["ExteriorLightOperationCheck" + suffix]);
            vehicleService.HornCheck = PassFailHelper.GetSwitchSelection(formCollection["HornCheck" + suffix]);
            vehicleService.DashboardWarningLightCheck = PassFailHelper.GetSwitchSelection(formCollection["DashboardWarningLightCheck" + suffix]);
            vehicleService.BatteryHeldSecurelyCheck = PassFailHelper.GetSwitchSelection(formCollection["BatteryHeldSecurelyCheck" + suffix]);
            vehicleService.BatteryConditionCheck = PassFailHelper.GetSwitchSelection(formCollection["BatteryConditionCheck" + suffix]);
            vehicleService.TopUpNonSealedBattery = PassFailHelper.GetSwitchSelection(formCollection["TopUpNonSealedBattery" + suffix]);
            vehicleService.VisuallyInspectHTLeads = PassFailHelper.GetSwitchSelection(formCollection["VisuallyInspectHTLeads" + suffix]);
            vehicleService.StarterMotorEffectivenessTest = PassFailHelper.GetSwitchSelection(formCollection["StarterMotorEffectivenessTest" + suffix]);
            vehicleService.AlternatorChargingRateTest = PassFailHelper.GetSwitchSelection(formCollection["AlternatorChargingRateTest" + suffix]);
            vehicleService.PowerSteeringReservoirTopUpCheck = PassFailHelper.GetSwitchSelection(formCollection["PowerSteeringReservoirTopUpCheck" + suffix]);
            vehicleService.SteeringSuspensionComponentWearCorrosionCheck = PassFailHelper.GetSwitchSelection(formCollection["SteeringSuspensionComponentWearCorrosionCheck" + suffix]);
            vehicleService.SteeringRackGaiterConditionCheck = PassFailHelper.GetSwitchSelection(formCollection["SteeringRackGaiterConditionCheck" + suffix]);
            vehicleService.WheelBearingCheck = PassFailHelper.GetSwitchSelection(formCollection["WheelBearingCheck" + suffix]);
            vehicleService.GreaseSteeringSuspensionComponents = PassFailHelper.GetSwitchSelection(formCollection["GreaseSteeringSuspensionComponents" + suffix]);
            vehicleService.ExhaustSystemInspection = PassFailHelper.GetSwitchSelection(formCollection["ExhaustSystemInspection" + suffix]);
            vehicleService.ExhaustSmokeVisualCheck = PassFailHelper.GetSwitchSelection(formCollection["ExhaustSmokeVisualCheck" + suffix]);
            vehicleService.BrakePadWearDamageCheck = PassFailHelper.GetSwitchSelection(formCollection["BrakePadWearDamageCheck" + suffix]);
            vehicleService.BrakeCalliperCheck = PassFailHelper.GetSwitchSelection(formCollection["BrakeCalliperCheck" + suffix]);
            vehicleService.BrakeShoesWearDamageCheckCleanAdjust = PassFailHelper.GetSwitchSelection(formCollection["BrakeShoesWearDamageCheckCleanAdjust" + suffix]);
            vehicleService.WheelCylinderInspectionReportLeaks = PassFailHelper.GetSwitchSelection(formCollection["WheelCylinderInspectionReportLeaks" + suffix]);
            vehicleService.BrakeHydraulicSystemPipeHoseLeakChafingCorrosionCheck = PassFailHelper.GetSwitchSelection(formCollection["BrakeHydraulicSystemPipeHoseLeakChafingCorrosionCheck" + suffix]);
            vehicleService.HandbrakeLinkageTravelCheckLubricateAdjust = PassFailHelper.GetSwitchSelection(formCollection["HandbrakeLinkageTravelCheckLubricateAdjust" + suffix]);
            vehicleService.BrakeDiscDrumWearCracksCorrosionScoringPittingCheck = PassFailHelper.GetSwitchSelection(formCollection["BrakeDiscDrumWearCracksCorrosionScoringPittingCheck" + suffix]);
            vehicleService.BrakeFluidTopUpCheck = PassFailHelper.GetSwitchSelection(formCollection["BrakeFluidTopUpCheck" + suffix]);
            vehicleService.BrakeServoCheck = PassFailHelper.GetSwitchSelection(formCollection["BrakeServoCheck" + suffix]);
            vehicleService.BrakeFluidBoilTest = PassFailHelper.GetSwitchSelection(formCollection["BrakeFluidBoilTest" + suffix]);
            vehicleService.ReplaceBrakeFluidBleed = PassFailHelper.GetSwitchSelection(formCollection["ReplaceBrakeFluidBleed" + suffix]);
            vehicleService.RemoveRoadWheels = PassFailHelper.GetSwitchSelection(formCollection["RemoveRoadWheels" + suffix]);
            vehicleService.TyreSizeFittedCorrectly = PassFailHelper.GetSwitchSelection(formCollection["TyreSizeFittedCorrectly" + suffix]);
            vehicleService.TyreConditionThreadDepth = PassFailHelper.GetSwitchSelection(formCollection["TyreConditionThreadDepth" + suffix]);
            vehicleService.TyrePressureAdjustCheck = PassFailHelper.GetSwitchSelection(formCollection["TyrePressureAdjustCheck" + suffix]);
            vehicleService.SetWheelNutTorqueToManufacturer = PassFailHelper.GetSwitchSelection(formCollection["SetWheelNutTorqueToManufacturer" + suffix]);
            vehicleService.WheelBalanceCheck = PassFailHelper.GetSwitchSelection(formCollection["WheelBalanceCheck" + suffix]);
            vehicleService.WindscreenWiperConditionOperationCheck = PassFailHelper.GetSwitchSelection(formCollection["WindscreenWiperConditionOperationCheck" + suffix]);
            vehicleService.RearWindscreenWiperConditionOperationCheck = PassFailHelper.GetSwitchSelection(formCollection["RearWindscreenWiperConditionOperationCheck" + suffix]);
            vehicleService.WindscreenWasherOperationAlignJetsTopUpCheck = PassFailHelper.GetSwitchSelection(formCollection["WindscreenWasherOperationAlignJetsTopUpCheck" + suffix]);
            vehicleService.WindscreenChipCrackCheck = PassFailHelper.GetSwitchSelection(formCollection["WindscreenChipCrackCheck" + suffix]);
            vehicleService.MirrorConditionCheck = PassFailHelper.GetSwitchSelection(formCollection["MirrorConditionCheck" + suffix]);
            vehicleService.NumberPlateConditionCheck = PassFailHelper.GetSwitchSelection(formCollection["NumberPlateConditionCheck" + suffix]);
            vehicleService.CabinFilterCheck = PassFailHelper.GetSwitchSelection(formCollection["CabinFilterCheck" + suffix]);
            vehicleService.SeatbeltCheck = PassFailHelper.GetSwitchSelection(formCollection["SeatbeltCheck" + suffix]);
            vehicleService.DoorLockOperationCheck = PassFailHelper.GetSwitchSelection(formCollection["DoorLockOperationCheck" + suffix]);
            vehicleService.LubricateDoorHinges = PassFailHelper.GetSwitchSelection(formCollection["LubricateDoorHinges" + suffix]);
            vehicleService.ResetServiceLight = PassFailHelper.GetSwitchSelection(formCollection["ResetServiceLight" + suffix]);
            vehicleService.RoadTest = PassFailHelper.GetSwitchSelection(formCollection["RoadTest" + suffix]);
            vehicleService.LubricateBonnetCatch = PassFailHelper.GetSwitchSelection(formCollection["LubricateBonnetCatch" + suffix]);
            vehicleService.StampServiceBook = PassFailHelper.GetSwitchSelection(formCollection["StampServiceBook" + suffix]);
        }
    }
}
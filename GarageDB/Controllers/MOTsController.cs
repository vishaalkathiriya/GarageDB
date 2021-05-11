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
    public class MOTsController : Controller
    {
        public ActionResult View(Guid Id)
        {
            var db = new GarageContext();

            var MOT = db.MOTs.Find(Id);

            return View(MOT);
        }

        [HttpGet]
        public ActionResult Add(Guid VehicleId)
        {
            var MOT = new MOT();
            MOT.VehicleId = VehicleId;

            var db = new GarageContext();
            var Vehicle = db.Vehicles.Find(MOT.VehicleId);
            ViewBag.VehicleName = Vehicle.ToString();
            return View(MOT);
        }

        [HttpPost]
        public ActionResult Add(MOT MOT, FormCollection formCollection)
        {
            var db = new GarageContext();

            var GarageId = ((ApplicationUser)HttpContext.Session["user"]).GarageId;

            var CompanyId = db.Garages.Where(o => o.Id == GarageId).First().CompanyId;

            MOT.CompanyId = CompanyId;
            MOT.TestDateAndTime = DateTime.Now;

            PopulateMOTSelections(MOT, formCollection);

            MOT.InteriorChecksDefectsComments = MOT.InteriorChecksDefectsComments;
            MOT.ExteriorChecksDefectsComments = MOT.ExteriorChecksDefectsComments;
            MOT.UnderBonnetChecksDefectsComments = MOT.UnderBonnetChecksDefectsComments;
            MOT.UnderVehichleChecksDefectsComments = MOT.UnderVehichleChecksDefectsComments;
            MOT.EmissionsDefectsComments = MOT.EmissionsDefectsComments;
            MOT.BrakePerformanceDefectComments = MOT.BrakePerformanceDefectComments;

            db.MOTs.Add(MOT);

            if (ModelState.IsValid)
            {
                db.SaveChanges();

                var Vehicle = db.Vehicles.Find(MOT.VehicleId);

                var message = string.Format("MOT added for vehicle {0}", Vehicle.ToString());
                TempData["Message"] = message;

                return RedirectToAction("View", new { MOT.Id });
            }

            return View();
        }
        
        [HttpGet]
        public ActionResult Edit(Guid Id)
        {
            var db = new GarageContext();

            var MOT = db.MOTs.Find(Id);

            var Vehicle = db.Vehicles.Find(MOT.VehicleId);
            ViewBag.VehicleName = Vehicle.ToString();
            return View(MOT);
        }

        [HttpPost]
        public ActionResult Edit(MOT MOT, FormCollection formCollection)
        {
            var db = new GarageContext();

            var ExistingMOT = db.MOTs.Find(MOT.Id);

            PopulateMOTSelections(ExistingMOT, formCollection);

            ExistingMOT.InteriorChecksDefectsComments = MOT.InteriorChecksDefectsComments;
            ExistingMOT.ExteriorChecksDefectsComments = MOT.ExteriorChecksDefectsComments;
            ExistingMOT.UnderBonnetChecksDefectsComments = MOT.UnderBonnetChecksDefectsComments;
            ExistingMOT.UnderVehichleChecksDefectsComments = MOT.UnderVehichleChecksDefectsComments;
            ExistingMOT.EmissionsDefectsComments = MOT.EmissionsDefectsComments;
            ExistingMOT.BrakePerformanceDefectComments = MOT.BrakePerformanceDefectComments;

            if (ModelState.IsValid)
            {
                db.SaveChanges();

                var Vehicle = db.Vehicles.Find(ExistingMOT.VehicleId);

                var message = string.Format("MOT updated for vehicle {0}", Vehicle.ToString());
                TempData["Message"] = message;

                return RedirectToAction("View", new { ExistingMOT.Id });
            }

            return View(MOT);
        }

        private void PopulateMOTSelections(MOT MOT, FormCollection formCollection)
        {
            const string suffix = "Switch";

            MOT.SeatsAndSeatBelts = PassFailHelper.GetSwitchSelection(formCollection["SeatsAndSeatBelts" + suffix]);
            MOT.WarningLamps = PassFailHelper.GetSwitchSelection(formCollection["WarningLamps" + suffix]);
            MOT.Switches = PassFailHelper.GetSwitchSelection(formCollection["Switches" + suffix]);
            MOT.FrontViewWipersWashers = PassFailHelper.GetSwitchSelection(formCollection["FrontViewWipersWashers" + suffix]);
            MOT.BrakeControlsServo = PassFailHelper.GetSwitchSelection(formCollection["BrakeControlsServo" + suffix]);
            MOT.SteeringWheelAndColumn = PassFailHelper.GetSwitchSelection(formCollection["SteeringWheelAndColumn" + suffix]);
            MOT.DoorsMirrorsHorn = PassFailHelper.GetSwitchSelection(formCollection["DoorsMirrorsHorn" + suffix]);
            MOT.SpeedometerDriverControls = PassFailHelper.GetSwitchSelection(formCollection["SpeedometerDriverControls" + suffix]);
            MOT.RegistrationPlates = PassFailHelper.GetSwitchSelection(formCollection["RegistrationPlates" + suffix]);
            MOT.LampsAndRegistrationPlateLamps = PassFailHelper.GetSwitchSelection(formCollection["LampsAndRegistrationPlateLamps" + suffix]);
            MOT.IndicatorsHazards = PassFailHelper.GetSwitchSelection(formCollection["IndicatorsHazards" + suffix]);
            MOT.HeadlampsAndAim = PassFailHelper.GetSwitchSelection(formCollection["HeadlampsAndAim" + suffix]);
            MOT.StopLampsFogLampsReflectors = PassFailHelper.GetSwitchSelection(formCollection["StopLampsFogLampsReflectors" + suffix]);
            MOT.WheelsTyres = PassFailHelper.GetSwitchSelection(formCollection["WheelsTyres" + suffix]);
            MOT.ShockAbsorbers = PassFailHelper.GetSwitchSelection(formCollection["ShockAbsorbers" + suffix]);
            MOT.MirrorsWiperBladesFuelTankCap = PassFailHelper.GetSwitchSelection(formCollection["MirrorsWiperBladesFuelTankCap" + suffix]);
            MOT.Glazing = PassFailHelper.GetSwitchSelection(formCollection["Glazing" + suffix]);
            MOT.DoorsBootLidLoadingDoorsBonnet = PassFailHelper.GetSwitchSelection(formCollection["DoorsBootLidLoadingDoorsBonnet" + suffix]);
            MOT.Towbars = PassFailHelper.GetSwitchSelection(formCollection["Towbars" + suffix]);
            MOT.GeneralConditionOfBody = PassFailHelper.GetSwitchSelection(formCollection["GeneralConditionOfBody" + suffix]);
            MOT.VehicleStructure = PassFailHelper.GetSwitchSelection(formCollection["VehicleStructure" + suffix]);
            MOT.BrakingSystems = PassFailHelper.GetSwitchSelection(formCollection["BrakingSystems" + suffix]);
            MOT.ExhaustSystemsFuelSystem = PassFailHelper.GetSwitchSelection(formCollection["ExhaustSystemsFuelSystem" + suffix]);
            MOT.SpeedLimiter = PassFailHelper.GetSwitchSelection(formCollection["SpeedLimiter" + suffix]);
            MOT.SteeringAndPowerSterringComponents = PassFailHelper.GetSwitchSelection(formCollection["SteeringAndPowerSterringComponents" + suffix]);
            MOT.SuspensionComponents = PassFailHelper.GetSwitchSelection(formCollection["SuspensionComponents" + suffix]);
            MOT.SteeringIncludingPowerSteering = PassFailHelper.GetSwitchSelection(formCollection["SteeringIncludingPowerSteering" + suffix]);
            MOT.DriveShafts = PassFailHelper.GetSwitchSelection(formCollection["DriveShafts" + suffix]);
            MOT.SuspensionShockAbsorbers = PassFailHelper.GetSwitchSelection(formCollection["SuspensionShockAbsorbers" + suffix]);
            MOT.WheelBearings = PassFailHelper.GetSwitchSelection(formCollection["WheelBearings" + suffix]);
            MOT.WheelsAndTyres = PassFailHelper.GetSwitchSelection(formCollection["WheelsAndTyres" + suffix]);
            MOT.BrakeSystemsAndMechanicalComponents = PassFailHelper.GetSwitchSelection(formCollection["BrakeSystemsAndMechanicalComponents" + suffix]);
            MOT.ExhaustSystem = PassFailHelper.GetSwitchSelection(formCollection["ExhaustSystem" + suffix]);
            MOT.FuelSystemAndFuelTank = PassFailHelper.GetSwitchSelection(formCollection["FuelSystemAndFuelTank" + suffix]);
            MOT.StructureGeneralVehicleCondition = PassFailHelper.GetSwitchSelection(formCollection["StructureGeneralVehicleCondition" + suffix]);
            MOT.Emissions = PassFailHelper.GetSwitchSelection(formCollection["Emissions" + suffix]);
            MOT.BrakePerformance = PassFailHelper.GetSwitchSelection(formCollection["BrakePerformance" + suffix]);
        }

    }
}
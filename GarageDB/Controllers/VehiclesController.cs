using GarageDB.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageDB.Controllers
{
    [Authorize]
    public class VehiclesController : Controller
    {
        public ActionResult View(Guid Id)
        {
            var db = new GarageContext();

            var Vehicle = db.Vehicles.Find(Id);
            ViewBag.Customer = db.Customers.Find(Vehicle.CustomerId);

            return View(Vehicle);
        }

        [HttpGet]
        public ActionResult Add(Guid CustomerId)
        {
            var Vehicle = new Vehicle();
            Vehicle.CustomerId = CustomerId;
            return View(Vehicle);
        }

        [HttpPost]
        public ActionResult Add(Vehicle Vehicle)
        {
            var db = new GarageContext();

            var GarageId = ((ApplicationUser)HttpContext.Session["user"]).GarageId;

            var CompanyId = db.Garages.Where(o => o.Id == GarageId).First().CompanyId;

            Vehicle.CompanyId = CompanyId;

            db.Vehicles.Add(Vehicle);

            if (ModelState.IsValid)
            {
                db.SaveChanges();

                var message = string.Format("Vehicle {0} has been added", Vehicle.ToString());
                TempData["Message"] = message;

                return RedirectToAction("View", new { Vehicle.Id });
            }

            return View(Vehicle);
        }

        [HttpGet]
        public ActionResult Edit(Guid Id)
        {
            var db = new GarageContext();

            var Vehicle = db.Vehicles.Find(Id);

            return View(Vehicle);
        }

        [HttpPost]
        public ActionResult Edit(Vehicle Vehicle)
        {
            var db = new GarageContext();

            var ExistingVehicle = db.Vehicles.Find(Vehicle.Id);
            ExistingVehicle.RegistrationNumber = Vehicle.RegistrationNumber;
            ExistingVehicle.Colour = Vehicle.Colour;
            ExistingVehicle.Make = Vehicle.Make;
            ExistingVehicle.Model = Vehicle.Model;
            ExistingVehicle.VIN = Vehicle.VIN;
            ExistingVehicle.Updated = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.SaveChanges();

                var message = string.Format("Changes saved", Vehicle.ToString());
                TempData["Message"] = message;

                return RedirectToAction("View", new { Vehicle.Id });
            }

            return View(Vehicle);
        }

        public ActionResult Delete(Guid Id)
        {
            var db = new GarageContext();

            var Vehicle = db.Vehicles.Find(Id);

            Vehicle.Updated = DateTime.Now;
            Vehicle.Deleted = true;

            db.SaveChanges();

            var message = string.Format("Vehicle {0} has been deleted", Vehicle.ToString());
            TempData["Message"] = message;

            return RedirectToActionPermanent("View", "Customers", new { id = Vehicle.CustomerId });
        }

        public ActionResult _ReadVehicles([DataSourceRequest] DataSourceRequest request, Guid CustomerId)
        {
            var db = new GarageContext();

            var results = db.Vehicles.Where(
            o => o.CustomerId == CustomerId
                && o.Deleted == false);

            results.OrderBy(o => o.ToString());

            return Json(results.ToDataSourceResult(request));
        }

        public ActionResult _ReadVehicleEntries([DataSourceRequest] DataSourceRequest request, Guid Id)
        {
            var GarageId = ((ApplicationUser)HttpContext.Session["user"]).GarageId;
            var db = new GarageContext();
            var CompanyId = db.Garages.Where(o => o.Id == GarageId).First().CompanyId;

            var results = new List<EntryViewModel>();

            var MOTs = db.MOTs.Where(
                o => o.CompanyId == CompanyId
                && o.Deleted == false
                && o.VehicleId == Id);

            foreach (var item in MOTs)
            {
                results.Add(new EntryViewModel { Id = item.Id, Title = item.PassText + " MOT", ResultType = Enums.EntryType.MOT, Date = item.TestDateAndTime, Colour = item.Colour });
            }

            var VehicleServices = db.VehicleServices.Where(
                o => o.CompanyId == CompanyId
                && o.Deleted == false
                && o.VehicleId == Id);

            foreach (var item in VehicleServices)
            {
                results.Add(new EntryViewModel { Id = item.Id, Title = item.ServiceType.ToString() + " service", ResultType = Enums.EntryType.Service, Date = item.ServiceDateAndTime, Colour = RowColour.lightblue });
            }

            results = results.OrderByDescending(o => o.Date).ToList();

            return Json(results.ToDataSourceResult(request));
        }

        public ActionResult OpenEntry(Guid Id)
        {
            using (var db = new GarageContext())
            {
                var MOT = db.MOTs.Find(Id);
                if (MOT != null)
                {
                    return RedirectToAction("View", "MOTs", new { Id });
                }

                var VehicleService = db.VehicleServices.Find(Id);
                if (VehicleService != null)
                {
                    switch (VehicleService.ServiceType)
                    {
                        case Enums.ServiceType.Interim:
                            return RedirectToAction("Interim", "Servicing", new { Id });
                        case Enums.ServiceType.Full:
                            return RedirectToAction("Full", "Servicing", new { Id });
                        case Enums.ServiceType.Major:
                            return RedirectToAction("Major", "Servicing", new { Id });
                        default:
                            throw new IndexOutOfRangeException(Helpers.ErrorCodeHelper.FormatErrorMessage("G1001", "Unable to open entry. Please try again or contact support with this error."));
                    }
                }
            }

            throw new IndexOutOfRangeException(Helpers.ErrorCodeHelper.FormatErrorMessage("G1001", "Unable to open entry. Please try again or contact support with this error."));
        }
    }
}
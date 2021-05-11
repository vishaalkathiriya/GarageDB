using GarageDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageDB.Controllers
{
    [Authorize]
    public class GaragesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var GarageId = ((ApplicationUser)HttpContext.Session["user"]).GarageId;

            var db = new GarageContext();

            var Garage = db.Garages.Find(GarageId);

            return View(Garage);
        }

        [HttpPost]
        public ActionResult Edit(Garage Garage)
        {
            var db = new GarageContext();

            var ExistingGarage = db.Garages.Find(Garage.Id);
            ExistingGarage.Name = Garage.Name;
            ExistingGarage.TelephoneNumber = Garage.TelephoneNumber;
            ExistingGarage.Address = Garage.Address;
            ExistingGarage.Postcode = Garage.Postcode;
            ExistingGarage.Email = Garage.Email;
            ExistingGarage.Updated = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.SaveChanges();

                var message = string.Format("Changes saved", Garage.Name);
                TempData["Message"] = message;

                return RedirectToAction("Index", "Search");
            }

            return View(Garage);
        }

    }
}
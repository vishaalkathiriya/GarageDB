using GarageDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageDB.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        public ActionResult View(Guid Id)
        {
            var loggedInUser = ((ApplicationUser)HttpContext.Session["user"]);

            var db = new GarageContext();

            var Customer = db.Customers.Find(Id);

            var auditLogEntry = new AuditLogEntry(Customer.CompanyId, Enums.EntryType.Customer, Enums.AuditLogAction.Viewed, loggedInUser.Id, Customer.Id);

            db.AuditLog.Add(auditLogEntry);

            db.SaveChanges();

            return View(Customer);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var Customer = new Customer();
            return View(Customer);
        }

        [HttpPost]
        public ActionResult Add(Customer Customer)
        {
            var loggedInUser = ((ApplicationUser)HttpContext.Session["user"]);

            var db = new GarageContext();

            var GarageId = loggedInUser.GarageId;

            var CompanyId = db.Garages.Where(o => o.Id == GarageId).First().CompanyId;

            var auditLogEntry = new AuditLogEntry(CompanyId, Enums.EntryType.Customer, Enums.AuditLogAction.Added, loggedInUser.Id, Customer.Id);

            db.AuditLog.Add(auditLogEntry);

            Customer.CompanyId = CompanyId;

            db.Customers.Add(Customer);

            if (ModelState.IsValid)
            {
                db.SaveChanges();

                var message = string.Format("Customer {0} has been added", Customer.Name);
                TempData["Message"] = message;

                return RedirectToAction("View", new { Customer.Id });
            }

            return View(Customer);
        }

        [HttpGet]
        public ActionResult Edit(Guid Id)
        {
            var db = new GarageContext();

            var Customer = db.Customers.Find(Id);

            return View(Customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer Customer)
        {
            var loggedInUser = ((ApplicationUser)HttpContext.Session["user"]);

            var db = new GarageContext();

            var ExistingCustomer = db.Customers.Find(Customer.Id);
            ExistingCustomer.Name = Customer.Name;
            ExistingCustomer.TelephoneNumber = Customer.TelephoneNumber;
            ExistingCustomer.Address = Customer.Address;
            ExistingCustomer.Postcode = Customer.Postcode;
            ExistingCustomer.Email = Customer.Email;
            ExistingCustomer.Updated = DateTime.Now;

            var auditLogEntry = new AuditLogEntry(Customer.CompanyId, Enums.EntryType.Customer, Enums.AuditLogAction.Edited, loggedInUser.Id, Customer.Id);

            db.AuditLog.Add(auditLogEntry);

            if (ModelState.IsValid)
            {
                db.SaveChanges();

                var message = string.Format("Changes saved", Customer.Name);
                TempData["Message"] = message;

                return RedirectToAction("View", new { Customer.Id });
            }

            return View(Customer);
        }

        public ActionResult Delete(Guid Id)
        {
            var loggedInUser = ((ApplicationUser)HttpContext.Session["user"]);

            var db = new GarageContext();

            var Customer = db.Customers.Find(Id);

            Customer.Updated = DateTime.Now;
            Customer.Deleted = true;

            var auditLogEntry = new AuditLogEntry(Customer.CompanyId, Enums.EntryType.Customer, Enums.AuditLogAction.Deleted, loggedInUser.Id, Customer.Id);

            db.AuditLog.Add(auditLogEntry);

            db.SaveChanges();

            var message = string.Format("Customer {0} has been deleted", Customer.Name);
            TempData["Message"] = message;

            return RedirectPermanent("~/Search");
        }

        public JsonResult GetCustomers(string Search)
        {
            var db = new GarageContext();

            var GarageId = ((ApplicationUser)HttpContext.Session["user"]).GarageId;

            var CompanyId = db.Garages.Find(GarageId).CompanyId;

            if (Search.Length >= Constants.SearchMinimumLength)
            {
                var customers = SearchController.CustomerSearch(db, CompanyId, Search.ToLower()).Select(o => new { Id = o.Id, Name = o.Name });

                return Json(customers, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var customers = db.Customers.Join(db.AuditLog, cus => cus.Id, aud => aud.EntryId, (cus, aud) => cus).Where(o => o.CompanyId == CompanyId && o.Deleted == false).Take(10);

                return Json(customers, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
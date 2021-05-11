using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageDB.Controllers
{
    [Authorize]
    public class InvoicingController : Controller
    {
        public ActionResult View(Guid Id)
        {
            var db = new GarageContext();

            var Invoice = db.Invoices.Find(Id);

            return View(Invoice);
        }
    }
}
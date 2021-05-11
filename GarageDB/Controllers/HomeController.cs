using MvcReportViewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageDB.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Search");
        }

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult TestPage()
        {
            return this.Report(
                ReportFormat.Pdf,
                new ReportsController().GetReportPath("TestPage"));
        }
    }
}
using GarageDB.Models;
using MvcReportViewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageDB.Controllers
{
    public class ReportsController : Controller
    {
        public string GetReportPath(Guid companyId, string ReportName)
        {
            var db = new GarageContext();
            var company = db.Companies.Find(companyId);
            string path = System.Web.Configuration.WebConfigurationManager.AppSettings["SSRSEnvironment"];

            Report report = db.Reports.Where(r =>
                r.Name == ReportName
                && (r.CompanyId == null || (r.CompanyId != null && r.CompanyId == companyId))).FirstOrDefault();

            if (report != null)
            {
                path += string.Concat(System.Web.Configuration.WebConfigurationManager.AppSettings["SSRSPracticeReportPathPrefix"], @"/", company.Id.ToString(), @"/");
            }

            path += ReportName;

            return path;
        }

        public string GetReportPath(string ReportName)
        {
            var db = new GarageContext();
            string path = System.Web.Configuration.WebConfigurationManager.AppSettings["SSRSEnvironment"];

            path += ReportName;

            return path;
        }

        public ActionResult ExportToPDF(string ReportName)
        {
            var db = new GarageContext();
            var garageId = ((ApplicationUser)HttpContext.Session["user"]).GarageId;
            var companyId = db.Garages.Find(garageId).CompanyId;

            return this.Report(
                ReportFormat.Pdf,
                new ReportsController().GetReportPath(companyId, ReportName),
                new { companyId = companyId });
        }
    }
}
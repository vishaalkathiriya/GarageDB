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
    public class SearchController : Controller
    {
        public ActionResult Index(string Search)
        {
            List<EntryViewModel> results = Find(Search);

            ViewBag.SearchText = Search;

            return View(results);
        }

        public ActionResult _ReadSearch([DataSourceRequest] DataSourceRequest request, string Search)
        {
            List<EntryViewModel> results = Find(Search);

            return Json(results.ToDataSourceResult(request));
        }

        private List<EntryViewModel> Find(string Search)
        {
            var GarageId = ((ApplicationUser)HttpContext.Session["user"]).GarageId;
            var db = new GarageContext();
            var CompanyId = db.Garages.Where(o => o.Id == GarageId).First().CompanyId;

            var results = new List<EntryViewModel>();
            if (Search != null)
            {
                var searchToLower = Search.ToLower();
                IQueryable<Customer> customerResults = CustomerSearch(db, CompanyId, searchToLower);

                var vehicleResults = db.Vehicles.Where(
                    o => o.CompanyId == CompanyId
                    && o.Deleted == false
                    && (o.RegistrationNumber.ToLower().Contains(searchToLower)
                    || o.VIN.ToLower().Contains(searchToLower)));

                foreach (var item in customerResults)
                {
                    results.Add(new EntryViewModel { Id = item.Id, Title = item.ToString(), ResultType = Enums.EntryType.Customer, Colour = RowColour.white });
                }

                foreach (var item in vehicleResults)
                {
                    results.Add(new EntryViewModel { Id = item.Id, Title = item.ToString(), ResultType = Enums.EntryType.Vehicle, Colour = RowColour.lightgray });
                }

                results.OrderBy(o => o.Title);
            }

            return results;
        }

        /// <summary>
        /// Customer search
        /// </summary>
        /// <param name="db"></param>
        /// <param name="CompanyId"></param>
        /// <param name="SearchTermToLower">All characters in string must be in lower case</param>
        /// <returns></returns>
        public static IQueryable<Customer> CustomerSearch(GarageContext db, Guid CompanyId, string SearchTermToLower)
        {
            return db.Customers.Where(
                o => o.CompanyId == CompanyId
                && o.Deleted == false
                && (o.Name.ToLower().Contains(SearchTermToLower)
                || o.Address.ToLower().Contains(SearchTermToLower)
                || o.Postcode.ToLower().Contains(SearchTermToLower)
                || o.TelephoneNumber.ToLower().Contains(SearchTermToLower)
                || o.Email.ToLower().Contains(SearchTermToLower)));
        }

        public ActionResult OpenEntry(Guid Id)
        {
            using (var db = new GarageContext())
            {
                Customer customer = db.Customers.Find(Id);
                if (customer != null)
                {
                    return RedirectToAction("View", "Customers", new { Id });
                }

                Vehicle vehicle = db.Vehicles.Find(Id);
                if (vehicle != null)
                {
                    return RedirectToAction("View", "Vehicles", new { Id });
                }
            }

            throw new IndexOutOfRangeException(Helpers.ErrorCodeHelper.FormatErrorMessage("G1001", "Unable to open entry. Please try again or contact support with this error."));
        }
    }
}
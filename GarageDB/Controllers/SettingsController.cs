using GarageDB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageDB.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
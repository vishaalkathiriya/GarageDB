using Microsoft.AspNet.Identity.EntityFramework;
using StaffMembers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffMembers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();

            var staff = db.StaffMembers;

            return View();
        }

        public ActionResult AddTestData()
        {
            var db = new ApplicationDbContext();

            if (db.StaffRoles.Where(o => o.Name == "Admin").Count() < 1)
            {
                db.StaffRoles.Add(new StaffRole() { Name = "Admin" });
                db.SaveChanges();
            }

            if (db.StaffMembers.Where(o => o.Name == "ScottyAdmin").Count() < 1)
            {
                var staffRoles = db.StaffRoles.Where(o => o.Name == "Admin");

                var staffMember = new StaffMember() { Name = "ScottyAdmin", GarageId = Guid.NewGuid() };
                staffMember.StaffRoles = staffRoles.ToList();

                db.StaffMembers.Add(staffMember);

                db.SaveChanges();
            }

            return View();
        }
    }
}
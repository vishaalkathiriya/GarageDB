using GarageDB.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageDB.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Calendar");
        }

        public ActionResult Calendar(DateTime? Start)
        {
            if (HttpContext.Session["user"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            GarageContext db = new GarageContext();

            var GarageId = ((ApplicationUser)HttpContext.Session["user"]).GarageId;

            var CompanyId = db.Garages.Where(o => o.Id == GarageId).First().CompanyId;

            var appointments = new List<Schedule>();

            if (Start.HasValue)
            {
                ViewBag.Start = Start.Value.Date;
            }

            return View(appointments);
        }

        public virtual JsonResult ReadSchedule([DataSourceRequest] DataSourceRequest request)
        {
            var loggedInUser = ((ApplicationUser)HttpContext.Session["user"]);

            Guid GarageId = loggedInUser.GarageId;

            using (GarageContext db = new GarageContext())
            {
                var CompanyId = db.Garages.Where(o => o.Id == GarageId).First().CompanyId;
                DateTime startCutOff = DateTime.Now.AddMonths(-2);
                List<Appointment> appointments = db.Appointments.Where(a => a.Deleted == false && a.CompanyId == CompanyId && a.Start > startCutOff).ToList();
                var customers = db.Customers.Where(o => o.CompanyId == CompanyId);
                List<Schedule> schedules = new List<Schedule>();

                foreach (Appointment appointment in appointments)
                {
                    schedules.Add(new Schedule
                    {
                        Id = appointment.Id,
                        CustomerId = appointment.CustomerId.ToString(),
                        customer = appointment.CustomerId != Guid.Empty ? customers.Single(o => o.Id == appointment.CustomerId).Name : appointment.Title,
                        Title = appointment.Title,
                        Description = appointment.Notes,
                        Start = appointment.Start,
                        End = appointment.End,
                        ReminderSent = appointment.ReminderSent,
                        StaffMember = appointment.StaffMember != null ? appointment.StaffMember.Id.ToString() : Guid.Empty.ToString(),
                        AppointmentType = appointment.AppointmentStatus != null ? appointment.AppointmentStatus.Value.ToString() : null
                        //, ReminderSentByUserName = appointment.ReminderSentByUserName,
                        //SendReminderMessages = appointment.customer != null ? appointment.customer.SendReminderMessages : false,
                        //ShowArrivedButton = appointment.ShowArrivedButton,
                        //StatusEnum = appointment.StatusEnum,
                        //DefaultAppointmentLength = appointment.appointmentType != null ? appointment.appointmentType.DefaultAppointmentLength : 30,
                    });
                }

                return Json(schedules.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
        }

        public virtual JsonResult CreateSchedule([DataSourceRequest] DataSourceRequest request, Schedule schedule)
        {
            var loggedInUser = ((ApplicationUser)HttpContext.Session["user"]);

            GarageContext db = new GarageContext();

            List<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();

            if (errors.Count() > 0)
            {
                ViewBag.Error = Helpers.ErrorCodeHelper.FormatErrorMessage("G1003", "Unable to create appointment due to validation errors");
                //todo: display error
                //todo: low priority - save error to the database
            }
            else if (schedule != null)
            {
                Garage garage = db.Garages.Find(loggedInUser.GarageId);
                Appointment appointment = new Models.Appointment();
                schedule.Id = Guid.NewGuid();
                appointment.Id = schedule.Id;
                appointment.Start = schedule.Start;
                TimeSpan endTime = schedule.End - schedule.End.Date;
                schedule.End = schedule.Start.Date + endTime;
                appointment.End = schedule.End;
                appointment.Notes = schedule.Description;

                if (schedule.customer != null)
                {
                    Guid customerId;
                    if (Guid.TryParse(schedule.customer, out customerId))
                    {
                        var customer = db.Customers.Find(customerId);
                        appointment.CustomerId = customer.Id;
                        customer.Updated = DateTime.Now;
                        schedule.Title = customer.Name;
                    }
                    else
                    {
                        schedule.Title = schedule.customer;
                    }
                }
                else
                {
                    schedule.Title = "appointment";
                }

                appointment.Title = schedule.Title;
                appointment.CompanyId = garage.CompanyId;
                appointment.Notes = schedule.Description;
                appointment.AppointmentStatus = schedule.StatusEnum;
                if (schedule.AppointmentType != null && schedule.AppointmentType.Length > 0)
                {
                    appointment.WorkType = (Enums.WorkTypeEnum)Enum.Parse(typeof(Enums.WorkTypeEnum), schedule.AppointmentType);
                    switch (appointment.WorkType)
                    {
                        case Enums.WorkTypeEnum.Service:
                            appointment.End = appointment.Start.AddMinutes(Constants.ServiceDefaultMinutes);
                            break;
                        case Enums.WorkTypeEnum.MOT:
                            appointment.End = appointment.Start.AddMinutes(Constants.MOTDefaultMinutes);
                            break;
                        case Enums.WorkTypeEnum.Repair:
                            appointment.End = appointment.Start.AddMinutes(Constants.RepairDefaultMinutes);
                            break;
                        default:
                            break;
                    }
                }
                if (schedule.StaffMember != null && schedule.StaffMember.Length > 0 && new Guid(schedule.StaffMember) != Guid.Empty)
                {
                    appointment.StaffMember = db.StaffMembers.Find(new Guid(schedule.StaffMember));
                }
                if (db.Appointments.Find(appointment.Id) == null)
                {
                    db.Appointments.Add(appointment);
                }

                var auditLogEntry = new AuditLogEntry(garage.CompanyId, Enums.EntryType.Calendar, Enums.AuditLogAction.Added, loggedInUser.Id, appointment.Id);
                db.AuditLog.Add(auditLogEntry);

                db.SaveChanges();
            }
            else
            {
                ViewBag.Error = Helpers.ErrorCodeHelper.FormatErrorMessage("G1003", "Unable to create appointment");
                //todo: display error
            }

            return Json(new[] { schedule }.ToDataSourceResult(request));
        }

        public virtual JsonResult UpdateSchedule([DataSourceRequest] DataSourceRequest request, Schedule schedule)
        {
            GarageContext db = new GarageContext();

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            Guid? newCustomerId = null;

            if (errors.Count() > 0)
            {
                ViewBag.Error = Helpers.ErrorCodeHelper.FormatErrorMessage("G1004", "Unable to edit appointment");
                //todo: low priority - save error to the database
                //todo: display error on popup dialog
            }
            else if (schedule.Id != Guid.Empty)
            {
                Appointment target = db.Appointments.Find(schedule.Id);
                target.Start = schedule.Start;
                target.End = schedule.End;
                target.Notes = schedule.Description;

                if (schedule.CustomerId != null && schedule.CustomerId.Length > 0)
                {
                    Guid customerId;
                    if (Guid.TryParse(schedule.CustomerId, out customerId))
                    {
                        if (new Guid(schedule.CustomerId) != Guid.Empty)
                        {
                            var customer = db.Customers.Find(new Guid(schedule.CustomerId));
                            target.CustomerId = customer.Id;
                            customer.Updated = DateTime.Now;
                            schedule.Title = customer.Name;
                        }
                        else
                        {
                            //customerId is empty guid therefore new customer
                            newCustomerId = Guid.NewGuid();
                        }
                    }
                    else if (schedule.Title != schedule.CustomerId)
                    {
                        schedule.Title = schedule.CustomerId;
                        //Customer cust = target.Customer; //setting the customer to null in the next line does not work without this. for some reason, target.customer has to be read before it can be set to null.
                        //target.Customer = null;
                    }
                }
                else
                {
                    schedule.Title = "";
                }

                target.Title = schedule.Title;
                //if (schedule.StatusEnum == Enums.AppointmentStatus.Arrived && target.StatusEnum != Enums.AppointmentStatus.Arrived)
                //{
                //    target.Arrived = DateTime.Now;
                //    target.ArrivedUserSet = db.ApplicationUsers.Find(((ApplicationUser)HttpContext.Session["user"]).Id);
                //}
                //target.StatusEnum = schedule.StatusEnum;
                //if (schedule.appointmentType != null && schedule.appointmentType.Length > 0 && new Guid(schedule.appointmentType) != Guid.Empty)
                //{
                //    target.appointmentType = db.AppointmentTypes.Find(new Guid(schedule.appointmentType));
                //    target.End = target.Start.AddMinutes(db.AppointmentTypes.Find(new Guid(schedule.appointmentType)).DefaultAppointmentLength);
                //}
                //else
                //{
                //    target.appointmentType = null;
                //}
                //if (schedule.StaffMember != null && schedule.StaffMember.Length > 0 && new Guid(schedule.StaffMember) != Guid.Empty)
                //{
                //    target.StaffMember = db.ApplicationUsers.Find(schedule.StaffMember);
                //}
                //else
                //{
                //    target.appointmentType = null;
                //}
                db.Entry(target).State = EntityState.Modified;
                db.SaveChanges();

                if (newCustomerId != null)
                {
                    //redirect doesn't work
                    //return RedirectToActionPermanent("Add", "Customers", new { Id = newCustomerId });
                }
            }
            else
            {
                ViewBag.Error = Helpers.ErrorCodeHelper.FormatErrorMessage("G1004", "Unable to edit appointment");
            }

            return Json(new[] { schedule }.ToDataSourceResult(request, ModelState));

        }

        public virtual JsonResult DestroySchedule([DataSourceRequest] DataSourceRequest request, Schedule schedule)
        {
            if (schedule != null)
            {
                if (schedule.Id != Guid.Empty)
                {
                    using (GarageContext dbContext = new GarageContext())
                    {
                        Appointment appointment = dbContext.Appointments.Where(x => x.Id == schedule.Id).FirstOrDefault();
                        appointment.Deleted = true;
                        appointment.Updated = DateTime.Now;
                        appointment.DeletedByUserId = ((ApplicationUser)HttpContext.Session["user"]).Id;
                        dbContext.Entry(appointment).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
            }

            return Json(new[] { schedule }.ToDataSourceResult(request, ModelState));
        }

        public JsonResult GetAppointmentStatuses()
        {
            GarageContext db = new GarageContext();

            var AppointmentStatuses = new List<AppointmentStatus>();
            AppointmentStatuses.Add(new AppointmentStatus { Id = 0, Name = Constants.NotSelectedText });
            AppointmentStatuses.AddRange(db.AppointmentStatuses.OrderBy(a => a.Id).ToList());

            return Json(AppointmentStatuses, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStaffMembers()
        {
            GarageContext db = new GarageContext();
            Guid garageId = ((ApplicationUser)HttpContext.Session["user"]).GarageId;

            var StaffMembers = new List<StaffMember>();
            StaffMembers.Add(new StaffMember { Id = Guid.Empty, Name = Constants.NotSelectedText });
            StaffMembers.AddRange(db.StaffMembers.Where(o => o.GarageId == garageId && o.Deleted == false).OrderBy(o => o.Name).ToList().Select(o => new StaffMember { Id = o.Id, Name = o.Name }));

            return Json(StaffMembers, JsonRequestBehavior.AllowGet);
        }
    }
}
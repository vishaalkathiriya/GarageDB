using GarageDB.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace GarageDB
{
    public class GarageContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<Colour> Colours { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<ErrorCode> ErrorCodes { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Garage> Garages { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        public DbSet<LicenceKey> LicenceKeys { get; set; }

        public DbSet<MakeModel> MakesAndModels { get; set; }

        public DbSet<MOT> MOTs { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Reminder> Reminders { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleService> VehicleServices { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<WorkType> WorkTypes { get; set; }

        public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }

        public DbSet<StaffMember> StaffMembers { get; set; }

        public DbSet<StaffRole> StaffRoles { get; set; }

        public DbSet<AuditLogEntry> AuditLog { get; set; }

        static GarageContext()
        {
            Database.SetInitializer<GarageContext>(null);
        }

        //map model to specific table
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers"); //without this ApplicationUser model is automatically mapped to ApplicationUsers
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}
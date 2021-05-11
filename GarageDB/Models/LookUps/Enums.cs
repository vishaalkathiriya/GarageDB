using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Enums
    {
        public enum WorkTypeEnum
        {
            Service = 1,
            MOT = 2,
            Repair = 3
        }

        public enum ReminderType
        {
            Service = 1,
            MOT = 2
        }

        public enum TagType
        {
            Service = 1,
            Product = 2
        }

        public enum AppointmentStatusEnum
        {
            Booked = 1,
            Arrived = 2,
            Cancelled = 3,
            Rebooked = 4,
            [Description("No show")]
            No_show = 5
        }

        public enum TicketPriority
        {
            High = 1,
            Medium = 2,
            Low = 3
        }

        public enum TicketType
        {
            Task = 1,
            Bug_fix = 2,
            Feature = 3
        }

        public enum TicketStatus
        {
            New = 1,
            In_Progress = 2,
            Complete = 3
        }

        public enum EntryType
        {
            Customer = 1,
            Vehicle = 2,
            MOT = 3,
            Service = 4,
            Calendar = 5,
            Account = 6
        }

        public enum ServiceType
        {
            Interim = 1,
            Full = 2,
            Major = 3
        }

        public enum StaffRoleEnum
        {
            Servicing = 1,
            [Description("MOT tester")]
            MOT_tester = 2,
            Receptionist = 3,
            [Description("Full access")]
            Full_access = 5
        }

        public enum AuditLogAction
        {
            Viewed = 1,
            Added = 2,
            Edited = 3,
            Deleted = 4,
            Login = 5
        }
    }
}
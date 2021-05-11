using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Appointment : ClientRow
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public Guid CustomerId { get; set; }

        [MaxLength(2000)]
        public string Notes { get; set; }

        [DisplayName("Reminder sent")]
        public DateTime? ReminderSent { get; set; }

        public DateTime? Arrived { get; set; }

        [DisplayName("Status")]
        public Enums.AppointmentStatusEnum? AppointmentStatus { get; set; }

        [DisplayName("Service / MOT / repair")]
        public Enums.WorkTypeEnum? WorkType { get; set; }

        public virtual StaffMember StaffMember { get; set; }

        [DisplayName("Station")]
        [MaxLength(50)]
        public string StationName { get; set; }
    }
}
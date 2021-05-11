using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Reminder : ClientRow
    {
        public DateTime When { get; set; }

        public Enums.ReminderType Type { get; set; }

        public Guid CustomerId { get; set; }
    }
}
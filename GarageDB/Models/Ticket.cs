using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Ticket : ClientRow
    {
        [MinLength(128), MaxLength(128)]
        public string ClientUserId { get; set; }

        public string SupportPersonUsername { get; set; }

        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? Due { get; set; }

        public Enums.TicketPriority Priority { get; set; }

        public Enums.TicketType Type { get; set; }

        public Enums.TicketStatus Status { get; set; }
    }
}
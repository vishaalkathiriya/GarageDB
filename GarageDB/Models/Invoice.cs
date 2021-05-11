using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Invoice : ClientRow
    {
        public Guid GarageId { get; set; }

        [DisplayName("Date")]
        [Required]
        public DateTime InvoiceDate { get; set; }

        public string InvoiceNumber { get; set; }

        public string Notes { get; set; }
    }
}
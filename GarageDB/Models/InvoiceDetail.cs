using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class InvoiceDetail : ClientRow
    {
        public Guid InvoiceId { get; set; }

        public Guid CustomerId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [DisplayName("Price")]
        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
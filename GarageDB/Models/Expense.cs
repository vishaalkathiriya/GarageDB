using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Expense : ClientRow
    {
        [DisplayName("Date")]
        public DateTime ExpenseDate { get; set; }

        public Guid GarageId { get; set; }

        [Required]
        public string Payee { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public string ReferenceNumber { get; set; }

        [DisplayName("VAT Rate")]
        public decimal VATRate { get; set; }
    }
}
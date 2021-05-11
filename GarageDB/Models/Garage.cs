using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Garage : TableRow
    {
        public Guid CompanyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        [DisplayName("Tel")]
        public string TelephoneNumber { get; set; }

        public string Email { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
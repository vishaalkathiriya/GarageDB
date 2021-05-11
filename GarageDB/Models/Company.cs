using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Company : TableRow
    {
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

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
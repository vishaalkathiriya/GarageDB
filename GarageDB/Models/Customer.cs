using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Customer : ClientRow
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Postcode { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Tel")]
        public string TelephoneNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public override string ToString()
        {
            return string.Concat(Name, " ", Address, " ", Postcode, " ", TelephoneNumber);
        }
    }
}
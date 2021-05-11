using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Vehicle : ClientRow
    {
        public Guid CustomerId { get; set; }

        [Required]
        [DisplayName("Reg")]
        public string RegistrationNumber { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public string Colour { get; set; }

        public string VIN { get; set; }

        public override string ToString()
        {
            return string.Concat(Make, " ", Model, " ", RegistrationNumber, " ", Colour).Trim();
        }

        public string ToStringProperty
        {
            get
            {
                return ToString();
            }
        }
    }
}
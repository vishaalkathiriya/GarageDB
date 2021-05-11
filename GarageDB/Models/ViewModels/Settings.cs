using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageDB.Models.ViewModels
{
    public class Settings
    {
        [Key]
        public Guid GarageId { get; set; }

        [Required]
        [DisplayName("Garage name")]
        public string GarageName { get; set; }

        [Required]
        [DisplayName("Garage address")]
        public string GarageAddress { get; set; }

        [Required]
        [DisplayName("Garage postcode")]
        public string GaragePostcode { get; set; }

        [Required]
        [DisplayName("Garage tel")]
        public string GarageTelephoneNumber { get; set; }

        [DisplayName("Garage email")]
        public string GarageEmail { get; set; }

        [Required]
        [DisplayName("Company name")]
        public string CompanyName { get; set; }

        [Required]
        [DisplayName("Company address")]
        public string CompanyAddress { get; set; }

        [Required]
        [DisplayName("Company postcode")]
        public string CompanyPostcode { get; set; }

        [Required]
        [DisplayName("Company tel")]
        public string CompanyTelephoneNumber { get; set; }

        [DisplayName("Company email")]
        public string CompanyEmail { get; set; }
    }
}
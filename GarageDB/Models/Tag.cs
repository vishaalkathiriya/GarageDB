
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Tag : TableRow
    {
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// If null, tag is for all companies
        /// </summary>
        public Guid? CompanyId { get; set; }

        [DisplayName("Type")]
        public Enums.TagType TagTypeEnum { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
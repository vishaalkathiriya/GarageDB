using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Attachment : ClientRow
    {
        public Guid CustomerId { get; set; }

        [Required]
        public string Filename { get; set; }

        public string Comment { get; set; }

        public string InternalFilename
        {
            get
            {
                return string.Concat(base.Id.ToString(), "_", Filename); 
            }
        }
    }
}
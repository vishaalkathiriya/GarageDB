using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace GarageDB.Models
{
    public class StaffMember : ClientRow
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public Guid GarageId { get; set; }

        public virtual ICollection<StaffRole> StaffRoles { get; set; }
    }
}
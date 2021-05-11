using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StaffMembers.Models
{
    public class StaffMember
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public Guid GarageId { get; set; }

        public virtual ICollection<StaffRole> StaffRoles { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace GarageDB.Models
{
    public class StaffRole : EnumBase
    {
        public virtual ICollection<StaffMember> StaffMembers { get; set; }
    }
}
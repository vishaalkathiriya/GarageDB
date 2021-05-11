using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    /// <summary>
    /// Database records that are only created by users
    /// </summary>
    public abstract class ClientRow : TableRow
    {
        [MinLength(128), MaxLength(128)]
        public string AddedByUserId { get; set; }

        [MinLength(128), MaxLength(128)]
        public string DeletedByUserId { get; set; }

        public Guid CompanyId { get; set; }
    }
}
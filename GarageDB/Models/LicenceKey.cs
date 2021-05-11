using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    /// <summary>
    /// GarageDB licence keys
    /// </summary>
    public class LicenceKey : TableRow
    {
        public Guid GarageId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Report
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public bool IsCustom { get; set; }
        public string DisplayName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class AuditLogEntry : TableRow
    {
        [MaxLength(128)]
        public string AddedByUserId { get; set; }

        [MaxLength(128)]
        public string DeletedByUserId { get; set; }

        public Guid? CompanyId { get; set; }

        public Enums.EntryType EntryType { get; set; }

        public Enums.AuditLogAction AuditLogAction { get; set; }

        public Guid? EntryId { get; set; }

        public AuditLogEntry(Guid? CompanyId, Enums.EntryType EntryType, Enums.AuditLogAction AuditLogAction, string LoggedInUserId, Guid? EntryId)
        {
            this.CompanyId = CompanyId;
            this.EntryType = EntryType;
            this.AuditLogAction = AuditLogAction;
            this.AddedByUserId = LoggedInUserId;
            this.EntryId = EntryId;
        }
    }
}
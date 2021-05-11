using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class ErrorCode : TableRow
    {
        [Index("IX_ErrorCode", IsUnique = true)]
        [StringLength(5)]
        public string Code { get; set; }

        public string Description { get; set; }

        public string Solution { get; set; }
    }
}
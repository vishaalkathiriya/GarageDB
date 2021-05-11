using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class MakeModel : TableRow
    {
        [Index("IX_MakeModel", 1, IsUnique = true)]
        [StringLength(30)]
        public string Make { get; set; }

        [Index("IX_MakeModel", 2, IsUnique = true)]
        [StringLength(30)]
        public string Model { get; set; }

        public override string ToString()
        {
            return string.Concat(Make, " ", Model);
        }
    }
}
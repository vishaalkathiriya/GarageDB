using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Colour : TableRow
    {
        [Index("IX_Colour", IsUnique = true)]
        [StringLength(30)]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
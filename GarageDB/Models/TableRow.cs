using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public abstract class TableRow
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Added { get; set; }

        public DateTime Updated { get; set; }

        public bool Deleted { get; set; }

        public TableRow()
        {
            Id = Guid.NewGuid();
            Added = DateTime.Now;
            Updated = DateTime.Now;
            Deleted = false;
        }
    }
}
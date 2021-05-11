using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Note : ClientRow
    {
        public int CustomerId { get; set; }
        public string Text { get; set; }
    }
}
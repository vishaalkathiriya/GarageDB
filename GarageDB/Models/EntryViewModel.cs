using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class EntryViewModel
    {
        public EntryViewModel()
        {
            Colour = RowColour.white;
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public Enums.EntryType ResultType { get; set; }

        public DateTime? Date { get; set; }

        public string DateToString
        {
            get
            {
                if (Date.HasValue)
                {
                    return Date.Value.ToShortDateString() + " " + Date.Value.ToShortTimeString();
                }
                else
                {
                    return "";
                }
            }
        }

        public string Colour { get; set; }
    }
}
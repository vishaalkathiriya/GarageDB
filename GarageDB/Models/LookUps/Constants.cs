using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageDB.Models
{
    public class Constants
    {
        public const string RecordDateFormat = "dd/MM/yyyy HH:mm";

        public const string CheckedText = "checked";

        public const int ServiceDefaultMinutes = 60;

        public const int MOTDefaultMinutes = 45;

        public const int RepairDefaultMinutes = 60;

        public const int SearchMinimumLength = 3;

        /// <summary>
        /// Text to use for not selected option. E.g. in staff member drop down list on appointment pop up.
        /// </summary>
        public const string NotSelectedText = "";
    }
}
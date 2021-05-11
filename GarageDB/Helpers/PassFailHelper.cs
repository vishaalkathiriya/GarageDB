using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageDB.Helpers
{
    public class PassFailHelper
    {
        public static string GetPassFailGlyphHtml(bool? Pass)
        {
            if (Pass.HasValue == false)
            {
                return @"<span class=""glyphicon glyphicon-minus orange-text"" aria-hidden=""true""></span>";
            }
            else if (Pass.Value)
            {
                return @"<span class=""glyphicon glyphicon-ok green-text"" aria-hidden=""true""></span>";
            }
            else
            {
                return @"<span class=""glyphicon glyphicon-remove red-text"" aria-hidden=""true""></span>";
            }
        }

        public static bool GetSwitchSelection(object Input)
        {
            if (Input != null && Input.GetType() == String.Empty.GetType())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetCheckedAttribute(bool? Option)
        {
            return Option.HasValue && Option.Value ? Models.Constants.CheckedText : "";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageDB.Helpers
{
    public class ErrorCodeHelper
    {
        public static string FormatErrorMessage(string ErrorCode, string Message)
        {
            return string.Format("Error: {0} {1}", ErrorCode, Message);
        }
    }
}
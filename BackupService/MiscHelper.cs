using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupService
{
    class MiscHelper
    {
        const string defaultFormat = "dd_MM_yyyy";

        public static string GetDateString(string format = defaultFormat)
        {
            return DateTime.Now.ToString(format);
        }

        public static DateTime StringToDate(string dateString, string format = defaultFormat)
        {
            return DateTime.ParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture);
        }

        public static bool StringIsDate(string dateString, string format = defaultFormat)
        {
            try
            {
                StringToDate(dateString, format);
            }
            catch (FormatException)
            {
                return false;
            }
            return true;
        }
    }
}

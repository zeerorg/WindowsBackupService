using System;
using System.Runtime.Serialization;

namespace BackupLib
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

        [Serializable]
        public class EntityExistsException : Exception
        {
            internal EntityExistsException() { }
            internal EntityExistsException(string message) : base(message) { }
            internal EntityExistsException(string message, Exception inner) : base(message, inner) { }
            protected EntityExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        }

        [Serializable]
        public class EntityNotFoundException : Exception
        {
            internal EntityNotFoundException() { }
            internal EntityNotFoundException(string message) : base(message) { }
            internal EntityNotFoundException(string message, Exception inner) : base(message, inner) { }
            protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        }
    }
}

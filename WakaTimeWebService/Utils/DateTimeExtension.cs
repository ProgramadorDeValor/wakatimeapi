using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WakaTimeWebService.Utils
{
    public static class DateTimeExtension
    {
        public static string ToIsoString(this DateTime dateTime)
        {
            return dateTime.ToString("o", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}

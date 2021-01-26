using System;

namespace WakaTimeWebService.Utils
{
    public static class StringExtension
    {
        public static string ToBase64(this string baseString)
        {
            byte[] bytesStr = System.Text.Encoding.UTF8.GetBytes(baseString);
            return Convert.ToBase64String(bytesStr);
        }
    }
}

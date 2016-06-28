
using System;
using System.Text.RegularExpressions;

namespace WhenToDig90.Helpers
{
    public static class Strings
    {
        public static string BuildKey(string[] items)
        {
            var key = String.Join(string.Empty, items).ToLowerInvariant();
            return Regex.Replace(key, "[^0-9a-z]", string.Empty);
        }
    }
}

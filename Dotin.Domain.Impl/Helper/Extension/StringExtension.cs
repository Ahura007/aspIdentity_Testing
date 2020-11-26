using System.Collections.Generic;

namespace Dotin.HostApi.Domain.Helper.Extension
{
    public static class StringExtension
    {
        public static List<string> ReturnList(this string message)
        {
            return new List<string> { message };
        }
    }
}
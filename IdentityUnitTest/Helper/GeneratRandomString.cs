using System;
using System.Linq;

namespace IdentityUnitTest.Helper
{
    public static class RandomData
    {
        private static readonly Random Random = new Random();

        public static string StringGenerator()
        {
            var length = Random.Next(1, 20);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static int IntGenerate()
        {
            return Random.Next(100000000, 999999999);
        }
    }
}
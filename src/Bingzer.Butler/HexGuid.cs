using System;
using System.Linq;

namespace Bingzer.Butler
{
    public static class HexGuid
    {
        private const int Digits = 8;
        private static readonly Random Random = new Random();

        public static string GenerateUniqueId()
        {
            var buffer = new byte[Digits / 2];
            Random.NextBytes(buffer);
            var result = string.Concat(buffer.Select(x => x.ToString("X2")).ToArray());

            return result + Random.Next(16).ToString("X");
        }
    }
}

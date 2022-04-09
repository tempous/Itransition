using System;
using System.Security.Cryptography;
using System.Text;

namespace HMAC
{
    class Generator
    {
        const byte SIZE = 256 / 8;

        public static string GenerateKey()
        {
            var key = new byte[SIZE];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(key);
            return BitConverter.ToString(key).Replace("-", "");
        }
    }
}

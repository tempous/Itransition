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

        public static string GenerateHMAC(string key, string move)
        {
            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(move));
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}

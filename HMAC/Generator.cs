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
            RandomNumberGenerator.Create().GetBytes(key);
            return GetStringFromBytes(key);
        }

        public static string GenerateHMAC(string key, string message)
        {
            var hash = new HMACSHA256(GetStringBytes(key)).ComputeHash(GetStringBytes(message));
            return GetStringFromBytes(hash);
        }

        static byte[] GetStringBytes(string message) => Encoding.UTF8.GetBytes(message);

        static string GetStringFromBytes(byte[] bytes) => BitConverter.ToString(bytes).Replace("-", "");
    }
}

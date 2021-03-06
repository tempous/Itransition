using SHA3.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Itransition
{
    class Program
    {
        static string GetHash(Sha3 sha3256, byte[] bytes) => BitConverter.ToString(sha3256.ComputeHash(bytes)).Replace("-", "").ToLower();

        static void Main(string[] args)
        {
            var hashes = new List<string>();
            var email = "test@gmail.com";

            using (var sha3256 = Sha3.Sha3256())
            {
                foreach (var file in Directory.EnumerateFiles("R:\\task2"))
                    hashes.Add(GetHash(sha3256, File.ReadAllBytes(file)));
                
                Console.WriteLine("Generated hashes: " + hashes.Count);
                foreach (var hash in hashes)
                    Console.WriteLine(hash);

                hashes.Sort();
                Console.WriteLine("\nSorted hashes: " + hashes.Count);
                foreach (var hash in hashes)
                    Console.WriteLine(hash);

                string result = string.Join("", hashes) + email;
                Console.WriteLine("\nResult hash:");
                Console.WriteLine(GetHash(sha3256, Encoding.UTF8.GetBytes(result)));
            }
        }
    }
}

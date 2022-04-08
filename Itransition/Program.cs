using SHA3.Net;
using System;
using System.Collections.Generic;
using System.IO;

namespace Itransition
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashes = new List<string>();
            string email = "test@gmail.com";
            var result = "";

            using (var sha3256 = Sha3.Sha3256())
            {
                foreach (var file in Directory.EnumerateFiles("R:\\task2"))
                {
                    Console.WriteLine(file);
                    hashes.Add(BitConverter.ToString(sha3256.ComputeHash(File.ReadAllBytes(file))).Replace("-", "").ToLower());
                }

                Console.WriteLine("Generated hashes: " + hashes.Count);
                foreach (var hash in hashes)
                    Console.WriteLine(hash);

                Console.WriteLine();
                Console.WriteLine("Sorted hashes: " + hashes.Count);
                hashes.Sort();
                foreach (var hash in hashes)
                {
                    Console.WriteLine(hash);
                    result += hash;
                }

                result += email;
            }
        }
    }
}

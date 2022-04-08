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

            using (var sha3256 = Sha3.Sha3256())
            {
                foreach (var file in Directory.EnumerateFiles("R:\\task2"))
                {
                    Console.WriteLine(file);
                    Console.WriteLine(BitConverter.ToString(sha3256.ComputeHash(File.ReadAllBytes(file))));
                }
            }
        }
    }
}

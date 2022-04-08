using System;
using System.IO;

namespace Itransition
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var file in Directory.EnumerateFiles("R:\\task2"))
                Console.WriteLine(file);
        }
    }
}

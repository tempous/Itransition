using System;
using System.Linq;

namespace HMAC
{
    class Program
    {
        static void Main(string[] arguments)
        {
            var args = arguments.Distinct();
            var argCount = args.Count();

            if (argCount < 3 || argCount % 2 == 0)
                Console.WriteLine("Incorrect number of arguments - less than 3 or even!");
        }
    }
}

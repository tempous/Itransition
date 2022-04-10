﻿using System;
using System.Linq;

namespace HMAC
{
    class Program
    {
        static void Main(string[] args)
        {
            //var moves = args.Distinct().ToArray();
            var moves = new string[] { "rock", "paper", "scissors", "lizard", "spock", "bear", "fish" };
            var moveCount = moves.Count();

            if (moveCount < 3 || moveCount % 2 == 0)
                Console.WriteLine("Incorrect number of arguments - less than 3 or even!");
            else
            {
                var key = Generator.GenerateKey();
                var computerNumber = Generator.GenerateRandomIntNumber(moveCount);
                var computerMove = moves[computerNumber];
                var hmac = Generator.GenerateHMAC(key, computerMove);
                Console.WriteLine($"Computer HMAC: {hmac}");
            }
        }
    }
}

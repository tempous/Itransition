using System;
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

                Console.WriteLine("Menu: available moves:");
                for (int i = 0; i < moveCount; i++)
                    Console.WriteLine($" {i + 1} - {moves[i]}");
                Console.WriteLine(" 0 - [exit]");
                Console.WriteLine("-1 - [help]");

                var playerNumber = 0;
                var isCorrect = false;

                while (!isCorrect)
                {
                    Console.Write($"Enter your move [-1..{moveCount}]: ");
                    isCorrect = int.TryParse(Console.ReadLine(), out playerNumber);
                    if (isCorrect) isCorrect = (playerNumber < -1 || playerNumber > moveCount) ? false : true;
                }

                if (playerNumber == 0)
                {
                    Console.WriteLine("Exit: game over");
                    return;
                }
                else
                {
                    var rules = Rules.Generate(moves);
                    var ruleTable = Table.Create(moves, rules);

                    if (playerNumber == -1)
                    {
                        Console.WriteLine("Help: rule table");
                        Rules.GetWinPositions(rules);
                        Table.Print();
                    }
                    else
                    {
                        var playerMove = moves[playerNumber - 1];
                        Console.WriteLine($"Your move: {playerMove}");
                        Console.WriteLine($"Computer move: {computerMove}");
                        Console.WriteLine($"Status: {ruleTable[computerNumber + 1, playerNumber]}");
                        Console.WriteLine($"Computer HMAC key: {key}");
                    }
                }
            }
        }
    }
}

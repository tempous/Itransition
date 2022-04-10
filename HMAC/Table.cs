using System;
using System.Collections.Generic;

namespace HMAC
{
    class Table
    {
        public static string[,] ruleTable;
        static int size;

        static string GetStatus(Dictionary<int, List<int>> rules, int i, int j)
        {
            return rules[i].Contains(j) ? "Win" : "Lose";
        }

        public static string[,] Create(string[] moves, Dictionary<int, List<int>> rules)
        {
            size = moves.Length + 1;
            ruleTable = new string[size, size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (i == 0)
                        ruleTable[i, j] = (j == 0) ? "" : moves[j - 1];
                    else
                        ruleTable[i, j] = (j == 0) ? moves[i - 1] : ((i == j) ? "Draw" : GetStatus(rules, i-1, j-1));

            return ruleTable;
        }

        public static void Print()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write(ruleTable[i, j].PadRight((j == 0) ? 15 : 10));

                Console.WriteLine();
            }
        }
    }
}

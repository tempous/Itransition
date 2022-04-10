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
    }
}

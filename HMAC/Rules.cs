using System;
using System.Collections.Generic;

namespace HMAC
{
    class Rules
    {
        public static Dictionary<int, List<int>> Generate(string[] moves)
        {
            Dictionary<int, List<int>> rules = new();

            var moveCount = moves.Length;
            var offset = (moveCount- 1) / 2;

            for (int i = 0; i < moveCount; i++)
            {
                var winPositions = new List<int>();

                for (int j = i + 1; j <= i + offset; j++)
                    winPositions.Add(j % moveCount);

                rules.Add(i, winPositions);
            }

            return rules;
        }
    }
}

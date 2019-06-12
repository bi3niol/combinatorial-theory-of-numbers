using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombinatorialTheoryOfNumbers.LibDotNet.AdvancedStrategy
{
    public class AdvancedPlayer2 : IPlayer2<int, int>
    {
        Dictionary<int, List<int>> helperDict = new Dictionary<int, List<int>>();
        static Random random = new Random();
        public void Clear()
        {
            //does nothing
        }

        public int Move(IGameState<int, int> gameState, int player1Reuslt)
        {
            int maxLength = int.MinValue;
            helperDict.Clear();

            for (int c = 0; c < gameState.PossibleColors; c++)
            {
                var coloredNumbers = gameState.GetColoredSubset(c);
                coloredNumbers.Add(player1Reuslt);
                int length = Helpers.GetLengthOfLongestArithmeticSubsequence(coloredNumbers.ToList());
                if (length > maxLength)
                    maxLength = length;

                if (helperDict.ContainsKey(length))
                    helperDict[length].Add(c);
                else
                    helperDict.Add(length, new List<int> { c });
            }

            var res = helperDict.Where(kp => kp.Key != maxLength).SelectMany(kp => kp.Value).ToArray();

            if (res.Length == 0)
                res = helperDict.SelectMany(kp => kp.Value).ToArray();

            return res[random.Next(res.Length)];
        }
    }
}

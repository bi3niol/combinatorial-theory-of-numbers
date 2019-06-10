using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombinatorialTheoryOfNumbers.LibDotNet.AdvancedStrategy
{
    public class AdvancedPlayer2 : IPlayer2<int, int>
    {
        public void Clear()
        {
            //does nothing
        }

        public int Move(IGameState<int, int> gameState, int player1Reuslt)
        {
            int minColor = 0;
            int minLength = int.MaxValue;
            for (int c = 0; c < gameState.PossibleColors; c++)
            {
                var coloredNumbers = gameState.GetColoredSubset(c);
                coloredNumbers.Add(player1Reuslt);
                int length = Helpers.GetLengthOfLongestArithmeticSubsequence(coloredNumbers.ToList());
                if (length < minLength)
                {
                    minLength = length;
                    minColor = c;
                }
            }
            return minColor;
        }
    }
}

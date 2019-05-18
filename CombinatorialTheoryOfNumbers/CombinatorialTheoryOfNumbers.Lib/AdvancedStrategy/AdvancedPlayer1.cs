using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombinatorialTheoryOfNumbers.Lib.AdvancedStrategy
{
    public class AdvancedPlayer1 : IPlayer1<int, int>
    {
        private int _maxChosen = 0;
        public void Clear()
        {
            _maxChosen = 0;
        }

        public int Move(IGameState<int, int> gameState)
        {
            int maxLength = 0, chosenNumber = 0;
            for(int i = 0; i < gameState.MaxGameLength && i < gameState.TargetSeriesLength * (_maxChosen + 1); i++)
            {
                if(gameState[i] == -1)
                {
                    for (int c = 0; c < gameState.PossibleColors; c++)
                    {
                        var coloredNumbers = gameState.GetColoredSubset(c);
                        coloredNumbers.Add(i);
                        int length = Helpers.GetLengthOfLongestArithmeticSubsequence(coloredNumbers.ToList());
                        if (length > maxLength)
                        {
                            maxLength = length;
                            chosenNumber = i;
                        }
                    }
                }
            }
            if(chosenNumber > _maxChosen)
            {
                _maxChosen = chosenNumber;
            }
            return chosenNumber;
        }
    }
}

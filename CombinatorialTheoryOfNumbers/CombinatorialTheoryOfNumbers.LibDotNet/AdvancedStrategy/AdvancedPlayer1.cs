using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombinatorialTheoryOfNumbers.LibDotNet.AdvancedStrategy
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
            foreach(var num in gameState.AvailableNumbers)
            {
                for (int c = 0; c < gameState.PossibleColors; c++)
                {
                    var coloredNumbers = gameState.GetColoredSubset(c);
                    coloredNumbers.Add(num);
                    int length = Helpers.GetLengthOfLongestArithmeticSubsequence(coloredNumbers.ToList());
                    if (length > maxLength)
                    {
                        maxLength = length;
                        chosenNumber = num;
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

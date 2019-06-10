using CombinatorialTheoryOfNumbers.LibDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.LibDotNet.RandomStrategy
{
    public class ManualPlayer2 : IPlayer2<int, int>
    {
        public void Clear()
        {
        }

        public int Move(IGameState<int, int> gameState, int player1Reuslt)
        {
            bool successfulRead = false;
            int chosenNumber = 0;
            do
            {
                Console.WriteLine($"Pick an integer from 0-{gameState.PossibleColors - 1} range");
                successfulRead = int.TryParse(Console.ReadLine(), out chosenNumber);
            } while (!successfulRead || chosenNumber < 0 || chosenNumber >= gameState.PossibleColors);
            return chosenNumber;
        }
    }
}

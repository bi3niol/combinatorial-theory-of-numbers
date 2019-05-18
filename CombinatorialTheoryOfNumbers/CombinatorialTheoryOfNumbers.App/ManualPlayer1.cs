using CombinatorialTheoryOfNumbers.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.App
{
    public class ManualPlayer1 : IPlayer1<int, int>
    {
        public void Clear()
        {
            // does nothing
        }

        public int Move(IGameState<int, int> gameState)
        {
            bool successfulRead = false;
            int chosenNumber = 0;
            do
            {
                Console.WriteLine("Pick a non-negative integer");
                successfulRead = int.TryParse(Console.ReadLine(), out chosenNumber);
            } while (!successfulRead || !NumberIsValid(gameState, chosenNumber));
            return chosenNumber;
        }

        public bool NumberIsValid(IGameState<int, int> gameState, int number)
        {
            if(gameState[number] != -1)
            {
                Console.WriteLine($"{number} is already colored");
                return false;
            }
            return number >= 0;
        }
    }
}

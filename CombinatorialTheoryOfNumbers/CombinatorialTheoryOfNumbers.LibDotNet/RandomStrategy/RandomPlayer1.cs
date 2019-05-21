using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.LibDotNet.RandomStrategy
{
    public class RandomPlayer1 : IPlayer1<int, int>
    {
        private int _randomSeed;
        private Random _rng;

        public RandomPlayer1(int randomSeed)
        {
            _randomSeed = randomSeed;
            _rng = new Random(_randomSeed);
            Clear();
        }

        public void Clear()
        {
            
        }

        public int Move(IGameState<int, int> gameState)
        {
            int index = _rng.Next(gameState.AvailableNumbers.Count);
            int chosen = gameState.AvailableNumbers[index];

            return chosen;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.LibDotNet.RandomStrategy
{
    public class RandomPlayer2 : IPlayer2<int, int>
    {
        private int _randomSeed;
        private Random _rng;

        public RandomPlayer2(int randomSeed)
        {
            _randomSeed = randomSeed;
            _rng = new Random(_randomSeed);
            Clear();
        }

        public void Clear()
        {
            
        }

        public int Move(IGameState<int, int> gameState, int player1Reuslt)
        {
            return _rng.Next(gameState.PossibleColors);
        }
    }
}

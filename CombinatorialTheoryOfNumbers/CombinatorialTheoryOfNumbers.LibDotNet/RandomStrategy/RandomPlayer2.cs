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
            Clear();
        }
        public void Clear()
        {
            _rng = new Random(_randomSeed);
        }

        public int Move(IGameState<int, int> gameState, int player1Reuslt)
        {
            return _rng.Next(gameState.PossibleColors-1);
        }
    }
}

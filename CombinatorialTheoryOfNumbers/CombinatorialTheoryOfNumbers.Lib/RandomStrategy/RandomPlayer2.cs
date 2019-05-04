using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.Lib.RandomStrategy
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
            int color = -1;
            do
            {
                color = _rng.Next(gameState.PossibleColors);
            } while (gameState[player1Reuslt - 1] == color || gameState[player1Reuslt + 1] == color);
            return color;
        }
    }
}

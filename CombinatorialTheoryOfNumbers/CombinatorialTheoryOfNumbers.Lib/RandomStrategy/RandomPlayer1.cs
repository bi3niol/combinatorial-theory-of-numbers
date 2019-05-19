﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.Lib.RandomStrategy
{
    public class RandomPlayer1 : IPlayer1<int, int>
    {
        private int _randomSeed;
        private Random _rng;

        public RandomPlayer1(int randomSeed)
        {
            _randomSeed = randomSeed;
            Clear();
        }

        public void Clear()
        {
            _rng = new Random(_randomSeed);
        }

        public int Move(IGameState<int, int> gameState)
        {
            int index = _rng.Next(gameState.AvailableNumbers.Count-1);
            int chosen = gameState.AvailableNumbers[index];

            return chosen;
        }
    }
}

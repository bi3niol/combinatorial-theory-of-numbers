using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.Lib.LinearStrategy
{
    public class LinearPlayer2 : IPlayer2<int, int>
    {
        private int _lastColor;

        public LinearPlayer2()
        {
            Clear();
        }

        public void Clear()
        {
            _lastColor = 0;
        }

        public int Move(IGameState<int, int> gameState, int player1Reuslt)
        {
            int chosen = _lastColor;
            _lastColor = (_lastColor + 1) % gameState.PossibleColors;
            return chosen;
        }
    }
}

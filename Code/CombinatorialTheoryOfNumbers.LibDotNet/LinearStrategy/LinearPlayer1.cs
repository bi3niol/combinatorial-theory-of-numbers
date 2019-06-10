using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.LibDotNet.LinearStrategy
{
    public class LinearPlayer1 : IPlayer1<int, int>
    {
        private int _lastIndex;

        public LinearPlayer1()
        {
            Clear();
        }

        public void Clear()
        {
            _lastIndex = 0;
        }

        public int Move(IGameState<int, int> gameState)
        {
            return _lastIndex++;
        }
    }
}

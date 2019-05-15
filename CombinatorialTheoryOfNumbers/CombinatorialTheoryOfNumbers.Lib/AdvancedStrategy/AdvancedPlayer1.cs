using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.Lib.AdvancedStrategy
{
    public class AdvancedPlayer1 : IPlayer1<int, int>
    {
        public void Clear()
        {
            //does nothing
        }

        public int Move(IGameState<int, int> gameState)
        {
            throw new NotImplementedException();
        }
    }
}

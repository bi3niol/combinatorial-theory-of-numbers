using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.Lib
{
    public interface IPlayer1<P1Res, P2Res>
    {
        P1Res Move(IGameState<P1Res, P2Res> gameState);
    }
}

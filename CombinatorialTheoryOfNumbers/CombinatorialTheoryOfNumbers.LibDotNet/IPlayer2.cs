using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.LibDotNet
{
    public interface IPlayer2<P1Res, P2Res>:IPlayer
    {
        P2Res Move(IGameState<P1Res, P2Res> gameState, P1Res player1Reuslt);
    }
}

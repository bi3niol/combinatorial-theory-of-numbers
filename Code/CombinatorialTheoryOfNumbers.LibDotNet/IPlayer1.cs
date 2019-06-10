using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.LibDotNet
{
    public interface IPlayer1<P1Res, P2Res>: IPlayer
    {
        P1Res Move(IGameState<P1Res, P2Res> gameState);
    }
}

using System.Collections.Generic;

namespace CombinatorialTheoryOfNumbers.Lib
{
    public interface IGameState<P1Res, P2Res>
    {
        /// <summary>
        /// C
        /// </summary>
        int PossibleColors { get; }
        /// <summary>
        /// K
        /// </summary>
        int TargetSeriesLength { get; }
        /// <summary>
        /// L
        /// </summary>
        int MaxGameLength { get; }
        int CurrentRound { get; }
        P2Res this[int i] { get; }
        IEnumerable<RoundResult<P1Res,P2Res>> RoundResults { get; }

        bool HasWinner { get; }
        IPlayer Winner { get; }
        void NextTour(IPlayer1<P1Res, P2Res> P1, IPlayer2<P1Res, P2Res> P2);

        void Clear();
        void Clear(LaunchConfig config);
    }
}
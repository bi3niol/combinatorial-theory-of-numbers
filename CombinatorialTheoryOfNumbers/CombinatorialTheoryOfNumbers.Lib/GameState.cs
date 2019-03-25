using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.Lib
{
    internal class GameState : IGameState<int, int>
    {
        public int this[int i] {
            get {
                if (_RoundResults.ContainsKey(i))
                    return _RoundResults[i].Player2Result;

                return -1;
            }
            set {
                _RoundResults[i] = new RoundResult<int, int>()
                {
                    Player2Result = value,
                    Player1Result = i
                };
            }
        }

        public int PossibleColors { get; set; }

        public int TargetSeriesLength { get; set; }

        public int MaxGameLength { get; set; }

        public int CurrentRound { get; set; }

        public IReadOnlyList<RoundResult<int, int>> RoundResults => new List<RoundResult<int, int>>(_RoundResults.Values);

        private SortedList<int, RoundResult<int, int>> _RoundResults { get; set; } = new SortedList<int, RoundResult<int, int>>();

        internal static GameState FromConfig(LaunchConfig config)
        {
            return new GameState
            {
                MaxGameLength = config.L,
                PossibleColors = config.C,
                TargetSeriesLength = config.K
            };
        }
    }
}

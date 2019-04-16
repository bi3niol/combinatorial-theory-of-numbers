using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.Lib
{
    internal class GameState : IGameState<int, int>
    {
        public int this[int i]
        {
            get
            {
                if (_RoundResults.ContainsKey(i))
                    return _RoundResults[i].Player2Result;

                return -1;
            }
            set
            {
                _RoundResults.Add(i, new RoundResult<int, int>()
                {
                    Player2Result = value,
                    Player1Result = i
                });
            }
        }

        public int PossibleColors { get; private set; }

        public int TargetSeriesLength { get; private set; }

        public int MaxGameLength { get; private set; }

        public int CurrentRound { get; private set; }

        public IEnumerable<RoundResult<int, int>> RoundResults => _RoundResults.Values;

        public bool HasWinner { get; private set; }

        public IPlayer Winner { get; private set; }

        private SortedList<int, RoundResult<int, int>> _RoundResults { get; set; } = new SortedList<int, RoundResult<int, int>>();

        public void NextTour(IPlayer1<int, int> P1, IPlayer2<int, int> P2)
        {
            int p1res = P1.Move(this);
            this[p1res] = P2.Move(this, p1res);
        }

        public void Clear()
        {
            Winner = null;
            HasWinner = false;
            _RoundResults.Clear();
        }

        public void Clear(LaunchConfig config)
        {
            MaxGameLength = config.L;
            PossibleColors = config.C;
            TargetSeriesLength = config.K;
            Clear();
        }
    }
}

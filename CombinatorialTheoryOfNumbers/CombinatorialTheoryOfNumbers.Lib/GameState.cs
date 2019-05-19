using System;
using System.Collections.Generic;
using System.Linq;

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
                if (_ColoredNumbers.ContainsKey(value))
                    _ColoredNumbers[value].Add(i);
                else
                    _ColoredNumbers[value] = new SortedSet<int>(new[] { i });
            }
        }

        public int PossibleColors { get; private set; }

        public int TargetSeriesLength { get; private set; }

        public int MaxGameLength { get; private set; }

        public int CurrentRound { get; private set; }

        public IEnumerable<RoundResult<int, int>> RoundResults => _RoundResults.Values;

        public IReadOnlyList<int> AvailableNumbers => _AvailableNumbers;

        public bool HasWinner { get; private set; }

        public IPlayer Winner { get; private set; }

        private SortedList<int, RoundResult<int, int>> _RoundResults { get; set; } = new SortedList<int, RoundResult<int, int>>();

        private List<int> _AvailableNumbers { get; set; } = new List<int>();

        private Dictionary<int, SortedSet<int>> _ColoredNumbers = new Dictionary<int, SortedSet<int>>();

        public SortedSet<int> GetColoredSubset(int color)
        {
            if (_ColoredNumbers.ContainsKey(color))
                return new SortedSet<int>(_ColoredNumbers[color]);
            return new SortedSet<int>();
        }

        public void NextTour(IPlayer1<int, int> P1, IPlayer2<int, int> P2)
        {
            int p1res = P1.Move(this);
            int chosenColor = this[p1res] = P2.Move(this, p1res);
            _AvailableNumbers.Remove(p1res);

            var coloredNumbers = GetColoredSubset(chosenColor);
            if (Helpers.GetLengthOfLongestArithmeticSubsequence(coloredNumbers.ToList()) >= TargetSeriesLength)
            {
                Winner = P1;
                HasWinner = true;
            }
            else if (_RoundResults.Count >= MaxGameLength)
            {
                Winner = P2;
                HasWinner = true;
            }
        }

        public void Clear()
        {
            Winner = null;
            HasWinner = false;
            _RoundResults.Clear();
            foreach (var colored in _ColoredNumbers)
                colored.Value.Clear();

            _AvailableNumbers.Clear();
            _AvailableNumbers.AddRange(Enumerable.Range(0, MaxGameLength));
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

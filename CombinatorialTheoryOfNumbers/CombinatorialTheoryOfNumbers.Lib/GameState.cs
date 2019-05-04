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
            var coloredNumbers = RoundResults
                .Where(r => r.Player2Result == this[p1res])
                .Select(r => r.Player1Result)
                .ToArray();
            if (FindLengthOfLongestMonochromaticSequence(coloredNumbers) == TargetSeriesLength)
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
        }

        public void Clear(LaunchConfig config)
        {
            MaxGameLength = config.L;
            PossibleColors = config.C;
            TargetSeriesLength = config.K;
            Clear();
        }

        private int FindLengthOfLongestMonochromaticSequence(int[] coloredNumbers)
        {
            if(coloredNumbers.Length <= 2)
            {
                return coloredNumbers.Length;
            }
            int max = 2;
            int[] lengths = new int[coloredNumbers.Length];
            for(int i = 0; i < lengths.Length; i++)
            {
                lengths[i] = 2;
            }
            for(int i = lengths.Length - 2; i >= 0; i--)
            {
                int left = i - 1;
                int right = i + 1;
                while(left >= 0 && right < lengths.Length)
                {
                    if(coloredNumbers[left] + coloredNumbers[right] == 2 * coloredNumbers[i])
                    {
                        lengths[i] = Math.Max(lengths[right] + 1, lengths[i]);
                        max = Math.Max(max, lengths[i]);
                        left--;
                        right++;
                    }
                    else if(coloredNumbers[left] + coloredNumbers[right] < 2 * coloredNumbers[i])
                    {
                        right++;
                    }
                    else
                    {
                        left--;
                    }
                }
            }
            return max;
        }
    }
}

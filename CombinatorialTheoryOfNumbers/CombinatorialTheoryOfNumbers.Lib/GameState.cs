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
            if (FindLengthOfLongestMonochromaticSequence() == TargetSeriesLength)
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

        private int FindLengthOfLongestMonochromaticSequence()
        {
            if(_RoundResults.Count <= 2)
            {
                return _RoundResults.Count;
            }
            int[] lengths = new int[_RoundResults.Count];
            for(int i = 0; i < lengths.Length; i++)
            {
                lengths[i] = 2;
            }
            int max = 2;
            for(int i = lengths.Length - 2; i >= 0; i--)
            {
                int left = i - 1, right = i + 1;
                while (left >= 0 && right < lengths.Length)
                {
                    int leftKey = _RoundResults.Keys[left], rightKey = _RoundResults.Keys[right],
                        midKey = _RoundResults.Keys[i];
                    if(leftKey + rightKey == 2 * midKey &&
                        this[leftKey] == this[rightKey] && 
                        this[leftKey] == this[midKey] &&
                        this[midKey] != -1)
                    {
                        lengths[i] = Math.Max(lengths[left], lengths[i] + 1);
                        max = Math.Max(lengths[i], max);
                        left--;
                        right++;
                    }
                    else if(leftKey + rightKey < 2 * midKey)
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

using CombinatorialTheoryOfNumbers.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.App
{
    public class LongStatePresenter : IStatePresenter<int, int>
    {
        public void ShowState(IGameState<int, int> state)
        {
            foreach (var result in state.RoundResults)
            {
                Console.Write("{0}:{1} ", result.Player1Result, result.Player2Result);
            }
            Console.WriteLine();
        }
    }
}

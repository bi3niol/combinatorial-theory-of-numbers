using CombinatorialTheoryOfNumbers.LibDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CombinatorialTheoryOfNumbers.AppDotNet
{
    public class LongStatePresenter : IStatePresenter<int, int>
    {
        StreamWriter stream;

        public LongStatePresenter()
        {

        }

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

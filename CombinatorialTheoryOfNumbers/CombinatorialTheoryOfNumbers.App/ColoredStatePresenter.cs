using CombinatorialTheoryOfNumbers.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.App
{
    public class ColoredStatePresenter : IStatePresenter<int, int>
    {
        private readonly ConsoleColor[] ForegroundColors = new ConsoleColor[]
        {
            ConsoleColor.Red,
            ConsoleColor.Blue,
            ConsoleColor.Green,
            ConsoleColor.Cyan,
            ConsoleColor.Magenta,
            ConsoleColor.Yellow,
            ConsoleColor.DarkYellow,
            ConsoleColor.White
        };

        public void ShowState(IGameState<int, int> state)
        {
            foreach(var result in state.RoundResults)
            {
                Console.ForegroundColor = ForegroundColors[result.Player2Result];
                Console.Write("{0} ", result.Player1Result);
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}

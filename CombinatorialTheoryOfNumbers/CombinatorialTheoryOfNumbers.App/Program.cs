using CombinatorialTheoryOfNumbers.Lib;
using System;
using System.Collections.Generic;

namespace CombinatorialTheoryOfNumbers.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IStatePresenter<int, int> presenter = null;
            List<IPlayer1<int, int>> P1s = new List<IPlayer1<int, int>>
            {
                //
            };
            List<IPlayer2<int, int>> P2s = new List<IPlayer2<int, int>>
            {
                //
            };
            List<LaunchConfig> configs = new List<LaunchConfig>()
            {
                //configs
            };
            foreach (var P1 in P1s)
            {
                foreach (var P2 in P2s)
                {
                    Game game = new Game(P1, P2, presenter);
                    foreach (var config in configs)
                    {
                        game.Init(config);
                        var winner = game.Run();
                    }
                }
            }
        }
    }
}

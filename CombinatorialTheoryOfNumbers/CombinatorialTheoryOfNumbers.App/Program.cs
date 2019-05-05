using CombinatorialTheoryOfNumbers.Lib;
using CombinatorialTheoryOfNumbers.Lib.LinearStrategy;
using CombinatorialTheoryOfNumbers.Lib.RandomStrategy;
using System;
using System.Collections.Generic;

namespace CombinatorialTheoryOfNumbers.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IStatePresenter<int, int> presenter = new ColoredStatePresenter();
            List<IPlayer1<int, int>> P1s = new List<IPlayer1<int, int>>
            {
                new RandomPlayer1(10),
                new LinearPlayer1()
            };
            List<IPlayer2<int, int>> P2s = new List<IPlayer2<int, int>>
            {
                new RandomPlayer2(100),
                new LinearPlayer2()
            };
            List<LaunchConfig> configs = new List<LaunchConfig>()
            {
                new LaunchConfig(k: 3, c: 2, l: 6)
            };
            foreach (var P1 in P1s)
            {
                foreach (var P2 in P2s)
                {
                    Console.WriteLine($"{P1.GetType().Name} vs {P2.GetType().Name}");
                    Game game = new Game(P1, P2, presenter);
                    foreach (var config in configs)
                    {
                        game.Init(config);
                        var winner = game.Run();
                        Console.WriteLine(winner.GetType().Name + " won!");
                    }
                }
            }
        }
    }
}

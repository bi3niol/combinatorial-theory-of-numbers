using CombinatorialTheoryOfNumbers.LibDotNet;
using CombinatorialTheoryOfNumbers.LibDotNet.AdvancedStrategy;
using CombinatorialTheoryOfNumbers.LibDotNet.LinearStrategy;
using CombinatorialTheoryOfNumbers.LibDotNet.RandomStrategy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CombinatorialTheoryOfNumbers.AppDotNet
{
    public struct TestPlayer
    {
        public string Type { get; set; }
        public int Seed { get; set; }

        [JsonConstructor]
        public TestPlayer(string type, int seed)
        {
            Type = type;
            Seed = seed;
        }

        public TestPlayer(string type) : this(type, 0) { }
    }

    public class Test
    {
        public string Presenter { get; }
        public TestPlayer Player1 { get; }
        public TestPlayer Player2 { get; }
        public int K { get; }
        public int C { get; }
        public int L { get; }
        public int Iterations { get; }

        [JsonConstructor]
        public Test(string presenter, TestPlayer player1, TestPlayer player2, int k, int c, int l, int iterations)
        {
            Presenter = presenter;
            Player1 = player1;
            Player2 = player2;
            K = k;
            C = c;
            L = l;
            Iterations = iterations;
        }

        public Test(string presenter, string player1Type, int player1Seed, string player2Type, int player2Seed, int k, int c, int l, int iterations)
        {
            Presenter = presenter;
            Player1 = new TestPlayer(player1Type, player1Seed);
            Player2 = new TestPlayer(player2Type, player2Seed);
            K = k;
            C = c;
            L = l;
            Iterations = iterations;
        }

        public Test(string presenter, string player1Type, string player2Type, int k, int c, int l, int iterations)
            : this(presenter, player1Type, 0, player2Type, 0, k, c, l, iterations) { }
        public Test(string presenter, string player1Type, int player1Seed, string player2Type, int k, int c, int l, int iterations)
            : this(presenter, player1Type, player1Seed, player2Type, 0, k, c, l, iterations) { }
        public Test(string presenter, string player1Type, string player2Type, int player2Seed, int k, int c, int l, int iterations)
            : this(presenter, player1Type, 0, player2Type, player2Seed, k, c, l, iterations) { }

        public IPlayer1<int, int> GetPlayer1()
        {
            switch (Player1.Type.ToLower())
            {
                case "advanced": return new AdvancedPlayer1();
                case "linear": return new LinearPlayer1();
                case "random": return new RandomPlayer1(Player1.Seed);
                case "manual": return new ManualPlayer1();
                default: return null;
            }
        }

        public IPlayer2<int, int> GetPlayer2()
        {
            switch (Player2.Type.ToLower())
            {
                case "advanced": return new AdvancedPlayer2();
                case "linear": return new LinearPlayer2();
                case "random": return new RandomPlayer2(Player2.Seed);
                case "manual": return new ManualPlayer2();
                default: return null;
            }
        }

        public IStatePresenter<int, int> GetStatePresenter()
        {
            switch (Presenter.ToLower())
            {
                case "colored": return new ColoredStatePresenter();
                case "long": return new LongStatePresenter();
            }
            return new EmptyStatePresenter();
        }

        public void Run(int testNo)
        {
            IPlayer1<int, int> P1 = GetPlayer1();
            IPlayer2<int, int> P2 = GetPlayer2();
            IStatePresenter<int, int> Pres = GetStatePresenter();

            if (P1 == null || P2 == null || Pres == null || Player1.Type == "manual" || Player2.Type == "manual")
            {
                for (int it = 0; it < Iterations; it++)
                {
                    Console.WriteLine($"{testNo} - Invalid test");
                }
                return;
            }

            Game game = new Game(P1, P2, Pres);
            LaunchConfig config = new LaunchConfig(K, C, L);
            for (int it = 0; it < Iterations; it++)
            {
                game.Init(config);
                IPlayer result = game.Run();
                Console.Write($"{testNo}, {Player1.Type}, {Player1.Seed}, {Player2.Type}, {Player2.Seed}, {K}, {C}, {L}, {result.GetType().Name}\n");
            }
        }

        public void Run()
        {
            IPlayer1<int, int> P1 = GetPlayer1();
            IPlayer2<int, int> P2 = GetPlayer2();
            IStatePresenter<int, int> Pres = GetStatePresenter();

            if (P1 == null || P2 == null || Pres == null)
            {
                for (int it = 0; it < Iterations; it++)
                {
                    Console.WriteLine($"Invalid arguments - cannot execute the test.");
                }
                return;
            }

            Game game = new Game(P1, P2, Pres);
            game.Init(new LaunchConfig(K, C, L));
            var winner = game.Run();
            Console.WriteLine(winner.GetType().Name + " won!");
        }
    }
}

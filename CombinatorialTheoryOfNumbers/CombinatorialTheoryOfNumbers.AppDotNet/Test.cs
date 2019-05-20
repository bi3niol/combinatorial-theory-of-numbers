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
        public TestPlayer Player1 { get; }
        public TestPlayer Player2 { get; }
        public int K { get; }
        public int C { get; }
        public int L { get; }

        [JsonConstructor]
        public Test(TestPlayer player1, TestPlayer player2, int k, int c, int l)
        {
            Player1 = player1;
            Player2 = player2;
            K = k;
            C = c;
            L = l;
        }

        public Test(string player1Type, int player1Seed, string player2Type, int player2Seed, int k, int c, int l)
        {
            Player1 = new TestPlayer(player1Type, player1Seed);
            Player2 = new TestPlayer(player2Type, player2Seed);
            K = k;
            C = c;
            L = l;
        }

        public Test(string player1Type, string player2Type, int k, int c, int l) : this(player1Type, 0, player2Type, 0, k, c, l) { }
        public Test(string player1Type, int player1Seed, string player2Type, int k, int c, int l) : this(player1Type, player1Seed, player2Type, 0, k, c, l) { }
        public Test(string player1Type, string player2Type, int player2Seed, int k, int c, int l) : this(player1Type, 0, player2Type, player2Seed, k, c, l) { }

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

        public IPlayer Run(IStatePresenter<int, int> presenter)
        {
            IPlayer1<int, int> P1 = GetPlayer1();
            IPlayer2<int, int> P2 = GetPlayer2();

            if (P1 == null || P2 == null)
                return null;

            Game game = new Game(P1, P2, presenter);
            game.Init(new LaunchConfig(K, C, L));
            return game.Run();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.Lib
{
    public sealed class Game
    {
        public IPlayer1<int,int> Player1 { get; set; }
        public IPlayer2<int,int> Player2 { get; set; }
        public IGameState<int, int> GameState => _GameState;

        private GameState _GameState { get; set; }

        public Game(IPlayer1<int,int> player1, IPlayer2<int,int> player2, LaunchConfig config)
        {
            Player1 = player1;
            Player2 = player2;
            _GameState = Lib.GameState.FromConfig(config);
        }
    }
}

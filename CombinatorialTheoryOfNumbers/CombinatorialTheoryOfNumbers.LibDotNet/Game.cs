using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.LibDotNet
{
    public sealed class Game
    {
        public IPlayer1<int,int> Player1 { get; set; }
        public IPlayer2<int,int> Player2 { get; set; }
        public IGameState<int, int> GameState { get; private set; }
        private IStatePresenter<int, int> StatePresenter { get; set; }
        public Game(IPlayer1<int,int> player1, IPlayer2<int,int> player2, IStatePresenter<int,int> presenter)
        {
            Player1 = player1;
            Player2 = player2;
            GameState = new GameState();
            StatePresenter = presenter;
        }

        public IPlayer Run()
        {
            while (!GameState.HasWinner){
                GameState.NextTour(Player1, Player2);
                StatePresenter.ShowState(GameState);
            }
            return GameState.Winner;
        }

        public void Restart()
        {
            Player1.Clear();
            Player2.Clear();
            GameState.Clear();
        }
        public void Init(LaunchConfig config)
        {
            Restart();
            GameState.Clear(config);
        }
    }
}

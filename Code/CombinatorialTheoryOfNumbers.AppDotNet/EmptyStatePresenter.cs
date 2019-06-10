using CombinatorialTheoryOfNumbers.LibDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.AppDotNet
{
    public class EmptyStatePresenter : IStatePresenter<int, int>
    {
        public void ShowState(IGameState<int, int> state)
        {
        }
    }
}

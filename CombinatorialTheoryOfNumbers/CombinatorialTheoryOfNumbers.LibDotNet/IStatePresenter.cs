namespace CombinatorialTheoryOfNumbers.LibDotNet
{
    public interface IStatePresenter<P1Res,P2Res>
    {
        void ShowState(IGameState<P1Res,P2Res> state);
    }
}
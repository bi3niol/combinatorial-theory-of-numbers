namespace CombinatorialTheoryOfNumbers.Lib
{
    public sealed class LaunchConfig
    {
        public int K { get; }
        public int C { get; }
        public int L { get; }
        
        public LaunchConfig(int k, int c, int l)
        {
            K = k;
            C = c;
            L = l;
        }
    }
}
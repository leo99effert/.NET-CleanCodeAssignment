namespace Moo
{
    public interface ICalculator
    {
        public string CreateSecretSequence();
        public string GetResult(string secretSequnce, string guess);
    }
}

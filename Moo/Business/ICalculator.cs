namespace Moo
{
    public interface ICalculator
    {
        public string SecretSequence { get; set; }
        public string Guess { get; set; }
        public void CreateSecretSequence();
        public string GetResult();
    }
}

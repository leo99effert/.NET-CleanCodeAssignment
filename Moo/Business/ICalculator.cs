using Moo.Business;

namespace Moo
{
    public interface ICalculator
    {
        public string SecretSequence { get; set; }
        public string Guess { get; set; }
        public Result Result { get; set; }
        public void CreateSecretSequence();
        public void UpdateResult();
    }
}

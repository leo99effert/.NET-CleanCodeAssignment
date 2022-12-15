using Moo;
namespace Test
{
    [TestClass]
    public class SecretSequenceTest
    {
        private readonly ICalculator _calculator = new MooCalculator();
        [TestInitialize]
        public void Init()
        {
            _calculator.CreateSecretSequence();
        }
        [TestMethod]
        public void OnlyNumbers()
        {
            Assert.IsTrue(_calculator.SecretSequence.All(char.IsDigit));
        }
        [TestMethod]
        public void LengthIsFour()
        {
            Assert.AreEqual(4, _calculator.SecretSequence.Length);
        }
        [TestMethod]
        public void AllCharsAreUnique()
        {
            int uniqueChars = _calculator.SecretSequence.Length;
            for (int i = 0; i < _calculator.SecretSequence.Length; i++)
            {
                for (int j = 0; j < _calculator.SecretSequence.Length; j++)
                {
                    if (_calculator.SecretSequence[i] == _calculator.SecretSequence[j] && i != j)
                    {
                        uniqueChars--;
                    }
                }
            }
            Assert.AreEqual(_calculator.SecretSequence.Length, uniqueChars);
        }
    }
}
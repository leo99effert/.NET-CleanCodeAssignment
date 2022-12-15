using Moo;

namespace Test
{
    [TestClass]
    public class SecretSequenceTest
    {
        public ICalculator Calculator { get; set; } = new MooCalculator();
        [TestInitialize]
        public void Init()
        {
            Calculator.CreateSecretSequence();
        }
        [TestMethod]
        public void OnlyNumbers()
        {
            Assert.IsTrue(Calculator.SecretSequence.All(char.IsDigit));
        }
        [TestMethod]
        public void LengthIsFour()
        {
            Assert.AreEqual(4, Calculator.SecretSequence.Length);
        }
        [TestMethod]
        public void AllCharsAreUnique()
        {
            int uniqueChars = Calculator.SecretSequence.Length;
            for (int i = 0; i < Calculator.SecretSequence.Length; i++)
            {
                for (int j = 0; j < Calculator.SecretSequence.Length; j++)
                {
                    if (Calculator.SecretSequence[i] == Calculator.SecretSequence[j] && i != j)
                    {
                        uniqueChars--;
                    }
                }
            }
            Assert.AreEqual(Calculator.SecretSequence.Length, uniqueChars);
        }
    }
}
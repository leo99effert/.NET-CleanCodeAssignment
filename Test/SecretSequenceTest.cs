using Moo;
namespace Test
{
    [TestClass]
    public class SecretSequenceTest
    {
        [TestMethod]
        public void OnlyNumbers()
        {
            Assert.IsTrue(GameCalculator.CreateSecretSequence().All(char.IsDigit));
        }
        [TestMethod]
        public void LengthIsFour()
        {
            Assert.AreEqual(4, GameCalculator.CreateSecretSequence().Length);
        }
        [TestMethod]
        public void AllCharsAreUnique()
        {
            string secretSequence = GameCalculator.CreateSecretSequence();
            int uniqueChars = secretSequence.Length;
            for (int i = 0; i < secretSequence.Length; i++)
            {
                for (int j = 0; j < secretSequence.Length; j++)
                {
                    if (secretSequence[i] == secretSequence[j] && i != j)
                    {
                        uniqueChars--;
                    }
                }
            }
            Assert.AreEqual(secretSequence.Length, uniqueChars);
        }
    }
}
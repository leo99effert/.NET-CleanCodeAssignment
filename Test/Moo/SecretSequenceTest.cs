using Moo;
using Moo.Interfaces;

namespace Test
{
    [TestClass]
    public class SecretSequenceTest
    {
        public IUserInterface UserInterface { get; set; } = new ConsoleHandler();
        public ICalculator Calculator { get; set; }
        [TestInitialize]
        public void Init()
        {
            Calculator = new MooGame(UserInterface);
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
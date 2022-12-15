using Moo;
using System.Text.RegularExpressions;

namespace Test
{
    [TestClass]
    public class CalculateBullsAndCowsTest
    {
        private readonly ICalculator _calculator = new MooCalculator();
        [TestInitialize]
        public void Init()
        {
            _calculator.CreateSecretSequence();
        }
        [TestMethod]
        public void WhiteSpaceInput()
        {
            _calculator.Guess = "    ";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(_calculator.GetResult(), regex);
        }
        [TestMethod]
        public void EmptyInput()
        {
            _calculator.Guess = "";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(_calculator.GetResult(), regex);
        }
        [TestMethod]
        public void LongInput()
        {
            _calculator.Guess = "12345";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(_calculator.GetResult(), regex);
        }
        [TestMethod]
        public void ShortInput()
        {
            _calculator.Guess = "123";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(_calculator.GetResult(), regex);
        }
        [TestMethod]
        public void NotUniqueInput()
        {
            _calculator.Guess = "3333";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(_calculator.GetResult(), regex);
        }
        [TestMethod]
        public void LetterInput()
        {
            _calculator.Guess = "AaBb";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(_calculator.GetResult(), regex);
        }
    }
}

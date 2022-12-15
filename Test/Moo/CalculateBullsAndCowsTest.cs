using Moo;
using System.Text.RegularExpressions;

namespace Test
{
    [TestClass]
    public class CalculateBullsAndCowsTest
    {
        public ICalculator Calculator { get; set; } = new MooCalculator();
        [TestInitialize]
        public void Init()
        {
            Calculator.CreateSecretSequence();
        }
        [TestMethod]
        public void WhiteSpaceInput()
        {
            Calculator.Guess = "    ";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(string.Concat("BBBB".AsSpan(0, Calculator.Result.Bulls), ",", "CCCC".AsSpan(0, Calculator.Result.Cows)), regex);
        }
        [TestMethod]
        public void EmptyInput()
        {
            Calculator.Guess = "";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(string.Concat("BBBB".AsSpan(0, Calculator.Result.Bulls), ",", "CCCC".AsSpan(0, Calculator.Result.Cows)), regex);
        }
        [TestMethod]
        public void LongInput()
        {
            Calculator.Guess = "12345";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(string.Concat("BBBB".AsSpan(0, Calculator.Result.Bulls), ",", "CCCC".AsSpan(0, Calculator.Result.Cows)), regex);
        }
        [TestMethod]
        public void ShortInput()
        {
            Calculator.Guess = "123";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(string.Concat("BBBB".AsSpan(0, Calculator.Result.Bulls), ",", "CCCC".AsSpan(0, Calculator.Result.Cows)), regex);
        }
        [TestMethod]
        public void NotUniqueInput()
        {
            Calculator.Guess = "3333";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(string.Concat("BBBB".AsSpan(0, Calculator.Result.Bulls), ",", "CCCC".AsSpan(0, Calculator.Result.Cows)), regex);
        }
        [TestMethod]
        public void LetterInput()
        {
            Calculator.Guess = "AaBb";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(string.Concat("BBBB".AsSpan(0, Calculator.Result.Bulls), ",", "CCCC".AsSpan(0, Calculator.Result.Cows)), regex);
        }
    }
}

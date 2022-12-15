using Moo;
using Moo.Interfaces;
using System.Text.RegularExpressions;

namespace Test
{
    [TestClass]
    public class CalculateBullsAndCowsTest
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
        public void WhiteSpaceInput()
        {
            Calculator.Guess = "    ";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(Calculator.GetResult(), regex);
        }
        [TestMethod]
        public void EmptyInput()
        {
            Calculator.Guess = "";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(Calculator.GetResult(), regex);
        }
        [TestMethod]
        public void LongInput()
        {
            Calculator.Guess = "12345";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(Calculator.GetResult(), regex);
        }
        [TestMethod]
        public void ShortInput()
        {
            Calculator.Guess = "123";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(Calculator.GetResult(), regex);
        }
        [TestMethod]
        public void NotUniqueInput()
        {
            Calculator.Guess = "3333";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(Calculator.GetResult(), regex);
        }
        [TestMethod]
        public void LetterInput()
        {
            Calculator.Guess = "AaBb";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(Calculator.GetResult(), regex);
        }
    }
}

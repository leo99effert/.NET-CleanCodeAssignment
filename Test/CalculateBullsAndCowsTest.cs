using Moo;
using System.Text.RegularExpressions;

namespace Test
{
    [TestClass]
    public class CalculateBullsAndCowsTest
    {
        [TestMethod]
        public void WhiteSpaceInput()
        {
            string testInput = "    ";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(GameCalculator.GetBullsAndCows(GameCalculator.CreateSecretSequence(), testInput), regex);
        }
        [TestMethod]
        public void EmptyInput()
        {
            string testInput = "";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(GameCalculator.GetBullsAndCows(GameCalculator.CreateSecretSequence(), testInput), regex);
        }
        [TestMethod]
        public void LongInput()
        {
            string testInput = "12345";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(GameCalculator.GetBullsAndCows(GameCalculator.CreateSecretSequence(), testInput), regex);
        }
        [TestMethod]
        public void ShortInput()
        {
            string testInput = "123";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(GameCalculator.GetBullsAndCows(GameCalculator.CreateSecretSequence(), testInput), regex);
        }
        [TestMethod]
        public void NotUniqueInput()
        {
            string testInput = "3333";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(GameCalculator.GetBullsAndCows(GameCalculator.CreateSecretSequence(), testInput), regex);
        }
        [TestMethod]
        public void LetterInput()
        {
            string testInput = "AaBb";
            Regex regex = new(@"^B{0,4},C{0,4}$");
            StringAssert.Matches(GameCalculator.GetBullsAndCows(GameCalculator.CreateSecretSequence(), testInput), regex);
        }
    }
}

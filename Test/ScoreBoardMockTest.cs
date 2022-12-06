namespace Test
{
    [TestClass]
    public class ScoreBoardMockTest
    {
        private List<string> mockForTextFile = new List<string>()
        {
            "leo#&#4",
            "messo#&#3"
        };
        private string mockForPrintResult = "Player   games average\n" +
                                            "messo        1     3,00\n" +
                                            "leo          1     4,00\n";
        [TestMethod]
        public void ScoreBoardFormat()
        {
            Assert.AreEqual(mockForPrintResult, ScoreBoardMock.PrintScoreBoardMock(mockForTextFile));
        }
    }
}

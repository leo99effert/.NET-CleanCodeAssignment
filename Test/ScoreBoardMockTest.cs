namespace Test
{
    [TestClass]
    public class ScoreBoardMockTest
    {
        private List<string> mockForTextFile = new List<string>()
        {
            "leo#&#4",
            "messo#&#3",
            "leo#&#6",
            "leo#&#1",
            "zlatan#&#1",
            "ronaldo#&#1",
            "bolt#&#1",
            "007#&#1"
        };
        private string mockForPrintResult = "Player   games average\n" +
                                            "zlatan       1     1,00\n" +
                                            "ronaldo      1     1,00\n" +
                                            "bolt         1     1,00\n" +
                                            "007          1     1,00\n" +
                                            "messo        1     3,00\n" +
                                            "leo          3     3,67\n";
        [TestMethod]
        public void ScoreBoardFormat()
        {
            Assert.AreEqual(mockForPrintResult, ScoreBoardMock.PrintScoreBoardMock(mockForTextFile));
        }
    }
}

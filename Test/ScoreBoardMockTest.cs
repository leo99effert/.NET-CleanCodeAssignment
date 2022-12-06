namespace Test
{
    [TestClass]
    public class ScoreBoardMockTest
    {
        private List<string> mockForTextFile = new List<string>()
        {
            "leo#&#4",
            "l3o#&#1",
            "leo99effert#&#16",
            "leo#&#1",
            "peo#&#1",
            "neo#&#2",
            "zlatan#&#1"
        };
        private string mockForPrintResult = "Player   games average\n" +
                                            "l3o          1     1,00\n" +
                                            "peo          1     1,00\n" +
                                            "zlatan       1     1,00\n" +
                                            "neo          1     2,00\n" +
                                            "leo          2     2,50\n" +
                                            "leo99effert    1    16,00\n";
        [TestMethod]
        public void ScoreBoardFormat()
        {
            Assert.AreEqual(mockForPrintResult, ScoreBoardMock.PrintScoreBoardMock(mockForTextFile));
        }
    }
}

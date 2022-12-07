using Moo;

namespace Test
{
    [TestClass]
    public class HighScoresHandlerTest
    {
        private List<string> dataEntriesMock = new List<string>()
        {
            "sheldon#&#10",
            "leonard#&#9",
            "penny#&#1",
            "raj#&#2",
            "howard#&#3",
            "sheldon#&#20",
            "leonard#&#8",
            "sheldon#&#30"
        };
        private List<PlayerData> playerDatasMock = new List<PlayerData>()
        {
            new PlayerData("penny", 1),
            new PlayerData("raj", 2),
            new PlayerData("howard", 3),
            new PlayerData("leonard", 17),
            new PlayerData("sheldon", 60)
        };
        private string consoleStringMock = "Player   games average\n" +
                                           "penny        1     1,00\n" +
                                           "raj          1     2,00\n" +
                                           "howard       1     3,00\n" +
                                           "leonard      2     8,50\n" +
                                           "sheldon      3    20,00\n";

        [TestInitialize]
        public void Init()
        {
            playerDatasMock[3].GamesPlayed = 2;
            playerDatasMock[4].GamesPlayed = 3;
        }
        [TestMethod]
        public void DataEntriesToPlayerDatas()
        {
            CollectionAssert.AreEqual(playerDatasMock, HighScoresHandler.ConvertToPlayerData(dataEntriesMock));
        }

        [TestMethod]
        public void PlayerDatasToConsoleString()
        {
            Assert.AreEqual(consoleStringMock, HighScoresHandler.CreateConsoleString(playerDatasMock));
        }
    }
}

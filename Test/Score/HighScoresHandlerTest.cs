using Moo;

namespace Test
{
    [TestClass]
    public class HighScoresHandlerTest
    {
        public HighScoresHandler HighScoresHandler { get; set; } = new(new PlayerData("TestPlayer"));

        private readonly List<PlayerData> _playerDatasMock = new()
        {
            new PlayerData("penny", 1),
            new PlayerData("raj", 2),
            new PlayerData("howard", 3),
            new PlayerData("leonard", 17),
            new PlayerData("sheldon", 60)
        };
        private readonly string _consoleStringMock = "Player   games average\n" +
                                           "penny        1     1,00\n" +
                                           "raj          1     2,00\n" +
                                           "howard       1     3,00\n" +
                                           "leonard      2     8,50\n" +
                                           "sheldon      3    20,00\n";

        [TestInitialize]
        public void Init()
        {
            HighScoresHandler.AllPlayers = _playerDatasMock;
            _playerDatasMock[3].GamesPlayed = 2;
            _playerDatasMock[4].GamesPlayed = 3;
        }

        [TestMethod]
        public void PlayerDatasToConsoleString()
        {
            Assert.AreEqual(_consoleStringMock, HighScoresHandler.CreateScoreBoard());
        }
    }
}

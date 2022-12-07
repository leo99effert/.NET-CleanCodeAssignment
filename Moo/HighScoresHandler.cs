namespace Moo
{
    public class HighScoresHandler
    {
        public static List<string> ReadTextFile()
        {
            StreamReader textFile = new StreamReader("result.txt");
            List<string> playerDataEntries = new();
            string newLine;
            while ((newLine = textFile.ReadLine()) != null)
            {
                playerDataEntries.Add(newLine);
            }
            textFile.Close();
            return playerDataEntries;
        }

        public static List<PlayerData> ConvertToPlayerData(List<string> dataEntries)
        {
            List<PlayerData> playerDatas = new List<PlayerData>();
            foreach (string entry in dataEntries)
            {
                string[] nameAndScore = entry.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData playerData = new PlayerData(name, guesses);
                int pos = playerDatas.IndexOf(playerData);
                if (pos < 0)
                {
                    playerDatas.Add(playerData);
                }
                else
                {
                    playerDatas[pos].Update(guesses);
                }
            }
            List<PlayerData> inOrderPlayerData = playerDatas.OrderBy(p => p.Average()).ToList();
            return inOrderPlayerData;
        }

        public static string CreateConsoleString(List<PlayerData> playerDatas)
        {
            string consoleOutput = "Player   games average\n";
            foreach (PlayerData p in playerDatas)
            {
                consoleOutput += string.Format("{0,-9}{1,5:D}{2,9:F2}\n", p.Name, p.GamesPlayed, p.Average());
            }
            return consoleOutput;
        }
    }
}

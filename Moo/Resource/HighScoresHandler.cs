namespace Moo
{
    public class HighScoresHandler
    {
        public List<PlayerData> PlayerDatas { get; set; } = new();

        public void WriteToTextFile(PlayerData player)
        {
            StreamWriter output = new("result.txt", append: true);
            output.WriteLine(player.Name + "#&#" + player.TotalGuesses);
            output.Close();
        }

        public void ReadTextFile()
        {
            StreamReader textFile = new("result.txt");
            string newLine;
            while ((newLine = textFile.ReadLine()) != null)
            {
                ReadLine(newLine);
            }
            textFile.Close();
            PlayerDatas = PlayerDatas.OrderBy(p => p.Average()).ToList();
        }

        public void ReadLine(string newLine)
        {
            string[] nameAndScore = newLine.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);
            PlayerData playerData = new(name, guesses);
            int pos = PlayerDatas.IndexOf(playerData);
            if (pos < 0)
            {
                PlayerDatas.Add(playerData);
            }
            else
            {
                PlayerDatas[pos].Update(guesses);
            }
        }

        public string CreateConsoleString()
        {
            string consoleOutput = "Player   games average\n";
            foreach (PlayerData playerData in PlayerDatas)
            {
                consoleOutput += string.Format("{0,-9}{1,5:D}{2,9:F2}\n", playerData.Name, playerData.GamesPlayed, playerData.Average());
            }
            return consoleOutput;
        }
    }
}

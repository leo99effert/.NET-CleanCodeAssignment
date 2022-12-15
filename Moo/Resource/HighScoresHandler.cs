namespace Moo
{
    public class HighScoresHandler
    {
        public PlayerData CurrentPlayer { get; set; }
        public List<PlayerData> AllPlayers { get; set; } = new();
        public HighScoresHandler(PlayerData currentPlayer)
        {
            CurrentPlayer = currentPlayer;
        }

        public void WriteToTextFile()
        {
            StreamWriter output = new("result.txt", append: true);
            output.WriteLine(CurrentPlayer.Name + "#&#" + CurrentPlayer.TotalGuesses);
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
            AllPlayers = AllPlayers.OrderBy(p => p.Average()).ToList();
        }

        public void ReadLine(string newLine)
        {
            string[] nameAndScore = newLine.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);
            PlayerData playerData = new(name, guesses);
            int pos = AllPlayers.IndexOf(playerData);
            if (pos < 0)
            {
                AllPlayers.Add(playerData);
            }
            else
            {
                AllPlayers[pos].Update(guesses);
            }
        }

        public string CreateScoreBoard()
        {
            string output = "Player   games average\n";
            foreach (PlayerData playerData in AllPlayers)
            {
                output += string.Format("{0,-9}{1,5:D}{2,9:F2}\n", playerData.Name, playerData.GamesPlayed, playerData.Average());
            }
            return output;
        }
    }
}

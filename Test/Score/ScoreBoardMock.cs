namespace Test
{
    public static class ScoreBoardMock
    {
        public static string PrintScoreBoardMock(List<string> mockForTextFile)
        {
            List<PlayerDataMock> results = new List<PlayerDataMock>();
            foreach (string playerResult in mockForTextFile)
            {
                string[] nameAndScore = playerResult.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);

                PlayerDataMock player = new(name, guesses);
                int position = results.IndexOf(player);
                if (position < 0)
                {
                    results.Add(player);
                }
                else
                {
                    results[position].Update(guesses);
                }
            }
            List<PlayerDataMock> inOrderResults = results.OrderBy(p => p.Average()).ToList();
            string printedResult = "";
            printedResult += "Player   games average\n";
            foreach (PlayerDataMock player in inOrderResults)
            {
                printedResult += string.Format("{0,-9}{1,5:D}{2,9:F2}\n", player.Name, player.GamesPlayed, player.Average());
            }
            return printedResult;
        }
    }
    public class PlayerDataMock
    {
        public string Name { get; private set; }
        public int GamesPlayed { get; private set; }
        public int TotalGuesses { get; set; }


        public PlayerDataMock(string name, int guesses)
        {
            Name = name;
            GamesPlayed = 1;
            TotalGuesses = guesses;
        }

        public void Update(int guesses)
        {
            TotalGuesses += guesses;
            GamesPlayed++;
        }

        public double Average()
        {
            return (double)TotalGuesses / GamesPlayed;
        }

        public override bool Equals(Object p)
        {
            return Name.Equals(((PlayerDataMock)p).Name);
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}

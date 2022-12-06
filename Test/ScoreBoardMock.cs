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

                PlayerDataMock player = new PlayerDataMock(name, guesses);
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
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            string printedResult = "";
            printedResult += "Player   games average\n";

            foreach (PlayerDataMock player in results)
            {
                printedResult += string.Format("{0,-9}{1,5:D}{2,9:F2}\n", player.Name, player.NGames, player.Average());
            }
            return printedResult;
        }
    }
    public class PlayerDataMock
    {
        public string Name { get; private set; }
        public int NGames { get; private set; }
        int totalGuess;


        public PlayerDataMock(string name, int guesses)
        {
            this.Name = name;
            NGames = 1;
            totalGuess = guesses;
        }

        public void Update(int guesses)
        {
            totalGuess += guesses;
            NGames++;
        }

        public double Average()
        {
            return (double)totalGuess / NGames;
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

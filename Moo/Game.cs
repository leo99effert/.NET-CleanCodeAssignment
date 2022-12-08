namespace Moo
{
    public class Game
    {
        public PlayerData Player { get; set; }
        public void CreatePlayer()
        {
            Console.WriteLine("Enter your user name:\n");
            Player = new(Console.ReadLine());
        }
        public void RunGameLoop(string secretSequence)
        {
            string currentBullsAndCows = ",";
            Player.TotalGuesses = 0;
            while (currentBullsAndCows != "BBBB,")
            {
                string guess = Console.ReadLine();
                Player.TotalGuesses++;
                Console.WriteLine(guess + "\n");
                currentBullsAndCows = GameCalculator.GetBullsAndCows(secretSequence, guess);
                Console.WriteLine(currentBullsAndCows + "\n");
            }
        }
        public void EndAndSave()
        {
            Console.WriteLine("Correct, it took " + Player.TotalGuesses + " guesses\n");
            HighScoresHandler.WriteToTextFile(Player);
            List<string> dataEntries = HighScoresHandler.ReadTextFile();
            List<PlayerData> playerDatas = HighScoresHandler.ConvertToPlayerData(dataEntries);
            Console.WriteLine(HighScoresHandler.CreateConsoleString(playerDatas));
        }
        public bool AskForNewGame()
        {
            Console.WriteLine("Continue?");
            string answer = Console.ReadLine();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                return false;
            }
            return true;
        }
    }
}

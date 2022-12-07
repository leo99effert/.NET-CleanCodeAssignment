using Moo;

namespace MooGame
{
    public class MainClass
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Enter your user name:\n");
            PlayerData playerData = new(Console.ReadLine());

            bool continuePlaying = true;
            while (continuePlaying)
            {
                string secretSequence = GameCalculator.CreateSecretSequence();


                Console.WriteLine("New game:\n");
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + secretSequence + "\n");
                string guess = Console.ReadLine();

                playerData.TotalGuesses++;
                string bullsAndCows = GameCalculator.GetBullsAndCows(secretSequence, guess);
                Console.WriteLine(bullsAndCows + "\n");
                while (bullsAndCows != "BBBB,")
                {
                    guess = Console.ReadLine();
                    playerData.TotalGuesses++;
                    Console.WriteLine(guess + "\n");
                    bullsAndCows = GameCalculator.GetBullsAndCows(secretSequence, guess);
                    Console.WriteLine(bullsAndCows + "\n");
                }

                Console.WriteLine("Correct, it took " + playerData.TotalGuesses + " guesses\n");
                HighScoresHandler.WriteToTextFile(playerData);
                List<string> dataEntries = HighScoresHandler.ReadTextFile();
                List<PlayerData> playerDatas = HighScoresHandler.ConvertToPlayerData(dataEntries);
                Console.WriteLine(HighScoresHandler.CreateConsoleString(playerDatas));

                Console.WriteLine("Continue?");
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    continuePlaying = false;
                }
            }
        }
    }
}
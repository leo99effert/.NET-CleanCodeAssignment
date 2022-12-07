using Moo;

namespace MooGame
{
    public class MainClass
    {
        public static void Main(string[] args)
        {

            bool playOn = true;
            Console.WriteLine("Enter your user name:\n");
            string name = Console.ReadLine();

            while (playOn)
            {
                string goal = CreateSecretSequence();


                Console.WriteLine("New game:\n");
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + goal + "\n");
                string guess = Console.ReadLine();

                int nGuess = 1;
                string bbcc = CalculateBullsAndCows(goal, guess);
                Console.WriteLine(bbcc + "\n");
                while (bbcc != "BBBB,")
                {
                    nGuess++;
                    guess = Console.ReadLine();
                    Console.WriteLine(guess + "\n");
                    bbcc = CalculateBullsAndCows(goal, guess);
                    Console.WriteLine(bbcc + "\n");
                }
                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(name + "#&#" + nGuess);
                output.Close();

                List<string> dataEntries = HighScoresHandler.ReadTextFile();
                List<PlayerData> playerDatas = HighScoresHandler.ConvertToPlayerData(dataEntries);
                Console.WriteLine(HighScoresHandler.CreateConsoleString(playerDatas));

                Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    playOn = false;
                }
            }
        }
        public static string CreateSecretSequence()
        {
            string secretSequence = "";
            Random NumberGenerator = new();
            int random;
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    random = NumberGenerator.Next(10);
                }
                while (secretSequence.Contains(random.ToString()));
                secretSequence += random;
            }
            return secretSequence;
        }

        public static string CalculateBullsAndCows(string secretSequence, string guess)
        {
            int bulls = 0;
            int cows = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4 && j < guess.Length; j++)
                {
                    if (secretSequence[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return string.Concat("BBBB".AsSpan(0, bulls), ",", "CCCC".AsSpan(0, cows));
        }
    }
}
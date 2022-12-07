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
                PrintHighScores();
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


        public static void PrintHighScores()
        {
            List<string> dataEntries = ReadTextFile();
            List<PlayerData> playerDatas = ConvertToPlayerData(dataEntries);
            Console.WriteLine(CreateConsoleString(playerDatas));
        }

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

    public class PlayerData
    {
        public string Name { get; private set; }
        public int GamesPlayed { get; private set; }
        public int TotalGuesses { get; set; }


        public PlayerData(string name, int guesses)
        {
            this.Name = name;
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
            return Name.Equals(((PlayerData)p).Name);
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
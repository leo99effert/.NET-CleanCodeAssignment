using Moo.Interfaces;

namespace Moo
{
    public class Game : IGame
    {
        public PlayerData Player { get; set; }
        public IUserInterface UserInterface { get; set; }
        public ICalculator Calculator { get; set; }

        public Game(IUserInterface userInterface, ICalculator calculator)
        {
            UserInterface = userInterface;
            Calculator = calculator;
        }
        public void CreatePlayer()
        {
            UserInterface.Output("Enter your user name:\n");
            Player = new(UserInterface.Input());
        }
        public void StartNewGame()
        {
            Calculator.CreateSecretSequence();
            UserInterface.Output("New game:\n");
            //comment out or remove next line to play real games!
            UserInterface.Output("For practice, number is: " + Calculator.SecretSequence + "\n");
        }
        public void RunGameLoop()
        {
            string currentBullsAndCows = ",";
            Player.TotalGuesses = 0;
            while (currentBullsAndCows != "BBBB,")
            {
                Calculator.Guess = UserInterface.Input();
                Player.TotalGuesses++;
                UserInterface.Output(Calculator.Guess + "\n");
                currentBullsAndCows = Calculator.GetResult();
                UserInterface.Output(currentBullsAndCows + "\n");
            }
        }
        public void EndAndSave()
        {
            UserInterface.Output("Correct, it took " + Player.TotalGuesses + " guesses\n");
            HighScoresHandler highScoresHandler = new(Player);
            highScoresHandler.WriteToTextFile();
            highScoresHandler.ReadTextFile();
            UserInterface.Output(highScoresHandler.CreateScoreBoard());
        }
        public bool AskForNewGame()
        {
            UserInterface.Output("Continue?");
            string answer = UserInterface.Input();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                return false;
            }
            return true;
        }
    }
}

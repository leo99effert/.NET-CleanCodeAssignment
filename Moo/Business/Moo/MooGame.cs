using Moo.Interfaces;

namespace Moo
{
    public class MooGame : Game, IGuessingGame
    {
        public ICalculator Calculator { get; set; } = new MooCalculator();
        public MooGame(IUserInterface userInterface) : base(userInterface) { }
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
    }
}

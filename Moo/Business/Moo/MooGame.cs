using Moo.Interfaces;

namespace Moo
{
    public class MooGame : Game, IGuessingGame
    {
        public ICalculator Calculator { get; set; } = new MooCalculator();
        public MooGame(IUserInterface userInterface) : base(userInterface) { }
        public void StartNewGame()
        {
            UserInterface.Output("New game:\n");
            SecretSequence = Calculator.CreateSecretSequence();
            //comment out or remove next line to play real games!
            UserInterface.Output("For practice, number is: " + SecretSequence + "\n");
        }
        public void RunGameLoop()
        {
            string currentBullsAndCows = ",";
            Player.TotalGuesses = 0;
            while (currentBullsAndCows != "BBBB,")
            {
                string guess = UserInterface.Input();
                Player.TotalGuesses++;
                UserInterface.Output(guess + "\n");
                currentBullsAndCows = Calculator.GetResult(SecretSequence, guess);
                UserInterface.Output(currentBullsAndCows + "\n");
            }
        }
    }
}

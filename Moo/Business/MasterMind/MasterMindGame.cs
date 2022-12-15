using Moo.Interfaces;

namespace Moo
{
    internal class MasterMindGame : Game, IGuessingGame
    {
        public ICalculator Calculator { get; set; } = new MasterMindCalculator();
        public MasterMindGame(IUserInterface userInterface) : base(userInterface) { }
        public void StartNewGame()
        {
            Calculator.CreateSecretSequence();
            UserInterface.Output("B/b = Blue\n" +
                                 "G/g = Green\n" +
                                 "R/r = Red\n" +
                                 "Y/y = Yelow\n" +
                                 "O/o = Orange\n" +
                                 "P/p = Pink\n" +
                                 "W/w = White\n" +
                                 "S/s = Silver\n" +
                                 "New game:\n");
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

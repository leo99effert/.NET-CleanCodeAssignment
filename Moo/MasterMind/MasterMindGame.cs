namespace Moo
{
    internal class MasterMindGame : Game, IGuessingGame
    {
        public ICalculator Calculator { get; set; } = new MasterMindCalculator();
        public void StartNewGame()
        {
            Console.WriteLine("B/b = Blue\n" +
                              "G/g = Green\n" +
                              "R/r = Red\n" +
                              "Y/y = Yelow\n" +
                              "O/o = Orange\n" +
                              "P/p = Pink\n" +
                              "W/w = White\n" +
                              "S/s = Silver\n" +
                              "New game:\n");
            SecretSequence = Calculator.CreateSecretSequence();
            //comment out or remove next line to play real games!
            Console.WriteLine("For practice, number is: " + SecretSequence + "\n");
        }
        public void RunGameLoop()
        {
            string currentBullsAndCows = ",";
            Player.TotalGuesses = 0;
            while (currentBullsAndCows != "BBBB,")
            {
                string guess = Console.ReadLine();
                Player.TotalGuesses++;
                Console.WriteLine(guess + "\n");
                currentBullsAndCows = Calculator.GetResult(SecretSequence, guess);
                Console.WriteLine(currentBullsAndCows + "\n");
            }
        }

    }
}

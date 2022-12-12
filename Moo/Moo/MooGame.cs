namespace Moo
{
    public class MooGame : Game, IGuessingGame
    {
        public ICalculator Calculator { get; set; } = new MooCalculator();
        public void StartNewGame()
        {
            Console.WriteLine("New game:\n");
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

using Moo;

namespace MooGame
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Game game = new();
            game.CreatePlayer();

            bool continuePlaying = true;
            while (continuePlaying)
            {
                string secretSequence = GameCalculator.CreateSecretSequence();
                Console.WriteLine("New game:\n");
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + secretSequence + "\n");

                game.RunGameLoop(secretSequence);
                game.EndAndSave();
                continuePlaying = game.AskForNewGame();
            }
        }
    }
}
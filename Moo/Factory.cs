namespace Moo
{
    public class Factory
    {
        public static IGuessingGame CreateGame(string gameChosenByPlayer)
        {
            if (gameChosenByPlayer.Contains("moo"))
            {
                return new MooGame();
            }
            if (gameChosenByPlayer.Contains("mastermind"))
            {
                return new MasterMindGame();
            }
            throw new Exception("Game not found");
        }
    }
}

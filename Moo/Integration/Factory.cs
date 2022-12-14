using Moo.Interfaces;

namespace Moo
{
    public class Factory
    {
        public static IGuessingGame CreateGame(string gameChosenByPlayer, IUserInterface userInterface)
        {
            if (gameChosenByPlayer is "moo")
            {
                return new MooGame(userInterface);
            }
            if (gameChosenByPlayer is "mastermind")
            {
                return new MasterMindGame(userInterface);
            }
            throw new Exception("Game not found");
        }
    }
}

using Moo.Interfaces;

namespace Moo
{
    public class Factory
    {
        public IUserInterface UserInterface { get; set; }
        public Factory(IUserInterface userInterface)
        {
            UserInterface = userInterface;
        }
        public IGame CreateGame()
        {
            string gameChosenByPlayer = PickGame();
            if (gameChosenByPlayer is "moo")
            {
                return new MooGame(UserInterface);
            }
            if (gameChosenByPlayer is "mastermind")
            {
                return new MasterMindGame(UserInterface);
            }
            throw new Exception("Game not found");
        }
        public string PickGame()
        {
            string gameToPlay = "";
            while (gameToPlay is not "moo" && gameToPlay is not "mastermind")
            {
                UserInterface.Output("What game do you want to play?\nCurrently available games: Moo and MasterMind");
                gameToPlay = UserInterface.Input().ToLower();
            }
            return gameToPlay;
        }
    }
}

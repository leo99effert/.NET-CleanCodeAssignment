using Moo.Interfaces;

namespace Moo.Business.Shared
{
    public class GameFacade
    {
        public IUserInterface UserInterface { get; set; }
        public IGame Game { get; set; }
        public GameFacade(IUserInterface userInterface)
        {
            UserInterface = userInterface;
        }
        public void Run()
        {
            Factory factory = new(UserInterface);
            Game = factory.CreateGame();
            Game.CreatePlayer();
            bool continuePlaying = true;
            while (continuePlaying)
            {
                Game.StartNewGame();
                Game.RunGameLoop();
                Game.EndAndSave();
                continuePlaying = Game.AskForNewGame();
            }
        }
    }
}

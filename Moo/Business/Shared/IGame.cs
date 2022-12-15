using Moo.Interfaces;

namespace Moo
{
    public interface IGame
    {
        public PlayerData Player { get; set; }
        public IUserInterface UserInterface { get; set; }
        public ICalculator Calculator { get; set; }
        public void CreatePlayer();
        public void StartNewGame();
        public void RunGameLoop();
        public void EndAndSave();
        public bool AskForNewGame();
    }
}

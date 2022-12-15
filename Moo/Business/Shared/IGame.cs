using Moo.Interfaces;

namespace Moo
{
    public interface IGame
    {
        public PlayerData Player { get; set; }
        public IUserInterface UserInterface { get; set; }
        public void CreatePlayer();
        public void EndAndSave();
        public bool AskForNewGame();
    }
}

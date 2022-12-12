namespace Moo
{
    public interface IGame
    {
        public PlayerData Player { get; set; }
        public string SecretSequence { get; set; }
        public void CreatePlayer();
        public void EndAndSave();
        public bool AskForNewGame();
    }
}

using Moo.Interfaces;

namespace Moo
{
    public class Game : IGame
    {
        public PlayerData Player { get; set; }
        public string SecretSequence { get; set; } = "";
        public IUserInterface UserInterface { get; set; }

        public Game(IUserInterface userInterface)
        {
            UserInterface = userInterface;
        }
        public void CreatePlayer()
        {
            UserInterface.Output("Enter your user name:\n");
            Player = new(UserInterface.Input());
        }
        public void EndAndSave()
        {
            UserInterface.Output("Correct, it took " + Player.TotalGuesses + " guesses\n");
            HighScoresHandler.WriteToTextFile(Player);
            List<string> dataEntries = HighScoresHandler.ReadTextFile();
            List<PlayerData> playerDatas = HighScoresHandler.ConvertToPlayerData(dataEntries);
            UserInterface.Output(HighScoresHandler.CreateConsoleString(playerDatas));
        }
        public bool AskForNewGame()
        {
            UserInterface.Output("Continue?");
            string answer = UserInterface.Input();
            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            {
                return false;
            }
            return true;
        }
    }
}

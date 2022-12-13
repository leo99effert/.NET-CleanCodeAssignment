using Moo;
using Moo.Interfaces;

IUserInterface userInterface = new ConsoleHandler();

// Added functionality for VG assignment below
string gameToPlay = "";
while (gameToPlay is not "moo" && gameToPlay is not "mastermind")
{
    userInterface.Output("What game do you want to play?\nCurrently available games: Moo and MasterMind");
    gameToPlay = userInterface.Input().ToLower();
}
// Added functionality for VG assignment above

IGuessingGame game = Factory.CreateGame(gameToPlay, userInterface);
game.CreatePlayer();

bool continuePlaying = true;
while (continuePlaying)
{
    game.StartNewGame();
    game.RunGameLoop();
    game.EndAndSave();
    continuePlaying = game.AskForNewGame();
}
using Moo;

// Added functionality for VG assignment below
string gameToPlay = "";
while (gameToPlay.Contains("moo") is false && gameToPlay.Contains("mastermind") is false)
{
    Console.WriteLine("What game do you want to play?\nCurrently available games: Moo and MasterMind");
    gameToPlay = Console.ReadLine().ToLower();
}
// Added functionality for VG assignment above

IGuessingGame game = Factory.CreateGame(gameToPlay);
game.CreatePlayer();

bool continuePlaying = true;
while (continuePlaying)
{
    game.StartNewGame();
    game.RunGameLoop();
    game.EndAndSave();
    continuePlaying = game.AskForNewGame();
}
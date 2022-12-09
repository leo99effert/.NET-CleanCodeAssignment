using Moo;

MooGame game = new();
game.CreatePlayer();

bool continuePlaying = true;
while (continuePlaying)
{
    game.StartNewGame();
    game.RunGameLoop();
    game.EndAndSave();
    continuePlaying = game.AskForNewGame();
}
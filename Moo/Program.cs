using Moo;
using Moo.Business.Shared;
using Moo.Interfaces;

IUserInterface userInterface = new ConsoleHandler();
GameFacade game = new(userInterface);
game.Run();

using Moo.Interfaces;

namespace Moo
{
    internal class MasterMindGame : Game
    {
        public MasterMindGame(IUserInterface userInterface) : base(userInterface)
        {
            Calculator = new MasterMindCalculator();
        }
    }
}

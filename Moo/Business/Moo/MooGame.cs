using Moo.Interfaces;

namespace Moo
{
    public class MooGame : Game
    {
        public MooGame(IUserInterface userInterface) : base(userInterface)
        {
            Calculator = new MooCalculator();
        }
    }
}

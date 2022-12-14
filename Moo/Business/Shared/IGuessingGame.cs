namespace Moo
{
    public interface IGuessingGame : IGame
    {
        public ICalculator Calculator { get; set; }
        public void StartNewGame();
        public void RunGameLoop();
    }
}

namespace Moo
{
    public class PlayerData
    {
        public string Name { get; set; }
        public int GamesPlayed { get; set; }
        public int TotalGuesses { get; set; }


        public PlayerData(string name, int guesses)
        {
            this.Name = name;
            GamesPlayed = 1;
            TotalGuesses = guesses;
        }

        public void Update(int guesses)
        {
            TotalGuesses += guesses;
            GamesPlayed++;
        }

        public double Average()
        {
            return (double)TotalGuesses / GamesPlayed;
        }


        public override bool Equals(Object p)
        {
            return Name.Equals(((PlayerData)p).Name);
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}

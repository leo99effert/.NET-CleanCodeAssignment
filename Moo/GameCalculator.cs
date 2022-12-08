namespace Moo
{
    public class GameCalculator
    {
        public static string CreateSecretSequence()
        {
            string secretSequence = "";
            Random NumberGenerator = new();
            int random;
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    random = NumberGenerator.Next(10);
                }
                while (secretSequence.Contains(random.ToString()));
                secretSequence += random;
            }
            return secretSequence;
        }

        public static string GetResult(string secretSequence, string guess)
        {
            int bulls = 0;
            int cows = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4 && j < guess.Length; j++)
                {
                    if (secretSequence[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return string.Concat("BBBB".AsSpan(0, bulls), ",", "CCCC".AsSpan(0, cows));
        }
    }
}

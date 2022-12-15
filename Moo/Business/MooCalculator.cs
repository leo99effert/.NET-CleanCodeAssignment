namespace Moo
{
    public class MooCalculator : ICalculator
    {
        public string SecretSequence { get; set; }
        public string Guess { get; set; }

        public void CreateSecretSequence()
        {
            string newSecretSequence = "";
            Random NumberGenerator = new();
            int random;
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    random = NumberGenerator.Next(10);
                }
                while (newSecretSequence.Contains(random.ToString()));
                newSecretSequence += random;
            }
            SecretSequence = newSecretSequence;
        }

        public string GetResult()
        {
            int bulls = 0;
            int cows = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4 && j < Guess.Length; j++)
                {
                    if (SecretSequence[i] == Guess[j])
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

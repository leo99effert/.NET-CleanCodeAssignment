using Moo.Business;

namespace Moo
{
    public class MasterMindCalculator : ICalculator
    {
        public string SecretSequence { get; set; }
        public string Guess { get; set; }
        public Result Result { get; set; } = new Result();

        public void CreateSecretSequence()
        {
            string newSecretSequence = "";
            Random NumberGenerator = new();
            for (int i = 0; i < 4; i++)
            {
                int random = NumberGenerator.Next(8);
                newSecretSequence += (Colors)random;
            }
            SecretSequence = newSecretSequence;
        }

        public void UpdateResult()
        {
            Result.Bulls = 0;
            Result.Cows = 0;
            Guess = (Guess + "    ").Substring(0, 4).ToUpper();
            char[] secret = SecretSequence.ToCharArray();
            for (int i = 0; i < Guess.Length; i++)
            {
                if (Guess[i] == secret[i])
                {
                    Result.Bulls++;
                    secret[i] = 'X'; // To avoid being counted as Cow
                }
            }
            string checkedColors = "";
            for (int i = 0; i < Guess.Length; i++)
            {
                if (secret.Contains(Guess[i]) && checkedColors.Contains(Guess[i]) == false)
                {
                    int thisCharInSecret = 0;
                    int thisCharInGuess = 0;
                    for (int j = 0; j < secret.Length; j++)
                    {
                        if (secret[j] == Guess[i])
                        {
                            thisCharInSecret++;
                            checkedColors += Guess[i];
                        }
                        if (Guess[j] == Guess[i] && secret[j] != 'X') // Count the char without counting the Bulls
                        {
                            thisCharInGuess++;
                        }
                    }
                    while (thisCharInGuess > 0 && thisCharInSecret > 0)
                    {
                        Result.Cows++;
                        thisCharInSecret--;
                        thisCharInGuess--;
                    }
                }
            }
        }
    }
}

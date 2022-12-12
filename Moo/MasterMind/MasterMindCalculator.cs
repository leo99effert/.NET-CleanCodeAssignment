using System.Text.RegularExpressions;

namespace Moo
{
    internal class MasterMindCalculator : ICalculator
    {
        public string CreateSecretSequence()
        {
            string secretSequence = "";
            Random NumberGenerator = new();
            for (int i = 0; i < 4; i++)
            {
                int random = NumberGenerator.Next(8);
                secretSequence += (Colors)random;
            }
            return secretSequence;
        }

        public string GetResult(string secretSequence, string guess)
        {
            guess = (guess + "    ").Substring(0, 4).ToUpper();
            char[] secret = secretSequence.ToCharArray();
            string result = "";
            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == secret[i])
                {
                    result += "B";
                    secret[i] = 'X'; // To avoid being counted as Cow
                }
            }
            result += ",";
            string checkedColors = "";
            for (int i = 0; i < guess.Length; i++)
            {
                if (secret.Contains(guess[i]) && checkedColors.Contains(guess[i]) == false)
                {
                    int thisCharInSecret = 0;
                    int thisCharInGuess = 0;
                    for (int j = 0; j < secret.Length; j++)
                    {
                        if (secret[j] == guess[i])
                        {
                            thisCharInSecret++;
                            checkedColors += guess[i];
                        }
                        if (guess[j] == guess[i] && secret[j] != 'X') // Count the char without counting the Bulls
                        {
                            thisCharInGuess++;
                        }
                    }
                    while (thisCharInGuess > 0 && thisCharInSecret > 0)
                    {
                        result += "C";
                        thisCharInSecret--;
                        thisCharInGuess--;
                    }
                }
            }
            result = Regex.Replace(result, "\\s+", "");
            return result;
        }
    }
}

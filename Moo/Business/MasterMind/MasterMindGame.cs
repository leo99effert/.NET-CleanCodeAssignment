using Moo.Interfaces;
using System.Text.RegularExpressions;

namespace Moo
{
    public class MasterMindGame : Game, ICalculator
    {
        public string SecretSequence { get; set; }
        public string Guess { get; set; }

        public MasterMindGame(IUserInterface userInterface) : base(userInterface) { }
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

        public string GetResult()
        {
            Guess = (Guess + "    ").Substring(0, 4).ToUpper();
            char[] secret = SecretSequence.ToCharArray();
            string result = "";
            for (int i = 0; i < Guess.Length; i++)
            {
                if (Guess[i] == secret[i])
                {
                    result += "B";
                    secret[i] = 'X'; // To avoid being counted as Cow
                }
            }
            result += ",";
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

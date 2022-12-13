using Moo.Interfaces;

namespace Moo
{
    public class ConsoleHandler : IUserInterface
    {
        public void Output(string data)
        {
            Console.WriteLine(data);
        }
        public string Input()
        {
            return Console.ReadLine();
        }
    }
}

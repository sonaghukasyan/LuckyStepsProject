using LuckyStepsProject.ConsoleUI;
using LuckyStepsProject.GameManager;

namespace LuckyStepsProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IManager manager = new Manager();
            IUI console = new UI();
            manager.SetUI(console);
            console.StartGame();
        }
    }
}

using LuckyStepsProject.ConsoleUI;
using LuckyStepsProject.TheGame;
using LuckyStepsProject.ThePlayer;

namespace LuckyStepsProject.GameManager
{
    internal interface IManager
    {
        IUI ConsoleUI { get; set; }
        void SetUI(IUI ui);
        IGame Game { get; set; }

        void Register(IPlayer player);
    }
}

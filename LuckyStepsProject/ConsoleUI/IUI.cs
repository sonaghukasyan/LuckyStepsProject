using LuckyStepsProject.TheGame;
using LuckyStepsProject.ThePlayer;
using System;

namespace LuckyStepsProject.ConsoleUI
{
    internal interface IUI
    {
        event EventHandler<PlayRequestedArgs> NewPlayRequested;
        event Action<IPlayer> NewPlayerRegistered;
        bool IsGameOver { get; set; }
        StepType ChooseStep();
        void StartGame();
        void Play();
        void Winner();
        void StopGame();
        void Loser();
        void Register();
    }
}

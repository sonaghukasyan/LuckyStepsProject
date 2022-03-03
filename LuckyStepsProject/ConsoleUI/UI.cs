using LuckyStepsProject.TheGame;
using LuckyStepsProject.ThePlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStepsProject.ConsoleUI
{
    internal class UI : IUI
    {
        public event EventHandler<PlayRequestedArgs> NewPlayRequested;
        public event Action<IPlayer> NewPlayerRegistered;
        public  bool IsGameOver { get; set; }
        public IGame Game { get; set; }
        
        public UI()
        {
            this.Game = new Game();
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to the game! ");
            Console.WriteLine("P.Play  R.Register");
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.P:
                    Console.Clear();
                    Play();
                    break;
                case ConsoleKey.R:
                    Console.Clear();
                    Register();
                    StartGame();
                    break;
                default:
                    Console.Clear();
                    StartGame();
                    break;
            }
        }

        public void Play()
        {
            this.IsGameOver = false;
            Console.WriteLine("Enter your username: ");
            string username = Console.ReadLine();

            foreach (EventHandler<PlayRequestedArgs> e in NewPlayRequested.GetInvocationList())
            {
                try
                {
                    e?.Invoke(this, new PlayRequestedArgs(username));
                }

                catch { }
            }
        }

        public StepType ChooseStep()
        {
            Console.WriteLine("L.Left column   R.Right column   S.StopGame");

            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.L:
                    return StepType.Left;
                    
                case ConsoleKey.R:
                    return StepType.Right;
                
                default:
                    StopGame();
                    return StepType.Right;

            }
        }

       public void Winner()
       {
            Console.WriteLine("Congrats. You won 100 drams.");
       }

        public void Loser()
        {
            Console.WriteLine("You lost. Column is empty.");
        }
        public void StopGame()
        {
            this.IsGameOver = true;
            Console.WriteLine("Game stopped.");
            StartGame();
        }

       
        public void Register()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            IPlayer player = new Player(name, username);

            NewPlayerRegistered?.Invoke(player);
        }
    }
}

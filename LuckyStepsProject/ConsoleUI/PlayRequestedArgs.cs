
using LuckyStepsProject.ThePlayer;
using System;

namespace LuckyStepsProject.ConsoleUI
{
    internal class PlayRequestedArgs : EventArgs
    {
        public string Username { get; set; }
        public PlayRequestedArgs(string username)
        {
            this.Username = username;
        }
    }
}

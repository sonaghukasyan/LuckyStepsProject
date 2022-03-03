using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStepsProject.ThePlayer
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public int AttemptsPerDay { get; set ; }

        
        public Player(string name, string username)
        {
            this.Name = name;
            this.Username = username;
        }
    }
}

using LuckyStepsProject.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStepsProject.ThePlayer
{
    public interface IPlayer
    {
        string Name { get; set; }
        string Username { get; set; }

        [PlayAttemptCheck(3)]
        int AttemptsPerDay { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStepsProject.TheGame
{
    public class Step
    {
       public int IsWinner { get; set; }
       public StepType StepType { get; set; }
        public Step(int isWinner, StepType type)
        {
            this.IsWinner = isWinner;
            this.StepType = type;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStepsProject.CustomAttributes
{
    internal class PlayAttemptCheck: System.Attribute
    {
        public int MaxAttepts { get; set; }

        public PlayAttemptCheck(int maxAttempts)
        {
            this.MaxAttepts = maxAttempts;
        }
    }
}

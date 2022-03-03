using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStepsProject.TheGame
{
    internal interface IGame
    {
        int MoneyForWinner { get; set; }

        Step[,] MatrixSteps { get; set; }
        Step[,] CreateMatrix();
        void Stop();

    }
}

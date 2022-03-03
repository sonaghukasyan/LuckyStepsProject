using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStepsProject.TheGame
{
    internal class Game : IGame
    {
        public int MoneyForWinner { get; set; }
        public Step[,] MatrixSteps { get; set ; }

        public Game()
        {
            this.MoneyForWinner = 1000;
            this.MatrixSteps = new Step[10,2];
        }


        public Step[,] CreateMatrix()
        {
            Random rnd = new Random();
            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 2; column++)
                {
                    //1 means there is a money, 0 means it is empty.
                    int step = rnd.Next(0, 2);
                    if(column == 0)
                        this.MatrixSteps[row, column] = new Step(step,StepType.Left);
                    else
                        this.MatrixSteps[row, column] = new Step(step, StepType.Right);

                }
            }

            return this.MatrixSteps;
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStepsProject.DataFile
{
    internal interface IDataAccess<T>
    {
        void Save(IEnumerable<T> list);
        IEnumerable<T> Read();
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStepsProject.TheLogger
{
    internal class Logger : ILogger
    {
        private static string Path { get; set; }
        private static Logger _instance { get; set; }

        private static string Date { get; set; } = DateTime.Now.ToString("dd_M_yyy");
        private static int logDate = DateTime.Now.Day;

        private Logger()
        {
            Path = Date + "Logger.txt";
            if (!File.Exists(Path))
            {
                File.Create(Path).Close();
            }
        }


        public static Logger GetOrSetLogger()
        {
            if (_instance == null || DateTime.Now.Day != logDate)
            {
                _instance = new Logger();
            }
            return _instance;
        }

        private void Log(string mess)
        {
            File.AppendAllText(Path, $"{mess}\n");
        }

        public void Error(Exception ex)
        {
            string err = $"_Err_{ex.Message}";
            this.Log(err);
        }

        public void Error(string err)
        {
            err = $"_Err_{err}";
            this.Log(err);
        }

        public void Info(string info)
        {
            info = $"_Info_{info}";
            this.Log(info);
        }

        public void Warn(string warning)
        {
            warning = $"_Warning_{warning}";
            this.Log(warning);
        }

    }
}

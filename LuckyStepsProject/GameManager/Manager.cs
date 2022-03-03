using LuckyStepsProject.ConsoleUI;
using LuckyStepsProject.CustomAttributes;
using LuckyStepsProject.DataFile;
using LuckyStepsProject.TheGame;
using LuckyStepsProject.TheLogger;
using LuckyStepsProject.ThePlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LuckyStepsProject.GameManager
{
    internal class Manager: IManager
    {
        private IEnumerable<IPlayer> _players;

        public IUI ConsoleUI { get; set ; }
        public IGame Game { get; set; }

        private Logger _logger;
        private IDataAccess<IPlayer> _dataAccess;

        public Manager()
        {
            this._dataAccess = new DataAccess<IPlayer>("PlayerData");
            this._players = _dataAccess.Read();
            this._logger = Logger.GetOrSetLogger();
        }
        public void SetUI(IUI ui)
        {
            this.ConsoleUI = ui;
            this.ConsoleUI.NewPlayRequested += CheckUsername;
            this.ConsoleUI.NewPlayerRegistered += Register;
        }

        public void CheckUsername(object sender, PlayRequestedArgs args)
        {
            foreach (Player player in _players)
            {
                if (player.Username == args.Username)
                {
                    var atts = player.GetType().GetProperties().First().GetCustomAttributes(typeof(PlayAttemptCheck), false);
                    foreach (PlayAttemptCheck att in atts)
                    {
                        if (player.AttemptsPerDay > att.MaxAttepts)
                        {
                            _logger.Info("Max attempt are done. Player :" + player.Username);
                            throw new Exception("You did your max attempts per day. You can play tomorrow.");

                        }
                    }
                    StartGame(player);
                }
            }
            _logger.Error("Wrong username " + args.Username);
            throw new Exception("Wrong username.");
        }

        public void StartGame(Player player)
        {
            this.Game = new Game();
            Step[,] possibleSteps = this.Game.CreateMatrix();

            for(int i = 0; i < possibleSteps.GetLength(0); i++)
            {
                StepType step = this.ConsoleUI.ChooseStep();
                if (ConsoleUI.IsGameOver == false )
                {
                    if (step == StepType.Left && possibleSteps[i, 0].IsWinner == 1)
                    {
                        _logger.Info($" Player {player.Username} won {this.Game.MoneyForWinner}");
                        this.ConsoleUI.Winner();
                    }
                    else if (step == StepType.Right && possibleSteps[i, 1].IsWinner == 1)
                    {
                        _logger.Info($" Player {player.Username} won {this.Game.MoneyForWinner}");
                        this.ConsoleUI.Winner();
                    }
                    else
                    {
                        this.ConsoleUI.Loser();
                    }
                }
                else
                {
                    player.AttemptsPerDay += 1;
                    _dataAccess.Save(_players);
                }
            }
            player.AttemptsPerDay += 1;
            _dataAccess.Save(_players);
        }

        public void Register(IPlayer player)
        {
            _players = _players.Concat(new List<IPlayer>() { player });
            _dataAccess.Save(_players);
        }
    }
}

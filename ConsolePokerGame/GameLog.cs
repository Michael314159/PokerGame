using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePokerGame
{
    public class GameLog
    {
        private List<string> gamelog;

        public GameLog()
        {
            gamelog = new List<string>();
            gamelog.Add("STARTING GAME LOG STARTING GAME LOG STARTING GAME LOG");
        }

        public void AddToLog(string message)
        {
            gamelog.Add($"{DateTime.Now} {message}.");
        }
        public void WriteLog()
        {

            string dataPathLog = @"C:\Users\micha\consolePokerGame.log";
            gamelog.Add("ENDING GAME LOG ENDING GAME LOG ENDING GAME LOG");
            gamelog.Add(String.Empty);

            File.AppendAllLines(dataPathLog, gamelog);
            
        }
    }
}

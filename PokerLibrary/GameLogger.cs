using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    /// <summary>
    /// Create a game log robust enough  from which
    /// any type of View Model can be created (console,wpf,etc),
    /// and suitable for debugging.
    /// </summary>
    public class GameLogger
    {
        //possible logging levels
        public enum LogLevel { Debug, Info, Warning, Error };

        //assume debug
        public LogLevel Level = LogLevel.Debug;

        public enum LogEvents { GameStarting,GameWaiting,PlayingHand,
                                DealingCards,
                                PlayingPreflop,
                                DealingFlop,PlayingFlop,
                                DealingTurn,Playing,Turn,
                                DealingRiver,PlayingRiver,
                                DeterminingWinners,
                                AwardingPots,
                                MovingButtons,
                                HandEnding,GameEnding
        }

        string filename = @"C:\Users\micha\pokergame.log";

        //CONSTRUCTOR

        public GameLogger() { }
        public GameLogger(string filename) {
            this.filename = filename;   
        }

        public bool LogGameAction(string whathappened)
        {
            bool ret = false;

            StringBuilder sb = new StringBuilder();
            sb.Append($"{DateTime.Now} {whathappened}");
            sb.ToString();

            ret = WriteToLogFile(whathappened);

            return ret;
        }

        private bool WriteToLogFile(string whathappened)
        {
           
            bool ret = false;
            //string dataPathLog = @"C:\Users\micha\pokergame.log";
            //File.WriteAllLines(dataPathLog, this.LogMessages);

            string time = DateTime.Now.ToString();


            string[] lines = new string[1];
            lines[0] = $"{time} {whathappened}";
            


            File.AppendAllLines(filename, lines);
            ret = true;
            
            return ret;
        }

    }
}

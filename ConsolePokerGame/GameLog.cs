using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            // A dictionary that contains every instance Property and its value
            Dictionary<string, object> dictProperties = new Dictionary<string, object>();

            //Get all the properties and their valuse for this instance
            PropertyInfo[] RetrieveProperties()
            {
                //object is this instance
                var type = this.GetType();
                return type.GetProperties();
            }

            //Place this instances properties and values into a var
            var varProperties = RetrieveProperties();

            //Place into dictionary a dictionary to hold this property information
            foreach (var property in varProperties)
            {
                dictProperties.Add(property.Name, property.GetValue(this));
            }

            ////Use this info for the ToString override
            foreach (var item in dictProperties)
            {
                sb.AppendLine(item.Key + ": " + item.Value);
            }
            //Summarry line of most relevant info
            //sb.Append($"|SEAT NUMBER {Number} |DB {IsDealer} |SB {IsSmallBlind} |BB {IsBigBlind}");

            return sb.ToString();
        }
    }
}

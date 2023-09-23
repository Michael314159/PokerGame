using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePokerGame
{
    public class Player
    {
        public string PlayerName { get; set; }
        public decimal PlayerStack {  get; set; }
        public List<Card> PlayerHoleCards {  get; set; }

        
        public Player(string name) {
        
            this.PlayerName = name;
            this.PlayerStack = 0;
            this.PlayerHoleCards = new List<Card>();
        }


        public override string ToString()
        {
            //List all this objects properties and thei values.
            //Lengthy, but dynamically fins them ALL so I don't have to update the method
            //when I refactor


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

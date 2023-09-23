using System.Reflection;
using System.Text;

namespace ConsolePokerGame
{
    public enum PlayerAction
    {
        None,Fold,Check,Call,Bet,Raise
    }

    public enum PlayerResult
    {
        None,Lost,Won,SplitPot
    }
    public class Seat 
    {
        public int Seatnumber { get; set ; }

        public bool IsSmallBlind { get; set; }
        public bool IsBigBlind { get; set; }
        public bool IsDealerButton { get; set; }
        public bool IsPlayerReadyToPlay { get; set; }

        public bool HasMissedBlindButtons { get; set; }
        public bool HasSeatReservedButton { get; set; }
        public bool HasSeatedPlayer {  get; set; }  

        //These are thing we get from the player.
        //The Seat object needs to know about them because the Seat is displayed - not the player.

        public List<Card>? HoleCards { get; set; }
        public PlayerAction PlayersAction { get; set; }
        public decimal  PlayersWager { get; set; }
        public decimal  PlayersStack { get; set; }
        public PlayerResult PlayersResult { get; set; }

        

        //Constructor
        public Seat(int seatnumber)
        {
            this.Seatnumber = seatnumber;
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
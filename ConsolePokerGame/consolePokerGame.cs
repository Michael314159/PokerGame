using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePokerGame
{
    /// <summary>
    /// This will be poker game that runs as a console app.
    /// The Interfaces describe objects that a 
    /// simple poker game model must have for logic and display.
    /// 
    /// The View and ViewModel are derived from the Log for a
    /// bare bones game.
    /// </summary>
    public class consolePokerGame 
    {

        // Properties required to model the game
    
        public List<Seat> Seats { get; set; }
        public List<Player> Players { get; set; }
        public List<Card> Deck { get; set; }
        public List<Card> Board {  get; set; }

        public List<Pot> Pots { get; set; }

        public GameLog Log { get; set; }
        
      
        //Constructor
        public consolePokerGame() {

            this.Seats = new List<Seat>();
            this.Board = new List<Card>();
            this.Deck = new List<Card>();
            this.Players = new List<Player>();
            this.Pots = new List<Pot>();
            this.Log = new GameLog();

            this.Seats.Add(new Seat(1));
            this.Seats.Add(new Seat(2));
            this.Seats.Add(new Seat(3));
            this.Seats.Add(new Seat(4));
            this.Seats.Add(new Seat(5));
            this.Seats.Add(new Seat(6));
            this.Seats.Add(new Seat(7));
            this.Seats.Add(new Seat(8));
            this.Seats.Add(new Seat(9));

            StartGame();
        }

        private void StartGame()
        {
            this.Log.AddToLog(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
           


            PlayGame();
        }
        private void PlayGame()
        {
            this.Log.AddToLog(System.Reflection.MethodBase.GetCurrentMethod()!.Name);

            EndGame();
        }
        private void EndGame()
        {
            this.Log.AddToLog(System.Reflection.MethodBase.GetCurrentMethod()!.Name);

            //some test stuff
            this.Players.Add(new Player("fred"));
            this.Players.First().PlayerHoleCards.Add(new Card(11));
            this.Players.First().PlayerHoleCards.Add(new Card(12));



            this.Log.WriteLog();
            Console.WriteLine(this.ToString());


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

            foreach(var item in Seats)
            {
                sb.Append($"|SEAT NUMBER {item.Seatnumber} |DB {item.IsDealerButton} |SB {item.IsSmallBlind} |BB {item.IsBigBlind}");
                sb.AppendLine("");
            }
            sb.AppendLine($"");

            foreach (var item in Players)
            {
                sb.Append($"|PLAYER NAME {item.PlayerName} |STACK {item.PlayerStack}");

                if (item.PlayerHoleCards.Count > 0)
                {
                    List<Card> cards = item.PlayerHoleCards;
                    string c1 = cards[0].id.ToString();
                    string c2 = cards[1].id.ToString();

                    sb.AppendLine($"| HOLECARDS [{c1}] [{c2}]");
                };
            }
            sb.AppendLine($"");

            return sb.ToString();
        }
    }
}

using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;


namespace PokerLibrary
{
    public class GameState
    {
        public List<Seat> Seats { get; set; }
        public List<Player> Players { get; set; }
        public List<Card> Deck { get; set; }
        public List<Card> Board { get; set; }
        public Decimal CurrentWager { get; set; }

        public List<string> LogMessages { get; set; }
        public List<string> LogGameView { get; set; }


        public GameState(List<Seat> seats,
                            List<Player> players,
                            List<Card> deck,
                            List<Card> board,
                            decimal wager,
                            List<string> logMessages,
                            List<string> logGameView)
        {
            this.Seats = seats;
            this.Players = players;
            this.Deck = deck;
            this.Board = board;
            this.CurrentWager = wager;
            this.LogMessages = logMessages;
            this.LogGameView = logGameView;
           
        }

        public void WriteLog()
        {
            string dataPathLog = @"C:\Users\micha\pokergame.log";
            File.WriteAllLines(dataPathLog, this.LogMessages);

            string dataPathTxt = @"C:\Users\micha\pokergame.txt";
            File.WriteAllLines(dataPathTxt, this.LogGameView);


        }

      
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"GameStateView");

            StringBuilder sbSeats = new StringBuilder();
            foreach (Seat seat in this.Seats)
            {
                sbSeats.AppendLine($"{seat.Name} playing:{seat.IsPlaying.ToString()}" +
                    $" db:{seat.IsDealer.ToString()} sb:{seat.IsSmallBlind.ToString()}" +
                    $" bb:{seat.IsBigBlind.ToString()}");
            }
            sbSeats.ToString();

            sb.AppendLine($"{sbSeats}");
            sb.AppendLine($"");
           




            return sb.ToString();
        }


    }   
}

using System.Runtime.CompilerServices;
using System.Text;


namespace PokerLibrary
{
    internal class GameState
    {
        public List<Seat> Seats { get; set; }
        public List<Player> Players { get; set; }
        public List<Card> Deck { get; set; }
        public List<Card> Board { get; set; }
        public Decimal CurrentWager { get; set; }

        public int LastReturnCode = 0;
        public List<string> LogMessages { get; set; }


        public GameState(List<Seat> seats,
                            List<Player> players,
                            List<Card> deck,
                            List<Card> board,
                            decimal wager,
                            int lastReturnCode,
                            List<string> logMessages)
        {
            this.Seats = seats;
            this.Players = players;
            this.Deck = deck;
            this.Board = board;
            this.CurrentWager = wager;
            LastReturnCode = lastReturnCode;
            LogMessages = logMessages;
        }

        public void WriteLog()
        {
            string dataPath = @"C:\Users\micha\pokergame.log";
            File.WriteAllLines(dataPath, this.LogMessages);



        }
        private string ShowSeats()
        {
            StringBuilder sb = new StringBuilder();

            this.Seats.ForEach(x => sb.AppendLine(x.ToString()));

            return sb.ToString();
        }
        public override string ToString()
        {
            return ShowSeats();
        }

    }   
}

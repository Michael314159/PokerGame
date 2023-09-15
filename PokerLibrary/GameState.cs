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

        public override string ToString()
        {
            StringBuilder sbGame = new StringBuilder();
            StringBuilder sbSeats = new StringBuilder();
            StringBuilder sbPlayers = new StringBuilder();
            StringBuilder sbBoard = new StringBuilder();
            StringBuilder sbDeck = new StringBuilder();
            StringBuilder sbPots = new StringBuilder();
            StringBuilder sbWager = new StringBuilder();

            foreach (Seat seat in Seats)
            {
                sbSeats.Append(seat.ToString());
            }

            foreach (Seat seat in Seats)
            {
                if (seat.Player != null)
                {
                    sbPlayers.AppendLine(seat.Player.Name);
                }
            }

           

            //sbGame.AppendLine(sbPlayers.ToString());

            //this.Seats.Select(s => s.Player != null).ToList()
            //                    .ForEach(s => sbPlayers.AppendLine(s.ToString()));

            StringBuilder ret = new StringBuilder();

            ret.AppendLine(sbSeats.ToString());
            ret.AppendLine(sbPlayers.ToString());


            return ret.ToString();
        }
    }
}

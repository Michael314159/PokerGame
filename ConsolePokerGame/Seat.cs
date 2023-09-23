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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    /// <summary>
    /// Latest iteration of the Game Objecy
    /// </summary>
    public class TheGame
    {
        //The game objects needed for both logic and display
        LinkedList<Seat> seats;
        List<Card> deck;
        List<Player> players;
        List<Pot> pots;
        List<Card> board;
        decimal current_wager;

        

        //Constuctor
        public TheGame() {

            //These objects must exist
            // this._gameState = new GameState();
            this.deck = new List<Card>();
            this.seats = new LinkedList<Seat>();
            this.players = new List<Player>();
            this.board = new List<Card>();
            this.pots = new List<Pot>();

            // As A functional program, we only are born,live,and die
            StartTheGame();
            PlayTheGame();
            StopTheGame();
        }

        public bool StartTheGame() {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            string strMessage = "Game Starting";
            string strLogMessage = $"{strMethodName} {strMessage}";
            string strDisplayMessage = $"{strMessage}";
            LogMessage(strLogMessage);
            LogDisplay(strDisplayMessage);
            WriteToConsole(strMessage);

            // Make the needed game objects
            MakeDeck(this.deck);
            MakeLinkedSeats(this.seats);
            MakeBoard(this.board);
            MakePots(this.pots);
            MakeCurrentWager(this.current_wager);

            //DEBUG
            //Display what we have so far

            Console.WriteLine("DECK");
            foreach (Card item in deck)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("SEATS");
            foreach (var item in seats)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("BOARD");
            foreach (var item in board)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("POTS");
            foreach (var item in pots)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("WAGER");
            Console.WriteLine(current_wager.ToString());
            //MakePlayers(this.players);

            //for (LinkedListNode<Seat> node = this.seats.First; node != null; node = node.Next)
            //{
            //    Console.WriteLine("NODE:" + node.Value);
            //}

            //Console.WriteLine(this.deck[5].ToString());



            return true;
        }
        public bool PlayTheGame() {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            string strMessage = "Game Playing";
            string strLogMessage = $"{strMethodName} {strMessage}";
            string strDisplayMessage = $"{strMessage}";
            LogMessage(strLogMessage);
            LogDisplay(strDisplayMessage);
            WriteToConsole(strMessage);

            //Add some players to the seats
            MakePlayers(this.players);

            //Fill the table...
            foreach (var item in Enumerable.Range(0, seats.Count))
            {
                seats.ToList().ForEach(x =>
                {
                    x.AddPlayer(players[x.Number - 1]);
                    x.IsPlaying = true;
                    
                });
            }

            foreach (var item in seats)
            {
                Console.WriteLine(item.ToString());
            }



            LinkedListNode<Seat> currentNode = seats.First;
            Console.WriteLine("I am looping through list");
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value.ToString());
                if (currentNode.Value.Number == 1)
                {
                    currentNode.Value.IsDealer = true;
                }
                if (currentNode.Value.Number == 2)
                {
                    currentNode.Value.IsSmallBlind = true;
                }
                if (currentNode.Value.Number == 3)
                {
                    currentNode.Value.IsBigBlind = true;
                }
                currentNode = currentNode.Next;
            }
            Console.WriteLine("SEATS");
            foreach (var item in seats)
            {
                Console.WriteLine(item.ToString());
            }

            return true;
        }
        public bool StopTheGame() {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            string strMessage = "Game Stoping";
            string strLogMessage = $"{strMethodName} {strMessage}";
            string strDisplayMessage = $"{strMessage}";
            LogMessage(strLogMessage);
            LogDisplay(strDisplayMessage);
            WriteToConsole(strMessage);



            //Save the logs
            WriteLogs();
            return true;
        }



        #region Helper Methods
        private decimal MakeCurrentWager(decimal wager)
        {
            //gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");
            wager = 0;
            return wager;

        }
        private List<Pot> MakePots(List<Pot> pots)
        {
            //gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");

            pots.Clear();
            pots.Add(new Pot(0)); pots.Add(new Pot(1)); pots.Add(new Pot(2));
            pots.Add(new Pot(3)); pots.Add(new Pot(4)); pots.Add(new Pot(5));
            pots.Add(new Pot(6)); pots.Add(new Pot(7)); pots.Add(new Pot(8));

            return pots;
        }
        private List<Card> MakeBoard(List<Card> board)
        {
            //gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");
            board.Add(new Card(Rank.None, Suit.None));
            board.Add(new Card(Rank.None, Suit.None));
            board.Add(new Card(Rank.None, Suit.None));


            return board;
        }
        private List<Player> MakePlayers(List<Player> players)
        {
            //gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");
            players.Clear();
            players.Add(new Player("Arnold", 100));
            players.Add(new Player("Barney", 200));
            players.Add(new Player("Charles", 300));
            players.Add(new Player("David", 400));
            players.Add(new Player("Evelyn", 500));
            players.Add(new Player("Frank", 600));
            players.Add(new Player("George", 700));
            players.Add(new Player("Harold", 800));
            players.Add(new Player("Indira", 900));


            return players;
        }

        private LinkedList<Seat> MakeLinkedSeats(LinkedList<Seat> seats)
        {
            var seatnumbers = Enumerable.Range(1, 9).ToList();
            seatnumbers.ForEach(x =>
            {
                seats.AddLast(new Seat(x));
            });

            

            //DEBUG
            //foreach (var item in seats)
            //{
            //    WriteToConsole(item.ToString());
            //}

            return seats;
        }
        private List<Seat> MakeSeats(List<Seat> seats)
        {
            var seatnumbers = Enumerable.Range(1, 9).ToList();
            seatnumbers.ForEach(x =>
            {
                seats.Add(new Seat(x));
            });


            //DEBUG
            //foreach (var item in seats)
            //{
            //    WriteToConsole(item.ToString());
            //}

            return seats;
        }

        private List<Card> MakeDeck(List<Card> deck)
        {
            var cardnumbers = Enumerable.Range(1, 52).ToList();
            cardnumbers.ForEach(x =>
            {
                Rank rank = (Rank)((x % 13) + 1);   //we add '1' because the enums start at 0=none 
                Suit suit = (Suit)((x % 4) + 1);
                deck.Add(new Card(rank, suit));
            });
            //DEBUG
            //foreach (var item in deck)
            //{
            //    WriteToConsole(item.ToString());
            //}
            return deck;
        }
        #endregion
        #region Logging and debugging

        //this is the log 
        public List<string> Log = new List<string>();
        //this is what we display
        public List<string> Display = new List<string>();

        public void WriteLogs()
        {
            string dataPathlog = @"C:\Users\micha\pokergame.log";
            File.WriteAllLines(dataPathlog, this.Log);

            string dataPathdisplay = @"C:\Users\micha\pokergame.txt";
            File.WriteAllLines(dataPathdisplay, this.Display);
        }

        public void WriteToConsole(string message)
        {
            Console.WriteLine(message);
        }


        //Add messsage to the log
        private void LogMessage( string message )
        {

            Log.Add($"{DateTime.Now} {message}" );
        }

        //add message to the display log
        private void LogDisplay(string message)
        {

            Display.Add($"{DateTime.Now} {message}");
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public class Game
    {
        /// <summary>
        /// If the game were cpmpleted functions.....
        /// </summary>

        
        /// <summary>
        /// Game objects
        /// 
        /// Everything that can be made Displable is an object.
        /// The Game Model also will use them
        /// </summary>
        /// 
        List<Card> _deck;
        List<Seat> _seats;
        List<Player> _players;
        List<Card> _board;
        List<Pot> _pots;
        decimal _current_bet;


        public Game() { 
        
            this._deck = new List<Card>();
            this._seats = new List<Seat>();
            this._players = new List<Player>();
            this._board = new List<Card>();
            this._pots = new List<Pot>();
            this._current_bet = 0;

            _deck = MakeDeck(_deck);
            _seats = MakeSeats(_seats);
            _players = MakePlayers(_players);
            _board = MakeBoard(_board);
            _pots = MakePots(_pots);
            _current_bet = 0;

            // We;ve created the game objects...
            // Start the game.

            StartUp();

        }


        public  void StartUp()
        {
            ShowGame();
           

        }
        public void ShowGame()
        {
            //No changes so no need to retrun objects


            //ShowSeats();
           // ShowPlayers();
            
           // _seats[2].IsPlaying = true;
            //_seats[2].AddPlayer(_players[0]);
            //_seats[4].IsPlaying = true;
            //_seats[4].IsDealer = true;
            //_seats[4].AddPlayer(_players[1]);
            //_seats[5].IsPlaying = false;
            //
            //_seats[5].AddPlayer(_players[2]);

            // ShowSeats();
            // ShowPlayers();
            //ShowDeck();

            ShowSeats();

            //

            SeatPlayers(_seats,_players);

            ShowSeats();

            MoveDealerButton(_seats);
            MoveDealerButton(_seats);

            MoveDealerButton(_seats);
            MoveDealerButton(_seats);
            MoveDealerButton(_seats);

            MoveDealerButton(_seats);

            MoveDealerButton(_seats);
            MoveDealerButton(_seats);

            MoveDealerButton(_seats);
            MoveDealerButton(_seats);
            MoveDealerButton(_seats);



            ShowSeats();

        }
        private List<Seat> MoveDealerButton(List<Seat> seats)
        {

            return Seat.MoveDealerButton(seats);


        }

        private List<Seat> MoveSmallBlindButton(List<Seat> seats)
        {

            return Seat.MoveSmallBlindButton(seats);


        }

        private List<Seat> MoveBigBlindButton(List<Seat> seats)
        {

            return Seat.MoveBigBlindButton(seats);


        }



        private List<Pot> MakePots(List<Pot> pots)
        {
            pots.Clear();
            pots.Add(new Pot(0)); pots.Add(new Pot(1)); pots.Add(new Pot(2));
            pots.Add(new Pot(3)); pots.Add(new Pot(4)); pots.Add(new Pot(5));
            pots.Add(new Pot(6)); pots.Add(new Pot(7)); pots.Add(new Pot(8));

            return pots;

        }

        private List<Card> MakeBoard(List<Card> board)
        {
            board.Clear();
            board.Add(new Card(Rank.None, Suit.None));
            board.Add(new Card(Rank.None, Suit.None));
            board.Add(new Card(Rank.None, Suit.None));

            return board;


        }

        private List<Player> MakePlayers(List<Player> players)
        {
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

        private  List<Seat> MakeSeats(List<Seat> seats)
        {
            seats.Clear();  
            seats.Add(new Seat(1));
            seats.Add(new Seat(2));
            seats.Add(new Seat(3));
            seats.Add(new Seat(4));
            seats.Add(new Seat(5));
            seats.Add(new Seat(6));
            seats.Add(new Seat(7));
            seats.Add(new Seat(8));
            seats.Add(new Seat(9));

            return seats;
        }

        private List<Seat> SeatPlayers(List<Seat> seats , List<Player> players)
        {
            //for eats of the nine seats....
            for (int i = 0; i < seats.Count; i++)
            {
                // up to 9 plauers form player list
                for (int j = 0; j < players.Count; j++)
                {
                    seats[i].Player = players[j];

                }
            }

            //make them all active for now...;

            foreach (Seat seat in seats)
            {
                if (seat.Player != null)
                {
                    seat.IsPlaying = true;
                }
            }
            return seats;

        }
        private List<Card> MakeDeck(List<Card> deck)
        {

            List<Card> new_deck = new List<Card>() {   new Card(Rank.Two,Suit.Clubs),new Card(Rank.Three,Suit.Clubs),new Card(Rank.Four,Suit.Clubs),
                                        new Card(Rank.Five,Suit.Clubs),new Card(Rank.Six,Suit.Clubs),new Card(Rank.Seven,Suit.Clubs),
                                        new Card(Rank.Eight,Suit.Clubs),new Card(Rank.Nine,Suit.Clubs),new Card(Rank.Ten,Suit.Clubs),
                                        new Card(Rank.Jack,Suit.Clubs),new Card(Rank.Queen,Suit.Clubs),new Card(Rank.King,Suit.Clubs),
                                        new Card(Rank.Ace,Suit.Clubs),
                                        new Card(Rank.Two,Suit.Diamonds),new Card(Rank.Three,Suit.Diamonds),new Card(Rank.Four,Suit.Diamonds),
                                        new Card(Rank.Five,Suit.Diamonds),new Card(Rank.Six,Suit.Diamonds),new Card(Rank.Seven,Suit.Diamonds),
                                        new Card(Rank.Eight,Suit.Diamonds),new Card(Rank.Nine,Suit.Diamonds),new Card(Rank.Ten,Suit.Diamonds),
                                        new Card(Rank.Jack,Suit.Diamonds),new Card(Rank.Queen,Suit.Diamonds),new Card(Rank.King,Suit.Diamonds),
                                        new Card(Rank.Ace,Suit.Diamonds),
                                        new Card(Rank.Two,Suit.Hearts),new Card(Rank.Three,Suit.Hearts),new Card(Rank.Four,Suit.Hearts),
                                        new Card(Rank.Five,Suit.Hearts),new Card(Rank.Six,Suit.Hearts),new Card(Rank.Seven,Suit.Hearts),
                                        new Card(Rank.Eight,Suit.Hearts),new Card(Rank.Nine,Suit.Hearts),new Card(Rank.Ten,Suit.Hearts),
                                        new Card(Rank.Jack,Suit.Hearts),new Card(Rank.Queen,Suit.Hearts),new Card(Rank.King,Suit.Hearts),
                                        new Card(Rank.Ace,Suit.Hearts),
                                        new Card(Rank.Two,Suit.Spades),new Card(Rank.Three,Suit.Spades),new Card(Rank.Four,Suit.Spades),
                                        new Card(Rank.Five,Suit.Spades),new Card(Rank.Six,Suit.Spades),new Card(Rank.Seven,Suit.Spades),
                                        new Card(Rank.Eight,Suit.Spades),new Card(Rank.Nine,Suit.Spades),new Card(Rank.Ten,Suit.Spades),
                                        new Card(Rank.Jack,Suit.Spades),new Card(Rank.Queen,Suit.Spades),new Card(Rank.King,Suit.Spades),
                                        new Card(Rank.Ace,Suit.Spades)
                                };
            _deck = new_deck;

            return _deck;
        }
       

        private void ShowSeats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Seat s in this._seats )
            {
               
              // sb.AppendLine(s.Player!.Name + " " + s.Player.Chips.ToString() + "Cards:" + s.Player.Cards[0].ToString() +
              
                sb.Append(s.Name.ToString() + " ");
                sb.Append($"isPlaying: {s.IsPlaying.ToString()} ");
                sb.Append($"isDealer: {s.IsDealer.ToString()} ");
                sb.Append($"isSmallBlind: {s.IsSmallBlind.ToString()} ");
                sb.Append($"isBigBlind: {s.IsBigBlind.ToString()} ");

                sb.AppendLine();

            }

            Console.WriteLine(sb.ToString());
            Console.WriteLine();
        }

        private void ShowPlayers()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Seat s in this._seats)
            {
                if (s.Player == null)
                {
                    sb.AppendLine(s.Name + " has no player seated.");
                } else
                {
                    sb.AppendLine(s.Name + " " + s.Player.Name);
                }
                
               

            }

            Console.WriteLine(sb.ToString());
            Console.WriteLine();
        }



        public void ShowDeck()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 13; i++)
            {
                sb.Append(_deck[i].ToString() + " ");
            }

            sb.AppendLine();
            sb.AppendLine();
            for (int i = 13; i < 26; i++)
            {
                sb.Append(_deck[i].ToString() + " ");
            }
            sb.AppendLine();
            sb.AppendLine();


            for (int i = 26; i < 39; i++)
            {
                sb.Append(_deck[i].ToString() + " ");
            }
            sb.AppendLine();
            sb.AppendLine();
            for (int i = 39; i < 52; i++)
            {
                sb.Append(_deck[i].ToString() + " ");
            }
            sb.AppendLine();


            Console.WriteLine(sb.ToString());
            Console.WriteLine();

        }


    }
}

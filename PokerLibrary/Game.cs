using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    //High level poker game objects


    public enum LogAction
    {
        GameStarting, GameStarted, GameEnding, GameEnded,
        PlayingOneHand
    }

   


    
    public class Game
    {
        //Create the game objects

        public List<string> Log;
        public List<Seat> Seats;
        public List<Player>? Players;
        public List<Card>? Deck;

        public Game() {

            Log = new List<string>();
            Seats = new List<Seat>();
            Deck = new List<Card>();
        }

        public void GameStart()
        {
            Log.Add(LogAction.GameStarting.ToString());

            Seats = new List<Seat> { new Seat(1), new Seat(2),new Seat(3), new Seat(4), new Seat(5),
                                     new Seat(6), new Seat(7),new Seat(8), new Seat(9)
                                    };

            //ShowSeats();
            FillAllSeats();
            MakeDeck();
        }

        public void MakeDeck()
        {
            Deck = new List<Card>() {   new Card(Rank.Two,Suit.Clubs),new Card(Rank.Three,Suit.Clubs),new Card(Rank.Four,Suit.Clubs),
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
        }



        public void FillAllSeats()
        {
            Players = new List<Player>() { new Player("Anton", 300), new Player("Betty",310), new Player("Carl",320),
                                            new Player("David",330),new Player("Everett", 340),new Player("Frank", 350),
                                            new Player("George", 360),new Player("Hank", 370),new Player("Indira", 380)
            };

            int cnt = 0;
            foreach (Seat seat in Seats)
            {
                seat.Player = Players[cnt++];
            }
        }
           
        public void PlayOneHand()
        {
            Log.Add(LogAction.PlayingOneHand.ToString());
        }

        public void GameEnd()
        {
            Log.Add(LogAction.GameEnding.ToString());
            ShowLog();
            ShowSeats();
            ShowDeck();
        }
        public void ShowLog()
        {
            foreach (var line in Log)
            {
                Console.WriteLine(line);
            }
        }


        public void ShowDeck()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 13; i++)
            {
                sb.Append(Deck[i].ToString() + " ");     
            }

            sb.AppendLine();
            sb.AppendLine();
            for (int i = 13; i < 26; i++)
            {
                sb.Append(Deck[i].ToString() + " ");
            }
            sb.AppendLine();
            sb.AppendLine();


            for (int i = 26; i < 39; i++)
            {
                sb.Append(Deck[i].ToString() + " ");
            }
            sb.AppendLine();
            sb.AppendLine();
            for (int i = 39; i < 52; i++)
            {
                sb.Append(Deck[i].ToString() + " ");
            }
            sb.AppendLine();
            sb.AppendLine();


            Console.WriteLine(sb.ToString());
        }
        public void ShowSeats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var s in Seats)
            {
                if (Players == null)
                {
                    sb.AppendLine(s.Name);

                }
                else
                {
                    sb.AppendLine(s.Player!.Name + " " + s.Player.Chips.ToString());

                }

            }

            Console.WriteLine(sb.ToString());
        }




    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    /// <summary>
    /// To Facilitate a functional architecture, begin the task in a modular, expandabe fashion.
    /// </summary>
    public class HiLevelGame
    {
        // Define the Game's objects. Thins that will need to be disoplayed and things the
        // fame model will use to run the model.

        //It may be best this list is exhaustive at first. refactoring will tidy thing up.


        //start with that which must have a visual interface AND be part of the model



        List<Card> _deck;
        List<Seat> _seats;
        List<Player> _players;
        List<Card> _board;
        List<Pot> _pots;
        decimal _current_bet;

        // This object contains the compler gameState



        //Simple Constructor for now - eventually it should take arguments.
        public HiLevelGame()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);

            this._deck = new List<Card>();
            this._seats = new List<Seat>();
            this._players = new List<Player>();
            this._board = new List<Card>();
            this._pots = new List<Pot>();
            this._current_bet = 0;

           StartGame();
        }
        private void PostConstructorTasks()
        {

            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);

            // Use a private function even for the most trivial to avoid futuer bloating

            this._deck = MakeDeck(_deck);
            this._seats = MakeSeats(_seats);
            this._players = MakePlayers(_players);
            this._board = MakeBoard(_board);
            this._pots = MakePots(_pots);
            this._current_bet = MakeCurrentBet();

        }
           
        public void StartGame()
        {
            PostConstructorTasks();
            Gameloop();
            //_deck = QuickCheck(_deck);
        }

        private void ShowSeats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Seat s in this._seats)
            {

                // sb.AppendLine(s.Player!.Name + " " + s.Player.Chips.ToString() + "Cards:" + s.Player.Cards[0].ToString() +

                sb.Append(s.Name.ToString() + " ");
                sb.Append($"isPlaying: {s.IsPlaying.ToString()} ");
                sb.Append($"isDealer: {s.IsDealer.ToString()} ");
                sb.Append($"isSmallBlind: {s.IsSmallBlind.ToString()} ");
                sb.Append($"isBigBlind: {s.IsBigBlind.ToString()} ");

                if (s.Player?.Cards != null)
                {
                    foreach (Card c in s.Player.Cards)
                    {
                        sb.Append($" {c.ToString()}");
                    }
                }

                sb.AppendLine();

            }

            Console.WriteLine(sb.ToString());
            Console.WriteLine();
        }

        private void Gameloop()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);

            bool gameover = false;

            while (gameover != true)
            {


                Console.WriteLine("Simple game loop.");
                Console.WriteLine("");

                Console.WriteLine("Enter 'q' to quit.");
                Console.WriteLine("Enter 'p' to play a hand.");

                string answer = Console.ReadLine() ?? "q";
                Console.WriteLine(answer);

                if (answer == "q")
                {
                    EndGame();
                    gameover = true;
                }

               if (answer == "p")
                {
                    PlayAHand();
                }


            }

        }
        private List<Card> QuickCheck(List<Card> cards)
        {
            var basicQuery = (from card in cards
                              select card).ToList();
            var basicQuery2 = (from card in cards
                               select new Card()
                               {
                                   
                                   Rank = card.Rank,
                                   Suit = Suit.None
                               }
                              ).ToList();

            List<int> cardNumbers = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,
                14,15,16,17,18,19,20,21,22,23,
                24,25,26,27,28,29,30,31,32,33,
                34,35,36,37,38,39,40,41,42,43,
                44,45,46,47,48,49,50,51,52
            };
            


            var TransformIntoDeckQuery = (from num in cardNumbers
                                          select new Card()
                                          {
                                              Rank = (Rank)num,
                                              Suit = Suit.None
                                          }).ToList();
           
           

            var basicMethod = cards.Where(x => x.Rank == Rank.Six)
                                    .ToList();

            List<Card> halfdeck = new List<Card>();

            halfdeck = basicQuery.ToList();

            foreach (Card card in TransformIntoDeckQuery)
            {
                Console.WriteLine(card.ToString());
            }

            return cards;

           

        }
        private void PlayAHand()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
            DealPreFlop();
            PlayPreFlop();
            DealFlop();
            PlayFlop();
            DealTurn();
            PlayTurn();
            DealRiver();
            PlayRiver();
            AwardPots();
        }

        private void AwardPots()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);

            Console.WriteLine("EXTENSION");
            _ = _deck.ShowCards();
        }

        private void PlayRiver()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
        }

        private void DealRiver()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
        }

        private void PlayTurn()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
        }

        private void DealTurn()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
        }

        private void PlayFlop()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
        }

        private void DealFlop()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
        }

        private void PlayPreFlop()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
        }

        private void DealPreFlop()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
        }

        private void EndGame()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
        }

        private decimal MakeCurrentBet()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
            return 0m;

        }

        private List<Pot> MakePots(List<Pot> pots)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
            return pots;
        }

        private List<Card> MakeBoard(List<Card> board)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
            return board;
        }

        private List<Player> MakePlayers(List<Player> players)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
            return players;
        }

        private List<Seat> MakeSeats(List<Seat> seats)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
            //for (int i = 1;i < 10; i++)
            //{
            //    seats.Add(new Seat(i));
            //}

            //List<int> seatnumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var seatnumbers = Enumerable.Range(1, 9).ToList();

            seatnumbers.ForEach(x => 
            {
                seats.Add(new Seat(x));
            });


          

            return seats;


        }

        private List<Card> MakeDeck(List<Card> deck)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);

            var cardnumbers = Enumerable.Range(1, 52).ToList();
            

            cardnumbers.ForEach(x =>
            {
                Rank rank = (Rank)((x % 13) + 1);   //we add '1' because the enums start at 0=none 
                Suit suit = (Suit)((x % 4) + 1);
                deck.Add(new Card(rank, suit));
            });



            return deck;
        }



       
    }
}



using System;
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
            return seats;
        }

        private List<Card> MakeDeck(List<Card> deck)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
            return deck;
        }
    }
}



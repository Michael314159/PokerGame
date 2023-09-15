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
    /// To Facilitate a functional architecture, write the game in a modular, expandabe fashion.
    /// </summary>
    public class HiLevelGame
    {
        // Define the Game's objects. 
        //
        // The game_state wil contain references to all the game objects.
        // We will pass this List of references to each funstion that needs it, and
        // REPLACE the game_state with the changes made by the function.
        //
        // We are trying to avoid any function that modifies ANY data outsite of itself.
        //
        // That means any change in the game is made by a process of tight functions.

       
        List<Card> _deck;
        List<Seat> _seats;
        List<Player> _players;
        List<Card> _board;
        List<Pot> _pots;
        decimal _current_bet;
        List<string> _gamelog;
        int _last_return_code;

        // This object contains the complete gameState

        GameState _game_state;

        //Simple Constructor for now
        public  HiLevelGame()
        {
           // gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");

            this._deck = new List<Card>();
            this._seats = new List<Seat>();
            this._players = new List<Player>();
            this._board = new List<Card>();
            this._pots = new List<Pot>();
            this._current_bet = 0;
            this._gamelog = new List<string>();
            this._last_return_code = -1;

            this._deck = MakeDeck(_deck);
            this._seats = MakeSeats(_seats);
            this._players = MakePlayers(_players);
            this._board = MakeBoard(_board);
            this._pots = MakePots(_pots);
            this._gamelog = MakeGameLog(_gamelog);
            this._current_bet = MakeCurrentBet(_current_bet);

            this._game_state = new GameState(_seats, _players, _deck, _board, _current_bet,
                                                _last_return_code, _gamelog);


            //Run the game
            
            Gameloop(_game_state!);


       
        }

        private List<string> MakeGameLog(List<string> log)
        {
            DateTime now = DateTime.Now;

            log.Add($"{now} +  GAMELOG Starting...............");
           
            return log;

        }

        private  void Gameloop(GameState gamestate)
        {
            //Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
            gamestate.LogMessages.Add($"In {System.Reflection.MethodBase.GetCurrentMethod()!.Name}");


            bool gameover = false;

            while (gameover != true)
            {


                Console.WriteLine("Welcome to the game!.");
                Console.WriteLine("");

                Console.WriteLine("Enter 'q' to quit.");
                Console.WriteLine("Enter 'p' to play a hand.");

                string answer = Console.ReadLine() ?? "q";

                if (answer == "q")
                {

                    GameEnding(gamestate);
                    gameover = true;
                }

               if (answer == "p")
                {
                   gamestate =  PlayAHand(gamestate);
                }


            }

        }

        private GameState GameEnding(GameState gamestate)
        {
            //The game is created and enters the game loop.
            //When the game loop ends, print the log
            gamestate.LogMessages.Add($"In {System.Reflection.MethodBase.GetCurrentMethod()!.Name}");

            gamestate.LogMessages.Add($"{DateTime.Now} +  GAMELOG ENDING...............");

            gamestate.LogMessages.ForEach(message => Console.WriteLine(message));

            return gamestate;
        }

        private GameState PlayAHand(GameState gamestate)
        {
            //Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");


           // Console.WriteLine(gamestate.ToString());


            gamestate = MoveDealerButton(gamestate);
           // if( gamestate.Seats.Any(x => x.IsDealer == false) {  }
            gamestate = MoveBigBlindButton(gamestate);
            gamestate = MoveSmallBlindButton(gamestate);

            //Console.WriteLine(gamestate.ToString());

            gamestate = DealPreFlop(gamestate);
            gamestate = PlayPreFlop(gamestate);
            gamestate = DealFlop(gamestate);
            gamestate = PlayFlop(gamestate);
            gamestate = DealTurn(gamestate);
            gamestate = PlayTurn(gamestate);
            gamestate = DealRiver(gamestate);
            gamestate = PlayRiver(gamestate);
            gamestate = AwardPots(gamestate);

            //Console.WriteLine("I played a handccccccccccccccccccccccccccc"); ;

            return gamestate;
        }

        private GameState MoveDealerButton(GameState gamestate)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  {System.Reflection.MethodBase.GetCurrentMethod()!.Name}");

            //Seat should Know how t move buttons.....
            List<Seat> seats = new List<Seat>();
            seats = gamestate.Seats;

            seats = Seat.MoveDealerButton(seats);

            gamestate.Seats = seats;

            return gamestate;
        }
        private GameState MoveBigBlindButton(GameState gamestate)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  {System.Reflection.MethodBase.GetCurrentMethod()!.Name}");

            //Seat should Know how t move buttons.....
            List<Seat> seats = new List<Seat>();
            seats = gamestate.Seats;

            seats = Seat.MoveBigBlindButton(seats);

            gamestate.Seats = seats;
            return gamestate;
        }
        private GameState MoveSmallBlindButton(GameState gamestate)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  {System.Reflection.MethodBase.GetCurrentMethod()!.Name}");

            //Seat should Know how t move buttons.....
            List<Seat> seats = new List<Seat>();
            seats = gamestate.Seats;

            seats = Seat.MoveSmallBlindButton(seats);

            gamestate.Seats = seats;

            return gamestate;
        }

        private GameState AwardPots(GameState gamestate)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");

            return gamestate;
        }

        private GameState PlayRiver(GameState gamestate)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");
            return gamestate;
        }

        private GameState DealRiver(GameState gamestate)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");
            return gamestate;

        }

        private GameState PlayTurn(GameState gamestate)
        {
     
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");
            return gamestate;

        }

        private GameState DealTurn(GameState gamestate)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");
            return gamestate;

        }

        private GameState PlayFlop(GameState gamestate)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");

            return gamestate;
        }

        private GameState DealFlop(GameState gamestate)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");
            return gamestate;

        }

        private GameState PlayPreFlop(GameState gamestate)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");
            return gamestate;

        }

        private GameState DealPreFlop(GameState gamestate)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");
            return gamestate;

        }


        private GameState EndGame(GameState gamestate)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");
            return gamestate;

        }

        private decimal MakeCurrentBet(decimal wager)
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
            board.Add(new Card(Rank.None,Suit.None));
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

        private List<Seat> MakeSeats(List<Seat> seats)
        {
            //gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");
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
            //gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");

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



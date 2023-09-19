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
        List<string> _gameview;

        // This object contains the complete gameState

        GameState _game_state;

        //Simple Constructor for now
        public HiLevelGame()
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
            this._gameview = new List<string>();

            this._deck = MakeDeck(_deck);
            this._seats = MakeSeats(_seats);
            this._players = MakePlayers(_players);
            this._board = MakeBoard(_board);
            this._pots = MakePots(_pots);
            this._gamelog = MakeGameLog(_gamelog);
            this._gamelog = MakeGameViewLog(_gamelog);

            this._current_bet = MakeCurrentBet(_current_bet);

            this._game_state = new GameState(_seats, _players, _deck, _board, _current_bet,
                                                _last_return_code, _gamelog, _gameview);


            //Run the game

            Gameloop(_game_state!);



        }

        private List<string> MakeGameViewLog(List<string> gameview)
        {
            DateTime now = DateTime.Now;

            gameview.Add($"{now} +  GAMEVIEW Starting...............");

            return gameview;
        }

        private List<string> MakeGameLog(List<string> log)
        {
            DateTime now = DateTime.Now;

            log.Add($"{now} +  GAMELOG Starting...............");

            return log;

        }

        private void Gameloop(GameState gamestate)
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
                    
                    gamestate = PlayAHand(gamestate);
                    
                }


            }

        }
       
        private GameState LogMessage(GameState gamestate, string message)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} XXXX {message}");



            return gamestate;
        }

        private GameState GameStateChange(GameState gamestate, string message)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} XXXX {message}");



            return gamestate;
        }

        private GameState GameEnding(GameState gamestate)
        {
            //The game is created and enters the game loop.
            //When the game loop ends, print the log
            gamestate.LogMessages.Add($"In {System.Reflection.MethodBase.GetCurrentMethod()!.Name}");

            gamestate.LogMessages.Add($"{DateTime.Now} +  GAMELOG ENDING...............");

           gamestate.LogMessages.ForEach(message => Console.WriteLine(message));

            gamestate.WriteLog();
            gamestate.WriteGameView();
            return gamestate;
        }

        private GameState PlayAHand(GameState gamestate)
        {
            

            //Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  {System.Reflection.MethodBase.GetCurrentMethod()!.Name}");
            gamestate.LogGameView.Add($"{DateTime.Now} New hand Starting:");
            //seat some players
            gamestate = MakeTestTable(gamestate);

            if (gamestate.Seats.Where( x => x.IsPlaying).Count() < 2)
            {
                gamestate.LogMessages.Add("Not Enough Players");
                gamestate.LogGameView.Add($"{DateTime.Now} Not enough players:");

                return gamestate;

            }

            //HACK 
            gamestate.Seats[2].IsDealer = true;


            gamestate = MoveDealerButton(gamestate);
            gamestate.LogGameView.Add($"{DateTime.Now} Dealer Button Moved");
            //gamestate.LogGameView.Add($"{DateTime.Now} {gamestate.ToString()}");



            gamestate = MoveBigBlindButton(gamestate);
            gamestate = MoveSmallBlindButton(gamestate);

            gamestate = DealPreFlop(gamestate);
            gamestate = PlayPreFlop(gamestate);
            gamestate = DealFlop(gamestate);
            gamestate = PlayFlop(gamestate);
            gamestate = DealTurn(gamestate);
            gamestate = PlayTurn(gamestate);
            gamestate = DealRiver(gamestate);
            gamestate = PlayRiver(gamestate);
            gamestate = AwardPots(gamestate);

            return gamestate;
        }

        private GameState MoveButtons(GameState gamestate)
        {
            return gamestate;
        }

        private GameState MoveDealerButton(GameState gamestate)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  {System.Reflection.MethodBase.GetCurrentMethod()!.Name}");
            
            

            //HACK
            gamestate.Seats[0].IsPlaying = true;
            gamestate.Seats[2].IsPlaying = true;
            gamestate.Seats[3].IsPlaying = true;
            gamestate.Seats[8].IsPlaying = true;

            gamestate.Seats.ForEach(x => gamestate.LogGameView.Add(x.ToString()));
            //llookuptable

            //int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //var seatTable = nums.ToLookup(k => k)
            //                .Select(k => new KeyValuePair<int, int[]>
            //                (k.Key, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
            //var actionSequenceTable = seatTable.ToList();   
            
            //foreach ( var item in seatTable )
            //{
            //    if (item.Key == 1)
            //    {
            //        item.Value = nums.TakeWhile(k => k != 0).ToArray();
            //    }
            //}

            //Current Active Seat
            //var currentActiveSeat = gamestate.Seats
            //                            .Where(x => x.IsDealer)
            //                            .First();
            //what would the 'last' lamda to select the next active seat look like?
            // x => x  {
            //                      seats.where( x => x.Number > actionSeatNumber
            //                 }.First().Seat

            //last code is....

            //ForEach(s => s.....

           


            ////this must be true, or modify code to check for null and exit 
            //var dealerseatnumber = gamestate.Seats
            //    .Where(x => x.IsDealer)
            //    .First().Number;
            ////this must be 3 or greater for concept testing
            //var activeseatlist = Enumerable.Range(0, gamestate.Seats.Count)
            //    .Select(i => gamestate.Seats[i])
            //    .Where(j => j.IsPlaying)
            //    .ToList();

            //var activeseatnumbers = Enumerable.Range(0, activeseatlist.Count())
            //    .Select(i => activeseatlist[i].Number)
            //    .ToList();
            ////gran the seatnumbers that are greater
            //var activeseatsBigger = activeseatnumbers
            //    .SkipWhile(x => x <= dealerseatnumber)
            //    .ToList();
            ////grab the seat numbers thst sre smaller
            //var activeseatsSmaller = activeseatnumbers
            //    .TakeWhile(x => x < dealerseatnumber)
            //    .ToList();
            //// action sequence is currentseat + bigger + smaller
            
            //List<int> actionsequence = new List<int>();
            //actionsequence.Add(dealerseatnumber);
            //for (int i = 0;i < activeseatsBigger.Count; i++)
            //{
            //    actionsequence.Add(activeseatsBigger[i]);

            //}
            //for (int j = 0; j < activeseatsBigger.Count; j++)
            //{
            //    actionsequence.Add(activeseatsSmaller[j]);

            //}
            //// next dealer seat is....

            //int nextdealerseaternumber = 0;

            //for (int k = 0; k < activeseatnumbers.Count; k++)
            //{
            //    if (activeseatlist[k].Number > dealerseatnumber)
            //    {
            //        //next dealer seat is...
            //        nextdealerseaternumber = activeseatlist[k].Number;
            //    }
            //}

            ////What is

            ////[0,1,2,3,4,5,6,7,8]
            //var seatNumberIndexes = Enumerable.Range(0, 9);

            //int nextbuttonseatnumber = 10; //force error
            //int currentbuttonseatnumber = 10; //force error 

            ////find current button seat number
            //foreach (int i in seatNumberIndexes) 
            //{ 
            //    if (gamestate.Seats[i].IsDealer)
            //    {
            //        currentbuttonseatnumber = gamestate.Seats[i].Number;
            //    }
            //}


            ////find next button seat number
            //foreach (int i in seatNumberIndexes)
            //{
            //    if ((gamestate.Seats[i].IsPlaying) &&
            //        (gamestate.Seats[i].Number > currentbuttonseatnumber))
            //    {
            //        currentbuttonseatnumber = gamestate.Seats[i].Number;
            //    }
            //}


            //////
            ////foreach (int idx in seatNumberIndexes)
            ////{
            ////    if (gamestate.Seats[idx].Number > currentseatnumber)
            ////    {
            ////        nextdealerseaternumber = gamestate.Seats[idx].Number + 1;
            ////    }
            ////}




            ////    //update gamestate
            ////    foreach (int idx in seatNumberIndexes)
            ////{
            ////    //should it be updated?

            ////    //set new button
            ////    if (gamestate.Seats[idx].Number == nextseatnumber)
            ////    {
            ////        gamestate.Seats[idx].IsDealer = true;
            ////    }
            ////    //remove the old button
            ////    if (gamestate.Seats[idx].Number == currentseatnumber)
            ////    {
            ////        gamestate.Seats[idx].IsDealer = false;
            ////    }
            ////    //otherwise no change
            ////}
            return gamestate;
        }
        private GameState MoveBigBlindButton(GameState gamestate)
        {
           
            return gamestate;
        }
        private GameState MoveSmallBlindButton(GameState gamestate)
        {
            gamestate.LogMessages.Add($"{DateTime.Now} +  In  {System.Reflection.MethodBase.GetCurrentMethod()!.Name}");

            //First active seat to the right of the Deaslerbutton

            //gamestate.LogGameView.Add($"{DateTime.Now} Small Blind Button Moved");
            //gamestate.LogGameView.Add($"{DateTime.Now} {gamestate.ToString()}");

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
            
            var seatnumbers = Enumerable.Range(1, 9).ToList();

            seatnumbers.ForEach(x => 
            {
                seats.Add(new Seat(x));
            });


          

            return seats;


        }
        private GameState MakeTestTable( GameState gamestate)
        {
            //fill a table for testing
            gamestate.Seats[0].IsPlaying = true;
            gamestate.Seats[2].IsPlaying = true;
            gamestate.Seats[3].IsPlaying = true;
            gamestate.Seats[8].IsPlaying = true;



            return gamestate;
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



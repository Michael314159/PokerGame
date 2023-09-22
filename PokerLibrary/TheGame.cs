using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    /// <summary>
    /// A game that models a holdem game that is opened and waiting for players.
    /// 
    /// When enought players are added to it, it starrts to play and
    /// continues to play until there are no longer enough players.
    /// A log suitable for  building a View Model is written,
    /// 
    /// The calling object must supply players.
    /// The calling object must read the log and/or build View/ViewModels
    /// to access the gamestate.
    /// 
    /// </summary>
    public class TheGame
    {
        //The game objects needed for both logic and display
        List<Seat> seats;
        List<Card> deck;
        List<Player> players;
        List<Pot> pots;
        List<Card> board;
        decimal current_wager;

        //The GameState object IS the game.
        //It is created with references to ALL the game objects,
        //
        //The game progresses by sending the GameObject to the function
        //that models the next event in the game.
        //The function is passed the GameStae, Modifys it, and returns the new Gamestate
        //That makes it mostly functional. Mimics Immutable States.

        public GameState gamestate;

        //Handles loggin and create data for ViewModel
        public GameLogger logger;

        //Constuctor
        public TheGame() {

            //These objects must exist
            // this._gameState = new GameState();
            this.deck = new List<Card>();
            this.seats = new List<Seat>();
            this.players = new List<Player>();
            this.board = new List<Card>();
            this.pots = new List<Pot>();

            this.logger = new GameLogger();
           
            //Thers 5 objects ARE the game.

            this.gamestate = new GameState(this.seats,this.players,this.deck,
                                             this.board,this.current_wager);


            // As A functional program, we only are born,live,and die
            this.gamestate = StartTheGame(this.gamestate);

        }

        public GameState StartTheGame(GameState gamestate) {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);

            // Make the needed game objects
            MakeDeck(this.deck);
            MakeSeats(this.seats);
            MakeBoard(this.board);
            MakePots(this.pots);
            MakeCurrentWager(this.current_wager);


            return gamestate;
        }
        public GameState PlayTheGame(GameState gamestate) {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);

            gamestate = Gameloop(gamestate);

            return gamestate; 
        }
        public GameState StopTheGame(GameState gamestate) {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);



            
            return gamestate;
        }

        




        #region Helper Methods

        //Do something to each Seat circular starting from a particular seat
        // until conditon reached.

        private int NextSeatNumberWhereIsPlaying(GameState gamestate,int startAtSeatNumer)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);

            //This where we start our search
            int current_seatnumber = gamestate.Seats.FirstOrDefault(x => x.Number == startAtSeatNumer).Number;
           
            //Check each seat in order for the condiiton. Give up after one pass.
            for (int i = 0; i < 9; i++)
            {
                //get the next seat number
                int next_seatnumber = Seat.NextSeatNumber(current_seatnumber);
                //if the next seat satisfies condtions, bingo
                //otherwise check the next one

                //is Playing?
                //idx is one less than seatnumber....
                if (gamestate.Seats[next_seatnumber - 1].IsPlaying == true)
                {
                    return gamestate.Seats[i].Number;
                }

               
            }
            return 0; //if we failed......
        }

        private  GameState Gameloop(GameState gamestate)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);

            //for now, play 1 hand then quit

            gamestate = PlayAHand(gamestate);
            return gamestate;

            //bool gameover = false;

            //while (gameover != true)
            //{


            //    Console.WriteLine("Welcome to the game!.");
            //    Console.WriteLine("");

            //    Console.WriteLine("Enter 'q' to quit.");
            //    Console.WriteLine("Enter 'p' to play a hand.");

            //    string answer = Console.ReadLine() ?? "q";

            //    if (answer == "q")
            //    {
            //        gameover = true;
            //    }

            //    if (answer == "p")
            //    {

            //        gamestate = PlayAHand(gamestate);

            //    }


            //}
            //return gamestate;
        }
        private GameState PlayAHand(GameState gamestate)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);



            //gamestate = MoveDealerButton(gamestate);


            //gamestate = MoveBigBlindButton(gamestate);
            //gamestate = MoveSmallBlindButton(gamestate);

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

        private GameState AwardPots(GameState gamestate)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);
            return gamestate;
        }

        private GameState PlayRiver(GameState gamestate)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);
            return gamestate;
        }

        private GameState DealRiver(GameState gamestate)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);
            return gamestate;
        }

        private GameState PlayTurn(GameState gamestate)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);
            return gamestate;
        }

        private GameState DealTurn(GameState gamestate)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);
            return gamestate;
        }

        private GameState PlayFlop(GameState gamestate)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);
            return gamestate;
        }

        private GameState DealFlop(GameState gamestate)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);
            return gamestate;
        }

        private GameState PlayPreFlop(GameState gamestate)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);
            return gamestate;
        }

        private GameState DealPreFlop(GameState gamestate)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);
            return gamestate;
        }

        private GameState MoveDealerButton(GameState gamestate)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);

            //Log the seats before the move
            foreach (var item in gamestate.Seats)
            {
                //gamestate.LogGameView.Add(item.ToString());
                //gamestate.LogMessages.Add(item.ToString());
                //Console.WriteLine($"{item.ToString()}");
            }

            //Now the hard part. 

            
            return gamestate;
        }

        private decimal MakeCurrentWager(decimal wager)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);
            //gamestate.LogMessages.Add($"{DateTime.Now} +  In  { System.Reflection.MethodBase.GetCurrentMethod()!.Name}");
            wager = 0;
            return wager;

        }
        private List<Pot> MakePots(List<Pot> pots)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);

            pots.Clear();
            pots.Add(new Pot(0)); pots.Add(new Pot(1)); pots.Add(new Pot(2));
            pots.Add(new Pot(3)); pots.Add(new Pot(4)); pots.Add(new Pot(5));
            pots.Add(new Pot(6)); pots.Add(new Pot(7)); pots.Add(new Pot(8));

            return pots;
        }
        private List<Card> MakeBoard(List<Card> board)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);

            board.Add(new Card(Rank.None, Suit.None));
            board.Add(new Card(Rank.None, Suit.None));
            board.Add(new Card(Rank.None, Suit.None));


            return board;
        }
        private GameState MakePlayers(GameState gamestate)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);

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

            gamestate.Players = players;
            return gamestate;
        }
        private GameState SeatPlayers(GameState gamestate)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);

            return gamestate;
        }
       
        private List<Seat> MakeSeats(List<Seat> seats)
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);

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
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            logger.LogGameAction(strMethodName);

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
        

    }
}

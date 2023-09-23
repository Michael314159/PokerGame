using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePokerGame
{
    /// <summary>
    /// This will be poker game that runs as a console app.
    /// The Interfaces describe objects that a 
    /// simple poker game model must have for logic and display.
    /// 
    /// The View and ViewModel are derived from the Log for a
    /// bare bones game.
    /// </summary>
    public class consolePokerGame 
    {

        //Handles the models View
       // ConsoleView consoleView;

        //Maps the Model to the view
        ConsoleViewModel ConsoleViewModel;

        // Properties required by the interfaces

        List<Seat> seats;
        List<Card> board;
        List<Card> deck;
        List<Player> player;
        List<Pot> pots;
        GameLog log;
      
        //Constructor
        public consolePokerGame() {
            this.seats = new List<Seat>();
            this.board = new List<Card>();
            this.deck = new List<Card>();
            this.player = new List<Player>();
            this.pots = new List<Pot>();
            this.log = new GameLog();

            //this.consoleView = new ConsoleView();
            this.ConsoleViewModel = new ConsoleViewModel();

            StartGame();
        }

        private void StartGame()
        {
            this.log.AddToLog(System.Reflection.MethodBase.GetCurrentMethod()!.Name);

            //This is how we abstract away the Display responsibilities of the game object
            ConsoleViewModel.ConsoleView.Display();

            PlayGame();
        }
        private void PlayGame()
        {
            this.log.AddToLog(System.Reflection.MethodBase.GetCurrentMethod()!.Name);

            EndGame();
        }
        private void EndGame()
        {
            this.log.AddToLog(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
            this.log.WriteLog();
        }
    }
}

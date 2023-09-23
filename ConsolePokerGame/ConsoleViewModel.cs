using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePokerGame
{
    
    public class ConsoleViewModel
    {
        private consolePokerGame consolePokerGame;
        private ConsoleView ConsoleView;



        public ConsoleViewModel() { 
        
            this.ConsoleView = new ConsoleView();
            this.consolePokerGame = new consolePokerGame();
        }   

        public void DisplayView()
        {
            this.ConsoleView.Display();
        }
    }
   
}

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
        public ConsoleView ConsoleView { get; set; }

        public ConsoleViewModel() { 
        
            this.ConsoleView = new ConsoleView();
        }   

        public void DisplayView()
        {
            this.ConsoleView.Display();
        }
    }
   
}

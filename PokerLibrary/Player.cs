using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public enum Act
    {
        Fold,Check,Call,Bet,Raise,Reraise,AllIn
    }
    public class Player
    {
        public string Name { get; set; }
        public  decimal Chips { get; set; }

        public Act Action { get; set; }

        public Player(string name, decimal chips) {
        
            this.Name = name; 
            this.Chips = chips;

        } 


    }
}

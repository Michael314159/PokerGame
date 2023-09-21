using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public enum PlayerActions
    {
        Fold,Check,Call,Bet,Raise,Reraise,AllIn
    }
    public class Player
    {
        public string Name { get; set; }
        public  decimal Chips { get; set; }

        public List<Card>? Cards { get; set; }


        public Player(string name, decimal chips) {
        
            this.Name = name; 
            this.Chips = chips;
            this.Cards = new List<Card>() { new Card(Rank.None, Suit.None), new Card(Rank.None, Suit.None) };

        } 

        
     

    }
}

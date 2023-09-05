using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public enum Rank
    {
        None,Ace,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten,Jack,Queen,King
    }

    public enum Suit
    {
        None,Clubs,Diamonds,Hearts,Spades
    }
    public class Card
    {
        public Rank Rank { get; set; }
        public Suit Suit { get; set;}

        public Card()
        {
            this.Rank = Rank.None;
            this.Suit = Suit.None;
        }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Rank.ToString()}Of{this.Suit.ToString()}");
            return sb.ToString();
        }
    }
   
}

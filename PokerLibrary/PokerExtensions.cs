using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    /// <summary>
    /// Extensions useful for poker programming
    /// </summary>
    public static class PokerExtensions
    {
        public static int ClubCount(this List<Card> cards )
        {
            return cards.Select(c => c.Suit = Suit.Clubs).Count();
        }

        public static bool IsFlush(this List<Card> cards )
        {
            return (cards.ClubCount() == 5);
        }
        public static int CubeMe(this int value)
        {
            //return the inputs value cubed
            return value * value * value;
        }

        public static int HowManyAces( this List<Card> value)
        {
            return value.Where(x => x.Rank == Rank.Ace).Count();
        }

        public static bool HasAces(this List<Card> value)
        {
            return value.Where(IsAce).Any();
        }

        public static bool IsAce(this Card value)
        {
            return (value.Rank == Rank.Ace);
        }
    }
}


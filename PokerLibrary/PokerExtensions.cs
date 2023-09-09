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

        public static int CubeMe(this int value)
        {
            //return the inputs value cubed
            return value * value * value;
        }

        public static int HowManyAces( this List<Card> value)
        {
            return value.Where(x => x.Rank == Rank.Ace).Count();
        }
    }
}


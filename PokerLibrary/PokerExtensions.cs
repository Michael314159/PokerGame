using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    /// <summary>
    /// Extensions useful for poker programming
    /// </summary>
    public static class PokerExtensions
    {
        public static string ShowCards(this List<Card> cards)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Empty);

            foreach (Card card in cards)
            {
                sb.Append(card.Rank.ToString());
                sb.Append(card.Suit.ToString());
                sb.Append(' ');
            }

            return sb.ToString();
        }
        public static bool IsStraight(this List<Card> cards)
        {
            //List<Rank> RankCardRanks = new List<Rank>();
            List<int> IntCardRanks = new List<int>();

            //new list of type int from the passed list
            IntCardRanks = cards.Select(c => c.Rank).Select(x => (int)x).ToList();

            //numeric sort
            IntCardRanks.Sort();

            //weve gone from 'rank.five,rank.ace,rank.king,rank.two' to 1,5,13,2 sorted to 1,2,5,13

            // if hi - lo = 4, its a straight (ace is 1
            // if the sum of the cards = 47 --[1,13,12,11,10] --- is an ace high straight,

            bool ret = false; 

            if (IntCardRanks.Last() - IntCardRanks.First() == 4 ||
                IntCardRanks.Sum() == 47)
            {
                ret = true;
            }

            return ret;

        }
        public static bool IsFlush(this List<Card> cards )
        {
            bool ret = false;
            ret = cards.All(c => c.Suit == Suit.Clubs) ||
                  cards.All(c => c.Suit == Suit.Diamonds) ||
                  cards.All(c => c.Suit == Suit.Hearts) ||
                  cards.All(c => c.Suit == Suit.Spades);

            return ret;
        }



        public static bool IsStraightFlush(this List<Card> cards )
        {
            return (cards.IsFlush() && cards.IsStraight());
        }
    }
}


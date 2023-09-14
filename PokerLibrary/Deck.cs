using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public class Deck
    {
        public List<Card> deck {  get; set; }


        public Deck() {
            deck = new List<Card>();
            CreateDeck();
        }

        private void CreateDeck()
        {
            
            List<int> intSuitNumberRange = (List<int>)Enumerable.Range(1, 4);
            List<int> intRankNumberRange = (List<int>)Enumerable.Range(1, 13);
            List<int> intCardNumnerRange = (List<int>)Enumerable.Range(1, 52);


          //  this.deck.AddRange(intSuitNumberRange.Select);



        }
    }
}

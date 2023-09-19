using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        //Get all the properties and their valuse for this instance

        private PropertyInfo[] RetrieveProperties()
        {
            //object is this instance
            var type = this.GetType();
            return type.GetProperties();
        }


        public override string ToString()
        { //// A dictionary that contains every instance Propertie and its value

            StringBuilder sb = new StringBuilder();


            Dictionary<string, object> dictProperties = new Dictionary<string, object>();

            //// Get all of this instances properties and values
            var varProperties = RetrieveProperties();

            ////Create a dictionary to hold this property information
            foreach (var property in varProperties)
            {
                dictProperties.Add(property.Name, property.GetValue(this));
            }

            ////Use this info for the ToString override
            foreach (var item in dictProperties)
            {
                sb.AppendLine(item.Key + ": " + item.Value);
            }
            sb.Append($"{this.Rank.ToString()}Of{this.Suit.ToString()}");
            return sb.ToString();
        }
    }
   
}

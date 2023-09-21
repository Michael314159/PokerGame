using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public class Seat
    {
       

        public int Number { get; set; }
        public string Name { get; set; }



        public Player? Player { get; set; }



        public bool HasPlayer { get; set; }
        public bool IsPlaying { get; set; }
        public bool IsDealer { get; set; }
        public bool IsBigBlind { get; set; }
        public bool IsSmallBlind { get; set; }

        public Seat(int number)
        {

            this.Number = number;
            this.Name = $"Seat {Number}";
            this.HasPlayer = false ;

        }

        public void AddPlayer(Player player)
        {
            this.Player = player;
            this.HasPlayer = true ;
        }

        public void RemovePlayer()
        {
            this.Player = null;
            this.HasPlayer = false ;
        }



        //Get all the properties and their valuse for this instance
        
        private PropertyInfo[] RetrieveProperties()
        {
            //object is this instance
            var type = this.GetType();
            return type.GetProperties();
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            //// A dictionary that contains every instance Propertie and its value
            //Dictionary<string, object> dictProperties = new Dictionary<string, object>();

            //// Get all of this instances properties and values
            //var varProperties = RetrieveProperties();

            ////Create a dictionary to hold this property information
            //foreach (var property in varProperties)
            //{
            //    dictProperties.Add(property.Name, property.GetValue(this));
            //}

            ////Use this info for the ToString override
            //foreach (var item in dictProperties)
            //{
            //    sb.AppendLine(item.Key + ": " + item.Value);
            //}
            //Summarry line of most relevant info
            sb.Append($"|SEAT NUMBER {Number} |DB {IsDealer} |SB {IsSmallBlind} |BB {IsBigBlind}");

            return sb.ToString();

        }
       
        //Seat should know its neighbor
        // Seat are in a circular clockwise order

        public static int NextSeatNumber(int number)
        {
            switch (number)
            {
                case 1: return 2;                 
                case 2: return 3; 
                case 3: return 4; 
                case 4: return 5; 
                case 5: return 6; 
                case 6: return 7; 
                case 7: return 8; 
                case 8: return 9; 
                case 9: return 1; 


                default: throw new SystemException("NextSeatFataError");
            }
        }

        //Sometime its easier to deal with index in a list rather than intrinsic seatnumber
        //Assumes list is in 1,2,3,4,5,6,7,8,9 order
        public static int NextSeatIdxNumber(int number)
        {
            switch (number)
            {
                case 1: return 2;
                case 2: return 3;
                case 3: return 4;
                case 4: return 5;
                case 5: return 6;
                case 6: return 7;
                case 7: return 8;
                case 8: return 9;
                case 9: return 0;


                default: throw new SystemException("NextSeatFataError");
            }
        }

    }
}

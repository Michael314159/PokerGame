using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public class Seat
    {
       

        public int Number { get; set; }
        public string Name { get; set; }



        public Player? Player { get; set; }



    
        public bool IsPlaying { get; set; }
        public bool IsDealer { get; set; }
        public bool IsBigBlind { get; set; }
        public bool IsSmallBlind { get; set; }

        public Seat(int number)
        {

            this.Number = number;
            this.Name = $"Seat {Number}";

        }

        public void AddPlayer(Player player)
        {
            this.Player = player;
        }

        public void RemovePlayer()
        {
            this.Player = null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.Append(Name.ToString() + " ");
            sb.Append($"isPlaying: {IsPlaying.ToString()} ");
            sb.Append($"isDealer: {IsDealer.ToString()} ");
            sb.Append($"isSmallBlind: {IsSmallBlind.ToString()} ");
            sb.Append($"isBigBlind: {IsBigBlind.ToString()} ");

            return sb.ToString();

        }
    }
}

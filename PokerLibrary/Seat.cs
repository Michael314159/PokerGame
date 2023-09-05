using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public class Seat
    {
        public Seat() { }

        public int Number { get; set; }
        public string? Name { get; set; }

        public Player? Player { get; set; }


        public Seat(int number) {
        
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    /// <summary>
    /// there can be sevearal pots if some players all in
    /// </summary>
    public class Pot
    {
        public int id;
        public decimal size;

        public Pot(int pot_number) { 
        
            this.id = pot_number; 
            this.size = 0;

        }
    }
}

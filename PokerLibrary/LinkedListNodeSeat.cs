using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public class LinkedListNodeSeat
    {
        public int data;
        public LinkedListNodeSeat? next;

        public LinkedListNodeSeat(int x) {
        
            this.data = x;          //Seat Number
            this.next = null;
        }
    }
}

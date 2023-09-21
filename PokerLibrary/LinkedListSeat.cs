using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    public class LinkedListSeat
    {

        int count = 0;
        LinkedListNodeSeat? head;
        public LinkedListSeat() {   
        
            this.head = null;


        }

        public void AddNodeToFront(int seatnumber)
        {
            LinkedListNodeSeat node = new LinkedListNodeSeat(seatnumber);
            node.next = head;
            head = node;
            count++;
        }

        public void PrintList()
        {
            LinkedListNodeSeat runner = head;
            while (runner != null)
            {
                Console.WriteLine(runner.data.ToString());
                runner = runner.next;
            }
        }
    }
}

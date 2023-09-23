using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePokerGame
{
    public class ConsoleView
    {

        public ConsoleView()
        {



        }

        public void Display()
        {
            //Build a table

            string[] table = new string[7];

            string tab = "     ";
            string tab15 = "               ";
            string placeholder = "XXXXXXXXXXXXXXX";

            string top = "_______________________________________________________________________________________________";
            string sbRow1 = ($"{tab15}{tab}     SEAT4     {tab}     SEAT5     {tab}     SEAT6     {tab}{tab15}");
            string sbRow2 = ($"     SEAT3     {tab}{tab15}{tab}{tab15}{tab}{tab15}{tab}     SEAT7     ");
            string sbRow3 = ($"{tab15}{tab}{tab15}{tab}RS RS RS RS RS {tab}{tab15}{tab}{tab15}");
            string sbRow4 = ($"     SEAT2     {tab}{tab15}{tab}   $$$$$$$$$   {tab}{tab15}{tab}     SEAT8     ");
            string sbRow5 = ($"{tab15}{tab}     SEAT1     {tab}{tab15}{tab}     SEAT9     {tab}{tab15}");
            string bottom = "_______________________________________________________________________________________________";

            table[0] = top;
            table[1] = sbRow1;
            table[2] = sbRow2;
            table[3] = sbRow3;
            table[4] = sbRow4;
            table[5] = sbRow5;
            table[6] = bottom;

            for (int i = 0; i < table.Length; i++) {

                Console.WriteLine(table[i]);
            }
        }
    }
}

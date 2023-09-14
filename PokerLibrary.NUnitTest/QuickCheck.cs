using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace PokerLibrary.NUnitTest
{
    public class QuickCheck
    {
        //check an idea

        public static void CheckIdea()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);

            List<Card> deck = new List<Card>();

            HiLevelGame game = new HiLevelGame();

            
        }              
    }
    
}

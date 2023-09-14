using System.Security.Cryptography.X509Certificates;

namespace PokerLibrary.NUnitTest
{
    public class Tests
    {

        
        
        

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AdHoc()
        {
            Card card;
           
                
            //cards.ForEach(c => Console.WriteLine(c.ToString()));
            //Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);
            //int[] nums = { 20, 15, 31, 34, 35, 40, 50, 90, 99, 100 };
            //nums
            //.ToLookup(k => k, k => nums.Where(n => n < k))
            //.Select(k => new KeyValuePair<int, double>
            //(k.Key, 100 * ((double)k.First().Count() / (double)nums.Length)));
            
        }


        [Test]
        public void pokerHandIsStraight()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);

            List<Card> pokerHand = new List<Card>() {   new Card(Rank.Ace , Suit.Clubs) ,
                                                    new Card(Rank.Two , Suit.Diamonds),
                                                    new Card(Rank.Four , Suit.Hearts),
                                                    new Card(Rank.Six , Suit.Hearts),
                                                    new Card(Rank.Three , Suit.Clubs)
                                                };
            //not part of the functio, just printing the hand
            pokerHand.Select(x => x.Rank).Select(x => (int)x).ToList().ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine($"Is the hand a Straight? : {pokerHand.IsStraight()}");

            
        }

      

        [Test]
        public void pokerHandIsFlush()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);

            List<Card> pokerHand = new List<Card>() {   new Card(Rank.Ace , Suit.Hearts) ,
                                                    new Card(Rank.Two , Suit.Hearts),
                                                    new Card(Rank.Four , Suit.Hearts),
                                                    new Card(Rank.Six , Suit.Hearts),
                                                    new Card(Rank.Three , Suit.Hearts)
                                                };
            //not part of the functio, just printing the hand
            pokerHand.Select(x => x.Suit).ToList().ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine($"Is the hand a Flush? : {pokerHand.IsFlush()}");
        }
        [Test]
        public void pokerHandIsStraightFlush() {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);

            List<Card> pokerHand = new List<Card>() {   new Card(Rank.Ace , Suit.Hearts) ,
                                                    new Card(Rank.Two , Suit.Hearts),
                                                    new Card(Rank.Four , Suit.Hearts),
                                                    new Card(Rank.Five , Suit.Hearts),
                                                    new Card(Rank.Three , Suit.Hearts)
                                                };

            //not part of the functio, just printing the hand

            List<int> intList = new List<int>();
            //pokerHand.Select(x => x.Rank).Select(x => (int)x).ToList().ForEach(x => Console.WriteLine(x.ToString()));
            intList = pokerHand.Select(x => x.Rank).Select(x => (int)x).ToList().ToList();

            List<string> strList = new List<string>();
            //pokerHand.Select(x => x.Suit).Select(x => x.ToString()).ToList().ForEach(x => Console.WriteLine(x.ToString()));
            strList = pokerHand.Select(x => x.Suit).Select(x => x.ToString()).ToList();

           // intList.ForEach(x => Console.WriteLine(x.ToString() + " "));
           // strList.ForEach(x => Console.WriteLine(x.ToString()));

            intList.Zip(strList, (a, b) => a.ToString() + b.ToString()).ToList().ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine($"Is the hand a StraightFlush? : {pokerHand.IsStraightFlush()}");
        }
    }
}
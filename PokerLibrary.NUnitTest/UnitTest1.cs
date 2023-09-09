namespace PokerLibrary.NUnitTest
{
    public class Tests
    {

        
        
        

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void pokerHandHasAces()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);

            List<Card> pokerHand = new List<Card>() {   new Card(Rank.Ace , Suit.Clubs) ,
                                                    new Card(Rank.Ace , Suit.Diamonds),
                                                    new Card(Rank.Ace , Suit.Hearts),
                                                    new Card(Rank.Two , Suit.Clubs)
                                                };


            if (pokerHand.HasAces()) {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void pokerHandHasNoAces()
        {

            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()!.Name);

            List<Card> pokerHand = new List<Card>() {   new Card(Rank.Three , Suit.Clubs) ,
                                                    new Card(Rank.King , Suit.Diamonds),
                                                    new Card(Rank.Four , Suit.Hearts),
                                                    new Card(Rank.Two , Suit.Clubs)
                                                };


            if (pokerHand.HasAces())
            {
                Assert.Fail();
            }
            else
            {
                Assert.Pass();
            }
        }
    }
}
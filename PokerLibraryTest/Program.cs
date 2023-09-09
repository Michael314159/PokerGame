// See https://aka.ms/new-console-template for more information
using PokerLibrary;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello, World!");

Card C1 = new Card(Rank.Two , Suit.Clubs);
Card C2 = new Card(Rank.Four, Suit.Diamonds);
Card C3 = new Card(Rank.Ace, Suit.Hearts);
Card C4 = new Card(Rank.Eight, Suit.Spades);
Card C5 = new Card(Rank.Ten, Suit.Clubs);

List<Card> CardHand = new List<Card>() { C1, C2, C3, C4, C5 };


CardHand.ForEach( x => Console.WriteLine(x.ToString()));

Console.WriteLine(CardHand.HowManyAces().ToString());
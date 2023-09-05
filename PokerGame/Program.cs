// See https://aka.ms/new-console-template for more information



// Game Entry

using PokerLibrary;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine("You are executing PokerGame");
        Console.WriteLine("__________________________");




        // From yhe poker library
        Game game = new Game();

        //Game Loop

        game.GameStart();
        bool GameOver = false;

        while (!GameOver)
        {
            game.PlayOneHand();
            GameOver = true;
        }

        game.GameEnd();
    }
}
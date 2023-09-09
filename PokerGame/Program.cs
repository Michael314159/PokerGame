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
        // Game game = new Game();

        HiLevelGame game = new HiLevelGame();
        game.StartGame();
        //Game Loop
        
    }
}
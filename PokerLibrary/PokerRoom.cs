using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PokerLibrary
{
    /// <summary>
    /// Model A Poker Room.
    /// () -> ConsoleApp
    /// // Display a menu built on:
    ///           Statements[]
    ///           Questions[]
    ///    and Do what the answer implies
    ///    In: ()
    ///    Out: bool
    /// </summary>
    public class PokerRoom
    {
        //The game 
        TheGame game;

        bool IsSeatAvailble = false;

        //various questions that can be displayed on the console
        Dictionary<string, List<string>> statements;

        //Does the proffered game have any seats immediately available
        bool IsSeatAvailable = true;
       
        public PokerRoom()
        { 
            //Have an empty but ready game table availble
            this.game = new TheGame();

            //A dictionary of statements that can be printed
            this.statements = MakeStatementDictionary();

            // Simple menu - Play,Wait,Leave
            MainMenu();
        }

        //This is the user interface. In our case, a console
        //Question/Answer Loop until the Quit answer is received.
        private void MainMenu()
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            Console.WriteLine(strMethodName);

            bool quit = false;

            while (!quit)
            {
                string answer = String.Empty;
                string temp = statements["Welcome"].FirstOrDefault();
                Console.WriteLine(temp);
                answer = Console.ReadLine();

                if (answer == "p") { Play(); quit = true; };
                if (answer == "w") { Wait(); quit = true; };
                if (answer == "l") { Leave(); quit = true; };
                if (answer == "sp") { ShowPlayers(); quit = true; };

            }


        }

        private void ShowPlayers()
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            Console.WriteLine(strMethodName);

            if (game.gamestate.Seats.Select(x => x.HasPlayer == true).Count() > 0) 
            {
                game.gamestate.Seats.Select(x => x.HasPlayer == true)
                                     .ToList().ForEach(x => Console.WriteLine());
            } else
            {
                Console.WriteLine("None to show");
            }
            MainMenu();
        }

        private void AddPlayerMenu()
        {
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            Console.WriteLine(strMethodName);

            bool quit = false;

            while (!quit)
            {
                string name = String.Empty;
                //string temp = statements["Welcome"].FirstOrDefault();
                string temp = "Player Name?";
                Console.WriteLine(temp);
                name = Console.ReadLine();

                if (name.Length > 0 && name.Length < 10) {
                    Player p = new Player(name, 0);
                    if (game.gamestate.Seats.Select(x => x.HasPlayer).Count() < 9){
                        //seat available
                        foreach (var item in game.gamestate.Seats)
                        {
                            if (!item.HasPlayer)
                            {
                                item.AddPlayer(p);
                                Console.WriteLine($"{p.Name} added to the game");
                                break;

                            }
                        }
                        break;
                    } else
                    {
                        foreach (var item in game.gamestate.Seats)
                        {
                            if (!item.HasPlayer)
                            {
                                item.AddPlayer(p);
                                Console.WriteLine($"{p.Name} added to the waiting list");
                                break;

                            }

                        }
                        break;
                    }
                    throw new SystemException("Unable to add player. Call the Floor.");
                }
                Console.Write($"{name} is not a valid name.");
                MainMenu();
            }
            MainMenu();

        }

       

       

        private void Leave()
        {
            //Do cleanup
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            Console.WriteLine(strMethodName);
        }
        private void Wait()
        {
            //Add to wait list
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            Console.WriteLine(strMethodName);
            AddPlayerMenu();
        }
        private void Play()
        {
            //Seat Player
            string strMethodName = System.Reflection.MethodBase.GetCurrentMethod()!.Name;
            Console.WriteLine(strMethodName);
            AddPlayerMenu();        }

       
        private static Dictionary<string, List<string>> MakeStatementDictionary()
        {
            Dictionary<string, List<string>> statement_dict;
            statement_dict = new Dictionary<string, List<string>>()
            {
                ["Welcome"] = new List<string>()
                {
                    "Welcome to the Room." + Environment.NewLine +
                    "We have this Holdem game available." + Environment.NewLine +
                    "[p] to Play." + Environment.NewLine +
                    "[w] to Wait." + Environment.NewLine +
                    "[sp] to SHow Players." + Environment.NewLine +
                    "[l] to Leave." + Environment.NewLine



                },

                ["AddPlayer"] = new List<string>()
                {
                    "Name?" + Environment.NewLine +
                    "[y/n]"
                },
                ["WaitingList"] = new List<string>()
                {
                    "Do you want to wait for an open seat?" + Environment.NewLine +
                    "[y/n]"
                },
                ["Wait"] = new List<string>()
                {
                    "O.K. We will call you when a seat is available" + Environment.NewLine +
                    "Please wait."
                }

            };

            return statement_dict;
        }
       
    }
}

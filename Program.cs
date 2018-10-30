using System;
using System.Collections.Generic;
using System.IO;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            //creates list for players
            List<Player> Players = new List<Player>();
            //list variables
            bool Continue = true;

            //loops questions as long as continue is true
            while (Continue)
            {
                Console.WriteLine("Select a Task (Please Enter A Number)");
                Console.WriteLine("\t1. Add Player \n\t2. Edit Player \n\t3. Start Game \n\t4. Exit");
                var response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        //adds player
                        Console.WriteLine("This Case Adds Player");
                        break;

                    case "2":
                        //edit player
                        Console.WriteLine("This case edits players");
                        break;

                    case "3":
                        //starts game
                        startgame();
                        break;
                    case "4":
                        //exits program
                        Console.WriteLine("This case ends the game");
                        Continue = false;
                        break;
                    //exits program
                    default:
                        Console.WriteLine("Input is not readable.");
                        break;
                }
            }
        }
        public static void startgame()
        {
            Console.WriteLine("Game is started");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace Monopoly
{
    class Program
    {
        
        static List<Space> Spaces = new List<Space>();
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
            /*
            public Property(int givenRent, int givenPrice, bool givenOwned, int givenOwner,
            string givenName, string givenType, int givenPosition): base(givenName, givenType, givenPosition)
             */
            /*
            public Transport(int givenRent, int givenPrice, bool givenOwned, int givenOwner,
            string givenName, string givenType, int givenPosition): base(givenName, givenType, givenPosition)
             */
             /*public Utility(bool givenRentDualUtility, int givenRentNumber,int givenRent, int givenPrice, bool givenOwned, int givenOwner, string givenColor,
            string givenName, string givenType, int givenPosition)
             */
            Console.WriteLine("LOADING...");
            otherSpace Go = new otherSpace("collect 200", "Go", "otherSpace", 1);
            Spaces.Add(Go);
            Property MediterranianAve = new Property(2, 60, false, 0, "Brown", "Mediterranian Ave.", "Property", 2);
            Spaces.Add(MediterranianAve);
            otherSpace CommChest = new otherSpace("Draw Community Chest Card", "Community Chest", "otherSpace", 3);
            Spaces.Add(CommChest);
            Property BalticAve = new Property(4, 60, false, 0,"Brown", "Baltic Ave.", "Property", 4);
            Spaces.Add(MediterranianAve);
            otherSpace IncomeTax = new otherSpace("Pay Income Tax", "Income Tax", "otherSpace", 5);
            Spaces.Add(IncomeTax);
            //I changed the ReadingRailraod. It's something we can discuss but I believe it acts similar to a resedential property 
            //since the rent amount increases as you accumulate more railroads. This is the reason I believe it deserves its own 
            //class. I'll go ahead and submit the assignment as it is in the master branch though -mreveles
            Property ReadingRailroad = new Property(50, 200, false, 0, "White", "ReadingRailroad", "Transprt", 8);
            Spaces.Add(ReadingRailroad);

            Console.WriteLine("Game is started");
        }
    }
}

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
            //array of space objects
            
            //CURRENTLY ONLY THE FIRST 15 SPACES FOR TESTING PURPOSES
            spaces[] = [
                {
                    //position
                    1,
                    //name
                    'Go',
                    //type
                    'Otherspace',
                    //color
                    'White',
                    //houses
                    0,
                    //hotels
                    0,
                    //rent
                    0,
                    //price
                    0
                },{
                    //position
                    2,
                    //name
                    'Mediterranian Ave.',
                    //type
                    'Property',
                    //color
                    'Brown',
                    //houses
                    0,
                    //hotels
                    0,
                    //rent
                    2,
                    //price
                    60
                },{
                    //position
                    3,
                    //name
                    'Community Chest',
                    //type
                    'Otherspace',
                    //color
                    'White',
                    //houses
                    0,
                    //hotels
                    0,
                    //rent
                    0,
                    //price
                    0
                },{
                    //position
                    4,
                    //name
                    'Baltic Ave.',
                    //type
                    'Property',
                    //color
                    'Brown',
                    //houses
                    0,
                    //hotels
                    0,
                    //rent
                    4,
                    //price
                    60
                },{
                    //position
                    5,
                    //name
                    'Income Tax',
                    //type
                    'Otherspace',
                    //color
                    'White',
                    //houses
                    0,
                    //hotels
                    0,
                    //rent
                    0,
                    //price
                    0
                },{
                    //position
                    6,
                    //name
                    'Reading Railroad',
                    //type
                    'Utility',
                    //color
                    'White',
                    //houses
                    0,
                    //hotels
                    0,
                    //rent
                    6,
                    //price
                    200
                },{
                    //position
                    7,
                    //name
                    'Oriental Ave.',
                    //type
                    'Property',
                    //color
                    'Light Blue',
                    //houses
                    0,
                    //hotels
                    0,
                    //rent
                    6,
                    //price
                    100
                },{
                    //position
                    8,
                    //name
                    'Chance',
                    //type
                    'Otherspace',
                    //color
                    'White',
                    //houses
                    0,
                    //hotels
                    0,
                    //rent
                    0,
                    //price
                    0
                },{
                    //position
                    9,
                    //name
                    'Vermont Ave.',
                    //type
                    'Property',
                    //color
                    'Light Blue',
                    //houses
                    0,
                    //hotels
                    0,
                    //rent
                    6,
                    //price
                    100
                },{
                    //position
                    10,
                    //name
                    'Connecticut Ave.',
                    //type
                    'Property',
                    //color
                    'Light Blue',
                    //houses
                    0,
                    //hotels
                    0,
                    //rent
                    8,
                    //price
                    100
                },{
                    //position
                    11,
                    //name
                    'Jail',
                    //type
                    'Otherspace',
                    //color
                    'White',
                    //houses
                    0,
                    //hotels
                    0,
                    //rent
                    0,
                    //price
                    0
                },{
                    //position
                    12,
                    //name
                    'St. Charles Place',
                    //type
                    'Property',
                    //color
                    'Magenta',
                    //houses
                    0,
                    //hotels
                    0,
                    //rent
                    10,
                    //price
                    140
                },{
                    //position
                    13,
                    //name
                    'Electric Company',
                    //type
                    'Utility',
                    //color
                    'White',
                    //houses
                    0,
                    //hotels
                    0,
                    //rent
                    0,
                    //price
                    150
                },{
                    //position
                    14,
                    //name
                    'States Ave.',
                    //type
                    'Property',
                    //color
                    'Magenta',
                    //houses
                    0,
                    //hotels
                    0,
                    //rent
                    10,
                    //price
                    140
                },{
                    //position
                    15,
                    //name
                    'Virginia Ave.',
                    //type
                    'Property',
                    //color
                    'Magenta',
                    //houses
                    0,
                    //hotels
                    0,
                    //rent
                    12,
                    //price
                    160
                },
            ]

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

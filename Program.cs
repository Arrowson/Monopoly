using System;
using System.Collections.Generic;
using System.IO;

namespace Monopoly
{
    class Program
    {
        
        static List<Space> Spaces = new List<Space>();
        static List<Player> Players = new List<Player>();
        static int currentPlayer = 0;
        static void Main(string[] args)
        {
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
                        addPlayer();
                        break;

                    case "2":
                        //edit player
                        editPlayer();
                        break;

                    case "3":
                        //starts game
                        startgame("Utilities.txt", 'U');
                        startgame("Properties.txt", 'P');
                        startgame("OtherSpace.txt", 'O');
                        runGame();
                        break;
                    case "4":
                        //exits program
                        Console.WriteLine("Thank you!");
                        Continue = false;
                        break;
                    //exits program
                    default:
                        Console.WriteLine("Input is not readable.");
                        break;
                }
            }
        }
        public static void startgame(string fileName, char DataType )
        {
            string[] lines = System.IO.File.ReadAllLines(@fileName);
            int i = 1;
            
            foreach(string line in lines){
                //Console.WriteLine(line);
                string[] sData = line.Split(',');
                //Console.WriteLine(line);
                if (i != 0){
                    if(DataType == 'U'){
                        //add string[] to Utility Constructor
                        Spaces.Add(new Utility(sData));
                    }
                    if(DataType == 'P'){
                        Spaces.Add(new Property(sData));
                    }
                    if(DataType == 'O'){
                        Spaces.Add(new otherSpace(sData));
                    }
                }
                i++;
            }
            //Console.WriteLine(Spaces);
            
        }
        public static void addPlayer(){
            Console.WriteLine("What is your player's name: ");
            string holdName = Console.ReadLine();
            Player TempPlayer = new Player(holdName);
            Players.Add(TempPlayer);
            TempPlayer.ListInfo();
            
            /*
            string Name;
            int playerPiece;
            int plyrPosition;
            int plyrMoney;
             */
        }
        public static void editPlayer(){
            foreach (Player player in Players){
                string Display = player.ShowName();
                Console.WriteLine(Display);
            }
            Console.WriteLine("Which Player do you want to edit? (name) ");
            string holdName = Console.ReadLine();
            getPlayerByName(holdName);
        }
        public static Player getPlayerByName(string givenName){
            foreach(Player p in Players){
                if(p.ShowName() == givenName){
                    Console.WriteLine("What's the new name? ");
                    string NewName = Console.ReadLine();
                    p.updateName(NewName);
                }
            }
            return null;
        }
        public static void runGame(){
            bool continueGame = true;
            while (continueGame){
                if(Players.Count == 1){
                    string winner = Players[0].ShowName();
                    Console.WriteLine("Congratulations, {0}, you beat everyone else!", winner);
                    continueGame = false;
                }else{
                    doTurn(Players[currentPlayer]);
                    currentPlayer++;
                    if(currentPlayer >= Players.Count){
                        currentPlayer = 0;
                    }
                }
            }
        }
        public static void doTurn(Player p){
            Console.WriteLine("--------------------------------");
            Console.WriteLine(p.ShowName());
            Console.WriteLine("");
            p.RollDice();
            int test = p.getPosition();
            string potentialNewOwner = "blank";
            foreach(Space s in Spaces){
                if(test == s.getPosition()){
                    s.showData();
                    if((s.getType() == "Property" || s.getType() == "Utility") && s.CheckOwned() == false){
                        bool insideProperty = true;
                        while (insideProperty){
                            Console.WriteLine("***********************");
                            Console.WriteLine("Do you want to buy this? yes or no");
                            string userInput = Console.ReadLine();
                            if(userInput == "yes"){
                                p.BuySpace(s.getName(), s.getPrice());
                                s.updateOwner(p.ShowName());
                                insideProperty = false;
                            }else if(userInput == "no"){
                                insideProperty = false;
                            }
                        }
                    }else if((s.getType() == "Property" || s.getType() == "Utility") && s.CheckOwned() == true){
                        p.PayRent(s.getRent());
                        string PlayerName = s.getOwner();
                        foreach(Player p1 in Players){
                            if(PlayerName == p1.ShowName()){
                                p1.getRent(s.getRent());
                            }
                        }
                        
                    }
                }
                potentialNewOwner = s.getOwner();
            }
            if(p.getPlyrMoney() <= 0){
                foreach(Player p1 in Players){
                    if(p1.ShowName() == potentialNewOwner){
                        p1.receiveProperty(p.transferOwner());
                    }
                }
                
                Players.Remove(p);
            }
        }
    }
}

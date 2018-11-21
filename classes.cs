using System;
using System.Collections.Generic;
using System.IO;

//start of space class
public abstract class Space
{
    //General variables for Space
    protected string Name;
    protected string Type;
    protected int position;
    //Original Constructor. Can be removed
    public Space(string givenName, string givenType, int givenPosition){
        Name = givenName;
        Type = givenType;
        position = givenPosition;
    }
    //Constructor called for adding OtherSpaces to Board
    public Space(string[] datas){
        Name = datas[0].Trim();
        Type = datas[1].Trim();
        position = int.Parse(datas[2].Trim());
    }
    public Space(){
        Console.WriteLine("Called the wrong Space Constructor");
    }
    public virtual int getPosition(){
        return position;
    }
    public virtual string getOwner(){
        return null;
    }
    public virtual int getRent(){
        return 0;
    }
    public virtual void showData(){
        
    }
    public string getType(){
        return Type;
    }
    public virtual bool CheckOwned(){
        return false;
    }
    public virtual int getPrice(){
        return 0;
    }
    public virtual string getName(){
        return "name";
    }
    public virtual void updateOwner(string givenOwner){}
}

public class Property : Space
{
    //player enum to store player pieces names
    protected enum PlayerPieces
    {
        Dog = 1, Cat = 2, TopHat = 3, Battleship = 4, Shoe = 5, Wheelbarrow = 6, Thimble = 7, Iron = 8

    }
    protected int Rent;
    protected int price;
   // removed because it's calculatable
   // int mortgagePrice;
    protected bool owned;
    protected string owner;
    protected string color;
    // start of property functions
    public virtual void calculaterent()
    {
        //rent typically is only rent
        Rent = Rent;
    }
    public override void updateOwner(string givenOwner)
    {
        //transfers ownership to other player
        owned = true;
        owner = givenOwner;
        Console.WriteLine("Owner is now: {0}", owner);
    }
    public override bool CheckOwned(){
        return owned;
    }
    //Original Constructor. Can be removed.
    public Property(int givenRent, int givenPrice, bool givenOwned, string givenOwner, string givenColor,
    string givenName, string givenType, int givenPosition): base(givenName, givenType, givenPosition){
        Rent = givenRent;
        price = givenPrice;
        owned = givenOwned;
        owner = givenOwner;
        color = givenColor;
        //DEBUG
        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", Rent, price, owned, owner, Name, Type, position, color);
    }
    //Constructor used when adding Properties to the board
    public Property(string[] datas):base(datas){
        Rent = int.Parse(datas[3].Trim());
        price = Convert.ToInt32(datas[4].Trim());
        owned = bool.Parse(datas[5].Trim());
        owner = datas[6].Trim();
        color = datas[7].Trim();
    }
    //Blank constructor used for DEBUGGING
    public Property(){
        Console.WriteLine("Called the Wrong Property Constructor");
    }
    public override string getOwner(){
        return owner;
    }
    public override void showData(){
        Console.WriteLine("{0}", Name);
        Console.WriteLine("{0}", Type);
        Console.WriteLine("{0}", position);
        Console.WriteLine("{0}", color);
        Console.WriteLine("Price: {0}", price);
        Console.WriteLine("Rent: {0}", Rent);
        if(owned == false){
            Console.WriteLine("Currently unowned.");
        }else{
            Console.WriteLine("Owned by {0}", owner);
        }
    }
    public override int getRent(){
        return Rent;
    }
    public override int getPrice(){
        return price;
    }
    public override string getName(){
        return Name;
    }
    
    
}
//start of resedential property class
public class Resedential : Property
{
    int rent2Houses;
    int rent3Houses;
    int rentHotel;
    //functions for resedential properties
    public override void calculaterent()
    {
        if(rent2Houses == 1){
            Rent *= 2;
        }else if(rent3Houses == 1){
            Rent *= 3;
        }else if(rentHotel == 1){
            Rent *= 4;
        }
    }
    public override void updateOwner(string givenOwner)
    {

    }
    public Resedential(){
        Console.WriteLine("Called the Wrong Resedential Constructor");
    }
}
//end of resedential property class
//start of utility property class
public class Utility : Property
{
    bool rentDualUtility;
    int RentDualUtility;
    //utility class functions
    public override void updateOwner(string givenOwner)
    {
        owned = true;
        owner = givenOwner;
        Console.WriteLine("Owner is now: {0}", owner);
    }
    //Original Constructor. Can be removed
    public Utility(bool givenRentDualUtility, int givenRentNumber,int givenRent, int givenPrice, bool givenOwned, string givenOwner, string givenColor,
    string givenName, string givenType, int givenPosition):
    base(givenRent,givenPrice,givenOwned,givenOwner, givenColor,
    givenName,givenType,givenPosition){
        rentDualUtility = givenRentDualUtility;
        RentDualUtility = givenRentNumber;
        Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}", Name, Type, position, color, owned, owner, price, Rent, rentDualUtility, RentDualUtility);
    }
    //Constructor used for adding Utilities to the Board
    public Utility(string[] datas):base(datas){
        rentDualUtility = bool.Parse(datas[8].Trim());
        //Console.WriteLine(datas[0].Trim());
        RentDualUtility = Convert.ToInt32(datas[9].Trim());
        //Console.WriteLine(datas[1].Trim());
    }
    public override string getOwner(){
        return owner;
    }
    public override int getRent(){
        if(rentDualUtility == true){
            Rent = Rent + (10 * RentDualUtility);
        }
        return Rent;
    }
}
//end of utility property class
//start of otherSpace
public class otherSpace : Space
{
    string action;
    //functions for otherSpace
    public void performAction(Player player)
    {
        switch (action){

            case "200":
                player.CompleteTask(200);
                break;
            case "Community":
                //creates a random number between 1 and 20. It multiplies it by 10 and will either add or subtract 
                //the amount from the player's money.
                Random CardDrawn = new Random();
                int initial = CardDrawn.Next(1,3);
                int amount = CardDrawn.Next(1, 21);
                int charge = amount * 10;
                
                if(initial == 1){
                    player.CompleteTask(charge);
                }
                else{
                    player.CompleteTask(charge);
                }
                break;
            case "-100":
                player.CompleteTask(-100);
                break;
            case "Chance":
                //moves the player to a random place on the board
                Random rnd = new Random();
                int place = rnd.Next(1, 41);
                player.MovePlayer(place);
                break;
            case "Jail":
                //doesn't really do anything here.
                break;
            case "Parking":
                //playing by rules that it doesn't do anything. Can add a lottery or something later if we want.
                break;
            case "Go Jail":
                //makes the player go to jail and updates the boolean
                player.updateJail(true);
                player.MovePlayer(11);
                break;
            case "-200":
                player.CompleteTask(-200);
                break;
        }
    }
    //Original Constructor. Can be removed
    public otherSpace(string givenAction, string givenName, string givenType, int givenPosition)
    :base(givenName, givenType, givenPosition){
        action = givenAction;
        Name = givenName;
        Type = givenType;
        position = givenPosition;
        //DEBUG
        Console.WriteLine("{0}, {1}, {2}, {3}", action, Name, Type, position);
    }
    //Constructor used to add OtherSpaces to the Board
    public otherSpace(string[] datas):base(datas){
        action = datas[3].Trim();
    }
    public override void showData(){
        Console.WriteLine("{0}", Name);
        Console.WriteLine("{0}", position);
    }
}
public class Player
{
    string Name;
    //playerPiece is useless since we can determine by name
    //int playerPiece;
    int plyrPosition;
    int plyrMoney;
    List<string> PropertiesOwned;
    bool jailed;
    //player functions
    public Player(string givenName){
        Name = givenName;
        plyrPosition = 1;
        plyrMoney = 2000;
        jailed = false;
        PropertiesOwned = new List <string> ();
    }
    public void getRent(int rentMoney){
        Console.WriteLine("{0} just got paid ${1}", Name, rentMoney);
        plyrMoney += rentMoney;
        Console.WriteLine("Your new total is ${0}", plyrMoney);
    }
    public List<string> transferOwner(){
        return PropertiesOwned;
    }
    public string ShowName(){
        return Name;
    }
    public void receiveProperty(List<string> newProperties){
        PropertiesOwned.AddRange(newProperties);
        Console.WriteLine("{0}'s new list of properties are: ", Name);
        foreach(string element in PropertiesOwned){
            Console.WriteLine(element);
        }
        Console.WriteLine("----------");
    }
    public void ListInfo(){
        Console.WriteLine("Name: {0}", Name);
        Console.WriteLine("Current Position: {0}", plyrPosition);
        Console.WriteLine("Current Money: ${0}", plyrMoney);
        if(jailed == true){
            Console.WriteLine("{0} is currently in jail.", Name);
        }else{
            Console.WriteLine("{0} isn't in jail", Name);
        }
        bool DoContinue = true;
        while(DoContinue){
            Console.WriteLine("Show properties? (yes or no)");
            string answer = Console.ReadLine();
            if(answer == "yes"){
                foreach (string element in PropertiesOwned){
                    Console.WriteLine(element);
                }
                DoContinue = false;
            }else if(answer == "no"){
                DoContinue = false;
            }
        }
    }
    public void updateJail(bool update){
        jailed = update;
    }
    public void updateName(string givenName){
        Name = givenName;
    }
    public void updatePlayer()
    {

    }
    public void RollDice()
    {
        Random rnd = new Random();
        int dice = rnd.Next(1, 7);
        int dice2 = rnd.Next(1, 7);
        Console.WriteLine("You rolled {0} and {1}", dice, dice2);
        plyrPosition += (dice + dice2);
        if(plyrPosition >= 41){
            plyrPosition -= 40;
        }
    }
    public int getPosition(){
        return plyrPosition;
    }
    public int getPlyrMoney(){
        return plyrMoney;
    }
    public void PayRent(int rentCharge)
    {
        Console.WriteLine("You have to pay: ${0}", rentCharge);
        plyrMoney -= rentCharge;
        Console.WriteLine("You now have: ${0}", plyrMoney);
    }
    public void BuySpace(string SpaceName, int PriceAmount)
    {
        PropertiesOwned.Add(SpaceName);
        plyrMoney -= PriceAmount;
        Console.WriteLine("You now have: ${0}", plyrMoney);
        bool listProperties = true;
        while(listProperties){
            Console.WriteLine("List your properties? yes or no");
            string answer = Console.ReadLine();
            if(answer == "yes"){
                foreach(string s in PropertiesOwned){
                    Console.WriteLine(s);
                }
                listProperties = false;
            }else if (answer == "no"){
                listProperties = false;
            }
        }
    }
    public void CompleteTask(int task)
    {

    }
    public void Mortgage( int MortgageAmount, string SpaceName)
    {
        plyrMoney += MortgageAmount;
        PropertiesOwned.Remove(SpaceName);
    }
    public void BuyHouse()
    {
        //subject to change
        plyrMoney -= 100;
    }
    public void BuyHotel()
    {
        //subject to change
        plyrMoney -= 200;
    }
    public void MovePlayer(int x){
        plyrPosition = x;
    }
    //end of player functions
}
public class Bank
{
    int Money;
    int numberRemainingHouses;
    //only 32 houses allowed
    int numberRemaingHotels;
    //only 12 hotels allowed
    //Bank Functions
    public void ChargePlayer(int Amount)
    {
        Money += Amount;
    }
    public void PayPlayer(int Amount)
    {
        Money -= Amount;
    }
}
public class Dice
{
    int NumberDice;
    int NumberOnDice;
}
